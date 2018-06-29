using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcaraDataRequestApplication.Migrations
{
    public partial class ChangeTypeAndCreatedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DetailedDescriptionOfTheIntendedUse",
                table: "DataRequestApplications",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "DataRequestApplications",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 6, 28, 15, 50, 34, 349, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DetailedDescriptionOfTheIntendedUse",
                table: "DataRequestApplications",
                type: "text",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "DataRequestApplications",
                nullable: false,
                defaultValue: new DateTime(2018, 6, 28, 15, 50, 34, 349, DateTimeKind.Local),
                oldClrType: typeof(DateTime));
        }
    }
}
