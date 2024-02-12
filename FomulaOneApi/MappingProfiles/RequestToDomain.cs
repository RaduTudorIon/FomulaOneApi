using AutoMapper;
using FomulaOneApi.Entities;
using FormulaOne.Entities.Dtos.Requests;

namespace FomulaOne.Api.MappingProfiles;

public class RequestToDomain : Profile
{
    public RequestToDomain()
    {
        CreateMap<CreateDriverAchievementRequest, Achievement>()
            .ForMember(dest => dest.RaceWins, opt => opt.MapFrom(src => src.Wins))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(_ => 1))
            .ForMember(dest => dest.AddedDate, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(_ => DateTime.UtcNow));

        CreateMap<UpdateDriverAchievementRequest, Achievement>()
            .ForMember(dest => dest.RaceWins, opt => opt.MapFrom(src => src.Wins))
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(_ => DateTime.UtcNow));

        CreateMap<CreateDriverRequest, Driver>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(_ => 1))
            .ForMember(dest => dest.AddedDate, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(_ => DateTime.UtcNow));

        CreateMap<UpdateDriverRequest, Driver>()
            .ForMember(dest => dest.DriversNumber, opt => opt.MapFrom(src => src.DriverNumber))
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(_ => DateTime.UtcNow));
    }
}
