using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Roles.Migrations
{
    public partial class ModifideUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RepeatPassword",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RepeatPassword",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
