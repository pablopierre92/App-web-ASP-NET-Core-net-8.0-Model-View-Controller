using Microsoft.AspNetCore.Mvc;
using PabloNobrega.Models;
using System.Diagnostics;

namespace PabloNobrega.Controllers
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

		public IActionResult Sobre()
		{
			ViewData["Messagem"] = "Testando aplica��o em vers�o mais recente";
			ViewData["Email"] = "pablopierre@outlook.com";
			ViewData["Autor"] = "Pablo Pierre da N�brega";

			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
