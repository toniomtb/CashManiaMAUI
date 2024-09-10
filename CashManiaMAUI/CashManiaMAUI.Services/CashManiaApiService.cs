using System.Text;
using System.Text.Json;
using CashManiaMAUI.Services.DTOs;
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

    public async Task<RegisterResponseDTO> Register(RegisterRequestDTO requestDTO)
    {
        try
        {
            var jsonContent = JsonSerializer.Serialize(requestDTO);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/register", httpContent);

            if (response.IsSuccessStatusCode)
                return new RegisterResponseDTO { IsSuccess = true };

            var errorContent = await response.Content.ReadAsStringAsync();
            var validationErrors = JsonSerializer.Deserialize<HttpValidationProblemDetailsDTO>(errorContent);

            var errorMessage = string.Join("\n", validationErrors.errors
                .SelectMany(e => e.Value));

            return new RegisterResponseDTO
            {
                IsSuccess = false,
                ErrorMessage = errorMessage
            };
        }
        catch (Exception e)
        {
            return new RegisterResponseDTO
            {
                IsSuccess = false,
                ErrorMessage = "An unexpected error occurred. Please try again."
            };
        }
    }
}