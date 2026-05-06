using System.Text;
using System.Text.RegularExpressions;
using Mailitzr.Mail;
using Mailitzr.Services;
using Microsoft.Web.WebView2.Core;

namespace Mailitzr
{
    public partial class frmMain : Form
    {
        private enum SendJobUiPhase
        {
            Idle,
            Running,
            Paused,
            Stopping,
        }

        private static readonly Regex s_emailRegex = new(
            @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
            RegexOptions.IgnoreCase | RegexOptions.CultureInvariant,
            TimeSpan.FromMilliseconds(250));

        private readonly SuppressedAddressRegistry _suppressedRegistry = new();

        private bool stop;
        private Thread? thread = null;
        private readonly ManualResetEventSlim _sendMayProceed = new(true);
        private readonly SemaphoreSlim _previewLock = new(1, 1);
        private bool _webView2RuntimeWarningShown;
        private bool _previewNavCompletedHooked;

        public frmMain()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += FrmMain_KeyDown;

            txtMessage.TextChanged += (_, _) =>
            {
                UpdateMessageStats();
                RefreshMessagePreview();
            };
            tabEmail.SelectedIndexChanged += (_, _) =>
            {
                if (tabEmail.SelectedTab == tabPreview)
                    RefreshMessagePreview();
            };
            FormClosed += (_, _) => _previewLock.Dispose();

            btnOpenPreviewTab.Click += (_, _) => tabEmail.SelectedTab = tabPreview;
            btnZoom75.Click += (_, _) => SetPreviewZoom(0.75);
            btnZoom100.Click += (_, _) => SetPreviewZoom(1.0);
            btnZoom125.Click += (_, _) => SetPreviewZoom(1.25);

            btnLogCopy.Click += BtnLogCopy_Click;
            btnLogSave.Click += BtnLogSave_Click;

            mnuInsMail.Click += (_, _) => InsertAtCaret(txtMessage, "{mail}");
            mnuInsSubject.Click += (_, _) => InsertAtCaret(txtMessage, "{subject}");
            mnuInsDate.Click += (_, _) => InsertAtCaret(txtMessage, "{date}");
            cmsMsgMail.Click += (_, _) => InsertAtCaret(txtMessage, "{mail}");
            cmsMsgSubject.Click += (_, _) => InsertAtCaret(txtMessage, "{subject}");
            cmsMsgDate.Click += (_, _) => InsertAtCaret(txtMessage, "{date}");

            mnuFileOpen.Click += btnLoadRecipients_Click;
            mnuFileSaveLog.Click += BtnLogSave_Click;
            mnuFileExit.Click += (_, _) => Close();

            mnuActionAbout.Click += (_, _) => MessageBox.Show(
                "Created By Behdad Pedrood\n" +
                "• http://github.com/pedrood\n",
                "About Mailitzr",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            txtRecipientFilter.TextChanged += TxtRecipientFilter_TextChanged;
            lstRecipients.MouseDoubleClick += LstRecipients_MouseDoubleClick;
        }

        private void FrmMain_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.R)
            {
                RefreshMessagePreview();
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }

            if (e.Control && e.KeyCode == Keys.Tab)
            {
                var next = (tabEmail.TabCount + tabEmail.SelectedIndex + (e.Shift ? -1 : 1)) % tabEmail.TabCount;
                tabEmail.SelectedIndex = next;
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            ApplySendJobUiState(SendJobUiPhase.Idle);

            txtPassword.AccessibleName = "Mailbox password";

            _suppressedRegistry.MergeFromJsonFile(Path.Combine(AppContext.BaseDirectory, "suppressed-addresses.json"));
            TryLoadDefaultTemplate();
            txtSubject.Text = $"Newsletter | {DateTime.Now:dd.MM.yyyy}";
            UpdateMessageStats();
            RefreshMessagePreview();
            HookPreviewNavigationOnce();
        }

        private void TryLoadDefaultTemplate()
        {
            lblComposeTemplateHint.Visible = false;
            try
            {
                var path = Path.Combine(AppContext.BaseDirectory, "Template.html");
                if (!File.Exists(path))
                {
                    lblComposeTemplateHint.Text =
                        "No Template.html next to the app — paste HTML in the message area or add Template.html to the output folder.";
                    lblComposeTemplateHint.Visible = true;
                    return;
                }

                txtMessage.Text = File.ReadAllText(path);
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                lblComposeTemplateHint.Text = "Could not read Template.html. Check file permissions.";
                lblComposeTemplateHint.Visible = true;
            }
        }

        private void UpdateMessageStats()
        {
            var n = txtMessage.Text.Length;
            lblMessageStats.Text = $"Characters: {n:n0} / {txtMessage.MaxLength:n0}";
        }

        private void InsertAtCaret(TextBox box, string text)
        {
            var i = box.SelectionStart;
            box.Text = box.Text.Insert(i, text);
            box.SelectionStart = i + text.Length;
            box.Focus();
        }

        private void RefreshMessagePreview()
        {
            var html = txtMessage.Text ?? string.Empty;
            _ = ApplyPreviewAsync(html);
        }

        private void HookPreviewNavigationOnce()
        {
            _ = InitPreviewWebViewEventsAsync();
        }

        private async Task InitPreviewWebViewEventsAsync()
        {
            try
            {
                await webView21.EnsureCoreWebView2Async().ConfigureAwait(true);
                if (_previewNavCompletedHooked)
                    return;
                _previewNavCompletedHooked = true;
                webView21.CoreWebView2.NavigationCompleted += (_, _) =>
                {
                    BeginInvoke(() =>
                    {
                        lblPreviewStatus.Visible = false;
                        lblPreviewStatus.Text = string.Empty;
                    });
                };
            }
            catch
            {
                // runtime missing — handled in ApplyPreviewAsync
            }
        }

        private void SetPreviewZoom(double factor)
        {
            try
            {
                webView21.ZoomFactor = factor;
            }
            catch
            {
                // ignore if core not ready
            }
        }

        private async Task ApplyPreviewAsync(string html)
        {
            await _previewLock.WaitAsync().ConfigureAwait(true);
            try
            {
                BeginInvoke(() =>
                {
                    lblPreviewError.Visible = false;
                    lblPreviewError.Text = string.Empty;
                    lblPreviewStatus.Text = "Rendering preview…";
                    lblPreviewStatus.Visible = true;
                });

                await webView21.EnsureCoreWebView2Async().ConfigureAwait(true);
                webView21.NavigateToString(html);
            }
            catch (WebView2RuntimeNotFoundException)
            {
                BeginInvoke(() =>
                {
                    lblPreviewStatus.Visible = false;
                    lblPreviewError.Text = "WebView2 Runtime is not installed.";
                    lblPreviewError.Visible = true;
                });
                if (!_webView2RuntimeWarningShown)
                {
                    _webView2RuntimeWarningShown = true;
                    MessageBox.Show(
                        "Install the Microsoft Edge WebView2 Runtime to use HTML preview:\nhttps://developer.microsoft.com/microsoft-edge/webview2/",
                        "Mailitzr — Preview",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                BeginInvoke(() =>
                {
                    lblPreviewStatus.Visible = false;
                    lblPreviewError.Text = ex.Message;
                    lblPreviewError.Visible = true;
                });
            }
            finally
            {
                _previewLock.Release();
            }
        }

        private static string LogTimestamp() => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        private void WriteLog(string message, bool clear = false)
        {
            void append()
            {
                if (clear)
                    rtbLog.Clear();

                var err = message.Contains("Error", StringComparison.OrdinalIgnoreCase)
                          || message.Contains("error:", StringComparison.OrdinalIgnoreCase);
                rtbLog.SelectionStart = 0;
                rtbLog.SelectionLength = 0;
                rtbLog.SelectionColor = err ? Color.Firebrick : SystemColors.WindowText;
                rtbLog.SelectedText = message + Environment.NewLine;
            }

            if (rtbLog.InvokeRequired)
                rtbLog.Invoke(append);
            else
                append();
        }

        private void btnRecipient_Click(object sender, EventArgs e)
        {
            var recipient = txtRecipient.Text;
            if (lstRecipients.Items.IndexOf(recipient) == -1)
                lstRecipients.Items.Add(recipient);

            txtRecipient.Clear();
            txtRecipient.Focus();
        }

        private void btnSend_Click(object? sender, EventArgs e)
        {
            try
            {
                var count = lstRecipients.Items.Count;
                if (count == 0)
                {
                    MessageBox.Show("Add at least one recipient.", "Mailitzr", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var summary =
                    $"Send this newsletter?\n\n" +
                    $"Recipients: {count}\n" +
                    $"From (display): {txtDisplayName.Text}\n" +
                    $"Mailbox: {txtEmailAccount.Text}\n" +
                    $"Subject: {txtSubject.Text}\n";

                if (MessageBox.Show(summary, "Confirm send", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;

                IEmailSender mail;
                try
                {
                    mail = new ExchangeEmailSender(txtEmailAccount.Text, txtPassword.Text);
                }
                catch (ExchangeConnectionException ex)
                {
                    MessageBox.Show(ex.Message, "Mailitzr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _sendMayProceed.Set();
                prgSend.Maximum = Math.Max(1, lstRecipients.Items.Count);
                prgSend.Visible = true;
                ApplySendJobUiState(SendJobUiPhase.Running);

                for (var i = 0; i < lstRecipients.Items.Count; i++)
                    lstRecipients.SetItemChecked(i, false);

                thread = new Thread(() => Send(mail)) { IsBackground = false };
                thread.Start();
            }
            catch (Exception ex)
            {
                WriteLog($"Error:{ex.Message}");
            }
        }

        private void Send(IEmailSender mail)
        {
            try
            {
                stop = false;

                WriteLog($"{LogTimestamp()}\tJob Started.", clear: true);
                var total = lstRecipients.Items.Count;
                for (var i = 0; i < total; i++)
                {
                    _sendMayProceed.Wait();
                    if (stop)
                        break;

                    try
                    {
                        var emailAddress = lstRecipients.Items[i]?.ToString();
                        strStatus.Invoke(() =>
                        {
                            lblSendingTo.Text = string.IsNullOrEmpty(emailAddress) ? "" : $"Sending: {emailAddress}";
                        });

                        if (_suppressedRegistry.IsSuppressed(emailAddress))
                        {
                            WriteLog($"{LogTimestamp()}\t {emailAddress} has been unsubscribed.");
                            continue;
                        }

                        var emailBody = HtmlEmailTemplateMerger.Merge(
                            txtMessage.Text,
                            emailAddress!,
                            txtSubject.Text);

                        var message = new OutboundEmail(
                            txtSubject.Text,
                            emailBody,
                            txtDisplayName.Text,
                            emailAddress!);

                        if (mail.Send(message))
                        {
                            lstRecipients.Invoke(() =>
                                lstRecipients.SetItemChecked(lstRecipients.Items.IndexOf(emailAddress!), true));
                            strStatus.Invoke(() =>
                            {
                                prgSend.Value = Math.Min(prgSend.Maximum, i + 1);
                                lblEmailCount.Visible = true;
                                var remaining = total - i - 1;
                                var extra = remaining > 0 ? $"  ·  ~{remaining * 30}s gap for {remaining} left" : "";
                                lblEmailCount.Text = $"{i + 1}/{total}{extra}";
                            });
                            WriteLog($"{LogTimestamp()}\tEmail sent to {emailAddress}.");
                            if (i + 1 < total)
                                Thread.Sleep(30000);
                        }
                    }
                    catch (Exception ex)
                    {
                        WriteLog($"{LogTimestamp()}\t Error: {ex.Message}");
                    }
                }

                WriteLog($"{LogTimestamp()}\tJob Finished.");
            }
            finally
            {
                mail.Dispose();
                BeginInvoke(() =>
                {
                    lblSendingTo.Text = string.Empty;
                    prgSend.Visible = false;
                    ApplySendJobUiState(SendJobUiPhase.Idle);
                    tabEmail.SelectedTab = tabLog;
                    rtbLog.Focus();
                });
            }
        }

        private void ApplySendJobUiState(SendJobUiPhase phase)
        {
            switch (phase)
            {
                case SendJobUiPhase.Idle:
                    btnSend.Enabled = true;
                    btnPauseSend.Enabled = false;
                    btnPauseSend.Text = "&Pause";
                    btnStopSend.Enabled = false;
                    mnuActionStart.Enabled = true;
                    mnuActionStart.Text = "&Send";
                    mnuActionPause.Enabled = false;
                    mnuActionStop.Enabled = false;
                    break;
                case SendJobUiPhase.Running:
                    btnSend.Enabled = false;
                    btnPauseSend.Enabled = true;
                    btnPauseSend.Text = "&Pause";
                    btnStopSend.Enabled = true;
                    mnuActionStart.Enabled = false;
                    mnuActionStart.Text = "&Resume";
                    mnuActionPause.Enabled = true;
                    mnuActionStop.Enabled = true;
                    break;
                case SendJobUiPhase.Paused:
                    btnSend.Enabled = false;
                    btnPauseSend.Enabled = true;
                    btnPauseSend.Text = "&Resume";
                    btnStopSend.Enabled = true;
                    mnuActionStart.Enabled = true;
                    mnuActionStart.Text = "&Resume";
                    mnuActionPause.Enabled = false;
                    mnuActionStop.Enabled = true;
                    break;
                case SendJobUiPhase.Stopping:
                    btnSend.Enabled = false;
                    btnPauseSend.Enabled = false;
                    btnStopSend.Enabled = false;
                    mnuActionStart.Enabled = false;
                    mnuActionPause.Enabled = false;
                    mnuActionStop.Enabled = false;
                    break;
            }
        }

        private void PauseSendJob()
        {
            _sendMayProceed.Reset();
            ApplySendJobUiState(SendJobUiPhase.Paused);
        }

        private void ResumeSendJob()
        {
            _sendMayProceed.Set();
            ApplySendJobUiState(SendJobUiPhase.Running);
        }

        private void btnPauseSend_Click(object? sender, EventArgs e)
        {
            if (!btnPauseSend.Enabled)
                return;
            if (_sendMayProceed.IsSet)
                PauseSendJob();
            else
                ResumeSendJob();
        }

        private void btnStopSend_Click(object? sender, EventArgs e) => RequestStopSendJob();

        private void RequestStopSendJob()
        {
            if (prgSend.Visible)
            {
                if (MessageBox.Show(
                        "Stop the send job now? Some recipients may not have been processed.",
                        "Mailitzr",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning) != DialogResult.Yes)
                    return;
            }

            stop = true;
            _sendMayProceed.Set();
            ApplySendJobUiState(SendJobUiPhase.Stopping);
        }

        private void txtRecipient_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && btnAddRecipient.Enabled)
                btnRecipient_Click(sender, e);
        }

        private void TxtRecipientFilter_TextChanged(object? sender, EventArgs e)
        {
            var q = txtRecipientFilter.Text.Trim();
            if (string.IsNullOrEmpty(q))
                return;
            for (var i = 0; i < lstRecipients.Items.Count; i++)
            {
                var t = lstRecipients.Items[i]?.ToString() ?? "";
                if (t.Contains(q, StringComparison.OrdinalIgnoreCase))
                {
                    lstRecipients.SelectedIndex = i;
                    lstRecipients.TopIndex = i;
                    break;
                }
            }
        }

        private void LstRecipients_MouseDoubleClick(object? sender, MouseEventArgs e)
        {
            var i = lstRecipients.IndexFromPoint(e.Location);
            if (i < 0 || i >= lstRecipients.Items.Count)
                return;
            lstRecipients.Items.RemoveAt(i);
        }

        private void mnuRemoveRecipient_Click(object sender, EventArgs e)
        {
            var index = lstRecipients.SelectedIndex;
            if (index >= 0)
                lstRecipients.Items.RemoveAt(index);
        }

        private void mnuRemoveAllRecipients_Click(object sender, EventArgs e)
        {
            if (lstRecipients.Items.Count == 0)
                return;
            if (MessageBox.Show(
                    $"Remove all {lstRecipients.Items.Count} recipients?",
                    "Mailitzr",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) != DialogResult.Yes)
                return;
            lstRecipients.Items.Clear();
        }

        private void txtRecipient_TextChanged(object sender, EventArgs e)
        {
            btnAddRecipient.Enabled = IsValidEmailFormat(txtRecipient.Text);
        }

        private static bool IsValidEmailFormat(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;
            try
            {
                return s_emailRegex.IsMatch(text);
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private void btnLoadRecipients_Click(object? sender, EventArgs e)
        {
            if (ofdOpenFile.ShowDialog() != DialogResult.OK)
                return;

            var content = File.ReadAllText(ofdOpenFile.FileName);
            foreach (var recipient in content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
                lstRecipients.Items.Add(recipient);
        }

        private void BtnLogCopy_Click(object? sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(rtbLog.Text))
                Clipboard.SetText(rtbLog.Text);
        }

        private void BtnLogSave_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rtbLog.Text))
                return;
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.FileName = $"mailitzr-log-{DateTime.Now:yyyyMMdd-HHmmss}.txt";
            if (saveFileDialog1.ShowDialog(this) != DialogResult.OK)
                return;
            File.WriteAllText(saveFileDialog1.FileName, rtbLog.Text, Encoding.UTF8);
        }

        private void mnuActionStart_Click(object sender, EventArgs e)
        {
            if (!mnuActionStop.Enabled)
            {
                btnSend_Click(sender, e);
                return;
            }

            if (!mnuActionPause.Enabled)
                ResumeSendJob();
        }

        private void mnuActionPause_Click(object sender, EventArgs e) => PauseSendJob();

        private void mnuActionStop_Click(object sender, EventArgs e) => RequestStopSendJob();

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshMessagePreview();
        }
    }
}
