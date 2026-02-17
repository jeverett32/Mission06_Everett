using Microsoft.EntityFrameworkCore;
using Mission06_Everett.Models;

namespace Mission06_Everett.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}