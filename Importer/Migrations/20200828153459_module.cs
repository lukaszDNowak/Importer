using Microsoft.EntityFrameworkCore.Migrations;

namespace Importer.Migrations
{
    public partial class module : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "modules");

            migrationBuilder.AddColumn<int>(
                name: "ModuleNumber",
                table: "modules",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModuleNumber",
                table: "modules");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "modules",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
