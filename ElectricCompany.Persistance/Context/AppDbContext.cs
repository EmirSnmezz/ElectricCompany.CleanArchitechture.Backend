using ElectricCompany.Domain.Abstractions;
using ElectricCompany.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ElectricCompany.Persistance.Context
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options): base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<Entity>();

            foreach(var entry in entries)
            {
                if(entry.State == EntityState.Added)
                {
                    entry.Property(p => p.CreatedDate).CurrentValue = DateTime.UtcNow;
                }

                else if(entry.State == EntityState.Modified)
                {
                    entry.Property(p => p.UpdatedDate).CurrentValue = DateTime.UtcNow;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
