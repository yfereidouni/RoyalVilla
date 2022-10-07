using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoyalVilla.Infrastructures.DAL.EF.Migrations
{
    public partial class addInitialDataForVilla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2022, 10, 7, 13, 26, 18, 334, DateTimeKind.Local).AddTicks(60), "Fusce 11 tincidunt maximus leo, sed scelerisque messa auctor sit. Donce ex damilar nur duch calliperist.", "https://www.dotnetmastery.com/bluevillaimages/villa1.jpg", "Royal Villa", 5, 200.0, 550, new DateTime(2022, 10, 8, 13, 26, 18, 334, DateTimeKind.Local).AddTicks(94) },
                    { 2, "", new DateTime(2022, 10, 7, 13, 26, 18, 334, DateTimeKind.Local).AddTicks(101), "Fusce 11 tincidunt maximus leo, sed scelerisque messa auctor sit. Donce ex damilar nur duch calliperist.", "https://www.dotnetmastery.com/bluevillaimages/villa2.jpg", "Peremium Pool Villa", 4, 550.0, 900, new DateTime(2022, 10, 8, 13, 26, 18, 334, DateTimeKind.Local).AddTicks(103) },
                    { 3, "", new DateTime(2022, 10, 7, 13, 26, 18, 334, DateTimeKind.Local).AddTicks(106), "Fusce 11 tincidunt maximus leo, sed scelerisque messa auctor sit. Donce ex damilar nur duch calliperist.", "https://www.dotnetmastery.com/bluevillaimages/villa3.jpg", "Luxary Pool Villa", 4, 600.0, 1100, new DateTime(2022, 10, 8, 13, 26, 18, 334, DateTimeKind.Local).AddTicks(108) },
                    { 4, "", new DateTime(2022, 10, 7, 13, 26, 18, 334, DateTimeKind.Local).AddTicks(112), "Fusce 11 tincidunt maximus leo, sed scelerisque messa auctor sit. Donce ex damilar nur duch calliperist.", "https://www.dotnetmastery.com/bluevillaimages/villa4.jpg", "Diamond Villa", 3, 800.0, 680, new DateTime(2022, 10, 8, 13, 26, 18, 334, DateTimeKind.Local).AddTicks(113) },
                    { 5, "", new DateTime(2022, 10, 7, 13, 26, 18, 334, DateTimeKind.Local).AddTicks(116), "Fusce 11 tincidunt maximus leo, sed scelerisque messa auctor sit. Donce ex damilar nur duch calliperist.", "https://www.dotnetmastery.com/bluevillaimages/villa5.jpg", "Diamond Pool Villa", 4, 650.0, 1100, new DateTime(2022, 10, 8, 13, 26, 18, 334, DateTimeKind.Local).AddTicks(118) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
