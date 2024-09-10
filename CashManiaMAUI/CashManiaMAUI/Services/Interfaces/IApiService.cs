using CashManiaMAUI.Models.Users;

namespace CashManiaMAUI.Services.Interfaces;
public interface IApiService
{
    Task<AccessTokenResponse> Login(LoginRequest request);
    Task<RegisterResponse> Register(RegisterRequest request);
}