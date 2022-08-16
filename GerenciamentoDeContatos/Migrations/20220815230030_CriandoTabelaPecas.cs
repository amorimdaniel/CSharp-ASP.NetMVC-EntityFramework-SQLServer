using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciamentoDeContatos.Migrations
{
    public partial class CriandoTabelaPecas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pecas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    Preco = table.Column<double>(nullable: false),
                    Descricao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pecas", x => x.Id);
                });
        }
    }
}
