using Microsoft.EntityFrameworkCore.Migrations;

namespace ForumSoftware.Data.Migrations
{
    public partial class Experiments3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Forums",
                columns: new[] { "Id", "Description", "ForumId", "Name", "Test" },
                values: new object[] { 2, "Test", null, "The Guilds And Factions", null });

            migrationBuilder.InsertData(
                table: "Forums",
                columns: new[] { "Id", "Description", "ForumId", "Name", "Test" },
                values: new object[] { 3, "Test", null, "The Rosters", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Forums",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Forums",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
