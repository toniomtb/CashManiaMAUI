using System;

namespace CashManiaMAUI.Services.DTOs.Login;

public class LoginRequestDTO
{
    public string? email { get; set; }
    public string? password { get; set; }
    public string? twoFactorCode { get; set; }
    public string? twoFactorRecoveryCode { get; set; }
}