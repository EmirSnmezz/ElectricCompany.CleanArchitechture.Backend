using ElectricCompany.Application.Abstraction.Services;
using ElectricCompany.Persistance.Context;
using ElectricCompany.Persistance.Services;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("NpgsqlConnectionString");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(connectionString);
});

builder.Services.AddAutoMapper(typeof(ElectricCompany.Persistance.AssemblyReference).Assembly);

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddMediatR(mediatr => mediatr.RegisterServicesFromAssembly(typeof(ElectricCompany.Application.AssemblyReference).Assembly));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers().AddApplicationPart(typeof(ElectricCompany.Presentation.AssemblyReference).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
}

app.UseRouting();

app.MapControllerRoute(name: "", pattern: "{controller}/{action}");

app.Run();
