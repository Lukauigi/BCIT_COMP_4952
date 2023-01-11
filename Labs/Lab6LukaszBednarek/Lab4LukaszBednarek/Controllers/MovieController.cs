using Lab4LukaszBednarek.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Lab4LukaszBednarek.Controllers
{
    public class MovieController : Controller
    {
        private MovieDbContext MyContext { get; set; }

        public MovieController(MovieDbContext context)
        {
            //_logger = logger;
            MyContext = context;
        }

        public IActionResult Index()
        {
            //var movies = MyContext.Movies.Include(m => m.Category).OrderBy(m => m.Title).ToList();
            //return View(movies);

            //return Content("This is the Home Controller, the Index() method");
            return View();
        }

        public IActionResult Movies()
        {
            //var movies = MyContext.Movies.Include(m => m.Category).OrderBy(m => m.Title).ToList();
            //return View(movies);
            return View();
        }

        [Route("About")]
        public IActionResult About()
        {
            return Content("About us");
        }

        [Route("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        //[Authorize]
        public IActionResult Protected()
        {
            return View();
        }

        public IActionResult Authenticate()
        {
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
