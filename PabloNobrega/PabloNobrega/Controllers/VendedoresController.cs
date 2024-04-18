using Microsoft.AspNetCore.Mvc;
using PabloNobrega.Data;
using PabloNobrega.Migrations;
using PabloNobrega.Models;

namespace PabloNobrega.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly ApplicationDbContext _db;

        public VendedoresController(ApplicationDbContext db)
        {
            _db = db;
        }
        

        public IActionResult Index()
        {
            IEnumerable<Vendedor> vendedor = _db.Vendedor;
            return View(vendedor);
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

            Vendedor vendedor = _db.Vendedor.FirstOrDefault(x => x.Id == id);

            if (vendedor == null)
            {
                return NotFound();
            }


            return View(vendedor);

        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Vendedor vendedor = _db.Vendedor.FirstOrDefault(x => x.Id == id);

            if (vendedor == null)
            {
                return NotFound();
            }


            return View(vendedor);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(Vendedor vendedor)
        {

            if (ModelState.IsValid)
            {

                // Verifica se já existe um vendedor com o mesmo nome
                var vendedorExistente = _db.Vendedor.FirstOrDefault(x => x.Nome == vendedor.Nome);

                if (vendedorExistente != null)
                {
                    ModelState.AddModelError("Nome", "Já existe um Vendedor com esse nome.");
                    return View(vendedor); // Retorna para a view com o vendedor e uma mensagem de erro
                }

                _db.Vendedor.Add(vendedor);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Cadastro realizado com sucesso";

                return RedirectToAction("Index");  //se deu tudo certo volta pra index
            }

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Vendedor vendedor)
        {
            if (ModelState.IsValid)
            {

                // Verifica se já existe um vendedor com o mesmo nome
                var vendedorExistente = _db.Departamento.FirstOrDefault(x => x.Nome == vendedor.Nome);

                if (vendedorExistente != null)
                {
                    ModelState.AddModelError("Nome", "Já existe um departamento com esse nome.");
                    return View(vendedor); // Retorna para a view com o vendedor e uma mensagem de erro
                }

                _db.Vendedor.Update(vendedor);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Edição realizada com sucesso";

                return RedirectToAction("Index");
            }

            TempData["MensagemErro"] = "Algum erro ocorreu ao realizar edição";

            return View(vendedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Excluir(Vendedor vendedor)
        {
            if (vendedor == null)
            {
                return NotFound();
            }

            _db.Vendedor.Remove(vendedor);
            _db.SaveChanges();

            TempData["MensagemSucesso"] = "Exclusão realizada com sucesso";

            return RedirectToAction("Index");
        }
    }
}
  
