using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FriendlyChallenge.Models;
using FriendlyChallenge.Service.Authentication;

namespace FriendlyChallenge.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly OpenLibraryAPI.OpenLibraryClient _openLibraryClient;
        private readonly AuthenticationService _authenticationService;

        public HomeController(ILogger<HomeController> logger, AuthenticationService authenticationService)
        {
            _logger = logger;
            _authenticationService = authenticationService;
        }

        public async Task<IActionResult> Index()
        {
            //var result = _openLibraryClient.GetDeserializedObjectAsync<Dictionary<string, OpenLibraryAPI.Models.Book>>("books?format=json&bibkeys=ISBN:0201558025&jscmd=data").Result;
            //var test = await _authenticationService.Login("test", "test");
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
