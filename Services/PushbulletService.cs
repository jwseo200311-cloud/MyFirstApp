using System.Text;
using System.Text.Json;

namespace MyFirstApp.Services;

public class PushbulletService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _accessToken;

    public PushbulletService(IHttpClientFactory httpClientFactory, IConfiguration config)
    {
        _httpClientFactory = httpClientFactory;
        _accessToken = config["Pushbullet:AccessToken"] ?? "";
    }

    public async Task SendNotificationAsync(string title, string body)
    {
        var client = _httpClientFactory.CreateClient();
        client.DefaultRequestHeaders.Add("Access-Token", _accessToken);

        var payload = new
        {
            type = "note",
            title = title,
            body = body
        };

        var json = JsonSerializer.Serialize(payload);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        await client.PostAsync("https://api.pushbullet.com/v2/pushes", content);
    }
}
