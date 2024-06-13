using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionTareas.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTareaItemConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TareaItems",
                table: "TareaItems");

            migrationBuilder.RenameTable(
                name: "TareaItems",
                newName: "TareasItems");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TareasItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TareasItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TareasItems",
                table: "TareasItems",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TareasItems",
                table: "TareasItems");

            migrationBuilder.RenameTable(
                name: "TareasItems",
                newName: "TareaItems");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TareaItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TareaItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TareaItems",
                table: "TareaItems",
                column: "Id");
        }
    }
}
