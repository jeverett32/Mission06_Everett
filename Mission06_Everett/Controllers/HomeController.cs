using Microsoft.AspNetCore.Mvc;
using Mission06_Everett.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Mission06_Everett.Controllers
{
    /// <summary>
    /// Main controller handling movie collection operations
    /// </summary>
    public class HomeController : Controller
    {
        // Database context for accessing movie data
        private MovieContext _context;

        // Constructor with dependency injection of MovieContext
        public HomeController(MovieContext temp)
        {
            _context = temp;
        }

        // Displays the home page
        public IActionResult Index() => View();

        // Displays the "Get to Know Joel" page
        public IActionResult GetToKnowJoel() => View();

        /// <summary>
        /// GET: Displays the form to add a new movie
        /// </summary>
        [HttpGet]
        public IActionResult EnterMovie()
        {
            // Load categories for dropdown, sorted alphabetically
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View();
        }

        /// <summary>
        /// POST: Saves a new movie to the database
        /// </summary>
        [HttpPost]
        public IActionResult EnterMovie(Movie response)
        {
            // Add the new movie to the database
            _context.Movies.Add(response);
            _context.SaveChanges();

            // Show confirmation page
            return View("Confirmation");
        }

        /// <summary>
        /// Displays a list of all movies in the collection
        /// </summary>
        public IActionResult MovieList()
        {
            // Retrieve all movies sorted by title
            var movies = _context.Movies
                .OrderBy(x => x.Title).ToList();

            return View(movies);
        }

        /// <summary>
        /// GET: Loads a movie for editing
        /// </summary>
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Find the specific movie by ID
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            // Load categories for dropdown, sorted alphabetically
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            // Reuse the EnterMovie view for editing
            return View("EnterMovie", recordToEdit);
        }

        /// <summary>
        /// POST: Saves updated movie information
        /// </summary>
        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            // Update the movie record in the database
            _context.Update(updatedInfo);
            _context.SaveChanges();

            // Redirect back to the movie list
            return RedirectToAction("MovieList");
        }

        /// <summary>
        /// GET: Displays confirmation page before deleting a movie
        /// </summary>
        [HttpGet]
        public IActionResult Delete(int id)
        {
            // Find the specific movie to delete
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        /// <summary>
        /// POST: Permanently deletes a movie from the collection
        /// </summary>
        [HttpPost]
        public IActionResult Delete(Movie application)
        {
            // Remove the movie from the database
            _context.Movies.Remove(application);
            _context.SaveChanges();

            // Redirect back to the movie list
            return RedirectToAction("MovieList");
        }
    }
}