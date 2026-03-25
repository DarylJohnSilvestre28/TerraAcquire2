using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TerraAcquire.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class SyncScheduledBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ScheduledBy",
                table: "TrippingSchedules",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScheduledBy",
                table: "TrippingSchedules");
        }
    }
}
