using Microsoft.AspNetCore.Http;
using System.Text.Json;

public static class SessionExtensions
{
    public static void SetSession<T>(this ISession session, string key, T value)
    {
        var jsonData = JsonSerializer.Serialize(value);
        session.Set(key, System.Text.Encoding.UTF8.GetBytes(jsonData));
    }

    public static T? GetSession<T>(this ISession session, string key)
    {
        if (session.TryGetValue(key, out byte[] data))
        {
            var jsonData = System.Text.Encoding.UTF8.GetString(data);
            return JsonSerializer.Deserialize<T>(jsonData);
        }
        return default;
    }
}
