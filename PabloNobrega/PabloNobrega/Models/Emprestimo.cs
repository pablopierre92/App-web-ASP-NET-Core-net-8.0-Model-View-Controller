using System.ComponentModel.DataAnnotations;

namespace PabloNobrega.Models
{
    public class Emprestimo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do Recebedor!")]
        public string Recebedor { get; set; }

		[Required(ErrorMessage = "Digite o nome do Fornecedor!")]
		public string Fornecedor { get; set; }

		[Required(ErrorMessage = "Digite o nome do Equipamento!")]
		public string EquipamentoEmprestado { get; set; }

        public DateTime DataUltimaAtualizacao { get; set; } = DateTime.Now;
    }
}
