using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TsukuyomiMuseum.Models;

namespace TsukuyomiMuseum.Database
{
    public class MuseumContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<Supply> Supplies { get; set; }

        public DbSet<Publication> Publications { get; set; }

        public DbSet<Event> Events { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=TsukuyomiMuseumDb;" +
            "Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
