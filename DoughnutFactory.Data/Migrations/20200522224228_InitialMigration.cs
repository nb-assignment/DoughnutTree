using Microsoft.EntityFrameworkCore.Migrations;

namespace DoughnutFactory.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoughnutTreeNodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositiveNodeId = table.Column<int>(type: "int", nullable: true),
                    NegativeNodeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoughnutTreeNodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoughnutTreeNodes_DoughnutTreeNodes_NegativeNodeId",
                        column: x => x.NegativeNodeId,
                        principalTable: "DoughnutTreeNodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DoughnutTreeNodes_DoughnutTreeNodes_PositiveNodeId",
                        column: x => x.PositiveNodeId,
                        principalTable: "DoughnutTreeNodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoughnutTreeNodes_NegativeNodeId",
                table: "DoughnutTreeNodes",
                column: "NegativeNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_DoughnutTreeNodes_PositiveNodeId",
                table: "DoughnutTreeNodes",
                column: "PositiveNodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoughnutTreeNodes");
        }
    }
}
