using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Elite.DataCollecting.API.Migrations
{
    public partial class AddDocumentData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentData",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    DocumentText = table.Column<string>(nullable: true),
                    ImportedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentData", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentData");
        }
    }
}
