using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations.Pg
{
    /// <inheritdoc />
    public partial class addressupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 22, 23, 3, 20, 66, DateTimeKind.Local).AddTicks(7050),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 7, 22, 14, 37, 31, 188, DateTimeKind.Local).AddTicks(9410));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ProductImages",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 22, 23, 3, 20, 66, DateTimeKind.Local).AddTicks(8100),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 7, 22, 14, 37, 31, 189, DateTimeKind.Local).AddTicks(460));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "CartItems",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 22, 23, 3, 20, 66, DateTimeKind.Local).AddTicks(2500),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 7, 22, 14, 37, 31, 187, DateTimeKind.Local).AddTicks(6880));

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "Address",
                type: "character varying(35)",
                maxLength: 35,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Address",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "FullAddress",
                table: "Address",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Address",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Address",
                type: "character varying(35)",
                maxLength: 35,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Address",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Address");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 22, 14, 37, 31, 188, DateTimeKind.Local).AddTicks(9410),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 7, 22, 23, 3, 20, 66, DateTimeKind.Local).AddTicks(7050));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ProductImages",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 22, 14, 37, 31, 189, DateTimeKind.Local).AddTicks(460),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 7, 22, 23, 3, 20, 66, DateTimeKind.Local).AddTicks(8100));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "CartItems",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 22, 14, 37, 31, 187, DateTimeKind.Local).AddTicks(6880),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 7, 22, 23, 3, 20, 66, DateTimeKind.Local).AddTicks(2500));

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "Address",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(35)",
                oldMaxLength: 35);

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Address",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "FullAddress",
                table: "Address",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Address",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Address",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(35)",
                oldMaxLength: 35);
        }
    }
}
