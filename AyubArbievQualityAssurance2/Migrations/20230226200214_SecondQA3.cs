using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QualityAssurance2.Data.Migrations
{
    /// <inheritdoc />
    public partial class SecondQA3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "Id",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "Id", "DateAdd", "FirstName", "LastName", "OrderAmount", "PhoneNum" },
                values: new object[] { 1, new DateTime(2023, 2, 27, 2, 1, 50, 724, DateTimeKind.Local).AddTicks(5483), "Adm", "Adminuch", 0, "0555 555 555" });
        }
    }
}
