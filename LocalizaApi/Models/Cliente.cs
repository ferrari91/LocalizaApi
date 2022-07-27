using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalizaApi.Models
{
    public class Cliente
    {
        [Key]
        public int Id_Cliente { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? Nome { get; set; }

        [Column(TypeName = "nvarchar(14)")]
        public string? Documento { get; set; }

        [Column(TypeName = "date")]
        public DateTime Data_Nascimento { get; set; }

        [Column(TypeName = "nvarchar(80)")]
        public string? Endereco { get; set; }

        [Column(TypeName = "nvarchar(4)")]
        public string? Numero { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? Bairro { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? Complemento { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? Cidade { get; set; }

        [Column(TypeName = "nvarchar(9)")]
        public string? CEP { get; set; }

        [Column(TypeName = "nvarchar(120)")]
        public string? Senha { get; set; }

        [Column(TypeName = "integer")]
        public int Nivel_Acesso { get; set; }
    }
}
