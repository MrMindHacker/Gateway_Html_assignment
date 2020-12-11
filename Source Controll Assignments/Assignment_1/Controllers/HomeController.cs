using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using source_control_assignment1.Models;

namespace source_control_assignment1.Controllers
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

        [Route("user")]
        public IActionResult UserInfo(){
            return View();
        }

        [Route("user")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UserInfo(UserInfoViewModel userModel){
            if (ModelState.IsValid)
            {
                ModelState.Clear();
            }
            return View();
        }
    }
}
