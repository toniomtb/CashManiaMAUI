using CashManiaMAUI.Models.Users;
using CashManiaMAUI.Services.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CashManiaMAUI.ViewModels;

public partial class SignInPageViewModel(IApiService apiService) : ObservableObject
{
    [ObservableProperty]
    string? email;

    [ObservableProperty]
    string? password;

    [RelayCommand]
    private async void SignIn()
    {
        if (email == null || password == null)
        {
            Application.Current.MainPage.DisplayAlert("Error", "All fields are required", "OK");
            return;
        }

        var request = new LoginRequest
        {
            email = email,
            password = password,
            twoFactorCode = null,
            twoFactorRecoveryCode = null,
        };
        var loginResponse =  await apiService.Login(request);

        if (loginResponse.accessToken == null)
            Application.Current.MainPage.DisplayAlert("Error", $"Login error, invalid data.", "OK");
        else
            Application.Current.MainPage.DisplayAlert("Success", $"Login successful. Access token = {loginResponse.accessToken}", "OK");
    }
}
