using CashManiaMAUI.Services.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CashManiaMAUI.ViewModels;

public partial class SignUpPageViewModel(IApiService apiService) : ObservableObject
{
    [ObservableProperty]
    string? email;

    [ObservableProperty]
    string? password;

    [ObservableProperty]
    string? confirmPassword;

    [RelayCommand]
    private async void SignUp()
    {
        if (!await ValidateSignUpData())
            return;

        if(await apiService.Register(Email, Password))
            Application.Current.MainPage.DisplayAlert("Success", "Sign Up successful, go to Login page", "OK");
        else
            Application.Current.MainPage.DisplayAlert("Error", "There was an error signin in", "OK");
    }

    private async Task<bool> ValidateSignUpData()
    {
        //TODO: VALIDATE EMAIL.

        if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(ConfirmPassword))
        {
            await Application.Current.MainPage.DisplayAlert("Error", "All fields are required", "OK");
            return false;
        }

        if (Password != ConfirmPassword)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Passwords do not match", "OK");
            return false;
        }

        return true;
    }
}