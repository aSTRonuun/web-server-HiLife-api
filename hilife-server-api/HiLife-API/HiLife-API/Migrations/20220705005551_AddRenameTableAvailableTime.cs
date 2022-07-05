using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HiLife_API.Migrations
{
    public partial class AddRenameTableAvailableTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_patient_PatientId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_availabletime_Doctors_DoctorId1",
                table: "availabletime");

            migrationBuilder.DropPrimaryKey(
                name: "PK_availabletime",
                table: "availabletime");

            migrationBuilder.DropIndex(
                name: "IX_availabletime_DoctorId1",
                table: "availabletime");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "DoctorId1",
                table: "availabletime");

            migrationBuilder.RenameTable(
                name: "Appointments",
                newName: "appointments");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_PatientId",
                table: "appointments",
                newName: "IX_appointments_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_DoctorId",
                table: "appointments",
                newName: "IX_appointments_DoctorId");

            migrationBuilder.AlterColumn<long>(
                name: "DoctorId",
                table: "availabletime",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "availabletime",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_availabletime",
                table: "availabletime",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_appointments",
                table: "appointments",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_availabletime_DoctorId",
                table: "availabletime",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_Doctors_DoctorId",
                table: "appointments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_patient_PatientId",
                table: "appointments",
                column: "PatientId",
                principalTable: "patient",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_availabletime_Doctors_DoctorId",
                table: "availabletime",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_Doctors_DoctorId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_patient_PatientId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_availabletime_Doctors_DoctorId",
                table: "availabletime");

            migrationBuilder.DropPrimaryKey(
                name: "PK_availabletime",
                table: "availabletime");

            migrationBuilder.DropIndex(
                name: "IX_availabletime_DoctorId",
                table: "availabletime");

            migrationBuilder.DropPrimaryKey(
                name: "PK_appointments",
                table: "appointments");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "availabletime");

            migrationBuilder.RenameTable(
                name: "appointments",
                newName: "Appointments");

            migrationBuilder.RenameIndex(
                name: "IX_appointments_PatientId",
                table: "Appointments",
                newName: "IX_Appointments_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_appointments_DoctorId",
                table: "Appointments",
                newName: "IX_Appointments_DoctorId");

            migrationBuilder.AlterColumn<long>(
                name: "DoctorId",
                table: "availabletime",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<long>(
                name: "DoctorId1",
                table: "availabletime",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_availabletime",
                table: "availabletime",
                column: "DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_availabletime_DoctorId1",
                table: "availabletime",
                column: "DoctorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_patient_PatientId",
                table: "Appointments",
                column: "PatientId",
                principalTable: "patient",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_availabletime_Doctors_DoctorId1",
                table: "availabletime",
                column: "DoctorId1",
                principalTable: "Doctors",
                principalColumn: "id");
        }
    }
}
