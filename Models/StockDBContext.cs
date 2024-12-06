using Microsoft.EntityFrameworkCore;
namespace StockReader.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<RegisteredUser> RegisteredUsers { get; set; }
    }
}