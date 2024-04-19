using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using PabloNobrega.Controllers;
using PabloNobrega.Data;
using PabloNobrega.Models;
using PabloNobrega.Services.Exceptions;
using System.Linq.Expressions;


namespace PabloNobrega.Services
{
	public class VendedorService
	{
		private readonly ApplicationDbContext _db;

		public VendedorService(ApplicationDbContext db)
		{
			_db = db;
		}

		
		public async Task<List<Vendedor>> FindAllAsync()
		{
			return await _db.Vendedor.ToListAsync();
		}

		

		public  async Task InsertAsync(Vendedor obj)
		{

			_db.Vendedor.Add(obj);
			await _db.SaveChangesAsync();
			
		}

		public async Task<Vendedor> FindByIdAsync(int id)
		{
			return await _db.Vendedor.Include(obj => obj.Departamento).FirstOrDefaultAsync(obj => obj.Id == id);
		}

		public async Task RemoveAsync(int id)
		{
			var obj = await _db.Vendedor.FindAsync(id);
			_db.Vendedor.Remove(obj);
			await _db.SaveChangesAsync();
		}

		public async Task UpdateAsync(Vendedor obj)
		{
			bool qualquer = await _db.Vendedor.AnyAsync(x => x.Id == obj.Id);

			if (!qualquer)
			{
				throw new NotFoundException("Id não encontrado");
			}
			try
			{
				_db.Update(obj);
				await _db.SaveChangesAsync();
			}catch(DbConcurrencyException e)
			{
				throw new DbConcurrencyException(e.Message);
			}
		}

		
	}
}
