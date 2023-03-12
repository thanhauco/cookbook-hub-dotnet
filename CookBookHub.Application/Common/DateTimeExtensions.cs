namespace CookBookHub.Application.Common;

public static class DateTimeExtensions
{
    public static string ToRelativeTime(this DateTime dateTime)
    {
        var timeSpan = DateTime.UtcNow - dateTime;

        if (timeSpan.TotalSeconds < 60)
            return "just now";
        if (timeSpan.TotalMinutes < 60)
            return $"{(int)timeSpan.TotalMinutes} minutes ago";
        if (timeSpan.TotalHours < 24)
            return $"{(int)timeSpan.TotalHours} hours ago";
        if (timeSpan.TotalDays < 7)
            return $"{(int)timeSpan.TotalDays} days ago";
        if (timeSpan.TotalDays < 30)
            return $"{(int)(timeSpan.TotalDays / 7)} weeks ago";
        if (timeSpan.TotalDays < 365)
            return $"{(int)(timeSpan.TotalDays / 30)} months ago";
        
        return $"{(int)(timeSpan.TotalDays / 365)} years ago";
    }

    public static bool IsToday(this DateTime dateTime)
    {
        return dateTime.Date == DateTime.UtcNow.Date;
    }

    public static bool IsThisWeek(this DateTime dateTime)
    {
        var startOfWeek = DateTime.UtcNow.AddDays(-(int)DateTime.UtcNow.DayOfWeek);
        return dateTime >= startOfWeek && dateTime <= DateTime.UtcNow;
    }
}
