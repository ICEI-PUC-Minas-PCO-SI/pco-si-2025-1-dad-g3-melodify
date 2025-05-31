using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avaliaçãoecomentários.Migrations
{
    /// <inheritdoc />
    public partial class AddAvaliacaoIdToComentario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Avaliacoes_Id_Avaliacao",
                table: "Comentarios");

            migrationBuilder.RenameColumn(
                name: "Id_Avaliacao",
                table: "Comentarios",
                newName: "AvaliacaoId");

            migrationBuilder.RenameIndex(
                name: "IX_Comentarios_Id_Avaliacao",
                table: "Comentarios",
                newName: "IX_Comentarios_AvaliacaoId");

            migrationBuilder.AlterColumn<string>(
                name: "Texto",
                table: "Avaliacoes",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Avaliacoes_AvaliacaoId",
                table: "Comentarios",
                column: "AvaliacaoId",
                principalTable: "Avaliacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Avaliacoes_AvaliacaoId",
                table: "Comentarios");

            migrationBuilder.RenameColumn(
                name: "AvaliacaoId",
                table: "Comentarios",
                newName: "Id_Avaliacao");

            migrationBuilder.RenameIndex(
                name: "IX_Comentarios_AvaliacaoId",
                table: "Comentarios",
                newName: "IX_Comentarios_Id_Avaliacao");

            migrationBuilder.AlterColumn<string>(
                name: "Texto",
                table: "Avaliacoes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Avaliacoes_Id_Avaliacao",
                table: "Comentarios",
                column: "Id_Avaliacao",
                principalTable: "Avaliacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
