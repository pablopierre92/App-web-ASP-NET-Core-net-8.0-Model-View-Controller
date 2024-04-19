using Microsoft.EntityFrameworkCore;
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

		public async Task <List<Departamento>> FindAllAsync()
		{
			return await _db.Departamento.OrderBy(x=>x.Nome).ToListAsync();
		}
	}
}
