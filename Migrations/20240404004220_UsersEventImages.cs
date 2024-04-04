using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TigerTix.Web.Migrations
{
    /// <inheritdoc />
    public partial class UsersEventImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imageName",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageName",
                table: "Events");
        }
    }
}
