using AutoMapper;
using RoyalVilla.Core.Entities.Villas;
using RoyalVilla.Core.Entities.VillasNumbers;
using RoyalVilla.Endpoints.VillaAPI.Models.DTOs;
using System.Runtime;

namespace RoyalVilla.Endpoints.VillaAPI;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<Villa, VillaDTO>().ReverseMap();
        CreateMap<Villa, VillaCreateDTO>().ReverseMap();
        CreateMap<Villa, VillaUpdateDTO>().ReverseMap();

        CreateMap<VillaNumber, VillaNumberDTO>().ReverseMap();
        CreateMap<VillaNumber, VillaNumberCreateDTO>().ReverseMap();
        CreateMap<VillaNumber, VillaNumberUpdateDTO>().ReverseMap();
    }
}
