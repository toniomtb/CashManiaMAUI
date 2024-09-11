﻿using CashManiaMAUI.Models.Transactions;
using CashManiaMAUI.Models.Users;

namespace CashManiaMAUI.Services.Interfaces;
public interface IApiService
{
    Task<AccessTokenResponse> Login(LoginRequest request);
    Task<RegisterResponse> Register(RegisterRequest request);
    Task<IEnumerable<Transaction>?> GetTransactionsFiltered(DateTime startDate, DateTime endDate);
    Task<bool> AddTransaction(Transaction transaction);
}