using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DE_TallerTabla2.Migrations
{
    public partial class promo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Promos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PromoId = table.Column<int>(type: "int", nullable: false),
                    PromoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PromoDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BurgerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promos_Burger_BurgerId",
                        column: x => x.BurgerId,
                        principalTable: "Burger",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Promos_BurgerId",
                table: "Promos",
                column: "BurgerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Promos");
        }
    }
}
