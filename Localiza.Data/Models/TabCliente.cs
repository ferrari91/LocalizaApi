// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Localiza.Data.Models
{
    [Table("tab_Cliente")]
    public partial class TabCliente
    {
        [Key]
        [Column("Id_Cliente")]
        public int IdCliente { get; set; }
        [StringLength(100)]
        public string Nome { get; set; }
        [StringLength(14)]
        public string Documento { get; set; }
        [Column("Data_Nascimento", TypeName = "date")]
        public DateTime DataNascimento { get; set; }
        [StringLength(80)]
        public string Endereco { get; set; }
        [StringLength(4)]
        public string Numero { get; set; }
        [StringLength(50)]
        public string Bairro { get; set; }
        [StringLength(50)]
        public string Complemento { get; set; }
        [StringLength(50)]
        public string Cidade { get; set; }
        [Column("CEP")]
        [StringLength(9)]
        public string Cep { get; set; }
        [StringLength(120)]
        public string Senha { get; set; }
        [Column("Nivel_Acesso")]
        public int NivelAcesso { get; set; }
    }
}