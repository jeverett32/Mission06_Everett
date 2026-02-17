using System.ComponentModel.DataAnnotations;
namespace Mission06_Everett.Models
{
    /// <summary>
    /// Represents a movie category/genre
    /// </summary>
    public class Category
    {
        // Primary key for the Category entity
        [Key]
        public int CategoryId { get; set; }

        // Name of the category (e.g., Action, Comedy, Drama)
        public string CategoryName { get; set; }
    }
}
