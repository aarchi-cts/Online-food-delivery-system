using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_food_delivery_system.Migrations
{
    /// <inheritdoc />
    public partial class modelupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Agents_AgentID",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Orders_OrderID",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Restaurants_RestaurantID",
                table: "MenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Orders_OrderID",
                table: "Payments");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Agents_AgentID",
                table: "Deliveries",
                column: "AgentID",
                principalTable: "Agents",
                principalColumn: "AgentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Orders_OrderID",
                table: "Deliveries",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Restaurants_RestaurantID",
                table: "MenuItems",
                column: "RestaurantID",
                principalTable: "Restaurants",
                principalColumn: "RestaurantID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                table: "Orders",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Orders_OrderID",
                table: "Payments",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Agents_AgentID",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Orders_OrderID",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Restaurants_RestaurantID",
                table: "MenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Orders_OrderID",
                table: "Payments");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Agents_AgentID",
                table: "Deliveries",
                column: "AgentID",
                principalTable: "Agents",
                principalColumn: "AgentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Orders_OrderID",
                table: "Deliveries",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Restaurants_RestaurantID",
                table: "MenuItems",
                column: "RestaurantID",
                principalTable: "Restaurants",
                principalColumn: "RestaurantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                table: "Orders",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Orders_OrderID",
                table: "Payments",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID");
        }
    }
}
