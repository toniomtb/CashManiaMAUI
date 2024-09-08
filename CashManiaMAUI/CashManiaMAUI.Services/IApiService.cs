using System;
using CashManiaMAUI.Services.DTOs.Login;

namespace CashManiaMAUI.Services;

public interface IApiService
{
    public Task<AccessTokenResponseDTO> Login(LoginRequestDTO requestDTO);
}
