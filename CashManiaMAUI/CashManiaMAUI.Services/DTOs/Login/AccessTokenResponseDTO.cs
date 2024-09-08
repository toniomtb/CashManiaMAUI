using System;

namespace CashManiaMAUI.Services.DTOs.Login;

public class AccessTokenResponseDTO
{
    public string? tokenType { get; set; }
    public string? accessToken { get; set; }
    public int expiresIn { get; set; }
    public string? refreshToken { get; set; }
}
