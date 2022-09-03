using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleNote_WebAPI.Infrastructure.Migrations
{
    public partial class initalAndSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attributies",
                columns: table => new
                {
                    Attribute_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributies", x => x.Attribute_Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Project_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Completed = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Project_Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Creation_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Last_Login_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_Id);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Note_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Completed = table.Column<bool>(type: "bit", nullable: false),
                    Project_ID_FK = table.Column<int>(type: "int", nullable: true),
                    Attribute_Id_FK = table.Column<int>(type: "int", nullable: true),
                    User_Id_FK = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Note_Id);
                    table.ForeignKey(
                        name: "FK_Notes_Attributies_Attribute_Id_FK",
                        column: x => x.Attribute_Id_FK,
                        principalTable: "Attributies",
                        principalColumn: "Attribute_Id");
                    table.ForeignKey(
                        name: "FK_Notes_Projects_Project_ID_FK",
                        column: x => x.Project_ID_FK,
                        principalTable: "Projects",
                        principalColumn: "Project_Id");
                    table.ForeignKey(
                        name: "FK_Notes_Users_User_Id_FK",
                        column: x => x.User_Id_FK,
                        principalTable: "Users",
                        principalColumn: "User_Id");
                });

            migrationBuilder.InsertData(
                table: "Attributies",
                columns: new[] { "Attribute_Id", "Name" },
                values: new object[] { 1, "first attributies" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Project_Id", "Completed", "Title" },
                values: new object[] { 1, false, "first project" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "User_Id", "Creation_Date", "Last_Login_Date", "Password", "UserName" },
                values: new object[] { 1, new DateTime(2022, 8, 31, 18, 39, 31, 314, DateTimeKind.Local).AddTicks(6350), new DateTime(2022, 8, 31, 18, 39, 31, 314, DateTimeKind.Local).AddTicks(6384), "firstPass", "first userName" });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Note_Id", "Attribute_Id_FK", "Completed", "Note", "Project_ID_FK", "User_Id_FK" },
                values: new object[] { 1, null, false, "first note", null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Attributies_Name",
                table: "Attributies",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notes_Attribute_Id_FK",
                table: "Notes",
                column: "Attribute_Id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_Project_ID_FK",
                table: "Notes",
                column: "Project_ID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_User_Id_FK",
                table: "Notes",
                column: "User_Id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_Title",
                table: "Projects",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Attributies");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
