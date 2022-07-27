using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalizaApi.Migrations
{
    public partial class Clientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tab_Cliente",
                columns: table => new
                {
                    Id_Cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Documento = table.Column<string>(type: "nvarchar(14)", nullable: true),
                    Data_Nascimento = table.Column<DateTime>(type: "date", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(80)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(4)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CEP = table.Column<string>(type: "nvarchar(9)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(120)", nullable: true),
                    Nivel_Acesso = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_Cliente", x => x.Id_Cliente);
                });

            migrationBuilder.CreateTable(
                name: "tb_Veiculo_Modelo",
                columns: table => new
                {
                    Id_Marca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(80)", nullable: true),
                    Modelo = table.Column<string>(type: "nvarchar(80)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Veiculo_Modelo", x => x.Id_Marca);
                });

            migrationBuilder.CreateTable(
                name: "tab_Veiculo",
                columns: table => new
                {
                    Id_Veiculo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Placa = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Codigo_Marca = table.Column<int>(type: "int", nullable: false),
                    Ano = table.Column<string>(type: "nvarchar(4)", nullable: true),
                    Valor = table.Column<decimal>(type: "numeric(15,2)", nullable: false),
                    Combustivel = table.Column<string>(type: "nvarchar(35)", nullable: true),
                    Limite_PortaMala = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Categoria = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_Veiculo", x => x.Id_Veiculo);
                    table.ForeignKey(
                        name: "FK_tab_Veiculo_tb_Veiculo_Modelo_Codigo_Marca",
                        column: x => x.Codigo_Marca,
                        principalTable: "tb_Veiculo_Modelo",
                        principalColumn: "Id_Marca",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tab_Veiculo_Codigo_Marca",
                table: "tab_Veiculo",
                column: "Codigo_Marca");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tab_Cliente");

            migrationBuilder.DropTable(
                name: "tab_Veiculo");

            migrationBuilder.DropTable(
                name: "tb_Veiculo_Modelo");
        }
    }
}
