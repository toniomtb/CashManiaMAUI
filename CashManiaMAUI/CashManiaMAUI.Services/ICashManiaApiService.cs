using CashManiaMAUI.Services.DTOs.Users;

namespace CashManiaMAUI.Services;

public interface ICashManiaApiService
{
    Task<AccessTokenResponseDTO> Login(LoginRequestDTO requestDTO);
    Task<RegisterResponseDTO> Register(RegisterRequestDTO requestDTO);
}