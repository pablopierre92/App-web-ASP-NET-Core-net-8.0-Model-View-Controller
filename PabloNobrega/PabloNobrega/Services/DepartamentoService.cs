using PabloNobrega.Data;
using PabloNobrega.Models;

namespace PabloNobrega.Services
{
	public class DepartamentoService
	{
		private readonly ApplicationDbContext _db;

		public DepartamentoService(ApplicationDbContext db)
		{
			_db = db;
		}

		public List<Departamento> FindAll()
		{
			return _db.Departamento.OrderBy(x=>x.Nome).ToList();
		}
	}
}
