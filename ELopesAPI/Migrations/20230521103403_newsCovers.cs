using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELopesAPI.Migrations
{
    public partial class newsCovers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "NewsPost",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cover",
                table: "NewsPost");
        }
    }
}
