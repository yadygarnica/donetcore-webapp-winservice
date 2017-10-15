using AspNetCoreApp.Core.Processors;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreApp.Service.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            this.ViewData["Message"] = NetStandardProcessor.AboutText;

            return View();
        }

        public IActionResult Contact()
        {
            this.ViewData["Message"] = NetStandardProcessor.ContactTest;

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
