using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerSupport.EntityFramework.Migrations
{
    public partial class AddAssigneeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Assignee",
                table: "Tickets");

            migrationBuilder.AddColumn<long>(
                name: "AssigneeId",
                table: "Tickets",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Assignees",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignees", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_AssigneeId",
                table: "Tickets",
                column: "AssigneeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Assignees_AssigneeId",
                table: "Tickets",
                column: "AssigneeId",
                principalTable: "Assignees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.InsertData(
                table: "Assignees",
                columns: new [] { "Firstname", "Lastname" },
                values: new object[,] 
                {
                    { "John", "Doe" },
                    { "Jeffrey", "Organo" },
                    { "Aileen", "Valencia"}
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Assignees_AssigneeId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Assignees");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_AssigneeId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "AssigneeId",
                table: "Tickets");

            migrationBuilder.AddColumn<string>(
                name: "Assignee",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
