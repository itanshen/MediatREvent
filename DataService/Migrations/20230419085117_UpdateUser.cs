using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataService.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Remark",
                table: "Users",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Persons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 19, 8, 51, 17, 350, DateTimeKind.Utc).AddTicks(5234),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 19, 6, 50, 21, 978, DateTimeKind.Utc).AddTicks(8146));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remark",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Persons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 19, 6, 50, 21, 978, DateTimeKind.Utc).AddTicks(8146),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 19, 8, 51, 17, 350, DateTimeKind.Utc).AddTicks(5234));
        }
    }
}
