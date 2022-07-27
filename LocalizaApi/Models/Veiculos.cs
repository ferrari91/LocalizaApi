using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalizaApi.Models
{
    public class Veiculos
    {
        [Key]
        public int Id_Veiculo { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string? Placa { get; set; }

        [ForeignKey("Codigo_Marca")]
        public Veiculo_Modelo? Marca { get; set; }
        public int Codigo_Marca { get; set; }

        [Column(TypeName = "nvarchar(4)")]
        public string? Ano { get; set; }

        [Column(TypeName = "numeric(15,2)")]
        public double Valor { get; set; }

        [Column(TypeName = "nvarchar(35)")]
        public string? Combustivel { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? Limite_PortaMala { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? Categoria { get; set; }
    }

    public class Veiculo_Modelo
    {
        [Key]
        public int Id_Marca { get; set; }

        [Column(TypeName = "nvarchar(80)")]
        public string? Marca { get; set; }

        [Column(TypeName = "nvarchar(80)")]
        public string? Modelo { get; set; }
    }
}
