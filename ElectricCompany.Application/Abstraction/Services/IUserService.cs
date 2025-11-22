using ElectricCompany.Application.Features.UserFeatures.Commands.Register;
using ElectricCompany.Application.Features.UserFeatures.Queries.UserQueries.GetAllUser;
using ElectricCompany.Domain.DTOS;

namespace ElectricCompany.Application.Abstraction.Services
{
    public interface IUserService
    {
        Task CreateUserAsync(RegisterUserCommand request, CancellationToken cancellationToken);
        Task<List<UserDto>> GetAllUserAsync();
    }
}
