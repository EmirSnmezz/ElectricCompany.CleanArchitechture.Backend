using Microsoft.EntityFrameworkCore;

namespace ElectricCompany.Persistance.Context
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options): base(options) {}
    }
}
