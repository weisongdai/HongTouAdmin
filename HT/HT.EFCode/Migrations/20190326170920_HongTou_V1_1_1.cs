using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HT.EFCode.Migrations
{
    public partial class HongTou_V1_1_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HT_Roles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CareatTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    Description = table.Column<string>(maxLength: 254, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HT_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HT_Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CareatTime = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(maxLength: 24, nullable: false),
                    Password = table.Column<string>(maxLength: 254, nullable: false),
                    PasswordSalt = table.Column<string>(maxLength: 6, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    PhoneNum = table.Column<string>(maxLength: 11, nullable: false),
                    Avatar = table.Column<string>(maxLength: 254, nullable: false),
                    Enabled = table.Column<short>(type: "bit", nullable: false, defaultValue: (short)1),
                    Gender = table.Column<int>(nullable: false, defaultValue: 0),
                    IDCard = table.Column<string>(maxLength: 18, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HT_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HT_UserAndRole",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    RoleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HT_UserAndRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_HT_UserAndRole_HT_Roles_UserId",
                        column: x => x.UserId,
                        principalTable: "HT_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HT_UserAndRole_HT_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "HT_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HT_UserAndRole");

            migrationBuilder.DropTable(
                name: "HT_Roles");

            migrationBuilder.DropTable(
                name: "HT_Users");
        }
    }
}
