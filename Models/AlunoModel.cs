using ProjetoTurma.Enum;
using System.ComponentModel.DataAnnotations;

namespace ProjetoTurma.Models
{
    public class AlunoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o Email")]
        [EmailAddress(ErrorMessage = "Digiet o email corretamente")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a Escola")]
        public string Escola { get; set; }

        [Required(ErrorMessage = "Informe o Curso")]
        public string Curso { get; set; }

        [Required(ErrorMessage = "Informe a Situação")]
        public SituacaoEnum Situacao { get; set; }
    }
}
