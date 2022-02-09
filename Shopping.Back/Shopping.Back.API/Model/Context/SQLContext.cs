using Microsoft.EntityFrameworkCore;
using Shopping.API.Model.Base;

namespace Shopping.API.Model.Context
{
    public class SQLContext : DbContext
    {
        public SQLContext() { }

        public SQLContext(DbContextOptions<SQLContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        public override int SaveChanges()
        {
            DateTime now = DateTime.UtcNow;

            foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Property(nameof(BaseEntity.CreatedAt)).CurrentValue == null)
                        entry.Property(nameof(BaseEntity.CreatedAt)).CurrentValue = now;
                }

                entry.Property(nameof(BaseEntity.UpdatedAt)).CurrentValue = now;
            }

            return base.SaveChanges();
        }
    }
}
