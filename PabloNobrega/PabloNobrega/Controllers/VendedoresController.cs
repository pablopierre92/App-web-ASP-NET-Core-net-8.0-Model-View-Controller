using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using PabloNobrega.Data;
using PabloNobrega.Migrations;
using PabloNobrega.Models;
using PabloNobrega.Models.ViewModels;
using PabloNobrega.Services;
using PabloNobrega.Services.Exceptions;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;



namespace PabloNobrega.Controllers
{
	public class VendedoresController : Controller
	{
		private readonly VendedorService _vendedorService;
		private readonly DepartamentoService _departamentoService;
		

		public VendedoresController(VendedorService vendedorService, DepartamentoService departamentoService)
		{
			_vendedorService = vendedorService;
			_departamentoService = departamentoService;
			
		}

		/*private readonly ApplicationDbContext _db;
		
		public VendedoresController(ApplicationDbContext db)
		{
			_db = db;
		}

		public IActionResult Index()
		{
			IEnumerable<Vendedor> vendedor = _db.Vendedor;
			return View(vendedor);
		}*/

		public async Task<IActionResult> Index()
		{
			var list = await _vendedorService.FindAllAsync();
			return View(list);

			
		}

		[HttpGet]
		public async Task<IActionResult> Cadastrar()
		{
			var departamentos = await _departamentoService.FindAllAsync(); // busca no banco todos os departamentos
			var viewModel = new VendedorFormViewModel { Departamentos = departamentos };
			return View(viewModel);
		}

		[HttpGet]
		public async Task <IActionResult> Editar(int? id)
		{
			if (id == null || id == 0)
			{
				return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
			}

			var obj = await _vendedorService.FindByIdAsync(id.Value);

			if (obj == null)
			{
				return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
			}

			List<Departamento> departamentos = await _departamentoService.FindAllAsync();
			VendedorFormViewModel viewModel = new VendedorFormViewModel { Vendedor = obj, Departamentos = departamentos };
			return View(viewModel);

		}

		[HttpGet]
		public async Task<IActionResult> Excluir(int? id)
		{
			if (id == null || id == 0)
			{
				return RedirectToAction(nameof(Error), new { message = "Id não foi fornecido" });
			}

			var obj = await _vendedorService.FindByIdAsync (id.Value);

			if (obj == null)
			{
				return RedirectToAction(nameof(Error), new { message = "Id não foi encontrado" });
			}


			return View(obj);

		}

		[HttpPost]
		[ValidateAntiForgeryToken] //proteção
		public async Task<IActionResult> Cadastrar(Vendedor vendedor)
		{

			if (!ModelState.IsValid)
			{

				var departamentos = await _departamentoService.FindAllAsync();
				var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departamentos };
				return View(viewModel);
												
			}
			await _vendedorService.InsertAsync(vendedor);
				return RedirectToAction(nameof(Index), TempData["MensagemSucesso"] = "Cadastro realizado com sucesso" );
			//

			
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Editar(int id, Vendedor vendedor)
		{
			if (!ModelState.IsValid)
			{

				var departamentos = await _departamentoService.FindAllAsync();
				var viewModel = new VendedorFormViewModel {  Vendedor = vendedor, Departamentos = departamentos };
				return View(viewModel);

			}

			if (id != vendedor.Id)
			{
				return RedirectToAction(nameof(Error), new { message = "Id incompatível" });
			}
			try
			{
				await _vendedorService.UpdateAsync(vendedor);
				return RedirectToAction(nameof(Index), TempData["MensagemSucesso"] = "Edição realizada com sucesso");
			}
			catch (ApplicationException e)
			{
				return RedirectToAction(nameof(Error), new { message = e.Message });
			}

			
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task <IActionResult> Excluir(int id)
		{
			try
			{
				await _vendedorService.RemoveAsync(id);
				return RedirectToAction(nameof(Index), TempData["MensagemSucesso"] = "Remoção realizada com sucesso" );
			}
			catch (IntegrityException e)
			{
				return RedirectToAction(nameof(Error), new { message = e.Message });
			}
		}
	}
}

