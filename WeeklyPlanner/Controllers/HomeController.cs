using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeeklyPlanner.Models;

namespace WeeklyPlanner.Controllers
{
    

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            bool result = User.IsInRole("ADMINISTRATOR");
            if (result)
            {
                return View();
            }
            else
            {
                return View("~/Views/Home/UserIndex.cshtml");
            }
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult UserCreation()
        {
            return RedirectToAction("Index", "User");
        }

        public IActionResult RoleAttachment()
        {
            return RedirectToAction("Index", "Roles");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
