using System;

namespace CashManiaMAUI.Models.Login;

public class LoginRequest
{
    public string email { get; set; }
    public string password { get; set; }
    public string twoFactorCode { get; set; }
    public string twoFactorRecoveryCode { get; set; }
}