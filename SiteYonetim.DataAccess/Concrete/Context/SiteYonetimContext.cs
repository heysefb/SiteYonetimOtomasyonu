using Microsoft.EntityFrameworkCore;
using SiteYonetim.Entity.Concrete;

namespace SiteYonetim.DataAccess.Concrete.Context
{
    public class SiteYonetimContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=SiteYonetimDb;User Id=sa;Password=Guc1uB!rSifre123;TrustServerCertificate=True");
        }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Dues> Dues { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}