using ControleDeBar.WebApp.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ControleDeBar.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
