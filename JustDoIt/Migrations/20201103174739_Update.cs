using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JustDoIt.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "Date", "Note", "UserId" },
                values: new object[] { 1, new DateTime(2012, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hy, today I read the book", 1 });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "Date", "Note", "UserId" },
                values: new object[] { 2, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hy, today I swim", 2 });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "Date", "Note", "UserId" },
                values: new object[] { 3, new DateTime(2012, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hy, today I read the book and in the evening run", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
