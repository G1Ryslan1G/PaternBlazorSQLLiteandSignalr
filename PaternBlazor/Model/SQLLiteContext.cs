using Microsoft.EntityFrameworkCore;

namespace PaternBlazor.Model
{
    public class SQLLiteContext : DbContext
    {
        public SQLLiteContext(DbContextOptions<SQLLiteContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
