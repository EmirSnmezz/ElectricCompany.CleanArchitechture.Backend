using ElectricCompany.Domain.DTOS;
using MediatR;

namespace ElectricCompany.Application.Features.UserFeatures.Commands.Register
{
    public sealed record RegisterUserCommand(string Username, string Email, string Password, string Fullname) : IRequest<MessageResponse>;
}
