using AutoMapper;
using CashManiaMAUI.Models.Users;
using CashManiaMAUI.Services.DTOs.Users;

namespace CashManiaMAUI.Automapper;

public class DTOToDomainMappingPorfile : Profile
{
    public DTOToDomainMappingPorfile()
    {
        MapLogin();
    }

    private void MapLogin()
    {
        CreateMap<AccessTokenResponseDTO, AccessTokenResponse>();
    }
}