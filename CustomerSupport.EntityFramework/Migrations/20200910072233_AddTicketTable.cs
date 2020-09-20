using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerSupport.EntityFramework.Migrations
{
    public partial class AddTicketTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Project = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    Reporter = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Assignee = table.Column<string>(nullable: true),
                    Priority = table.Column<string>(nullable: true),
                    OriginalEstimate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
