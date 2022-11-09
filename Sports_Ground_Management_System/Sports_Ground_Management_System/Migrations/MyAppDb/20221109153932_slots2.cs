using Microsoft.EntityFrameworkCore.Migrations;

namespace Sports_Ground_Management_System.Migrations.MyAppDb
{
    public partial class slots2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ground_BookedSlot_BookedSlotId",
                table: "Ground");

            migrationBuilder.DropIndex(
                name: "IX_Ground_BookedSlotId",
                table: "Ground");

            migrationBuilder.DropColumn(
                name: "BookedSlotId",
                table: "Ground");

            migrationBuilder.CreateIndex(
                name: "IX_BookedSlot_GroundId",
                table: "BookedSlot",
                column: "GroundId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookedSlot_Ground_GroundId",
                table: "BookedSlot",
                column: "GroundId",
                principalTable: "Ground",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedSlot_Ground_GroundId",
                table: "BookedSlot");

            migrationBuilder.DropIndex(
                name: "IX_BookedSlot_GroundId",
                table: "BookedSlot");

            migrationBuilder.AddColumn<int>(
                name: "BookedSlotId",
                table: "Ground",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ground_BookedSlotId",
                table: "Ground",
                column: "BookedSlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ground_BookedSlot_BookedSlotId",
                table: "Ground",
                column: "BookedSlotId",
                principalTable: "BookedSlot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
