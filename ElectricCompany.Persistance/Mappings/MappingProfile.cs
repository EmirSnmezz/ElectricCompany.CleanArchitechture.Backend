using AutoMapper;
using ElectricCompany.Application.Features.UserFeatures.Commands.Register;
using ElectricCompany.Domain.Entites;

namespace ElectricCompany.Persistance.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterUserCommand, User>().ReverseMap();
        }
    }
}
