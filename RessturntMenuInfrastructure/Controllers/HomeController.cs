using Microsoft.AspNetCore.Mvc;
using RestaurantMenuInfrastructure.Models;
using System.Diagnostics;

namespace RestaurantMenuInfrastructure.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Details(string dishName)
        {
          
            ViewBag.Dish = dishName;
            return View();
        }
    }
}