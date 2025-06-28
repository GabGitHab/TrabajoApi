using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrabajoApi.Migrations
{
    /// <inheritdoc />
    public partial class seAgregoParentesis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ArtistaId",
                table: "CategoriaArtistas",
                newName: "Artista");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Artista",
                table: "CategoriaArtistas",
                newName: "ArtistaId");
        }
    }
}
