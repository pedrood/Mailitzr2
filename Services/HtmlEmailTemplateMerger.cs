namespace Mailitzr.Services;

/// <summary>
/// Pure template substitution (open for new tokens without changing send logic).
/// </summary>
public static class HtmlEmailTemplateMerger
{
    public static string Merge(
        string templateHtml,
        string recipientEmail,
        string subjectLine,
        DateTime? sentDateUtc = null)
    {
        ArgumentNullException.ThrowIfNull(templateHtml);
        var localDate = (sentDateUtc ?? DateTime.Now).ToLocalTime();
        return templateHtml
            .Replace("{mail}", recipientEmail, StringComparison.Ordinal)
            .Replace("{subject}", subjectLine ?? string.Empty, StringComparison.Ordinal)
            .Replace("{date}", localDate.ToString("dd.MM.yyyy"), StringComparison.Ordinal);
    }
}
