using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoyalVilla.Infrastructures.DAL.EF.Migrations
{
    public partial class makeVillaNoASUniqueKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_VillasNumbers_VillaNo",
                table: "VillasNumbers",
                column: "VillaNo",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VillasNumbers_VillaNo",
                table: "VillasNumbers");
        }
    }
}
