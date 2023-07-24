using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations.Pg
{
    /// <inheritdoc />
    public partial class productstock2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StockCode",
                table: "Products",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 23, 21, 31, 10, 663, DateTimeKind.Local).AddTicks(230),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 7, 23, 20, 59, 24, 216, DateTimeKind.Local).AddTicks(9450));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ProductImages",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 23, 21, 31, 10, 663, DateTimeKind.Local).AddTicks(1310),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 7, 23, 20, 59, 24, 217, DateTimeKind.Local).AddTicks(570));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "CartItems",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 23, 21, 31, 10, 662, DateTimeKind.Local).AddTicks(5670),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 7, 23, 20, 59, 24, 216, DateTimeKind.Local).AddTicks(4630));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "StockCode",
                table: "Products",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 23, 20, 59, 24, 216, DateTimeKind.Local).AddTicks(9450),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 7, 23, 21, 31, 10, 663, DateTimeKind.Local).AddTicks(230));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ProductImages",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 23, 20, 59, 24, 217, DateTimeKind.Local).AddTicks(570),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 7, 23, 21, 31, 10, 663, DateTimeKind.Local).AddTicks(1310));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "CartItems",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 23, 20, 59, 24, 216, DateTimeKind.Local).AddTicks(4630),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 7, 23, 21, 31, 10, 662, DateTimeKind.Local).AddTicks(5670));
        }
    }
}
