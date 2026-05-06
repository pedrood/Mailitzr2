namespace Mailitzr.Mail;

/// <summary>
/// Abstraction for sending email (dependency inversion — UI depends on this, not on Exchange types).
/// </summary>
public interface IEmailSender : IDisposable
{
    /// <summary>Sends one HTML message. Returns false if the transport fails; does not throw for send failures.</summary>
    bool Send(OutboundEmail message);
}
