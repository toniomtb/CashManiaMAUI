namespace CashManiaMAUI.Services.DTOs.Users;

public record LoginRequestDto
{
    public string? email { get; set; }
    public string? password { get; set; }
    public string? twoFactorCode { get; set; }
    public string? twoFactorRecoveryCode { get; set; }
}