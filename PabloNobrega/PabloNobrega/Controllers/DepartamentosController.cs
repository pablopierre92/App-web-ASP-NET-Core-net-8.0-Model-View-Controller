using Microsoft.AspNetCore.Mvc;

namespace PabloNobrega.Controllers
{
    public class DepartamentosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
