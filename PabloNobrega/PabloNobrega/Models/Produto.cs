namespace PabloNobrega.Models
{
    public class Produto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public double Preço { get; set; }

        public int Quantidade { get; set; }

        public Departamento Departamento { get; set; }
    }
}
