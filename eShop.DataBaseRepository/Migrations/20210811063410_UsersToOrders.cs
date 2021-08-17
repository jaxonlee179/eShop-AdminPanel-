using Microsoft.EntityFrameworkCore.Migrations;

namespace eShop.DatabaseRepository.Migrations
{
    public partial class UsersToOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUsersId",
                schema: "orders",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ApplicationUsersId",
                schema: "orders",
                table: "Orders",
                column: "ApplicationUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_ApplicationUsersId",
                schema: "orders",
                table: "Orders",
                column: "ApplicationUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_ApplicationUsersId",
                schema: "orders",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ApplicationUsersId",
                schema: "orders",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ApplicationUsersId",
                schema: "orders",
                table: "Orders");
        }
    }
}
