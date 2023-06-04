using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentClinic_WebApi.Migrations
{
    /// <inheritdoc />
    public partial class VisitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "Visits",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "SlotId",
                table: "Visits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Visits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "VisitSlots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StartTime = table.Column<TimeOnly>(type: "time(6)", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "time(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitSlots", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_SlotId",
                table: "Visits",
                column: "SlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_VisitSlots_SlotId",
                table: "Visits",
                column: "SlotId",
                principalTable: "VisitSlots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_VisitSlots_SlotId",
                table: "Visits");

            migrationBuilder.DropTable(
                name: "VisitSlots");

            migrationBuilder.DropIndex(
                name: "IX_Visits_SlotId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "SlotId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Visits");
        }
    }
}
