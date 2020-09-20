using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerSupport.EntityFramework.Migrations
{
    public partial class AddIssueTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "IssueId",
                table: "Tickets",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_IssueId",
                table: "Tickets",
                column: "IssueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Issues_IssueId",
                table: "Tickets",
                column: "IssueId",
                principalTable: "Issues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.InsertData(
                table: "Issues",
                columns: new [] { "Description" },
                values: new object[,] 
                {
                    { "Task" },
                    { "Bug" },
                    { "Feature" }
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Issues_IssueId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_IssueId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "IssueId",
                table: "Tickets");
        }
    }
}
