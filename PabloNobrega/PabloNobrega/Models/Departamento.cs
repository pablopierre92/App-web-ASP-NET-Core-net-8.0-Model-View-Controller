namespace PabloNobrega.Models
{
    public class Departamento
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public Departamento()
        {
        }

        public Departamento(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
