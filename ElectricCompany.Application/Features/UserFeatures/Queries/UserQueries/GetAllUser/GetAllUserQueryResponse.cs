using ElectricCompany.Domain.DTOS;

namespace ElectricCompany.Application.Features.UserFeatures.Queries.UserQueries.GetAllUser
{
    public sealed record GetAllUserQueryResponse(IList<UserDto> users);
}
