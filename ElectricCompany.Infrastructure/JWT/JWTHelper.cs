using ElectricCompany.Application.Abstraction.JWT;
using ElectricCompany.Domain.Abstractions;
using ElectricCompany.Domain.DTOS;
using ElectricCompany.Domain.Entites;
using ElectricCompany.Infrastructure.JWT.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ElectricCompany.Infrastructure.JWT
{
    public class JWTHelper : IJwtPorvider
    {
        public IConfiguration Configuration { get; }
        private readonly JwtOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public JWTHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("JwtOptions").Get<JwtOptions>();
        }

        public AccessToken CreateAccessToken(User user, List<OperationClaims> claims)
        {
            _accessTokenExpiration = DateTime.UtcNow.AddMinutes(_tokenOptions.AccessTokenExpiration);       
            SecurityKey securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            SigningCredentials signingCredentials = SigningCredentialHelper.CreateSigningCredential(securityKey);
            JwtSecurityToken jwtToken = CreateJwtSecurityToken(user, _tokenOptions, claims, signingCredentials);
            JwtSecurityTokenHandler jwtHandler = new JwtSecurityTokenHandler();

            return new AccessToken()
            {
                Expiration = _accessTokenExpiration,
                Token = jwtHandler.WriteToken(jwtToken)
            };
        }

        public JwtSecurityToken CreateJwtSecurityToken(User user, JwtOptions jwtOptions, List<OperationClaims> claims, SigningCredentials signingCredential)
        {
            JwtSecurityToken jwtToken =new JwtSecurityToken
                (
                issuer: jwtOptions.Issuer,
                audience: jwtOptions.Audience,
                expires: _accessTokenExpiration,
                signingCredentials: signingCredential,
                notBefore: DateTime.UtcNow,
                claims: SetClaims(user, claims)
                );

            return jwtToken;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaims> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.Name} {user.Surname}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
    }
}
