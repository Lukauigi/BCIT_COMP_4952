using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Lab4LukaszBednarek.Models
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options): base(options) {  }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder myModelBuilder)
        {
            myModelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    MovieId = 1,
                    Title = "1917",
                    Year = 2019,
                    Rating = 9,
                    CategoryId = "A"
                },
                new Movie
                {
                    MovieId = 2,
                    Title = "Interstellar",
                    Year = 2014,
                    Rating = 8,
                    CategoryId = "S"
                },
                new Movie
                {
                    MovieId = 3,
                    Title = "Gladiator",
                    Year = 2000,
                    Rating = 10,
                    CategoryId = "D"
                }
            );

            myModelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = "A",
                    Name = "Action"
                },
                new Category
                {
                    CategoryId = "C",
                    Name = "Comedy"
                },
                new Category
                {
                    CategoryId = "D",
                    Name = "Drama"
                },
                new Category
                {
                    CategoryId = "H",
                    Name = "Horror"
                },
                new Category
                {
                    CategoryId = "K",
                    Name = "Kids"
                },
                new Category
                {
                    CategoryId = "S",
                    Name = "SciFi"
                }
            );
        }
    }
}
