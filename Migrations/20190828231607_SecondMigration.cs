using Microsoft.EntityFrameworkCore.Migrations;

namespace game.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Archer",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Samurai",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Wizard",
                table: "Users",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Archer",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Samurai",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Wizard",
                table: "Users");
        }
    }
}
