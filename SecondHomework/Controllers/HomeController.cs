using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SecondHomework.Models;

namespace SecondHomework.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "this is implementation of second homework ";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Ryzhckin Artem";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
