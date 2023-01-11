using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Lab4LukaszBednarek.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Lab4LukaszBednarek.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private MovieDbContext MyContext {  get; set; }

        public HomeController(MovieDbContext context)
        {
            //_logger = logger;
            MyContext = context;
        }

        public IActionResult Index()
        {
            //var movies = MyContext.Movies.Include(m => m.Category).OrderBy(m => m.Title).ToList();
            //return View(movies);

            return Content("This is the Home Controller, the Index() method");
        }

        public IActionResult About()
        {
            return Content("About us");
        }

        [Route("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
