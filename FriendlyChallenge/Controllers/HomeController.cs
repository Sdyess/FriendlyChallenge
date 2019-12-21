using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FriendlyChallenge.Models;

namespace FriendlyChallenge.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly OpenLibraryAPI.OpenLibraryClient _openLibraryClient;

        public HomeController(ILogger<HomeController> logger, OpenLibraryAPI.OpenLibraryClient openLibraryClient)
        {
            _logger = logger;
            _openLibraryClient = openLibraryClient;
        }

        public IActionResult Index()
        {
            //var result = _openLibraryClient.GetDeserializedObjectAsync<Dictionary<string, OpenLibraryAPI.Models.Book>>("books?format=json&bibkeys=ISBN:0201558025&jscmd=data").Result;
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
