using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoList.Migrations
{
    public partial class AddFewNewColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Data",
                table: "ToDo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "ToDo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubTask",
                table: "ToDo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "ToDo");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "ToDo");

            migrationBuilder.DropColumn(
                name: "SubTask",
                table: "ToDo");
        }
    }
}
