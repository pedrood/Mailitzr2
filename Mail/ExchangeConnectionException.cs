namespace Mailitzr.Mail;

/// <summary>
/// Thrown when the Exchange client cannot be initialized. UI may catch and present to the user.
/// </summary>
public sealed class ExchangeConnectionException : InvalidOperationException
{
    public ExchangeConnectionException(string message, Exception? innerException = null)
        : base(message, innerException)
    {
    }
}
