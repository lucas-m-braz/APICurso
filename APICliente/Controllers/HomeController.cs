using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APICliente.Models;

namespace APICliente.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Vender");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View("Vender");
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View("Vender");
        }

        public IActionResult Privacy()
        {
            return View("Vender");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
