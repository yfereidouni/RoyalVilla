using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoyalVilla.Infrastructures.DAL.EF.Migrations
{
    public partial class removeBaseEntityFromSomeEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VillasNumbers",
                table: "VillasNumbers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "VillasNumbers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VillasNumbers",
                table: "VillasNumbers",
                column: "VillaNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VillasNumbers",
                table: "VillasNumbers");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "VillasNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VillasNumbers",
                table: "VillasNumbers",
                column: "Id");
        }
    }
}
