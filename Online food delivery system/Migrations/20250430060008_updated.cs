using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_food_delivery_system.Migrations
{
    /// <inheritdoc />
    public partial class updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Payments_PaymentID",
                table: "Deliveries");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_PaymentID",
                table: "Deliveries");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Payments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_PaymentID",
                table: "Deliveries",
                column: "PaymentID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Payments_PaymentID",
                table: "Deliveries",
                column: "PaymentID",
                principalTable: "Payments",
                principalColumn: "PaymentID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Payments_PaymentID",
                table: "Deliveries");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_PaymentID",
                table: "Deliveries");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Payments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_PaymentID",
                table: "Deliveries",
                column: "PaymentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Payments_PaymentID",
                table: "Deliveries",
                column: "PaymentID",
                principalTable: "Payments",
                principalColumn: "PaymentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
