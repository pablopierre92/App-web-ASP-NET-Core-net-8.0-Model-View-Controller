using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace PabloNobrega.Models
{
    public class Vendedor
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
		public DateTime DataNascimento { get; set; }

        public double Salario { get; set; }

        public Departamento Departamento { get; set; }

        public int DepartamentoId { get; set; }

        public Vendedor() { }

        public Vendedor(int id, string nome, string email, DateTime dataNascimento, double salario, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            Salario = salario;
            Departamento = departamento;
        }

		public ICollection<Departamento> Departamentos { get; set; }
	}
	/*
			public void AddVendas(RegistroVendas rv)
			{
				Vendas.Add(rv);
			}

			public void RemoveVendas(RegistroVendas rv) {
				Vendas.Remove(rv);
			}

			public double TotalVendas(DateTime inicial, DateTime final)
			{
				return Vendas.Where(rv => rv.Date >= inicial && rv.Date <= final).Sum(rv => rv.Amount);
			}

			*/
}

