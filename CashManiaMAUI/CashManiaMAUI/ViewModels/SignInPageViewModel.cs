using CashManiaMAUI.Models.Users;
using CashManiaMAUI.Pages;
using CashManiaMAUI.Services.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CashManiaMAUI.ViewModels;

public partial class SignInPageViewModel(IApiService apiService,
    ISecureStorageService secureStorageService) : ObservableObject
{
    [ObservableProperty]
    string? email;

    [ObservableProperty]
    string? password;

    [RelayCommand]
    private async void SignIn()
    {
        if (Email == null || Password == null)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "All fields are required", "OK");
            return;
        }

        var request = new LoginRequest
        {
            email = Email,
            password = Password,
            twoFactorCode = null,
            twoFactorRecoveryCode = null,
        };
        var loginResponse =  await apiService.Login(request);

        if (loginResponse.accessToken == null)
            await Application.Current.MainPage.DisplayAlert("Error", $"Login error, invalid data.", "OK");
        else
        {
            secureStorageService.StoreLoginTokenAsync(loginResponse.accessToken);

            await Shell.Current.GoToAsync("//"+nameof(HomePage));
        }
    }
}