using ElectricCompany.Application.Abstraction.Services;
using ElectricCompany.Domain.DTOS;
using MediatR;

namespace ElectricCompany.Application.Features.UserFeatures.Commands.Register
{
    public sealed class RegisterUserCommadHandler : IRequestHandler<RegisterUserCommand, MessageResponse>
    {
        private readonly IUserService _userService;
        public RegisterUserCommadHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<MessageResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            await _userService.CreateUserAsync(request, cancellationToken);
            return new("Kullanıcı başarıyla oluşturuldu.");
        }
    }
}

