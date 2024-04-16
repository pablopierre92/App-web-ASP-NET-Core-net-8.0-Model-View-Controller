using Microsoft.AspNetCore.Mvc;
using PabloNobrega.Data;
using PabloNobrega.Models;

namespace PabloNobrega.Controllers
{
    public class EmprestimosController : Controller
    {
        readonly private ApplicationDbContext _db;

        public EmprestimosController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Emprestimo> emprestimo = _db.Emprestimo; // busca no banco todos os dados da tabela Emprestimo
            return View(emprestimo);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Cadastrar (Emprestimo emprestimo)
        {
            if(ModelState.IsValid)
            {
                _db.Emprestimo.Add(emprestimo);
                _db.SaveChanges();

                return RedirectToAction("Index");  //se deu tudo certo volta pra index
            }

            return View();
        }
    }
}
