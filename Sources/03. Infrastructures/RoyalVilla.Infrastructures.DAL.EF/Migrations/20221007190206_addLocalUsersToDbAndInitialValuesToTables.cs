using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoyalVilla.Infrastructures.DAL.EF.Migrations
{
    public partial class addLocalUsersToDbAndInitialValuesToTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocalUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalUsers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "LocalUsers",
                columns: new[] { "Id", "Name", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, "Yasser", "admin", "admin", "admin" },
                    { 2, "Majid", "user", "user", "user" }
                });

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2022, 10, 7, 22, 32, 6, 643, DateTimeKind.Local).AddTicks(1220), "Fusce 11 tincidunt maximus leo, sed scelerisque messa auctor sit. Donce ex damilar nur duch calliperist.", "https://www.dotnetmastery.com/bluevillaimages/villa1.jpg", "Royal Villa", 5, 200.0, 550, new DateTime(2022, 10, 8, 22, 32, 6, 643, DateTimeKind.Local).AddTicks(1250) },
                    { 2, "", new DateTime(2022, 10, 7, 22, 32, 6, 643, DateTimeKind.Local).AddTicks(1257), "Fusce 11 tincidunt maximus leo, sed scelerisque messa auctor sit. Donce ex damilar nur duch calliperist.", "https://www.dotnetmastery.com/bluevillaimages/villa2.jpg", "Peremium Pool Villa", 4, 550.0, 900, new DateTime(2022, 10, 8, 22, 32, 6, 643, DateTimeKind.Local).AddTicks(1259) },
                    { 3, "", new DateTime(2022, 10, 7, 22, 32, 6, 643, DateTimeKind.Local).AddTicks(1262), "Fusce 11 tincidunt maximus leo, sed scelerisque messa auctor sit. Donce ex damilar nur duch calliperist.", "https://www.dotnetmastery.com/bluevillaimages/villa3.jpg", "Luxary Pool Villa", 4, 600.0, 1100, new DateTime(2022, 10, 8, 22, 32, 6, 643, DateTimeKind.Local).AddTicks(1264) },
                    { 4, "", new DateTime(2022, 10, 7, 22, 32, 6, 643, DateTimeKind.Local).AddTicks(1267), "Fusce 11 tincidunt maximus leo, sed scelerisque messa auctor sit. Donce ex damilar nur duch calliperist.", "https://www.dotnetmastery.com/bluevillaimages/villa4.jpg", "Diamond Villa", 3, 800.0, 680, new DateTime(2022, 10, 8, 22, 32, 6, 643, DateTimeKind.Local).AddTicks(1268) },
                    { 5, "", new DateTime(2022, 10, 7, 22, 32, 6, 643, DateTimeKind.Local).AddTicks(1271), "Fusce 11 tincidunt maximus leo, sed scelerisque messa auctor sit. Donce ex damilar nur duch calliperist.", "https://www.dotnetmastery.com/bluevillaimages/villa5.jpg", "Diamond Pool Villa", 4, 650.0, 1100, new DateTime(2022, 10, 8, 22, 32, 6, 643, DateTimeKind.Local).AddTicks(1272) }
                });

            migrationBuilder.InsertData(
                table: "VillasNumbers",
                columns: new[] { "VillaNo", "CreatedDate", "SpecialDetails", "UpdatedDate", "VillaId" },
                values: new object[,]
                {
                    { 101, new DateTime(2022, 10, 7, 22, 32, 6, 643, DateTimeKind.Local).AddTicks(1543), "this is a dummy text.", new DateTime(2022, 10, 7, 22, 32, 6, 643, DateTimeKind.Local).AddTicks(1548), 1 },
                    { 102, new DateTime(2022, 10, 7, 22, 32, 6, 643, DateTimeKind.Local).AddTicks(1551), "this is a dummy text.", new DateTime(2022, 10, 7, 22, 32, 6, 643, DateTimeKind.Local).AddTicks(1553), 1 },
                    { 103, new DateTime(2022, 10, 7, 22, 32, 6, 643, DateTimeKind.Local).AddTicks(1555), "this is a dummy text.", new DateTime(2022, 10, 7, 22, 32, 6, 643, DateTimeKind.Local).AddTicks(1556), 1 },
                    { 201, new DateTime(2022, 10, 7, 22, 32, 6, 643, DateTimeKind.Local).AddTicks(1559), "this is a dummy text.", new DateTime(2022, 10, 7, 22, 32, 6, 643, DateTimeKind.Local).AddTicks(1560), 2 },
                    { 202, new DateTime(2022, 10, 7, 22, 32, 6, 643, DateTimeKind.Local).AddTicks(1562), "this is a dummy text.", new DateTime(2022, 10, 7, 22, 32, 6, 643, DateTimeKind.Local).AddTicks(1564), 2 },
                    { 301, new DateTime(2022, 10, 7, 22, 32, 6, 643, DateTimeKind.Local).AddTicks(1566), "this is a dummy text.", new DateTime(2022, 10, 7, 22, 32, 6, 643, DateTimeKind.Local).AddTicks(1567), 3 },
                    { 401, new DateTime(2022, 10, 7, 22, 32, 6, 643, DateTimeKind.Local).AddTicks(1569), "this is a dummy text.", new DateTime(2022, 10, 7, 22, 32, 6, 643, DateTimeKind.Local).AddTicks(1571), 4 },
                    { 501, new DateTime(2022, 10, 7, 22, 32, 6, 643, DateTimeKind.Local).AddTicks(1573), "this is a dummy text.", new DateTime(2022, 10, 7, 22, 32, 6, 643, DateTimeKind.Local).AddTicks(1575), 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalUsers");

            migrationBuilder.DeleteData(
                table: "VillasNumbers",
                keyColumn: "VillaNo",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "VillasNumbers",
                keyColumn: "VillaNo",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "VillasNumbers",
                keyColumn: "VillaNo",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "VillasNumbers",
                keyColumn: "VillaNo",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "VillasNumbers",
                keyColumn: "VillaNo",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "VillasNumbers",
                keyColumn: "VillaNo",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "VillasNumbers",
                keyColumn: "VillaNo",
                keyValue: 401);

            migrationBuilder.DeleteData(
                table: "VillasNumbers",
                keyColumn: "VillaNo",
                keyValue: 501);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
