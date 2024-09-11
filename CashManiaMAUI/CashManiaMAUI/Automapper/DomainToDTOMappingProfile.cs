using AutoMapper;
using CashManiaMAUI.Models.Users;
using CashManiaMAUI.Services.DTOs.Users;

namespace CashManiaMAUI.Automapper;
public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        MapLogin();
        MapRegister();
    }

    private void MapLogin()
    {
        CreateMap<LoginRequest, LoginRequestDto>();
    }

    private void MapRegister()
    {
        CreateMap<RegisterRequest, RegisterRequestDto>();
    }
}