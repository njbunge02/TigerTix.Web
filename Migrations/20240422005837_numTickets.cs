using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TigerTix.Web.Migrations
{
    /// <inheritdoc />
    public partial class numTickets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TicketHolder",
                table: "Purchases",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "numtickets",
                table: "Purchases",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "numtickets",
                table: "Purchases");

            migrationBuilder.AlterColumn<int>(
                name: "TicketHolder",
                table: "Purchases",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
