
using ElectricCompany.Domain.DTOS;
using ElectricCompany.Domain.Entites;

namespace ElectricCompany.Application.Abstraction.JWT
{
    public interface IJwtPorvider
    {
        AccessToken CreateAccessToken(User user, List<OperationClaims> claims);
    }
}
