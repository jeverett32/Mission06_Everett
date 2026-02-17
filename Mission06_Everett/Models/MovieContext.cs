using Microsoft.EntityFrameworkCore;
using Mission06_Everett.Models;

namespace Mission06_Everett.Models
{
    /// <summary>
    /// Database context for managing movie collection data
    /// </summary>
    public class MovieContext : DbContext
    {
        // Constructor that passes options to the base DbContext
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) { }

        // DbSet for Movie entities - represents the Movies table
        public DbSet<Movie> Movies { get; set; }

        // DbSet for Category entities - represents the Categories table
        public DbSet<Category> Categories { get; set; }
    }
}