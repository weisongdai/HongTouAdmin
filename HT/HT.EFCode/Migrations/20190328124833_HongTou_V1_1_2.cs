using Microsoft.EntityFrameworkCore.Migrations;

namespace HT.EFCode.Migrations
{
    public partial class HongTou_V1_1_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_HT_Users_IDCard",
                table: "HT_Users",
                column: "IDCard",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HT_Users_PhoneNum",
                table: "HT_Users",
                column: "PhoneNum",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HT_Users_IDCard",
                table: "HT_Users");

            migrationBuilder.DropIndex(
                name: "IX_HT_Users_PhoneNum",
                table: "HT_Users");
        }
    }
}
