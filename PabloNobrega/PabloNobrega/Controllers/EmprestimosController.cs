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

        public IActionResult Cadastrar()
        {
            return View();
        }
    }
}
