using CashManiaMAUI.Services.DTOs.Transactions;
using CashManiaMAUI.Services.DTOs.Users;

namespace CashManiaMAUI.Services;

public interface ICashManiaApiService
{
    Task<AccessTokenResponseDto> Login(LoginRequestDto requestDTO);
    Task<RegisterResponseDto> Register(RegisterRequestDto requestDTO);
    Task<bool> CheckLoginTokenIsValid(string authToken);
    Task<IEnumerable<TransactionDto>?> GetTransactionsFiltered(string authToken, DateTime startDate, DateTime endDate);
    Task<bool> AddTransaction(string authToken, TransactionDto transactionDto);
}