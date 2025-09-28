using Microsoft.EntityFrameworkCore;
using Plant.WebApp.Models;

namespace Plant.WebApp.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Planta> Plantas { get; set; }
    }
}
