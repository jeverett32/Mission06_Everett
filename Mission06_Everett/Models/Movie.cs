using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Everett.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Range(1888, 2026,ErrorMessage = "Must enter a year between 1888 and 2026")]
        public int Year { get; set; }
        public string? Director { get; set; }
        public string? Rating { get; set; } // Dropdown: G, PG, PG-13, R
        [Required]
        public bool? Edited { get; set; } // Yes/No
        public string? LentTo { get; set; }
        [Required]
        public int CopiedToPlex { get; set; }
        [MaxLength(25)]
        public string? Notes { get; set; }
    }
}