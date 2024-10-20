using Microsoft.EntityFrameworkCore;
using BulkyWeb.Models;
namespace BulkyWeb.data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        //creating Categories table

        public DbSet<Category> Categories { get; set; }

        //inserting initial data

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 0 },
                new Category { Id = 2, Name = "Romance", DisplayOrder = 1 },
                new Category { Id = 3, Name = "Comedy", DisplayOrder = 3 }
                );
        }
    }
}
