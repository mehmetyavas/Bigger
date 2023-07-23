using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations.Pg
{
    /// <inheritdoc />
    public partial class productstock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 23, 20, 59, 24, 216, DateTimeKind.Local).AddTicks(9450),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 7, 22, 23, 3, 20, 66, DateTimeKind.Local).AddTicks(7050));

            migrationBuilder.AddColumn<Guid>(
                name: "StockCode",
                table: "Products",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ProductImages",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 23, 20, 59, 24, 217, DateTimeKind.Local).AddTicks(570),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 7, 22, 23, 3, 20, 66, DateTimeKind.Local).AddTicks(8100));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "CartItems",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 23, 20, 59, 24, 216, DateTimeKind.Local).AddTicks(4630),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 7, 22, 23, 3, 20, 66, DateTimeKind.Local).AddTicks(2500));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockCode",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 22, 23, 3, 20, 66, DateTimeKind.Local).AddTicks(7050),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 7, 23, 20, 59, 24, 216, DateTimeKind.Local).AddTicks(9450));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ProductImages",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 22, 23, 3, 20, 66, DateTimeKind.Local).AddTicks(8100),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 7, 23, 20, 59, 24, 217, DateTimeKind.Local).AddTicks(570));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "CartItems",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 22, 23, 3, 20, 66, DateTimeKind.Local).AddTicks(2500),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 7, 23, 20, 59, 24, 216, DateTimeKind.Local).AddTicks(4630));
        }
    }
}
