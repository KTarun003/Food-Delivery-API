using Microsoft.EntityFrameworkCore.Migrations;

namespace Zinger_API.Data.Migrations
{
    public partial class AddedStatusToOrderAndAgent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderStatus",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AgentStatus",
                table: "Agents",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AgentStatus",
                table: "Agents");
        }
    }
}
