using AutoMapper;
using CashManiaMAUI.Models.Transactions;
using CashManiaMAUI.Models.Users;
using CashManiaMAUI.Services.DTOs.Transactions;
using CashManiaMAUI.Services.DTOs.Users;
using CashManiaMAUI.Services.Interfaces;

namespace CashManiaMAUI.Services;

public class ApiService(ISecureStorageService secureStorageService,
    ICashManiaApiService cashManiaApiService, IMapper mapper) : IApiService
{
    public async Task<AccessTokenResponse> Login(LoginRequest request)
    {
        var requestDTO = mapper.Map<LoginRequestDto>(request);
        var resultLogin = await cashManiaApiService.Login(requestDTO);
        return mapper.Map<AccessTokenResponse>(resultLogin);
    }

    public async Task<RegisterResponse> Register(RegisterRequest request)
    {
        var requestDTO = mapper.Map<RegisterRequestDto>(request);
        var resultRegister = await cashManiaApiService.Register(requestDTO);
        return mapper.Map<RegisterResponse>(resultRegister);
    }

    public async Task<bool> AddTransaction(Transaction transaction)
    {
        var authToken = await secureStorageService.GetLoginTokenAsync();
        if (authToken == null)
            return false;

        var transactionDto = mapper.Map<TransactionDto>(transaction);
        return await cashManiaApiService.AddTransaction(authToken, transactionDto);
    }

    public async Task<IEnumerable<Transaction>?> GetTransactionsFiltered(DateTime startDate, DateTime endDate)
    {
        var authToken = await secureStorageService.GetLoginTokenAsync();
        if (authToken == null)
            return null;

        var resultGet = await cashManiaApiService.GetTransactionsFiltered(authToken, startDate, endDate);
        return mapper.Map<IEnumerable<Transaction>>(resultGet);
    }
}