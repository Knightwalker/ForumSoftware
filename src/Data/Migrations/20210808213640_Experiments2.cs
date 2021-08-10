using Microsoft.EntityFrameworkCore.Migrations;

namespace ForumSoftware.Data.Migrations
{
    public partial class Experiments2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forums_Forums_ForumId1",
                table: "Forums");

            migrationBuilder.DropIndex(
                name: "IX_Forums_ForumId1",
                table: "Forums");

            migrationBuilder.DropColumn(
                name: "ForumId1",
                table: "Forums");

            migrationBuilder.AlterColumn<int>(
                name: "ForumId",
                table: "Forums",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Forums_ForumId",
                table: "Forums",
                column: "ForumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Forums_Forums_ForumId",
                table: "Forums",
                column: "ForumId",
                principalTable: "Forums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forums_Forums_ForumId",
                table: "Forums");

            migrationBuilder.DropIndex(
                name: "IX_Forums_ForumId",
                table: "Forums");

            migrationBuilder.AlterColumn<string>(
                name: "ForumId",
                table: "Forums",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ForumId1",
                table: "Forums",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Forums_ForumId1",
                table: "Forums",
                column: "ForumId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Forums_Forums_ForumId1",
                table: "Forums",
                column: "ForumId1",
                principalTable: "Forums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
