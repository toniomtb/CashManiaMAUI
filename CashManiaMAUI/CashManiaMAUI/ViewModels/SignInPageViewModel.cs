using System;

namespace CashManiaMAUI.ViewModels;

public class SignInPageViewModel : ObservableObject
{
    [ObservableProperty]
    string? email;

    [ObservableProperty]
    string? password;

}
