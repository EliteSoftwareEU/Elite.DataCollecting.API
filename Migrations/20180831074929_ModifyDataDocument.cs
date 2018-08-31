using Microsoft.EntityFrameworkCore.Migrations;

namespace Elite.DataCollecting.API.Migrations
{
    public partial class ModifyDataDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DocumentImportedPath",
                table: "DocumentData",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentImportedPath",
                table: "DocumentData");
        }
    }
}
