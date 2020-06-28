using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_EF_Deneme.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kargo",
                columns: table => new
                {
                    kargoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gonderenIsim = table.Column<string>(nullable: true),
                    aliciIsim = table.Column<string>(nullable: true),
                    aliciBirim = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    kargoAgirlik = table.Column<int>(nullable: true),
                    gonderenAdres = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kargo", x => x.kargoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kargo");
        }
    }
}
