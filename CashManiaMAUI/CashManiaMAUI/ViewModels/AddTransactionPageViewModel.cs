using CashManiaMAUI.Models.Enums;
using CashManiaMAUI.Models.Transactions;
using CashManiaMAUI.Services.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CashManiaMAUI.ViewModels
{
    public partial class AddTransactionPageViewModel(IApiService apiService) : ObservableObject
    {
        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private decimal? amount = null;

        [ObservableProperty]
        private DateTime date = DateTime.Now;

        [ObservableProperty]
        private bool isExpense = true;

        [RelayCommand]
        public async Task SaveTransaction()
        {
            if (Description == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Enter the description", "OK");
                return;
            }

            if (Amount == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Enter the amount", "OK");
                return;
            }

            var finalAmount = IsExpense ? -Math.Abs(Amount.Value) : Math.Abs(Amount.Value);

            var transaction = new Transaction
            {
                Amount = finalAmount,
                Type = isExpense ? TransactionType.Expense : TransactionType.Income,
                Date = Date,
                Description = Description
            };
            bool addResult = await apiService.AddTransaction(transaction);

            if(!addResult)
                await Application.Current.MainPage.DisplayAlert("Error", "Error adding transaction", "OK");

            await Shell.Current.GoToAsync("..");
        }

    }
}