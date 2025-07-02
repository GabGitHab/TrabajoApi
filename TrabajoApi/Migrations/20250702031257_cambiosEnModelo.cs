using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrabajoApi.Migrations
{
    /// <inheritdoc />
    public partial class cambiosEnModelo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordEncriptado",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordEncriptado",
                table: "Usuarios");
        }
    }
}
