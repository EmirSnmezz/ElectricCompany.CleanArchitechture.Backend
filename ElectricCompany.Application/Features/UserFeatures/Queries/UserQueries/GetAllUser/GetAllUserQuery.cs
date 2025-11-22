using MediatR;

namespace ElectricCompany.Application.Features.UserFeatures.Queries.UserQueries.GetAllUser
{
    public sealed record GetAllUserQuery() : IRequest<GetAllUserQueryResponse>;
    
}
