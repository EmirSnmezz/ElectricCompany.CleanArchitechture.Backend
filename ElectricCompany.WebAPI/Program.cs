using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
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
