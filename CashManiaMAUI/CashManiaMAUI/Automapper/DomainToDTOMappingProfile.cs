using AutoMapper;
using CashManiaMAUI.Models.Transactions;
using CashManiaMAUI.Models.Users;
using CashManiaMAUI.Services.DTOs.Transactions;
using CashManiaMAUI.Services.DTOs.Users;

namespace CashManiaMAUI.Automapper;
public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        MapLogin();
        MapRegister();
        MapTransaction();
    }

    private void MapLogin()
    {
        CreateMap<LoginRequest, LoginRequestDto>();
    }

    private void MapRegister()
    {
        CreateMap<RegisterRequest, RegisterRequestDto>();
    }

    private void MapTransaction()
    {
        CreateMap<Transaction, TransactionDto>();
    }
}