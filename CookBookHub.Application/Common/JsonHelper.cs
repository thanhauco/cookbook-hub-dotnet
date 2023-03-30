using System.Text.Json;

namespace CookBookHub.Application.Common;

public static class JsonHelper
{
    private static readonly JsonSerializerOptions DefaultOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true
    };

    public static string Serialize<T>(T obj)
    {
        return JsonSerializer.Serialize(obj, DefaultOptions);
    }

    public static T? Deserialize<T>(string json)
    {
        return JsonSerializer.Deserialize<T>(json, DefaultOptions);
    }

    public static bool TryDeserialize<T>(string json, out T? result)
    {
        try
        {
            result = Deserialize<T>(json);
            return result != null;
        }
        catch
        {
            result = default;
            return false;
        }
    }
}
