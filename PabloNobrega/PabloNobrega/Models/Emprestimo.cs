namespace PabloNobrega.Models
{
    public class Emprestimo
    {
        public int Id { get; set; }

        public string Recebedor { get; set; }

        public string Fornecedor { get; set; }

        public string EquipamentoEmprestado { get; set; }

        public DateTime DataUltimaAtualizacao { get; set; } = DateTime.Now;
    }
}
