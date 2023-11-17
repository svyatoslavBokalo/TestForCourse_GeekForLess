using Microsoft.EntityFrameworkCore;
using TestForCourse_Bokalo.Models;

namespace TestForCourse_Bokalo.Data
{
    public class DbContextApplication: DbContext
    {
        public DbSet<Catalog> Catalogs { get; set; }

        public DbContextApplication() { }

        public DbContextApplication(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             optionsBuilder.UseSqlite($"DataSource={Path.GetFullPath("Data")}\\DB_forTest.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catalog>()
                .HasMany(el => el.SubCatalogs)
                .WithOne(el => el.Parent)
                .HasForeignKey(el => el.ParentId);
        }
    }
}
