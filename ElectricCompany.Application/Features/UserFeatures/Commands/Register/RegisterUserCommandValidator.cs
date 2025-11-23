using FluentValidation;

namespace ElectricCompany.Application.Features.UserFeatures.Commands.Register
{
    public sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(p => p.Username).NotEmpty().WithMessage("Kullanıcı adı alanı boş geçilemez.");
            RuleFor(p => p.Username).NotNull().WithMessage("Kullanıcı adı alanı boş geçilemez.");
            RuleFor(p => p.Email).NotEmpty().WithMessage("E-Mail alanı boş geçilemez.");
            RuleFor(p => p.Email).NotNull().WithMessage("E-Mail alanı boş geçilemez.");
            RuleFor(p => p.Email).EmailAddress().WithMessage("Lütfen geçerli bir E-Mail giriniz.");
            RuleFor(p => p.Password).MinimumLength(8).WithMessage("Şifreniz minimum 8 karakter olmak zorundadır.");
            RuleFor(p => p.Name).NotEmpty().WithMessage("İsim bilgisi boş geçilemez.");
            RuleFor(p => p.Name).NotNull().WithMessage("İsim bilgisi boş geçilemez.");
            RuleFor(p => p.Surname).NotNull().WithMessage("Soyisim bilgisi boş geçilemez.");
        }
    }
}
