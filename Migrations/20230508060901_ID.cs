using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FizzBuzzWeb.Migrations
{
    public partial class ID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "year",
                table: "StolenData",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "nick",
                table: "StolenData",
                newName: "Nick");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "StolenData",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StolenData",
                table: "StolenData",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StolenData",
                table: "StolenData");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StolenData");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "StolenData",
                newName: "year");

            migrationBuilder.RenameColumn(
                name: "Nick",
                table: "StolenData",
                newName: "nick");
        }
    }
}
