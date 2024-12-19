using AutoMapper;
using UserService.Models.Db;
using UserService.Models.Dto.Responses;

namespace UserService.Infrastructure.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DbUser, GetUserResponse>().ReverseMap();
    }
}
