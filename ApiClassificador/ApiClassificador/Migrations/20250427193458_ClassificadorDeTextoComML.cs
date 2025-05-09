using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiClassificador.Migrations
{
    /// <inheritdoc />
    public partial class ClassificadorDeTextoComML : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassificacaoDeResultados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TextoOriginal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Classificacao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassificacaoDeResultados", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassificacaoDeResultados");
        }
    }
}
