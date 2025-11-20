using ElectricCompany.Domain.DTOS;
using MediatR;

namespace ElectricCompany.Application.Features.UserFeatures.Commands.Register
{
    public sealed class RegisterUserCommadHandler : IRequestHandler<RegisterUserCommand, MessageResponse>
    {
        public async Task<MessageResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {          
            return new("Kullanıcı başarıyla oluşturuldu.");
        }
    }
}

