using AutoMapper;
using BasicAPI.Models;

namespace BasicAPI.infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RoomEntity, Room>().ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.Rate / 100.0m));
        }
    }
}
