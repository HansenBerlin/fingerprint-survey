using System.Net.Mime;
using System.Text;
using System.Text.Json;
using fingerprint.Models;
namespace MinimalFrontend.Controller;


public class UserRepositoryController : IUserRepositoryController
{
    private readonly HttpClient _httpClient;
    private readonly string _usersEndpoint;

    public UserRepositoryController(HttpClient httpClient, string userEndpoint)
    {
        _httpClient = httpClient;
        _usersEndpoint = userEndpoint;
    }

    public async Task Create(UserModel user)
    {
        var json = new StringContent(
            JsonSerializer.Serialize(user),
            Encoding.UTF8,
            MediaTypeNames.Application.Json);
        using var httpResponseMessage = await _httpClient.PostAsync(_usersEndpoint, json);
    }
}