using ElectricCompany.Domain.DTOS;
using MediatR;

namespace ElectricCompany.Application.Features.UserFeatures.Commands.Login
{
    public sealed class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, MessageResponse>
    {
        public async Task<MessageResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            return new("Kullanıcı girişi başarılı");
        }
    }
}
