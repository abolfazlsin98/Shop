using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bugeto_Store.Persistence.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HomePageImages",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 5, 10, 44, 47, 108, DateTimeKind.Local).AddTicks(1665));

            migrationBuilder.UpdateData(
                table: "HomePageImages",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 5, 10, 44, 47, 108, DateTimeKind.Local).AddTicks(2273));

            migrationBuilder.UpdateData(
                table: "HomePageImages",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 5, 10, 44, 47, 108, DateTimeKind.Local).AddTicks(2285));

            migrationBuilder.UpdateData(
                table: "HomePageImages",
                keyColumn: "Id",
                keyValue: 4L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 5, 10, 44, 47, 108, DateTimeKind.Local).AddTicks(2287));

            migrationBuilder.UpdateData(
                table: "HomePageImages",
                keyColumn: "Id",
                keyValue: 5L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 5, 10, 44, 47, 108, DateTimeKind.Local).AddTicks(2290));

            migrationBuilder.UpdateData(
                table: "HomePageImages",
                keyColumn: "Id",
                keyValue: 6L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 5, 10, 44, 47, 108, DateTimeKind.Local).AddTicks(2292));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 5, 10, 44, 47, 104, DateTimeKind.Local).AddTicks(8525));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 5, 10, 44, 47, 108, DateTimeKind.Local).AddTicks(1144));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 5, 10, 44, 47, 108, DateTimeKind.Local).AddTicks(1253));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HomePageImages",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 5, 10, 44, 16, 364, DateTimeKind.Local).AddTicks(8558));

            migrationBuilder.UpdateData(
                table: "HomePageImages",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 5, 10, 44, 16, 364, DateTimeKind.Local).AddTicks(9187));

            migrationBuilder.UpdateData(
                table: "HomePageImages",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 5, 10, 44, 16, 364, DateTimeKind.Local).AddTicks(9199));

            migrationBuilder.UpdateData(
                table: "HomePageImages",
                keyColumn: "Id",
                keyValue: 4L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 5, 10, 44, 16, 364, DateTimeKind.Local).AddTicks(9202));

            migrationBuilder.UpdateData(
                table: "HomePageImages",
                keyColumn: "Id",
                keyValue: 5L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 5, 10, 44, 16, 364, DateTimeKind.Local).AddTicks(9204));

            migrationBuilder.UpdateData(
                table: "HomePageImages",
                keyColumn: "Id",
                keyValue: 6L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 5, 10, 44, 16, 364, DateTimeKind.Local).AddTicks(9207));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 5, 10, 44, 16, 361, DateTimeKind.Local).AddTicks(4979));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 5, 10, 44, 16, 364, DateTimeKind.Local).AddTicks(8030));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 5, 10, 44, 16, 364, DateTimeKind.Local).AddTicks(8148));
        }
    }
}
