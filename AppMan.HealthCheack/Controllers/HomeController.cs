using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppMan.HealthCheack.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

namespace AppMan.HealthCheack.Controllers
{
    public class HomeController : Controller
    {
        private ILoggerFactory _loggerFactory;

        public HomeController(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public IActionResult Index()
        {
            var logger = _loggerFactory.CreateLogger("MyLogger");
            logger.LogInformation("Calling the Index action");
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
    }
}