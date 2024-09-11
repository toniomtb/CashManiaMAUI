using CashManiaMAUI.Models.Transactions;
using CashManiaMAUI.Models.Users;

namespace CashManiaMAUI.Services.Interfaces;
public interface IApiService
{
    Task<AccessTokenResponse> Login(LoginRequest request);
    Task<RegisterResponse> Register(RegisterRequest request);
    Task<IEnumerable<Transaction>?> GetTransactionsFiltered(string authToken, DateTime startDate, DateTime endDate);
}