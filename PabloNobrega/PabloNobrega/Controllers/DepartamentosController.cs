using Microsoft.AspNetCore.Mvc;
using PabloNobrega.Data;
using PabloNobrega.Models;

namespace PabloNobrega.Controllers
{
    public class DepartamentosController : Controller
    {

        private readonly ApplicationDbContext _db;

        public DepartamentosController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<Departamento> departamento = _db.Departamento;
            return View(departamento);
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

            Departamento departamento = _db.Departamento.FirstOrDefault(x => x.Id == id);

            if (departamento == null)
            {
                return NotFound();
            }


            return View(departamento);

        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Departamento departamento = _db.Departamento.FirstOrDefault(x => x.Id == id);

            if (departamento == null)
            {
                return NotFound();
            }


            return View(departamento);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(Departamento departamento)
        {
            
            if (ModelState.IsValid)
            {

                // Verifica se já existe um departamento com o mesmo nome
                var departamentoExistente = _db.Departamento.FirstOrDefault(x => x.Nome == departamento.Nome);

                if (departamentoExistente != null)
                {
                    ModelState.AddModelError("Nome", "Já existe um departamento com esse nome.");
                    return View(departamento); // Retorna para a view com o departamento e uma mensagem de erro
                }

                _db.Departamento.Add(departamento);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Cadastro realizado com sucesso";

                return RedirectToAction("Index");  //se deu tudo certo volta pra index
            }

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Departamento departamento)
        {
            if (ModelState.IsValid)
            {

                // Verifica se já existe um departamento com o mesmo nome
                var departamentoExistente = _db.Departamento.FirstOrDefault(x => x.Nome == departamento.Nome);

                if (departamentoExistente != null)
                {
                    ModelState.AddModelError("Nome", "Já existe um departamento com esse nome.");
                    return View(departamento); // Retorna para a view com o departamento e uma mensagem de erro
                }

                _db.Departamento.Update(departamento);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Edição realizada com sucesso";

                return RedirectToAction("Index");
            }

            TempData["MensagemErro"] = "Algum erro ocorreu ao realizar edição";

            return View(departamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Excluir(Departamento departamento)
        {
            if (departamento == null)
            {
                return NotFound();
            }

            _db.Departamento.Remove(departamento);
            _db.SaveChanges();

            TempData["MensagemSucesso"] = "Exclusão realizada com sucesso";

            return RedirectToAction("Index");
        }
    }
}
    

