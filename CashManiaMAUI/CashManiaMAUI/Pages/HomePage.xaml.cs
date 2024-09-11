using CashManiaMAUI.ViewModels;

namespace CashManiaMAUI.Pages;

public partial class HomePage : ContentPage
{
	public HomePage(HomePageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}