using Microsoft.EntityFrameworkCore.Migrations;

namespace Elite.DataCollecting.API.Migrations
{
    public partial class AddDocumentSentences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sentences",
                table: "DocumentData",
                type: "jsonb",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sentences",
                table: "DocumentData");
        }
    }
}
