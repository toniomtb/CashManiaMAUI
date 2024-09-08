using System.Text;
using System.Text.Json;
using CashManiaMAUI.Services.DTOs.Login;

namespace CashManiaMAUI.Services;

public class ApiService
{
    HttpClient _client;

    public ApiService(HttpClient client)
    {
        _client = client;
    }

    public async Task<AccessTokenResponseDTO> Login(LoginRequestDTO requestDTO)
    {
        var jsonContent = JsonSerializer.Serialize(requestDTO);
        var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/login", httpContent);

        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<AccessTokenResponseDTO>(responseContent);
    }
}
