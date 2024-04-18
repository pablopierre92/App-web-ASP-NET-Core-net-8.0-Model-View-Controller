using PabloNobrega.Data;

namespace PabloNobrega.Services
{
	public class VendedorServico
	{
		private readonly ApplicationDbContext _db;

		public VendedorServico(ApplicationDbContext db)
		{
			_db = db;
		}


	}
}
