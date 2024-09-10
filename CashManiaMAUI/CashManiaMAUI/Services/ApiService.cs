using AutoMapper;
using CashManiaMAUI.Models.Users;
using CashManiaMAUI.Services.DTOs.Users;
using CashManiaMAUI.Services.Interfaces;

namespace CashManiaMAUI.Services;

public class ApiService(ICashManiaApiService cashManiaApiService, IMapper mapper) : IApiService
{
    public async Task<AccessTokenResponse> Login(string email, string password)
    {
        var request = new LoginRequest
        {
            email = email,
            password = password,
            twoFactorCode = null,
            twoFactorRecoveryCode = null,
        };

        var requestDTO = mapper.Map<LoginRequestDTO>(request);

        var resultLogin = await cashManiaApiService.Login(requestDTO);
        return mapper.Map<AccessTokenResponse>(resultLogin);
    }

    public async Task<bool> Register(string email, string password)
    {
        var request = new RegisterRequest
        {
            email = email,
            password = password,
        };

        var requestDTO = mapper.Map<RegisterRequestDTO>(request);
        return await cashManiaApiService.Register(requestDTO);
    }
}