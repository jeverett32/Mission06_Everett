using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Everett.Models
{
    /// <summary>
    /// Represents a movie in Joel Hilton's film collection
    /// </summary>
    public class Movie
    {
        // Primary key for the Movie entity
        [Key]
        [Required]
        public int MovieId { get; set; }

        // Foreign key linking to the Category table
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

        // Navigation property for the related Category
        public Category? Category { get; set; }

        // Movie title - required field
        [Required]
        public string Title { get; set; }

        // Release year - must be between 1888 (first movie) and 2026
        [Required]
        [Range(1888, 2026,ErrorMessage = "Must enter a year between 1888 and 2026")]
        public int Year { get; set; }

        // Director name - optional field
        public string? Director { get; set; }

        // MPAA rating (G, PG, PG-13, R) - optional field
        public string? Rating { get; set; }

        // Indicates if the movie has been edited for content
        [Required]
        public bool? Edited { get; set; }

        // Name of person who borrowed the movie - optional
        public string? LentTo { get; set; }

        // Indicates if movie is copied to Plex media server
        [Required]
        public int CopiedToPlex { get; set; }

        // Additional notes about the movie - limited to 25 characters
        [MaxLength(25)]
        public string? Notes { get; set; }
    }
}