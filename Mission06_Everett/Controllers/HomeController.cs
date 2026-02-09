using Microsoft.AspNetCore.Mvc;
using Mission06_Everett.Models;

namespace Mission06_Everett.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _context;

        public HomeController(MovieContext temp)
        {
            _context = temp;
        }

        public IActionResult Index() => View();

        public IActionResult GetToKnowJoel() => View();

        [HttpGet]
        public IActionResult EnterMovie() => View();

        [HttpPost]
        public IActionResult EnterMovie(Movie response)
        {
            _context.Movies.Add(response);
            _context.SaveChanges();
            return View("Confirmation");
        }
    }
}