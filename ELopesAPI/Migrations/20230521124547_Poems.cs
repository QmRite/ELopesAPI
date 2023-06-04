using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELopesAPI.Migrations
{
    public partial class Poems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Poems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PoemTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoemTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PoemTagJoins",
                columns: table => new
                {
                    PoemId = table.Column<int>(type: "int", nullable: false),
                    PoemTagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoemTagJoins", x => new { x.PoemId, x.PoemTagId });
                    table.ForeignKey(
                        name: "FK_PoemTagJoins_Poems_PoemId",
                        column: x => x.PoemId,
                        principalTable: "Poems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoemTagJoins_PoemTags_PoemTagId",
                        column: x => x.PoemTagId,
                        principalTable: "PoemTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PoemTagJoins_PoemTagId",
                table: "PoemTagJoins",
                column: "PoemTagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PoemTagJoins");

            migrationBuilder.DropTable(
                name: "Poems");

            migrationBuilder.DropTable(
                name: "PoemTags");
        }
    }
}
