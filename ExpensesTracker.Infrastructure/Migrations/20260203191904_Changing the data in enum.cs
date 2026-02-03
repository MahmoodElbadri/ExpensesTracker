using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpensesTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Changingthedatainenum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Type" },
                values: new object[] { new DateTime(2026, 2, 3, 21, 19, 4, 311, DateTimeKind.Local).AddTicks(6304), "INCOME" });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Type" },
                values: new object[] { new DateTime(2026, 2, 3, 21, 19, 4, 311, DateTimeKind.Local).AddTicks(6356), "EXPENSE" });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "Type" },
                values: new object[] { new DateTime(2026, 2, 3, 21, 19, 4, 311, DateTimeKind.Local).AddTicks(6359), "EXPENSE" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Transactions",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Type" },
                values: new object[] { new DateTime(2026, 2, 3, 21, 12, 50, 491, DateTimeKind.Local).AddTicks(8925), 1 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Type" },
                values: new object[] { new DateTime(2026, 2, 3, 21, 12, 50, 491, DateTimeKind.Local).AddTicks(8977), 0 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "Type" },
                values: new object[] { new DateTime(2026, 2, 3, 21, 12, 50, 491, DateTimeKind.Local).AddTicks(8983), 0 });
        }
    }
}
