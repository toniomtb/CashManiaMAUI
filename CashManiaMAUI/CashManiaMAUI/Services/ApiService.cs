using AutoMapper;
using CashManiaMAUI.Models.Users;
using CashManiaMAUI.Services.DTOs.Users;
using CashManiaMAUI.Services.Interfaces;

namespace CashManiaMAUI.Services;

public class ApiService(ICashManiaApiService cashManiaApiService, IMapper mapper) : IApiService
{
    public async Task<AccessTokenResponse> Login(LoginRequest request)
    {
        var requestDTO = mapper.Map<LoginRequestDTO>(request);
        var resultLogin = await cashManiaApiService.Login(requestDTO);
        return mapper.Map<AccessTokenResponse>(resultLogin);
    }

    public async Task<RegisterResponse> Register(RegisterRequest request)
    {
        var requestDTO = mapper.Map<RegisterRequestDTO>(request);
        var resultRegister = await cashManiaApiService.Register(requestDTO);
        return mapper.Map<RegisterResponse>(resultRegister);
    }
}