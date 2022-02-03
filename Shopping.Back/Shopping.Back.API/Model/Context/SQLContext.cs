using Microsoft.EntityFrameworkCore;

namespace Shopping.API.Model.Context
{
    public class SQLContext : DbContext
    {
        public SQLContext() { }

        public SQLContext(DbContextOptions<SQLContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
