using CashManiaMAUI.Services.Interfaces;

namespace CashManiaMAUI.Services;

public class SecureStorageService : ISecureStorageService
{
    private const string LOGIN_TOKEN = "LOGIN_TOKEN";

    public async Task StoreLoginTokenAsync(string token)
    {
        try
        {
            await SecureStorage.Default.SetAsync(LOGIN_TOKEN, token);
        }
        catch (Exception ex)
        {
            //TODO: HANDLE EXCEPTION
        }
    }

    public async Task<string?> GetLoginTokenAsync()
    {
        try
        {
            return await SecureStorage.Default.GetAsync(LOGIN_TOKEN);
        }
        catch (Exception ex)
        {
            //TODO: HANDLE EXCEPTION
            return null;
        }
    }

    public void RemoveLoginToken()
    {
        SecureStorage.Default.Remove(LOGIN_TOKEN);
    }
}
