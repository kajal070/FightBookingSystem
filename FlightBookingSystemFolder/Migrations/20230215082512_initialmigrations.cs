using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightBookingSystemFolder.Migrations
{
    /// <inheritdoc />
    public partial class initialmigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dbsetflight",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Flight = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    To = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    From = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fare = table.Column<float>(type: "real", nullable: false),
                    seatAvailable = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbsetflight", x => x.FlightId);
                });

            migrationBuilder.CreateTable(
                name: "registrations",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registrations", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "bookings",
                columns: table => new
                {
                    Bookingid = table.Column<int>(name: "Booking_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PassengerName = table.Column<string>(name: "Passenger_Name", type: "nvarchar(30)", maxLength: 30, nullable: false),
                    City = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PassportNo = table.Column<string>(name: "Passport_No", type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    ReferenceNo = table.Column<int>(type: "int", nullable: false),
                    FlightId = table.Column<int>(name: "Flight_Id", type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookings", x => x.Bookingid);
                    table.ForeignKey(
                        name: "FK_bookings_dbsetflight_Flight_Id",
                        column: x => x.FlightId,
                        principalTable: "dbsetflight",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookings_registrations_Email",
                        column: x => x.Email,
                        principalTable: "registrations",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "checkIns",
                columns: table => new
                {
                    Bookingid = table.Column<int>(name: "Booking_id", type: "int", nullable: false),
                    CheckInId = table.Column<int>(type: "int", nullable: false),
                    SeatAllocation = table.Column<int>(name: "Seat_Allocation", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_checkIns", x => x.Bookingid);
                    table.ForeignKey(
                        name: "FK_checkIns_bookings_Booking_id",
                        column: x => x.Bookingid,
                        principalTable: "bookings",
                        principalColumn: "Booking_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookings_Email",
                table: "bookings",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_Flight_Id",
                table: "bookings",
                column: "Flight_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "checkIns");

            migrationBuilder.DropTable(
                name: "bookings");

            migrationBuilder.DropTable(
                name: "dbsetflight");

            migrationBuilder.DropTable(
                name: "registrations");
        }
    }
}
