using AutoMapper;
using CashManiaMAUI.Models.Transactions;
using CashManiaMAUI.Models.Users;
using CashManiaMAUI.Services.DTOs.Transactions;
using CashManiaMAUI.Services.DTOs.Users;

namespace CashManiaMAUI.Automapper;

public class DTOToDomainMappingPorfile : Profile
{
    public DTOToDomainMappingPorfile()
    {
        MapLogin();
        MapRegister();
        MapTransactions();
    }

    private void MapLogin()
    {
        CreateMap<AccessTokenResponseDto, AccessTokenResponse>();
    }

    private void MapRegister()
    {
        CreateMap<RegisterResponseDto, RegisterResponse>();
    }

    private void MapTransactions()
    {
        CreateMap<TransactionDto, Transaction>();
    }
}