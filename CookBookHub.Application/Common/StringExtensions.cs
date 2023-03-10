namespace CookBookHub.Application.Common;

public static class StringExtensions
{
    public static string Truncate(this string value, int maxLength)
    {
        if (string.IsNullOrEmpty(value)) return value;
        return value.Length <= maxLength ? value : value.Substring(0, maxLength) + "...";
    }

    public static string ToSlug(this string value)
    {
        if (string.IsNullOrEmpty(value)) return string.Empty;
        
        value = value.ToLowerInvariant();
        value = System.Text.RegularExpressions.Regex.Replace(value, @"[^a-z0-9\s-]", "");
        value = System.Text.RegularExpressions.Regex.Replace(value, @"\s+", " ").Trim();
        value = value.Replace(" ", "-");
        
        return value;
    }

    public static bool IsValidEmail(this string email)
    {
        if (string.IsNullOrWhiteSpace(email)) return false;
        
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}
