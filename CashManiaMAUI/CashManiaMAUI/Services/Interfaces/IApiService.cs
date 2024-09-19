using CashManiaMAUI.Models.Transactions;
using CashManiaMAUI.Models.Users;

namespace CashManiaMAUI.Services.Interfaces;
public interface IApiService
{
    Task<AccessTokenResponse> Login(LoginRequest request);
    Task<RegisterResponse> Register(RegisterRequest request);
    Task<bool> CheckLoginTokenIsValid(string authToken);
    Task<IEnumerable<Transaction>?> GetTransactionsFiltered(DateTime startDate, DateTime endDate);
    Task<bool> AddTransaction(Transaction transaction);
    Task<bool> DeleteTransaction(int transactionId);
    Task<bool> UpdateTransaction(Transaction transaction);
}