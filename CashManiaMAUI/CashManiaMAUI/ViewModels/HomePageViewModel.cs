﻿using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using CashManiaMAUI.Models.Transactions;
using CashManiaMAUI.Pages;
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
        private Transaction? selectedTransaction;

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
            var transactions = await _apiService.GetTransactionsFiltered(StartDate, EndDate);

            if (transactions == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Error retreiving transactions", "OK");
                return;
            }

            Transactions.Clear();
            foreach (var transaction in transactions.OrderByDescending(x => x.Date))
            {
                Transactions.Add(transaction);
            }

            CalculateTotals();
        }

        [RelayCommand]
        public async Task AddTransaction()
        {
            await Shell.Current.GoToAsync(nameof(AddTransactionPage));

            LoadTransactionsCommand.Execute(null);
        }

        [RelayCommand]
        public async Task DeleteTransaction(Transaction transaction)
        {
            if (transaction == null)
                return;

            var success = await _apiService.DeleteTransaction(transaction.Id);

            if (success)
            {
                Transactions.Remove(transaction);
                CalculateTotals();
            }
            else
                await Application.Current.MainPage.DisplayAlert("Error", "Could not delete transaction.", "OK");
        }

        [RelayCommand]
        private async Task TransactionSelected()
        {
            if (SelectedTransaction != null)
            {
                var navigationParameter = new Dictionary<string, object>
                {
                    { "SelectedTransaction", SelectedTransaction }
                };

                await Shell.Current.GoToAsync(nameof(ModifyTransactionPage), navigationParameter);
            }
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
