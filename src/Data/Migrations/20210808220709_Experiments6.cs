using Microsoft.EntityFrameworkCore.Migrations;

namespace ForumSoftware.Data.Migrations
{
    public partial class Experiments6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Forums",
                columns: new[] { "Id", "Description", "ForumId", "Name", "Test" },
                values: new object[] { 4, "Test", 2, "The Guilds And Factions Test", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Forums",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
