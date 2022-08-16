using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciamentoDeContatos.Migrations
{
    public partial class CriandoTabelaServico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Servico",
                table: "Servico");

            migrationBuilder.RenameTable(
                name: "Servico",
                newName: "Servicos");

            migrationBuilder.AlterColumn<double>(
                name: "Preco",
                table: "Servicos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Servicos",
                table: "Servicos",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Servicos",
                table: "Servicos");

            migrationBuilder.RenameTable(
                name: "Servicos",
                newName: "Servico");

            migrationBuilder.AlterColumn<string>(
                name: "Preco",
                table: "Servico",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Servico",
                table: "Servico",
                column: "Id");
        }
    }
}
