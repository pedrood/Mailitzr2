namespace Mailitzr.Mail;

/// <summary>
/// Immutable payload for one outbound message. The mailbox identity is owned by <see cref="IEmailSender"/>.
/// (Named OutboundEmail to avoid clashing with Microsoft.Exchange.WebServices.Data.EmailMessage.)
/// </summary>
public sealed record OutboundEmail(
    string Subject,
    string HtmlBody,
    string SenderDisplayName,
    string RecipientEmail);
