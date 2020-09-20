using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerSupport.EntityFramework.Migrations
{
    public partial class AddPriorityTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Tickets");

            migrationBuilder.AddColumn<long>(
                name: "PriorityId",
                table: "Tickets",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Priorities",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priorities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PriorityId",
                table: "Tickets",
                column: "PriorityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Priorities_PriorityId",
                table: "Tickets",
                column: "PriorityId",
                principalTable: "Priorities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.InsertData(
                table: "Priorities",
                columns: new [] { "Description" },
                values: new object[,] 
                {
                    { "Low" },
                    { "Medium" },
                    { "High" },
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Priorities_PriorityId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Priorities");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_PriorityId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "PriorityId",
                table: "Tickets");

            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
