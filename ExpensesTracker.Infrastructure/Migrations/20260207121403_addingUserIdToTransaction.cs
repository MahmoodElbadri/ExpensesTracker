using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExpensesTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addingUserIdToTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Transactions");

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "Category", "Date", "Description", "Type" },
                values: new object[,]
                {
                    { 1, 5000m, "Salary", new DateTime(2026, 2, 3, 23, 17, 2, 553, DateTimeKind.Local).AddTicks(460), "Salary", "INCOME" },
                    { 2, 100m, "Groceries", new DateTime(2026, 2, 3, 23, 17, 2, 553, DateTimeKind.Local).AddTicks(505), "Groceries", "EXPENSE" },
                    { 3, 200m, "Entertainment", new DateTime(2026, 2, 3, 23, 17, 2, 553, DateTimeKind.Local).AddTicks(559), "Cinema", "EXPENSE" }
                });
        }
    }
}
