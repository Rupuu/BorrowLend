using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BorrowLend.Migrations
{
    public partial class ExpensesTypeXExpense : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExpenceType",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExpenceTypeId",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ExpenceTypeId",
                table: "Expenses",
                column: "ExpenceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpensesType_ExpenceTypeId",
                table: "Expenses",
                column: "ExpenceTypeId",
                principalTable: "ExpensesType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpensesType_ExpenceTypeId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_ExpenceTypeId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "ExpenceType",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "ExpenceTypeId",
                table: "Expenses");
        }
    }
}
