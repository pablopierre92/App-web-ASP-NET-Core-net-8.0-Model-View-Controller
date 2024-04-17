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

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Emprestimo emprestimo = _db.Emprestimo.FirstOrDefault(x => x.Id == id);

            if (emprestimo == null)
            {
                return NotFound();
            }


            return View(emprestimo);
            
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Emprestimo emprestimo = _db.Emprestimo.FirstOrDefault(x => x.Id == id);

            if (emprestimo == null)
            {
                return NotFound();
            }


            return View(emprestimo);

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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {
                _db.Emprestimo.Update(emprestimo);
                _db.SaveChanges();

                return RedirectToAction("Index");  
            }

            return View(emprestimo);
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Excluir(Emprestimo emprestimo)
		{
			if (emprestimo == null)
			{
                return NotFound();
			}

            _db.Emprestimo.Remove(emprestimo);
            _db.SaveChanges();

            return RedirectToAction("Index");
		}
	}
}
