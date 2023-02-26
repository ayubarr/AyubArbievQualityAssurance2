using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QualityAssurance2.Data.Migrations
{
    /// <inheritdoc />
    public partial class QAsecond2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Client",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdd",
                value: new DateTime(2023, 2, 26, 21, 33, 59, 424, DateTimeKind.Local).AddTicks(7265));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Client",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdd",
                value: new DateTime(2023, 2, 26, 21, 31, 16, 298, DateTimeKind.Local).AddTicks(3501));
        }
    }
}
