using CashManiaMAUI.ViewModels;

namespace CashManiaMAUI.Pages;

public partial class AddTransactionPage : ContentPage
{
	public AddTransactionPage(AddTransactionPageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}