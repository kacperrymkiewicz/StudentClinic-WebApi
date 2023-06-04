using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentClinic_WebApi.Migrations
{
    /// <inheritdoc />
    public partial class PatientVisitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VisitSlots",
                columns: new[] { "Id", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 6, new TimeOnly(11, 0, 0), new TimeOnly(10, 30, 0) },
                    { 7, new TimeOnly(11, 30, 0), new TimeOnly(11, 0, 0) },
                    { 8, new TimeOnly(12, 0, 0), new TimeOnly(11, 30, 0) },
                    { 9, new TimeOnly(12, 30, 0), new TimeOnly(12, 0, 0) },
                    { 10, new TimeOnly(13, 0, 0), new TimeOnly(12, 30, 0) },
                    { 11, new TimeOnly(13, 30, 0), new TimeOnly(13, 0, 0) },
                    { 12, new TimeOnly(14, 0, 0), new TimeOnly(13, 30, 0) },
                    { 13, new TimeOnly(14, 30, 0), new TimeOnly(14, 0, 0) },
                    { 14, new TimeOnly(15, 0, 0), new TimeOnly(14, 30, 0) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VisitSlots",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "VisitSlots",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "VisitSlots",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "VisitSlots",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "VisitSlots",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "VisitSlots",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "VisitSlots",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "VisitSlots",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "VisitSlots",
                keyColumn: "Id",
                keyValue: 14);
        }
    }
}
