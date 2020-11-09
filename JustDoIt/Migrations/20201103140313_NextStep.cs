using Microsoft.EntityFrameworkCore.Migrations;

namespace JustDoIt.Migrations
{
    public partial class NextStep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Email", "FirstName", "Password", "SecondName" },
                values: new object[] { 1, 18, "qwert@gmail.com", "Mykhailo", "123456", "Shastun" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Email", "FirstName", "Password", "SecondName" },
                values: new object[] { 2, 18, "qwer@gmail.com", "Volodymyr", "123456", "Sydorko" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Email", "FirstName", "Password", "SecondName" },
                values: new object[] { 3, 18, "qwerty@gmail.com", "Vadym", "123456", "Pyshniak" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
