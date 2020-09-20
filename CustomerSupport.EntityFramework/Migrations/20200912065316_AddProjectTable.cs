using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerSupport.EntityFramework.Migrations
{
    public partial class AddProjectTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Project",
                table: "Tickets");

            migrationBuilder.AddColumn<long>(
                name: "ProjectId",
                table: "Tickets",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ProjectId",
                table: "Tickets",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Projects_ProjectId",
                table: "Tickets",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new [] { "Description" },
                values: new object[,] 
                {
                    { "C#" },
                    { "Angular" },
                    { "Typescript" },
                    { "Javascript" },
                    { "Php" }
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Projects_ProjectId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ProjectId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Tickets");

            migrationBuilder.AddColumn<string>(
                name: "Project",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
