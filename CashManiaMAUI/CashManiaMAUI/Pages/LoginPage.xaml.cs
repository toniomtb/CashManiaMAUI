using CashManiaMAUI.ViewModels;

namespace CashManiaMAUI.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage(SignInPageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }

    private async void OnSignUpTapped(object? sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SignUpPage));
    }
}