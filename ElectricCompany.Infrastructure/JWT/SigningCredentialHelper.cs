using Microsoft.IdentityModel.Tokens;

namespace ElectricCompany.Infrastructure.JWT
{
    public static class SigningCredentialHelper
    {
        public static SigningCredentials CreateSigningCredential(SecurityKey securityKey)
        {
           return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
        }
    }
}
