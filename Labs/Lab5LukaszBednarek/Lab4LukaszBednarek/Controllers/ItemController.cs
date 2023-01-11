using Microsoft.AspNetCore.Mvc;

namespace Lab4LukaszBednarek.Controllers
{
    public class ItemController : Controller
    {
        /*
        public IActionResult Index()
        {
            return View();
        }
        */

        public IActionResult List(string Category, string ID = "All")
        {
            //return Content("Item Controller, List action, ID: " + ID);
            return Content("Item Controller, List action Category " + Category + ", Page " + ID);
        }

        public IActionResult Detail(string ID)
        {
            return Content("Item Controller, Detail action, ID: " + ID);
        }
    }
}
