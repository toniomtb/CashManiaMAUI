using System.Text.RegularExpressions;
using CashManiaMAUI.Models.Users;
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

        var request = new RegisterRequest
        {
            email = Email,
            password = Password,
        };
        var resultRegister = await apiService.Register(request);
        if (resultRegister.IsSuccess)
            await Application.Current.MainPage.DisplayAlert("Success", "Sign Up successful, go to Login page", "OK");
        else
            await Application.Current.MainPage.DisplayAlert("Error", $"{resultRegister.ErrorMessage}", "OK");
    }

    private async Task<bool> ValidateSignUpData()
    {
        if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(ConfirmPassword))
        {
            await Application.Current.MainPage.DisplayAlert("Error", "All fields are required", "OK");
            return false;
        }

        if (!IsValidEmail(Email))
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Please enter a valid email address", "OK");
            return false;
        }

        if (Password != ConfirmPassword)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Passwords do not match", "OK");
            return false;
        }

        return true;
    }

    private bool IsValidEmail(string email)
    {
        var emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, emailRegex);
    }
}