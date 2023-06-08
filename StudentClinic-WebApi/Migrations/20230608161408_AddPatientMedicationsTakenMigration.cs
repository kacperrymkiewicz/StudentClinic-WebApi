using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentClinic_WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddPatientMedicationsTakenMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Prescriptions",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<string>(
                name: "MedicationsTaken",
                table: "Patients",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MedicationsTaken",
                table: "Patients");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Date",
                table: "Prescriptions",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }
    }
}
