using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TerraAcquire.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddTrippingColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TrippingSchedules",
                table: "TrippingSchedules");

            migrationBuilder.RenameTable(
                name: "TrippingSchedules",
                newName: "trippingschedules");

            migrationBuilder.AlterColumn<string>(
                name: "Time",
                table: "trippingschedules",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ScheduledBy",
                table: "trippingschedules",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "AgentName",
                table: "trippingschedules",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<Guid>(
                name: "AgentId",
                table: "trippingschedules",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "trippingschedules",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "trippingschedules",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "trippingschedules",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_trippingschedules",
                table: "trippingschedules",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_trippingschedules",
                table: "trippingschedules");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "trippingschedules");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "trippingschedules");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "trippingschedules");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "trippingschedules");

            migrationBuilder.RenameTable(
                name: "trippingschedules",
                newName: "TrippingSchedules");

            migrationBuilder.AlterColumn<string>(
                name: "Time",
                table: "TrippingSchedules",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ScheduledBy",
                table: "TrippingSchedules",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "AgentName",
                table: "TrippingSchedules",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrippingSchedules",
                table: "TrippingSchedules",
                column: "Id");
        }
    }
}
