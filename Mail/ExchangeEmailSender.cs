using System.Net;
using Microsoft.Exchange.WebServices.Data;

namespace Mailitzr.Mail;

/// <summary>
/// Exchange Web Services implementation of <see cref="IEmailSender"/> (single responsibility: EWS transport).
/// </summary>
public sealed class ExchangeEmailSender : IEmailSender
{
    private readonly string _mailboxAddress;
    private readonly ExchangeService? _exchangeService;
    private bool _disposed;

    public ExchangeEmailSender(string mailAccount, string mailPassword)
    {
        _mailboxAddress = mailAccount ?? throw new ArgumentNullException(nameof(mailAccount));
        ArgumentNullException.ThrowIfNull(mailPassword);

        try
        {
            var service = new ExchangeService(ExchangeVersion.Exchange2016)
            {
                Credentials = new WebCredentials(mailAccount, mailPassword)
            };
            service.AutodiscoverUrl(mailAccount, RedirectionUrlValidationCallback);
            _exchangeService = service;
        }
        catch (Exception ex)
        {
            throw new ExchangeConnectionException(
                "Could not connect to Exchange. Check account, password, and network.",
                ex);
        }
    }

    public bool Send(OutboundEmail message)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
        ArgumentNullException.ThrowIfNull(message);

        if (_exchangeService == null)
            return false;

        try
        {
            var email = new EmailMessage(_exchangeService);
            email.ToRecipients.Add(message.RecipientEmail);
            email.Sender = new EmailAddress(message.SenderDisplayName, _mailboxAddress);
            email.Subject = message.Subject;
            email.Body = new MessageBody(BodyType.HTML, message.HtmlBody);
            email.Send();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public void Dispose()
    {
        if (_disposed)
            return;
        _disposed = true;
        _exchangeService?.Abort();
    }

    private static bool RedirectionUrlValidationCallback(string redirectionUrl)
    {
        return new Uri(redirectionUrl).Scheme == Uri.UriSchemeHttps;
    }
}
