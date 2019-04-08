using Microsoft.EntityFrameworkCore.Migrations;

namespace HT.EFCode.Migrations
{
    public partial class HongTou_V1_1_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                table: "HT_Users",
                maxLength: 254,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 254);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                table: "HT_Users",
                maxLength: 254,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 254,
                oldNullable: true);
        }
    }
}
