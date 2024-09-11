using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using CashManiaMAUI.Services.DTOs;
using CashManiaMAUI.Services.DTOs.Transactions;
using CashManiaMAUI.Services.DTOs.Users;

namespace CashManiaMAUI.Services;

public class CashManiaApiService(HttpClient client) : ICashManiaApiService
{
    public async Task<AccessTokenResponseDto> Login(LoginRequestDto requestDTO)
    {
        try
        {
            var jsonContent = JsonSerializer.Serialize(requestDTO);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/login", httpContent);

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<AccessTokenResponseDto>(responseContent);
        }
        catch (Exception e)
        {
            return new AccessTokenResponseDto();
        }
    }

    public async Task<RegisterResponseDto> Register(RegisterRequestDto requestDTO)
    {
        try
        {
            var jsonContent = JsonSerializer.Serialize(requestDTO);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/register", httpContent);

            if (response.IsSuccessStatusCode)
                return new RegisterResponseDto { IsSuccess = true };

            var errorContent = await response.Content.ReadAsStringAsync();
            var validationProblemDetails = JsonSerializer.Deserialize<HttpValidationProblemDetailsDto>(errorContent);

            var errorMessage = string.Join("\n", validationProblemDetails.errors
                .SelectMany(e => e.Value));

            return new RegisterResponseDto
            {
                IsSuccess = false,
                ErrorMessage = errorMessage
            };
        }
        catch (Exception e)
        {
            return new RegisterResponseDto
            {
                IsSuccess = false,
                ErrorMessage = "An unexpected error occurred. Please try again."
            };
        }
    }

    public async Task<IEnumerable<TransactionDto>?> GetTransactionsFiltered(string authToken, DateTime startDate, DateTime endDate)
    {
        try
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

            string start = startDate.ToString("yyyy-MM-dd");
            string end = endDate.ToString("yyyy-MM-dd");
            string url = $"/api/Transaction/get-filtered?startDate={start}&endDate={end}"; //TODO: no hardcoded urls

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var transactions = JsonSerializer.Deserialize<IEnumerable<TransactionDto>>(jsonResponse);
            
            return transactions ?? new List<TransactionDto>();
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<bool> AddTransaction(string authToken, TransactionDto transactionDto)
    {
        try
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

            var jsonContent = JsonSerializer.Serialize(transactionDto);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json"); 

            var response = await client.PostAsync("/api/Transaction/add", httpContent); //TODO: no hardcoded urls

            response.EnsureSuccessStatusCode();

            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}