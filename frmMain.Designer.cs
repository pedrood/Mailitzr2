namespace Mailitzr
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tabEmail = new TabControl();
            tabGeneral = new TabPage();
            splitContainer1 = new SplitContainer();
            btnSend = new Button();
            btnPauseSend = new Button();
            btnStopSend = new Button();
            txtServerAddress = new TextBox();
            txtPassword = new TextBox();
            txtDisplayName = new TextBox();
            txtEmailAccount = new TextBox();
            txtEmailAddress = new TextBox();
            btnLoadRecipients = new Button();
            btnAddRecipient = new Button();
            lstRecipients = new CheckedListBox();
            cmsRecipient = new ContextMenuStrip(components);
            mnuRemoveRecipient = new ToolStripMenuItem();
            mnuRemoveAllRecipients = new ToolStripMenuItem();
            txtRecipientFilter = new TextBox();
            txtRecipient = new TextBox();
            tabEditor = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            txtSubject = new TextBox();
            txtMessage = new TextBox();
            cmsMessage = new ContextMenuStrip(components);
            cmsMsgMail = new ToolStripMenuItem();
            cmsMsgSubject = new ToolStripMenuItem();
            cmsMsgDate = new ToolStripMenuItem();
            panelComposeToolbar = new Panel();
            lblComposeTemplateHint = new Label();
            flowComposeToolbar = new FlowLayoutPanel();
            lblMessageStats = new Label();
            btnOpenPreviewTab = new Button();
            tabPreview = new TabPage();
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            pnlPreviewToolbar = new Panel();
            flowPreviewTools = new FlowLayoutPanel();
            lblPreviewStatus = new Label();
            lblPreviewError = new Label();
            btnZoom75 = new Button();
            btnZoom100 = new Button();
            btnZoom125 = new Button();
            btnRefresh = new Button();
            tabLog = new TabPage();
            rtbLog = new RichTextBox();
            pnlLogTools = new Panel();
            btnLogSave = new Button();
            btnLogCopy = new Button();
            mnuInsMail = new ToolStripMenuItem();
            mnuInsSubject = new ToolStripMenuItem();
            mnuInsDate = new ToolStripMenuItem();
            mnuEdit = new ToolStripMenuItem();
            mnuFileSaveLog = new ToolStripMenuItem();
            lblSendingTo = new ToolStripStatusLabel();
            ofdOpenFile = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            timer1 = new System.Windows.Forms.Timer(components);
            strStatus = new StatusStrip();
            sslRecipients = new ToolStripStatusLabel();
            prgSend = new ToolStripProgressBar();
            lblEmailCount = new ToolStripStatusLabel();
            menuStrip2 = new MenuStrip();
            mnuFile = new ToolStripMenuItem();
            mnuFileOpen = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            mnuFileExit = new ToolStripMenuItem();
            mnuAction = new ToolStripMenuItem();
            mnuActionStart = new ToolStripMenuItem();
            mnuActionPause = new ToolStripMenuItem();
            mnuActionStop = new ToolStripMenuItem();
            mnuHelp = new ToolStripMenuItem();
            mnuActionAbout = new ToolStripMenuItem();
            tabEmail.SuspendLayout();
            tabGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            cmsRecipient.SuspendLayout();
            tabEditor.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            cmsMessage.SuspendLayout();
            panelComposeToolbar.SuspendLayout();
            flowComposeToolbar.SuspendLayout();
            tabPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            pnlPreviewToolbar.SuspendLayout();
            flowPreviewTools.SuspendLayout();
            tabLog.SuspendLayout();
            pnlLogTools.SuspendLayout();
            strStatus.SuspendLayout();
            menuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // tabEmail
            // 
            tabEmail.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabEmail.Controls.Add(tabGeneral);
            tabEmail.Controls.Add(tabEditor);
            tabEmail.Controls.Add(tabPreview);
            tabEmail.Controls.Add(tabLog);
            tabEmail.Location = new Point(0, 27);
            tabEmail.Margin = new Padding(4, 3, 4, 3);
            tabEmail.Name = "tabEmail";
            tabEmail.SelectedIndex = 0;
            tabEmail.Size = new Size(1008, 628);
            tabEmail.TabIndex = 0;
            // 
            // tabGeneral
            // 
            tabGeneral.Controls.Add(splitContainer1);
            tabGeneral.Location = new Point(4, 27);
            tabGeneral.Margin = new Padding(4, 3, 4, 3);
            tabGeneral.Name = "tabGeneral";
            tabGeneral.Padding = new Padding(4, 3, 4, 3);
            tabGeneral.Size = new Size(1000, 597);
            tabGeneral.TabIndex = 1;
            tabGeneral.Text = "General";
            tabGeneral.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(11, 3);
            splitContainer1.Margin = new Padding(4, 3, 4, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btnSend);
            splitContainer1.Panel1.Controls.Add(btnPauseSend);
            splitContainer1.Panel1.Controls.Add(btnStopSend);
            splitContainer1.Panel1.Controls.Add(txtServerAddress);
            splitContainer1.Panel1.Controls.Add(txtPassword);
            splitContainer1.Panel1.Controls.Add(txtDisplayName);
            splitContainer1.Panel1.Controls.Add(txtEmailAccount);
            splitContainer1.Panel1.Controls.Add(txtEmailAddress);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btnLoadRecipients);
            splitContainer1.Panel2.Controls.Add(btnAddRecipient);
            splitContainer1.Panel2.Controls.Add(lstRecipients);
            splitContainer1.Panel2.Controls.Add(txtRecipientFilter);
            splitContainer1.Panel2.Controls.Add(txtRecipient);
            splitContainer1.Size = new Size(992, 647);
            splitContainer1.SplitterDistance = 329;
            splitContainer1.TabIndex = 2;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(4, 163);
            btnSend.Margin = new Padding(4, 3, 4, 3);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(75, 27);
            btnSend.TabIndex = 2;
            btnSend.Text = "&Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // btnPauseSend
            // 
            btnPauseSend.Enabled = false;
            btnPauseSend.Location = new Point(87, 163);
            btnPauseSend.Margin = new Padding(4, 3, 4, 3);
            btnPauseSend.Name = "btnPauseSend";
            btnPauseSend.Size = new Size(78, 27);
            btnPauseSend.TabIndex = 3;
            btnPauseSend.Text = "&Pause";
            btnPauseSend.UseVisualStyleBackColor = true;
            btnPauseSend.Click += btnPauseSend_Click;
            // 
            // btnStopSend
            // 
            btnStopSend.Enabled = false;
            btnStopSend.Location = new Point(173, 163);
            btnStopSend.Margin = new Padding(4, 3, 4, 3);
            btnStopSend.Name = "btnStopSend";
            btnStopSend.Size = new Size(75, 27);
            btnStopSend.TabIndex = 4;
            btnStopSend.Text = "S&top";
            btnStopSend.UseVisualStyleBackColor = true;
            btnStopSend.Click += btnStopSend_Click;
            // 
            // txtServerAddress
            // 
            txtServerAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtServerAddress.Location = new Point(4, 3);
            txtServerAddress.Margin = new Padding(4, 3, 4, 3);
            txtServerAddress.Name = "txtServerAddress";
            txtServerAddress.PlaceholderText = "Server Address";
            txtServerAddress.Size = new Size(322, 26);
            txtServerAddress.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.Location = new Point(4, 131);
            txtPassword.Margin = new Padding(4, 3, 4, 3);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(322, 26);
            txtPassword.TabIndex = 1;
            // 
            // txtDisplayName
            // 
            txtDisplayName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDisplayName.Location = new Point(4, 35);
            txtDisplayName.Margin = new Padding(4, 3, 4, 3);
            txtDisplayName.Name = "txtDisplayName";
            txtDisplayName.PlaceholderText = "Display Name";
            txtDisplayName.Size = new Size(322, 26);
            txtDisplayName.TabIndex = 1;
            // 
            // txtEmailAccount
            // 
            txtEmailAccount.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEmailAccount.Location = new Point(4, 67);
            txtEmailAccount.Margin = new Padding(4, 3, 4, 3);
            txtEmailAccount.Name = "txtEmailAccount";
            txtEmailAccount.PlaceholderText = "Email Account";
            txtEmailAccount.Size = new Size(322, 26);
            txtEmailAccount.TabIndex = 1;
            // 
            // txtEmailAddress
            // 
            txtEmailAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEmailAddress.Location = new Point(4, 99);
            txtEmailAddress.Margin = new Padding(4, 3, 4, 3);
            txtEmailAddress.Name = "txtEmailAddress";
            txtEmailAddress.PlaceholderText = "Email Address";
            txtEmailAddress.Size = new Size(322, 26);
            txtEmailAddress.TabIndex = 1;
            // 
            // btnLoadRecipients
            // 
            btnLoadRecipients.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLoadRecipients.Location = new Point(573, 2);
            btnLoadRecipients.Margin = new Padding(4, 3, 4, 3);
            btnLoadRecipients.Name = "btnLoadRecipients";
            btnLoadRecipients.Size = new Size(75, 28);
            btnLoadRecipients.TabIndex = 2;
            btnLoadRecipients.Text = "&Load";
            btnLoadRecipients.UseVisualStyleBackColor = true;
            btnLoadRecipients.Click += btnLoadRecipients_Click;
            // 
            // btnAddRecipient
            // 
            btnAddRecipient.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddRecipient.Enabled = false;
            btnAddRecipient.Location = new Point(490, 3);
            btnAddRecipient.Margin = new Padding(4, 3, 4, 3);
            btnAddRecipient.Name = "btnAddRecipient";
            btnAddRecipient.Size = new Size(75, 27);
            btnAddRecipient.TabIndex = 2;
            btnAddRecipient.Text = "&Add";
            btnAddRecipient.UseVisualStyleBackColor = true;
            btnAddRecipient.Click += btnRecipient_Click;
            // 
            // lstRecipients
            // 
            lstRecipients.AllowDrop = true;
            lstRecipients.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstRecipients.ContextMenuStrip = cmsRecipient;
            lstRecipients.FormattingEnabled = true;
            lstRecipients.Location = new Point(6, 67);
            lstRecipients.Margin = new Padding(4, 3, 4, 3);
            lstRecipients.Name = "lstRecipients";
            lstRecipients.ScrollAlwaysVisible = true;
            lstRecipients.Size = new Size(642, 508);
            lstRecipients.TabIndex = 0;
            lstRecipients.Tag = "Recipients Email List";
            // 
            // cmsRecipient
            // 
            cmsRecipient.ImageScalingSize = new Size(20, 20);
            cmsRecipient.Items.AddRange(new ToolStripItem[] { mnuRemoveRecipient, mnuRemoveAllRecipients });
            cmsRecipient.Name = "contextMenuStrip1";
            cmsRecipient.Size = new Size(155, 52);
            // 
            // mnuRemoveRecipient
            // 
            mnuRemoveRecipient.Name = "mnuRemoveRecipient";
            mnuRemoveRecipient.Size = new Size(154, 24);
            mnuRemoveRecipient.Text = "Remove";
            mnuRemoveRecipient.Click += mnuRemoveRecipient_Click;
            // 
            // mnuRemoveAllRecipients
            // 
            mnuRemoveAllRecipients.Name = "mnuRemoveAllRecipients";
            mnuRemoveAllRecipients.Size = new Size(154, 24);
            mnuRemoveAllRecipients.Text = "Remove All";
            mnuRemoveAllRecipients.Click += mnuRemoveAllRecipients_Click;
            // 
            // txtRecipientFilter
            // 
            txtRecipientFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtRecipientFilter.Location = new Point(6, 36);
            txtRecipientFilter.Margin = new Padding(4, 3, 4, 3);
            txtRecipientFilter.Name = "txtRecipientFilter";
            txtRecipientFilter.PlaceholderText = "Filter list (jump to first match)";
            txtRecipientFilter.Size = new Size(642, 26);
            txtRecipientFilter.TabIndex = 4;
            // 
            // txtRecipient
            // 
            txtRecipient.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtRecipient.Location = new Point(6, 4);
            txtRecipient.Margin = new Padding(4, 3, 4, 3);
            txtRecipient.Name = "txtRecipient";
            txtRecipient.PlaceholderText = "Recipient";
            txtRecipient.Size = new Size(476, 26);
            txtRecipient.TabIndex = 1;
            txtRecipient.TextChanged += txtRecipient_TextChanged;
            txtRecipient.KeyUp += txtRecipient_KeyUp;
            // 
            // tabEditor
            // 
            tabEditor.Controls.Add(tableLayoutPanel1);
            tabEditor.Controls.Add(panelComposeToolbar);
            tabEditor.Location = new Point(4, 29);
            tabEditor.Margin = new Padding(4, 3, 4, 3);
            tabEditor.Name = "tabEditor";
            tabEditor.Padding = new Padding(4, 3, 4, 3);
            tabEditor.Size = new Size(1000, 595);
            tabEditor.TabIndex = 2;
            tabEditor.Text = "Compose";
            tabEditor.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(txtSubject, 0, 0);
            tableLayoutPanel1.Controls.Add(txtMessage, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(4, 81);
            tableLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(992, 511);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // txtSubject
            // 
            txtSubject.Dock = DockStyle.Top;
            txtSubject.Location = new Point(4, 3);
            txtSubject.Margin = new Padding(4, 3, 4, 3);
            txtSubject.Name = "txtSubject";
            txtSubject.PlaceholderText = "Subject";
            txtSubject.Size = new Size(984, 26);
            txtSubject.TabIndex = 2;
            // 
            // txtMessage
            // 
            txtMessage.ContextMenuStrip = cmsMessage;
            txtMessage.Dock = DockStyle.Fill;
            txtMessage.Location = new Point(4, 29);
            txtMessage.Margin = new Padding(4, 3, 4, 3);
            txtMessage.MaxLength = 100000;
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.PlaceholderText = "Message";
            txtMessage.ScrollBars = ScrollBars.Both;
            txtMessage.Size = new Size(984, 479);
            txtMessage.TabIndex = 0;
            // 
            // cmsMessage
            // 
            cmsMessage.ImageScalingSize = new Size(20, 20);
            cmsMessage.Items.AddRange(new ToolStripItem[] { cmsMsgMail, cmsMsgSubject, cmsMsgDate });
            cmsMessage.Name = "cmsMessage";
            cmsMessage.Size = new Size(176, 76);
            // 
            // cmsMsgMail
            // 
            cmsMsgMail.Name = "cmsMsgMail";
            cmsMsgMail.Size = new Size(175, 24);
            cmsMsgMail.Text = "Insert {mail}";
            // 
            // cmsMsgSubject
            // 
            cmsMsgSubject.Name = "cmsMsgSubject";
            cmsMsgSubject.Size = new Size(175, 24);
            cmsMsgSubject.Text = "Insert {subject}";
            // 
            // cmsMsgDate
            // 
            cmsMsgDate.Name = "cmsMsgDate";
            cmsMsgDate.Size = new Size(175, 24);
            cmsMsgDate.Text = "Insert {date}";
            // 
            // panelComposeToolbar
            // 
            panelComposeToolbar.Controls.Add(lblComposeTemplateHint);
            panelComposeToolbar.Controls.Add(flowComposeToolbar);
            panelComposeToolbar.Dock = DockStyle.Top;
            panelComposeToolbar.Location = new Point(4, 3);
            panelComposeToolbar.Name = "panelComposeToolbar";
            panelComposeToolbar.Size = new Size(992, 78);
            panelComposeToolbar.TabIndex = 2;
            // 
            // lblComposeTemplateHint
            // 
            lblComposeTemplateHint.Dock = DockStyle.Top;
            lblComposeTemplateHint.ForeColor = Color.DarkOrange;
            lblComposeTemplateHint.Location = new Point(0, 40);
            lblComposeTemplateHint.Name = "lblComposeTemplateHint";
            lblComposeTemplateHint.Padding = new Padding(4);
            lblComposeTemplateHint.Size = new Size(992, 36);
            lblComposeTemplateHint.TabIndex = 0;
            lblComposeTemplateHint.Text = "Template hint";
            lblComposeTemplateHint.Visible = false;
            // 
            // flowComposeToolbar
            // 
            flowComposeToolbar.AutoSize = true;
            flowComposeToolbar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowComposeToolbar.Controls.Add(lblMessageStats);
            flowComposeToolbar.Controls.Add(btnOpenPreviewTab);
            flowComposeToolbar.Dock = DockStyle.Top;
            flowComposeToolbar.Location = new Point(0, 0);
            flowComposeToolbar.Margin = new Padding(4, 3, 4, 3);
            flowComposeToolbar.Name = "flowComposeToolbar";
            flowComposeToolbar.Padding = new Padding(2);
            flowComposeToolbar.Size = new Size(992, 40);
            flowComposeToolbar.TabIndex = 1;
            flowComposeToolbar.WrapContents = false;
            // 
            // lblMessageStats
            // 
            lblMessageStats.AutoSize = true;
            lblMessageStats.Location = new Point(10, 6);
            lblMessageStats.Margin = new Padding(8, 4, 16, 4);
            lblMessageStats.Name = "lblMessageStats";
            lblMessageStats.Size = new Size(165, 18);
            lblMessageStats.TabIndex = 0;
            lblMessageStats.Text = "Characters: 0 / 100,000";
            lblMessageStats.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnOpenPreviewTab
            // 
            btnOpenPreviewTab.AutoSize = true;
            btnOpenPreviewTab.Location = new Point(195, 5);
            btnOpenPreviewTab.Margin = new Padding(4, 3, 4, 3);
            btnOpenPreviewTab.Name = "btnOpenPreviewTab";
            btnOpenPreviewTab.Size = new Size(140, 30);
            btnOpenPreviewTab.TabIndex = 1;
            btnOpenPreviewTab.Text = "Open &Preview tab";
            btnOpenPreviewTab.UseVisualStyleBackColor = true;
            // 
            // tabPreview
            // 
            tabPreview.Controls.Add(webView21);
            tabPreview.Controls.Add(pnlPreviewToolbar);
            tabPreview.Location = new Point(4, 29);
            tabPreview.Margin = new Padding(4, 3, 4, 3);
            tabPreview.Name = "tabPreview";
            tabPreview.Padding = new Padding(4, 3, 4, 3);
            tabPreview.Size = new Size(1000, 595);
            tabPreview.TabIndex = 0;
            tabPreview.Text = "Preview";
            tabPreview.UseVisualStyleBackColor = true;
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Dock = DockStyle.Fill;
            webView21.Location = new Point(4, 43);
            webView21.Name = "webView21";
            webView21.Size = new Size(992, 549);
            webView21.TabIndex = 0;
            webView21.ZoomFactor = 1D;
            // 
            // pnlPreviewToolbar
            // 
            pnlPreviewToolbar.Controls.Add(flowPreviewTools);
            pnlPreviewToolbar.Dock = DockStyle.Top;
            pnlPreviewToolbar.Location = new Point(4, 3);
            pnlPreviewToolbar.Name = "pnlPreviewToolbar";
            pnlPreviewToolbar.Size = new Size(992, 40);
            pnlPreviewToolbar.TabIndex = 1;
            // 
            // flowPreviewTools
            // 
            flowPreviewTools.AutoSize = true;
            flowPreviewTools.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowPreviewTools.Controls.Add(lblPreviewStatus);
            flowPreviewTools.Controls.Add(lblPreviewError);
            flowPreviewTools.Controls.Add(btnZoom75);
            flowPreviewTools.Controls.Add(btnZoom100);
            flowPreviewTools.Controls.Add(btnZoom125);
            flowPreviewTools.Controls.Add(btnRefresh);
            flowPreviewTools.Dock = DockStyle.Fill;
            flowPreviewTools.Location = new Point(0, 0);
            flowPreviewTools.Margin = new Padding(4, 3, 4, 3);
            flowPreviewTools.Name = "flowPreviewTools";
            flowPreviewTools.Padding = new Padding(2);
            flowPreviewTools.Size = new Size(992, 40);
            flowPreviewTools.TabIndex = 0;
            flowPreviewTools.WrapContents = false;
            // 
            // lblPreviewStatus
            // 
            lblPreviewStatus.AutoSize = true;
            lblPreviewStatus.ForeColor = Color.DimGray;
            lblPreviewStatus.Location = new Point(10, 6);
            lblPreviewStatus.Margin = new Padding(8, 4, 12, 4);
            lblPreviewStatus.Name = "lblPreviewStatus";
            lblPreviewStatus.Size = new Size(138, 18);
            lblPreviewStatus.TabIndex = 0;
            lblPreviewStatus.Text = "Rendering preview…";
            lblPreviewStatus.Visible = false;
            // 
            // lblPreviewError
            // 
            lblPreviewError.AutoSize = true;
            lblPreviewError.ForeColor = Color.Firebrick;
            lblPreviewError.Location = new Point(168, 6);
            lblPreviewError.Margin = new Padding(8, 4, 12, 4);
            lblPreviewError.Name = "lblPreviewError";
            lblPreviewError.Size = new Size(0, 18);
            lblPreviewError.TabIndex = 1;
            lblPreviewError.Visible = false;
            // 
            // btnZoom75
            // 
            btnZoom75.AutoSize = true;
            btnZoom75.Location = new Point(184, 5);
            btnZoom75.Margin = new Padding(4, 3, 4, 3);
            btnZoom75.Name = "btnZoom75";
            btnZoom75.Size = new Size(50, 30);
            btnZoom75.TabIndex = 2;
            btnZoom75.Text = "75%";
            btnZoom75.UseVisualStyleBackColor = true;
            // 
            // btnZoom100
            // 
            btnZoom100.AutoSize = true;
            btnZoom100.Location = new Point(242, 5);
            btnZoom100.Margin = new Padding(4, 3, 4, 3);
            btnZoom100.Name = "btnZoom100";
            btnZoom100.Size = new Size(58, 30);
            btnZoom100.TabIndex = 3;
            btnZoom100.Text = "100%";
            btnZoom100.UseVisualStyleBackColor = true;
            // 
            // btnZoom125
            // 
            btnZoom125.AutoSize = true;
            btnZoom125.Location = new Point(308, 5);
            btnZoom125.Margin = new Padding(4, 3, 4, 3);
            btnZoom125.Name = "btnZoom125";
            btnZoom125.Size = new Size(58, 30);
            btnZoom125.TabIndex = 4;
            btnZoom125.Text = "125%";
            btnZoom125.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            btnRefresh.AutoSize = true;
            btnRefresh.Location = new Point(374, 5);
            btnRefresh.Margin = new Padding(4, 3, 4, 3);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(68, 30);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // tabLog
            // 
            tabLog.Controls.Add(rtbLog);
            tabLog.Controls.Add(pnlLogTools);
            tabLog.Location = new Point(4, 29);
            tabLog.Name = "tabLog";
            tabLog.Padding = new Padding(4, 3, 4, 3);
            tabLog.Size = new Size(1000, 595);
            tabLog.TabIndex = 3;
            tabLog.Text = "Log";
            tabLog.UseVisualStyleBackColor = true;
            // 
            // rtbLog
            // 
            rtbLog.BackColor = SystemColors.Window;
            rtbLog.Dock = DockStyle.Fill;
            rtbLog.Font = new Font("Consolas", 9F);
            rtbLog.Location = new Point(4, 3);
            rtbLog.Name = "rtbLog";
            rtbLog.ReadOnly = true;
            rtbLog.Size = new Size(992, 553);
            rtbLog.TabIndex = 0;
            rtbLog.Text = "";
            // 
            // pnlLogTools
            // 
            pnlLogTools.Controls.Add(btnLogSave);
            pnlLogTools.Controls.Add(btnLogCopy);
            pnlLogTools.Dock = DockStyle.Bottom;
            pnlLogTools.Location = new Point(4, 556);
            pnlLogTools.Name = "pnlLogTools";
            pnlLogTools.Size = new Size(992, 36);
            pnlLogTools.TabIndex = 1;
            // 
            // btnLogSave
            // 
            btnLogSave.AutoSize = true;
            btnLogSave.Location = new Point(100, 4);
            btnLogSave.Margin = new Padding(4, 3, 4, 3);
            btnLogSave.Name = "btnLogSave";
            btnLogSave.Size = new Size(94, 30);
            btnLogSave.TabIndex = 1;
            btnLogSave.Text = "&Save log…";
            btnLogSave.UseVisualStyleBackColor = true;
            // 
            // btnLogCopy
            // 
            btnLogCopy.AutoSize = true;
            btnLogCopy.Location = new Point(4, 4);
            btnLogCopy.Margin = new Padding(4, 3, 4, 3);
            btnLogCopy.Name = "btnLogCopy";
            btnLogCopy.Size = new Size(88, 30);
            btnLogCopy.TabIndex = 0;
            btnLogCopy.Text = "Copy &all";
            btnLogCopy.UseVisualStyleBackColor = true;
            // 
            // mnuInsMail
            // 
            mnuInsMail.Name = "mnuInsMail";
            mnuInsMail.ShortcutKeys = Keys.Control | Keys.Shift | Keys.M;
            mnuInsMail.Size = new Size(279, 26);
            mnuInsMail.Text = "Insert {&mail}";
            // 
            // mnuInsSubject
            // 
            mnuInsSubject.Name = "mnuInsSubject";
            mnuInsSubject.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            mnuInsSubject.Size = new Size(279, 26);
            mnuInsSubject.Text = "Insert {&subject}";
            // 
            // mnuInsDate
            // 
            mnuInsDate.Name = "mnuInsDate";
            mnuInsDate.ShortcutKeys = Keys.Control | Keys.Shift | Keys.D;
            mnuInsDate.Size = new Size(279, 26);
            mnuInsDate.Text = "Insert {&date}";
            // 
            // mnuEdit
            // 
            mnuEdit.DropDownItems.AddRange(new ToolStripItem[] { mnuInsMail, mnuInsSubject, mnuInsDate });
            mnuEdit.Name = "mnuEdit";
            mnuEdit.Size = new Size(49, 24);
            mnuEdit.Text = "&Edit";
            // 
            // mnuFileSaveLog
            // 
            mnuFileSaveLog.Name = "mnuFileSaveLog";
            mnuFileSaveLog.Size = new Size(207, 26);
            mnuFileSaveLog.Text = "&Save log…";
            // 
            // lblSendingTo
            // 
            lblSendingTo.Name = "lblSendingTo";
            lblSendingTo.Size = new Size(993, 16);
            lblSendingTo.Spring = true;
            lblSendingTo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ofdOpenFile
            // 
            ofdOpenFile.FileName = "openFileDialog1";
            // 
            // strStatus
            // 
            strStatus.ImageScalingSize = new Size(20, 20);
            strStatus.Items.AddRange(new ToolStripItem[] { sslRecipients, lblSendingTo, prgSend, lblEmailCount });
            strStatus.Location = new Point(0, 658);
            strStatus.Name = "strStatus";
            strStatus.Size = new Size(1008, 22);
            strStatus.TabIndex = 1;
            strStatus.Text = "statusStrip1";
            // 
            // sslRecipients
            // 
            sslRecipients.Name = "sslRecipients";
            sslRecipients.Size = new Size(0, 16);
            // 
            // prgSend
            // 
            prgSend.Maximum = 10000;
            prgSend.Name = "prgSend";
            prgSend.Size = new Size(100, 16);
            prgSend.Visible = false;
            // 
            // lblEmailCount
            // 
            lblEmailCount.Name = "lblEmailCount";
            lblEmailCount.Size = new Size(0, 16);
            // 
            // menuStrip2
            // 
            menuStrip2.ImageScalingSize = new Size(20, 20);
            menuStrip2.Items.AddRange(new ToolStripItem[] { mnuFile, mnuEdit, mnuAction, mnuHelp });
            menuStrip2.Location = new Point(0, 0);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Size = new Size(1008, 28);
            menuStrip2.TabIndex = 2;
            menuStrip2.Text = "menuStrip2";
            // 
            // mnuFile
            // 
            mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuFileOpen, mnuFileSaveLog, toolStripMenuItem1, mnuFileExit });
            mnuFile.Name = "mnuFile";
            mnuFile.Size = new Size(46, 24);
            mnuFile.Text = "&File";
            // 
            // mnuFileOpen
            // 
            mnuFileOpen.Name = "mnuFileOpen";
            mnuFileOpen.Size = new Size(207, 26);
            mnuFileOpen.Text = "&Open recipients…";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(204, 6);
            // 
            // mnuFileExit
            // 
            mnuFileExit.Name = "mnuFileExit";
            mnuFileExit.Size = new Size(207, 26);
            mnuFileExit.Text = "E&xit";
            // 
            // mnuAction
            // 
            mnuAction.DropDownItems.AddRange(new ToolStripItem[] { mnuActionStart, mnuActionPause, mnuActionStop });
            mnuAction.Name = "mnuAction";
            mnuAction.Size = new Size(66, 24);
            mnuAction.Text = "A&ction";
            // 
            // mnuActionStart
            // 
            mnuActionStart.Name = "mnuActionStart";
            mnuActionStart.Size = new Size(129, 26);
            mnuActionStart.Text = "&Send";
            mnuActionStart.Click += mnuActionStart_Click;
            // 
            // mnuActionPause
            // 
            mnuActionPause.Name = "mnuActionPause";
            mnuActionPause.Size = new Size(129, 26);
            mnuActionPause.Text = "&Pause";
            mnuActionPause.Click += mnuActionPause_Click;
            // 
            // mnuActionStop
            // 
            mnuActionStop.Name = "mnuActionStop";
            mnuActionStop.Size = new Size(129, 26);
            mnuActionStop.Text = "S&top";
            mnuActionStop.Click += mnuActionStop_Click;
            // 
            // mnuHelp
            // 
            mnuHelp.DropDownItems.AddRange(new ToolStripItem[] { mnuActionAbout });
            mnuHelp.Name = "mnuHelp";
            mnuHelp.Size = new Size(55, 24);
            mnuHelp.Text = "&Help";
            // 
            // mnuActionAbout
            // 
            mnuActionAbout.Name = "mnuActionAbout";
            mnuActionAbout.Size = new Size(133, 26);
            mnuActionAbout.Text = "&About";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 680);
            Controls.Add(strStatus);
            Controls.Add(menuStrip2);
            Controls.Add(tabEmail);
            Font = new Font("Tahoma", 9F);
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmMain";
            Text = "Mailitzr 2";
            Load += frmMain_Load;
            tabEmail.ResumeLayout(false);
            tabGeneral.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            cmsRecipient.ResumeLayout(false);
            tabEditor.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            cmsMessage.ResumeLayout(false);
            panelComposeToolbar.ResumeLayout(false);
            panelComposeToolbar.PerformLayout();
            flowComposeToolbar.ResumeLayout(false);
            flowComposeToolbar.PerformLayout();
            tabPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            pnlPreviewToolbar.ResumeLayout(false);
            pnlPreviewToolbar.PerformLayout();
            flowPreviewTools.ResumeLayout(false);
            flowPreviewTools.PerformLayout();
            tabLog.ResumeLayout(false);
            pnlLogTools.ResumeLayout(false);
            pnlLogTools.PerformLayout();
            strStatus.ResumeLayout(false);
            strStatus.PerformLayout();
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabEmail;
        private TabPage tabPreview;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private TabPage tabGeneral;
        private TabPage tabEditor;
        private TextBox txtMessage;
        private OpenFileDialog ofdOpenFile;
        private SaveFileDialog saveFileDialog1;
        private TextBox txtServerAddress;
        private System.Windows.Forms.Timer timer1;
        private TextBox txtPassword;
        private TextBox txtEmailAddress;
        private TextBox txtDisplayName;
        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox txtSubject;
        private Button btnSend;
        private Button btnPauseSend;
        private Button btnStopSend;
        private Button btnLoadRecipients;
        private Button btnAddRecipient;
        private CheckedListBox lstRecipients;
        private TextBox txtRecipient;
        private TextBox txtRecipientFilter;
        private ContextMenuStrip cmsRecipient;
        private ContextMenuStrip cmsMessage;
        private ToolStripMenuItem cmsMsgMail;
        private ToolStripMenuItem cmsMsgSubject;
        private ToolStripMenuItem cmsMsgDate;
        private ToolStripMenuItem mnuRemoveRecipient;
        private ToolStripMenuItem mnuRemoveAllRecipients;
        private StatusStrip strStatus;
        private ToolStripStatusLabel sslRecipients;
        private ToolStripStatusLabel lblSendingTo;
        private ToolStripProgressBar prgSend;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem mnuFile;
        private ToolStripMenuItem mnuFileOpen;
        private ToolStripMenuItem mnuFileSaveLog;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem mnuFileExit;
        private ToolStripMenuItem mnuEdit;
        private ToolStripMenuItem mnuInsMail;
        private ToolStripMenuItem mnuInsSubject;
        private ToolStripMenuItem mnuInsDate;
        private ToolStripMenuItem mnuHelp;
        private ToolStripMenuItem mnuActionAbout;
        private ToolStripMenuItem mnuAction;
        private ToolStripMenuItem mnuActionStart;
        private ToolStripMenuItem mnuActionPause;
        private ToolStripMenuItem mnuActionStop;
        private ToolStripStatusLabel lblEmailCount;
        private TabPage tabLog;
        private RichTextBox rtbLog;
        private Panel pnlLogTools;
        private Button btnLogCopy;
        private Button btnLogSave;
        private TextBox txtEmailAccount;
        private Panel panelComposeToolbar;
        private FlowLayoutPanel flowComposeToolbar;
        private Label lblMessageStats;
        private Button btnOpenPreviewTab;
        private Label lblComposeTemplateHint;
        private Panel pnlPreviewToolbar;
        private FlowLayoutPanel flowPreviewTools;
        private Label lblPreviewStatus;
        private Label lblPreviewError;
        private Button btnZoom75;
        private Button btnZoom100;
        private Button btnZoom125;
        private Button btnRefresh;
    }
}