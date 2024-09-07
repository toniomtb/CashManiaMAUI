using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Text.RegularExpressions;

namespace CashManiaMAUI.ViewModels;

public partial class SignUpPageViewModel : ObservableObject
{
    [ObservableProperty]
    string? username;

    [ObservableProperty]
    string? password;

    [ObservableProperty]
    string? confirmPassword;

    [RelayCommand]
    private async void SignUp()
    {
        if (!await ValidateSignUpData())
            return;

        Application.Current.MainPage.DisplayAlert("Success", "Sign Up successful", "OK");
    }

    private async Task<bool> ValidateSignUpData()
    {
        if (Username != null && !IsUsernameValid(Username))
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Username must contain only letters or numbers.", "OK");
            return false;
        }

        if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(ConfirmPassword))
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

    private bool IsUsernameValid(string username)
    {
        return Regex.IsMatch(username, "^[a-zA-Z0-9]+$");
    }
}