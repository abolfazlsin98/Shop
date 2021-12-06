using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bugeto_Store.Persistence.Migrations
{
    public partial class addblog1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HomePageImages",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 6, 15, 17, 10, 415, DateTimeKind.Local).AddTicks(2081));

            migrationBuilder.UpdateData(
                table: "HomePageImages",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 6, 15, 17, 10, 415, DateTimeKind.Local).AddTicks(2730));

            migrationBuilder.UpdateData(
                table: "HomePageImages",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 6, 15, 17, 10, 415, DateTimeKind.Local).AddTicks(2741));

            migrationBuilder.UpdateData(
                table: "HomePageImages",
                keyColumn: "Id",
                keyValue: 4L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 6, 15, 17, 10, 415, DateTimeKind.Local).AddTicks(2744));

            migrationBuilder.UpdateData(
                table: "HomePageImages",
                keyColumn: "Id",
                keyValue: 5L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 6, 15, 17, 10, 415, DateTimeKind.Local).AddTicks(2746));

            migrationBuilder.UpdateData(
                table: "HomePageImages",
                keyColumn: "Id",
                keyValue: 6L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 6, 15, 17, 10, 415, DateTimeKind.Local).AddTicks(2749));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 6, 15, 17, 10, 411, DateTimeKind.Local).AddTicks(7553));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 6, 15, 17, 10, 415, DateTimeKind.Local).AddTicks(1595));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 6, 15, 17, 10, 415, DateTimeKind.Local).AddTicks(1694));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HomePageImages",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 6, 15, 16, 11, 444, DateTimeKind.Local).AddTicks(3004));

            migrationBuilder.UpdateData(
                table: "HomePageImages",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 6, 15, 16, 11, 444, DateTimeKind.Local).AddTicks(3625));

            migrationBuilder.UpdateData(
                table: "HomePageImages",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 6, 15, 16, 11, 444, DateTimeKind.Local).AddTicks(3635));

            migrationBuilder.UpdateData(
                table: "HomePageImages",
                keyColumn: "Id",
                keyValue: 4L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 6, 15, 16, 11, 444, DateTimeKind.Local).AddTicks(3637));

            migrationBuilder.UpdateData(
                table: "HomePageImages",
                keyColumn: "Id",
                keyValue: 5L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 6, 15, 16, 11, 444, DateTimeKind.Local).AddTicks(3640));

            migrationBuilder.UpdateData(
                table: "HomePageImages",
                keyColumn: "Id",
                keyValue: 6L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 6, 15, 16, 11, 444, DateTimeKind.Local).AddTicks(3642));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 6, 15, 16, 11, 441, DateTimeKind.Local).AddTicks(1251));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 6, 15, 16, 11, 444, DateTimeKind.Local).AddTicks(2502));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 6, 15, 16, 11, 444, DateTimeKind.Local).AddTicks(2604));
        }
    }
}
