using Microsoft.EntityFrameworkCore;
using CustomerApp.Models;

namespace CustomerApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public virtual DbSet<Customer> Customers { get; set; }
    }
}
