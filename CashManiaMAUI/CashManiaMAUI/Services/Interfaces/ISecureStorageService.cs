using System;

namespace CashManiaMAUI.Services.Interfaces;

public interface ISecureStorageService
{
    Task StoreLoginTokenAsync(string token);
    Task<string?> GetLoginTokenAsync();
    void RemoveLoginToken();
}