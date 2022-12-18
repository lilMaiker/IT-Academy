using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FriendsMVC.Migrations
{
    public partial class RefColCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CityForCountry",
                table: "Countries",
                type: "VARCHAR(45)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(45)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CityForCountry",
                keyValue: null,
                column: "CityForCountry",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "CityForCountry",
                table: "Countries",
                type: "VARCHAR(45)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(45)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
