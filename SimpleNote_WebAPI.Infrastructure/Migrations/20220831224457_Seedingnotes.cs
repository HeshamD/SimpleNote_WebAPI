using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleNote_WebAPI.Infrastructure.Migrations
{
    public partial class Seedingnotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Note_Id", "Attribute_Id_FK", "Completed", "Note", "Project_ID_FK", "User_Id_FK" },
                values: new object[,]
                {
                    { 2, null, false, "second note", 1, 1 },
                    { 3, 1, false, "third note", null, 1 },
                    { 4, 1, false, "fourth note", 1, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "User_Id",
                keyValue: 1,
                columns: new[] { "Creation_Date", "Last_Login_Date" },
                values: new object[] { new DateTime(2022, 8, 31, 18, 44, 56, 965, DateTimeKind.Local).AddTicks(5224), new DateTime(2022, 8, 31, 18, 44, 56, 965, DateTimeKind.Local).AddTicks(5257) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Note_Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Note_Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Note_Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "User_Id",
                keyValue: 1,
                columns: new[] { "Creation_Date", "Last_Login_Date" },
                values: new object[] { new DateTime(2022, 8, 31, 18, 39, 31, 314, DateTimeKind.Local).AddTicks(6350), new DateTime(2022, 8, 31, 18, 39, 31, 314, DateTimeKind.Local).AddTicks(6384) });
        }
    }
}
