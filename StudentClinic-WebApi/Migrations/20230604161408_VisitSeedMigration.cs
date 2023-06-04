using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentClinic_WebApi.Migrations
{
    /// <inheritdoc />
    public partial class VisitSeedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VisitSlots",
                columns: new[] { "Id", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 1, new TimeOnly(8, 30, 0), new TimeOnly(8, 0, 0) },
                    { 2, new TimeOnly(9, 0, 0), new TimeOnly(8, 30, 0) },
                    { 3, new TimeOnly(9, 30, 0), new TimeOnly(9, 0, 0) },
                    { 4, new TimeOnly(10, 0, 0), new TimeOnly(9, 30, 0) },
                    { 5, new TimeOnly(10, 30, 0), new TimeOnly(10, 0, 0) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VisitSlots",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VisitSlots",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VisitSlots",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VisitSlots",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VisitSlots",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
