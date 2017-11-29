using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using lab05.Models;

namespace lab05.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [ActionName("Sobre")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View("About");
        }

        [ActionName("Contactos")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View("Contact");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
