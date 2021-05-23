using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherDetails.Migrations
{
    public partial class ClimateDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WDetails",
                table: "WDetails");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "WDetails");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "WDetails",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WDetails",
                table: "WDetails",
                column: "City");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WDetails",
                table: "WDetails");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "WDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "WDetails",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WDetails",
                table: "WDetails",
                column: "CityId");
        }
    }
}
