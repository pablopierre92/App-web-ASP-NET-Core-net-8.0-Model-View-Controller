using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using PabloNobrega.Models;

namespace PabloNobrega.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Departamento> Departamento { get; set; }
        
        public DbSet<Emprestimo> Emprestimo { get; set; }

        public DbSet<Vendedor> Vendedor { get; set; }
    }
}
