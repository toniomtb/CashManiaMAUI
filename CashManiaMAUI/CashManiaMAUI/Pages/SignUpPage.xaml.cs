using CashManiaMAUI.ViewModels;

namespace CashManiaMAUI.Pages;

public partial class SignUpPage : ContentPage
{
	public SignUpPage(SignUpPageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}