using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HiLife_API.Migrations
{
    public partial class updatedTablePatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "refresh_token",
                table: "patient",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "refresh_token_experiy_time",
                table: "patient",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "refresh_token",
                table: "patient");

            migrationBuilder.DropColumn(
                name: "refresh_token_experiy_time",
                table: "patient");
        }
    }
}
