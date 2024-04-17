namespace PabloNobrega.Models
{
    public class Vendas
    {
        public int Id { get; set; }

        public Departamento Departamento { get; set; }

        public Vendedor Vendedor { get; set; }

        public Produto Produto { get; set; }

        public DateTime DataUltimaAtualizacao { get; set; } = DateTime.Now;


    }
}
