using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HiLife_API.Migrations
{
    public partial class AddAppointmentAndUpdatePatientAndDoctor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvailableTime_Doctors_DoctorId1",
                table: "AvailableTime");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AvailableTime",
                table: "AvailableTime");

            migrationBuilder.RenameTable(
                name: "AvailableTime",
                newName: "availabletime");

            migrationBuilder.RenameIndex(
                name: "IX_AvailableTime_DoctorId1",
                table: "availabletime",
                newName: "IX_availabletime_DoctorId1");

            migrationBuilder.AlterColumn<long>(
                name: "DoctorId1",
                table: "availabletime",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddPrimaryKey(
                name: "PK_availabletime",
                table: "availabletime",
                column: "DoctorId");

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PatientId = table.Column<long>(type: "bigint", nullable: false),
                    DoctorId = table.Column<long>(type: "bigint", nullable: false),
                    Modality = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AppointmentTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "patient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_availabletime_Doctors_DoctorId1",
                table: "availabletime",
                column: "DoctorId1",
                principalTable: "Doctors",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_availabletime_Doctors_DoctorId1",
                table: "availabletime");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_availabletime",
                table: "availabletime");

            migrationBuilder.RenameTable(
                name: "availabletime",
                newName: "AvailableTime");

            migrationBuilder.RenameIndex(
                name: "IX_availabletime_DoctorId1",
                table: "AvailableTime",
                newName: "IX_AvailableTime_DoctorId1");

            migrationBuilder.AlterColumn<long>(
                name: "DoctorId1",
                table: "AvailableTime",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AvailableTime",
                table: "AvailableTime",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AvailableTime_Doctors_DoctorId1",
                table: "AvailableTime",
                column: "DoctorId1",
                principalTable: "Doctors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
