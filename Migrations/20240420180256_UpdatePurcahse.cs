using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TigerTix.Web.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePurcahse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Purchases_PurchaseID",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "CVV",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "CardNumber",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ExpiryMo",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ExpiryYr",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "NameOnCard",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "PurchaseID",
                table: "Tickets",
                newName: "PurchaseId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_PurchaseID",
                table: "Tickets",
                newName: "IX_Tickets_PurchaseId");

            migrationBuilder.AlterColumn<int>(
                name: "PurchaseId",
                table: "Tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "cardNum",
                table: "Purchases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "eventID",
                table: "Purchases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "subtotal",
                table: "Purchases",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Purchases_PurchaseId",
                table: "Tickets",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Purchases_PurchaseId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "cardNum",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "eventID",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "subtotal",
                table: "Purchases");

            migrationBuilder.RenameColumn(
                name: "PurchaseId",
                table: "Tickets",
                newName: "PurchaseID");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_PurchaseId",
                table: "Tickets",
                newName: "IX_Tickets_PurchaseID");

            migrationBuilder.AlterColumn<int>(
                name: "PurchaseID",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CVV",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CardNumber",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExpiryMo",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExpiryYr",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameOnCard",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Purchases_PurchaseID",
                table: "Tickets",
                column: "PurchaseID",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
