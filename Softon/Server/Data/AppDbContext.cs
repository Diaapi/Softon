using Microsoft.EntityFrameworkCore;
using Softon.Shared;

namespace Softon.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }
        public DbSet<AppModel> apps { get; set; }
    }
}
