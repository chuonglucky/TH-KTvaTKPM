using ASC.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ASC.Solution.Configuration;
using Microsoft.Extensions.Options;
using ASC.Utilities;

namespace ASC.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IOptions<ApplicationSettings> _settings;
        public HomeController(IOptions<ApplicationSettings> settings)
        {
            _settings = settings;
        }
        public HomeController(ILogger<HomeController> logger, IOptions<ApplicationSettings> settings)
        {
            _logger = logger;
            _settings = settings;
        }

        public ActionResult Index()
        {
            //// Set Session
            HttpContext.Session.SetSession("Test", _settings.Value);

            //// Get Session
            var settings = HttpContext.Session.GetSession<ApplicationSettings>("Test");

            //// Usage of IOptions
            ViewBag.Title = settings.ApplicationTitle;

            ////Test fail test case
            //ViewData.Model = "Test";
            //throw new Exception("Login Fail!!!");

            return View();
        }

        /*public IActionResult Index()
        {

            ViewBag.Title = _settings.Value.ApplicationTitle;
            return View();
        }*/

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public  IActionResult Dashboard()
        {
            return View();
        }

    }
}
