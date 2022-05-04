using Microsoft.EntityFrameworkCore;
using Store.Data.Models;

namespace Store.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)  
        {

        }

        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }

    }
}
