using ElectricCompany.Domain.DTOS;
using MediatR;

namespace ElectricCompany.Application.Features.UserFeatures.Commands.Login
{
    public sealed record LoginUserCommand(string userNameOrEmail, string password) : IRequest<MessageResponse>;
}
