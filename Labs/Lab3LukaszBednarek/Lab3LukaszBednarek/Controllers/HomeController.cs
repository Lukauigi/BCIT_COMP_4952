using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Lab3LukaszBednarek.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

/// <summary>
/// Controllers of client requests of the web app.
/// Author: Lukasz Bednarek
/// Date: September 24, 2022
/// </summary>
namespace Lab3LukaszBednarek.Controllers
{
    /// <summary>
    /// The controller client requests on the index web page.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Responds to client GET request with the index web page.
        /// </summary>
        /// <returns> Initial render of view. </returns>
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.myCalculatedValue = 0;
            return View();
        }

        /// <summary>
        /// Responds to client POST request with an updated index web page.
        /// </summary>
        /// <param name="model"> A data model. </param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Index(ValueCalculatorModel model)
        {
            if (ModelState.IsValid)
                ViewBag.myCalculatedValue = model.CalculateValue();
            else
                ViewBag.myCalculatedValue = 0;
            return View();
        }

        [ActionName("Privacy")]
        public IActionResult Privacy()
        {
            ViewBag.PrivacyMessage = "We protect our customers' privacy!";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
