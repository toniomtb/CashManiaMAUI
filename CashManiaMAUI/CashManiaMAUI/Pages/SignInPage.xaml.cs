using CashManiaMAUI.ViewModels;

namespace CashManiaMAUI.Pages;

public partial class SignInPage : ContentPage
{
	public SignInPage(SignInPageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }

    private async void OnSignUpTapped(object? sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SignUpPage));
    }
}