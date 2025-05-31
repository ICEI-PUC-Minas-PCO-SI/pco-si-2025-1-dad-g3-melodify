using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autenticacao_e_Gestao_do_Usuario.Migrations
{
    /// <inheritdoc />
    public partial class M0131052025 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Senha_Id",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "Senha_Id",
                table: "Senhas",
                newName: "Usuario_Id");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Usuario_Id",
                table: "Senhas",
                newName: "Senha_Id");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Senha_Id",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
