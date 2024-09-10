using System.Text;
using System.Text.Json;
using CashManiaMAUI.Services.DTOs.Users;

namespace CashManiaMAUI.Services;

public class CashManiaApiService(HttpClient client) : ICashManiaApiService
{
    public async Task<AccessTokenResponseDTO> Login(LoginRequestDTO requestDTO)
    {
        try
        {
            var jsonContent = JsonSerializer.Serialize(requestDTO);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/login", httpContent);

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<AccessTokenResponseDTO>(responseContent);
        }
        catch (Exception e)
        {
            return new AccessTokenResponseDTO();
        }
    }

    public async Task<bool> Register(RegisterRequestDTO requestDTO)
    {
        try
        {
            var jsonContent = JsonSerializer.Serialize(requestDTO);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/register", httpContent);

            response.EnsureSuccessStatusCode();

            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}