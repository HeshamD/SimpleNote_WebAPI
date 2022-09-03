using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleNote_WebAPI.Infrastructure.Migrations
{
    public partial class seeding2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "User_Id",
                keyValue: 1,
                columns: new[] { "Creation_Date", "Last_Login_Date" },
                values: new object[] { new DateTime(2022, 9, 2, 18, 25, 14, 999, DateTimeKind.Local).AddTicks(9306), new DateTime(2022, 9, 2, 18, 25, 14, 999, DateTimeKind.Local).AddTicks(9337) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "User_Id", "Creation_Date", "Last_Login_Date", "Password", "UserName" },
                values: new object[] { 2, new DateTime(2022, 9, 2, 18, 25, 14, 999, DateTimeKind.Local).AddTicks(9340), new DateTime(2022, 9, 2, 18, 25, 14, 999, DateTimeKind.Local).AddTicks(9341), "guess", "user" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "User_Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "User_Id",
                keyValue: 1,
                columns: new[] { "Creation_Date", "Last_Login_Date" },
                values: new object[] { new DateTime(2022, 8, 31, 18, 44, 56, 965, DateTimeKind.Local).AddTicks(5224), new DateTime(2022, 8, 31, 18, 44, 56, 965, DateTimeKind.Local).AddTicks(5257) });
        }
    }
}
