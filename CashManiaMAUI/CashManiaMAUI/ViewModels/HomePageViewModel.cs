using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using CashManiaMAUI.Models.Transactions;
using CashManiaMAUI.Services.Interfaces;
using CommunityToolkit.Mvvm.Input;

namespace CashManiaMAUI.ViewModels
{
    public partial class HomePageViewModel : ObservableObject
    {
        private readonly IApiService _apiService;
        private readonly ISecureStorageService _secureStorageService;

        public ObservableCollection<Transaction> Transactions { get; set; } = new();

        [ObservableProperty]
        private decimal income;

        [ObservableProperty]
        private decimal expenses;

        [ObservableProperty]
        private decimal total;

        [ObservableProperty]
        private DateTime startDate;

        [ObservableProperty]
        private DateTime endDate;

        public HomePageViewModel(IApiService apiService, ISecureStorageService secureStorageService)
        {
            _apiService = apiService;
            _secureStorageService = secureStorageService;

            StartDate = DateTime.Now.AddMonths(-1);
            EndDate = DateTime.Now; 
        }

        [RelayCommand]
        public async Task LoadTransactions()
        {
            var authToken = await _secureStorageService.GetLoginTokenAsync();
            if (authToken == null)
                return;
            
            var transactions = await _apiService.GetTransactionsFiltered(authToken, StartDate, EndDate);

            if (transactions == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Error retreiving transactions", "OK");
                return;
            }

            Transactions.Clear();
            foreach (var transaction in transactions)
            {
                Transactions.Add(transaction);
            }

            CalculateTotals();
        }

        private void CalculateTotals()
        {
            Income = Transactions.Where(t => t.Amount > 0).Sum(t => t.Amount);
            Expenses = Transactions.Where(t => t.Amount < 0).Sum(t => t.Amount);
            Total = Income + Expenses;
        }

        partial void OnStartDateChanged(DateTime value)
        {
            LoadTransactionsCommand.Execute(null);
        }

        partial void OnEndDateChanged(DateTime value)
        {
            LoadTransactionsCommand.Execute(null);
        }
    }
}
