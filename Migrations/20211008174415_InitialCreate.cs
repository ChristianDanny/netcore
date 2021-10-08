using Microsoft.EntityFrameworkCore.Migrations;

namespace UserApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorreoUsu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PerfilUsu = table.Column<int>(type: "int", nullable: false),
                    EmpresaUsu = table.Column<int>(type: "int", nullable: false),
                    EstadoUsu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserItems", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserItems");
        }
    }
}
