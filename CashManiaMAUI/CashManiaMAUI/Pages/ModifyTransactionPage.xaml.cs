using CashManiaMAUI.ViewModels;

namespace CashManiaMAUI.Pages;

public partial class ModifyTransactionPage : ContentPage
{
	public ModifyTransactionPage(ModifyTransactionPageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}