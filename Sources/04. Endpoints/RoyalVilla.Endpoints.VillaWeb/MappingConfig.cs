using AutoMapper;
using RoyalVilla.Endpoints.VillaWeb.Models.DTOs;

namespace RoyalVilla.Endpoints.VillaWeb;

public sealed class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<VillaDTO, VillaCreateDTO>().ReverseMap();
        CreateMap<VillaDTO, VillaUpdateDTO>().ReverseMap();

        CreateMap<VillaNumberDTO, VillaNumberCreateDTO>().ReverseMap();
        CreateMap<VillaNumberDTO, VillaNumberUpdateDTO>().ReverseMap();
    }
}
