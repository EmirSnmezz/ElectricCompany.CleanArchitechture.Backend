using ElectricCompany.Application.Abstraction.Services;
using ElectricCompany.Application.Behaviors;
using ElectricCompany.Domain.Abstractions;
using ElectricCompany.Infrastructure.JWT;
using ElectricCompany.Persistance.Context;
using ElectricCompany.Persistance.Services;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("NpgsqlConnectionString");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(connectionString);
});

JwtOptions tokenOptions = builder.Configuration.GetSection("JwtOptions").Get<JwtOptions>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).
AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidAlgorithms = new[] { SecurityAlgorithms.HmacSha512 },
        ValidIssuer = tokenOptions.Issuer,
        ValidAudience = tokenOptions.Audience,
        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
    };
});

builder.Services.AddAutoMapper(typeof(ElectricCompany.Persistance.AssemblyReference).Assembly);

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddMediatR(mediatr => mediatr.RegisterServicesFromAssembly(typeof(ElectricCompany.Application.AssemblyReference).Assembly));

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddValidatorsFromAssembly(typeof(ElectricCompany.Application.AssemblyReference).Assembly);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers().AddApplicationPart(typeof(ElectricCompany.Presentation.AssemblyReference).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
}

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(name: "", pattern: "{controller}/{action}");

app.Run();
