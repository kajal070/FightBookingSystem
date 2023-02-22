using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightBookingSystemFolder.Migrations
{
    /// <inheritdoc />
    public partial class Updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookings_dbsetflight_Flight_Id",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_bookings_registrations_Email",
                table: "bookings");

            migrationBuilder.RenameColumn(
                name: "Flight_Id",
                table: "bookings",
                newName: "FlightId");

            migrationBuilder.RenameIndex(
                name: "IX_bookings_Flight_Id",
                table: "bookings",
                newName: "IX_bookings_FlightId");

            migrationBuilder.AddForeignKey(
                name: "FK__Book__Registration_I__1273C1CD",
                table: "bookings",
                column: "Email",
                principalTable: "registrations",
                principalColumn: "Email",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_dbsetflight_FlightId",
                table: "bookings",
                column: "FlightId",
                principalTable: "dbsetflight",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Book__Registration_I__1273C1CD",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_bookings_dbsetflight_FlightId",
                table: "bookings");

            migrationBuilder.RenameColumn(
                name: "FlightId",
                table: "bookings",
                newName: "Flight_Id");

            migrationBuilder.RenameIndex(
                name: "IX_bookings_FlightId",
                table: "bookings",
                newName: "IX_bookings_Flight_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_dbsetflight_Flight_Id",
                table: "bookings",
                column: "Flight_Id",
                principalTable: "dbsetflight",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_registrations_Email",
                table: "bookings",
                column: "Email",
                principalTable: "registrations",
                principalColumn: "Email",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
