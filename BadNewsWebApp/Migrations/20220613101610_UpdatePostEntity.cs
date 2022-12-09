using Microsoft.EntityFrameworkCore.Migrations;

namespace BadNewsWebApp.Migrations
{
    public partial class UpdatePostEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Posts",
                newName: "Introduction");

            migrationBuilder.AddColumn<string>(
                name: "Conclusion",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageCover",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Middle",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Quote",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Conclusion",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ImageCover",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Middle",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Quote",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "Introduction",
                table: "Posts",
                newName: "Content");
        }
    }
}
