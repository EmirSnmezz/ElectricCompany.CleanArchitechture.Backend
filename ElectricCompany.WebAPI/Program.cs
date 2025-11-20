using ElectricCompany.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("NpgsqlConnectionString");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString(connectionString);
});

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
