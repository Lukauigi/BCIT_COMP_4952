using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Lab4LukaszBednarek.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace Lab4LukaszBednarek.Controllers
{
    //[Authorize]
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

            //return Content("This is the Home Controller, the Index() method");
            return View();
        }

        public IActionResult Movie()
        {
            var movies = MyContext.Movies.Include(m => m.Category).OrderBy(m => m.Title).ToList();
            return View(movies);
        }

        [Route("About")]
        public IActionResult About()
        {
            return Content("About us");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public IActionResult Protected()
        {
            return View();
        }

        public IActionResult Authenticate()
        {
            var accessClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "John"),
                new Claim(ClaimTypes.Email, "John.Smith@gmail.com"),
                new Claim("Secret code", "TechPro 2022")
            };

            var googleClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "John T Smith"),
                new Claim(ClaimTypes.Email, "John.Smith@gmail.com"),
                new Claim(ClaimTypes.MobilePhone, "778-788-9090")
            };

            var accessIdentity = new ClaimsIdentity(accessClaims, "Access Identity");
            var googleIdentity = new ClaimsIdentity(googleClaims, "Google Identity");

            var userPrinciple = new ClaimsPrincipal(new[] { accessIdentity, googleIdentity });

            HttpContext.SignInAsync(userPrinciple);

            return RedirectToAction("Movie");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
