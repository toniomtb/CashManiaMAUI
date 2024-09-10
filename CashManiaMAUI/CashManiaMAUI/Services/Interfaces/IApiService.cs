using CashManiaMAUI.Models.Users;

namespace CashManiaMAUI.Services.Interfaces;
public interface IApiService
{
    Task<AccessTokenResponse> Login(string email, string password);
    Task<bool> Register(string email, string password);
}