using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace MinimalApi;

public class HttpController
{
    private readonly HttpClient _httpClient;

    public HttpController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<AdvancedUserModel> Get(UserModel user)
    {
        string usersEndpoint = $"https://eu.api.fpjs.io/visitors/{user.UiD}?api_key=gHhx0wYg3myKxD9e0P02";
        var httpResponseMessage = await _httpClient.GetAsync(usersEndpoint);
        var jsonResponse = await JsonDocument.ParseAsync(await httpResponseMessage.Content.ReadAsStreamAsync());
        var root = jsonResponse.RootElement.GetProperty("visits")[0];
        AdvancedUserModel userModel = new();
        try
        {
            var browserDetailsArray = root.GetProperty("browserDetails");
            var ipLocationArray = root.GetProperty("ipLocation");
            var ip = root.GetProperty("ip").ToString();
            var browserName = browserDetailsArray.GetProperty("browserName").ToString();
            var os = browserDetailsArray.GetProperty("os").ToString();
            var device = browserDetailsArray.GetProperty("device").ToString();
            var accuracy = ipLocationArray.GetProperty("accuracyRadius").ToString();
            ipLocationArray.TryGetProperty("postalCode", out var postalCode);

            userModel = new AdvancedUserModel
            {
                Uid = user.UiD,
                CommunicationType = user.CommunicationType,
                IntensityReal = user.IntensityReal,
                IntensityWish = user.IntensityWish,
                Control = user.Control,
                Browser = browserName,
                Os = os,
                Device = device,
                Ip = ip,
                PostalCode = postalCode.ToString(),
                Accuracy = accuracy
            };

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Console.WriteLine(root);
        }
        

        return userModel;
    }

    public async Task<UserModel[]> Get()
    {
        using var httpResponseMessage = await _httpClient.GetAsync("https://guugli.de/api/users");
        Console.WriteLine(httpResponseMessage.Content);
        return await httpResponseMessage.Content.ReadFromJsonAsync<UserModel[]>();
    }
}