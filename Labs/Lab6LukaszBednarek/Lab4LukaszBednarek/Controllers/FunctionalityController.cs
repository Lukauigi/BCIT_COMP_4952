using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Lab4LukaszBednarek.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Lab4LukaszBednarek.Controllers
{
    [AllowAnonymous]
    public class FunctionalityController : Controller
    {
        private MovieDbContext MyContext { get; set; }

        public FunctionalityController(MovieDbContext context)
        {
            MyContext = context;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Categories = MyContext.Categories.OrderBy(c => c.Name).ToList();
            return View("Edit", new Movie());
        }

        //[Route("Functionality/{id?}")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Categories = MyContext.Categories.OrderBy(c => c.Name).ToList();
            var movie = MyContext.Movies.Find(id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                if (movie.MovieId == 0)
                    MyContext.Movies.Add(movie);
                else
                    MyContext.Movies.Update(movie);
                MyContext.SaveChanges();
                return RedirectToAction("Movie", "Home");
            } 
            else
            {
                ViewBag.Action = (movie.MovieId == 0) ? "Add" : "Edit";
                return View(movie);
            }
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = MyContext.Movies.Find(id);
            return View(movie);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            MyContext.Movies.Remove(movie);
            MyContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
