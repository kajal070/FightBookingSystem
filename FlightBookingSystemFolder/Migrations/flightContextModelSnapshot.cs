﻿// <auto-generated />
using System;
using FlightBookingSystemFolder.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlightBookingSystemFolder.Migrations
{
    [DbContext(typeof(flightContext))]
    partial class flightContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FlightBookingSystemFolder.Models.Booking", b =>
                {
                    b.Property<int>("Booking_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Booking_id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("FlightId")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Passenger_Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Passport_No")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("ReferenceNo")
                        .HasColumnType("int");

                    b.HasKey("Booking_id");

                    b.HasIndex("Email");

                    b.HasIndex("FlightId");

                    b.ToTable("bookings");
                });

            modelBuilder.Entity("FlightBookingSystemFolder.Models.CheckIn", b =>
                {
                    b.Property<int>("Booking_id")
                        .HasColumnType("int");

                    b.Property<int>("Check_Id")
                        .HasColumnType("int")
                        .HasColumnName("CheckInId");

                    b.Property<int>("Seat_Allocation")
                        .HasColumnType("int");

                    b.HasKey("Booking_id");

                    b.ToTable("checkIns");
                });

            modelBuilder.Entity("FlightBookingSystemFolder.Models.Flight", b =>
                {
                    b.Property<int>("Flight_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("FlightId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Flight_Id"));

                    b.Property<DateTime>("DateAndTime")
                        .HasColumnType("datetime2");

                    b.Property<float>("Fare")
                        .HasColumnType("real");

                    b.Property<string>("From")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Flight");

                    b.Property<string>("To")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("seatAvailable")
                        .HasColumnType("int");

                    b.HasKey("Flight_Id");

                    b.ToTable("dbsetflight");
                });

            modelBuilder.Entity("FlightBookingSystemFolder.Models.Registration", b =>
                {
                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email");

                    b.ToTable("registrations");
                });

            modelBuilder.Entity("FlightBookingSystemFolder.Models.Booking", b =>
                {
                    b.HasOne("FlightBookingSystemFolder.Models.Registration", "Registration")
                        .WithMany("Bookings")
                        .HasForeignKey("Email")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Book__Registration_I__1273C1CD");

                    b.HasOne("FlightBookingSystemFolder.Models.Flight", "Flight")
                        .WithMany("Booking")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flight");

                    b.Navigation("Registration");
                });

            modelBuilder.Entity("FlightBookingSystemFolder.Models.CheckIn", b =>
                {
                    b.HasOne("FlightBookingSystemFolder.Models.Booking", "Booking")
                        .WithOne("CheckIn")
                        .HasForeignKey("FlightBookingSystemFolder.Models.CheckIn", "Booking_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("FlightBookingSystemFolder.Models.Booking", b =>
                {
                    b.Navigation("CheckIn")
                        .IsRequired();
                });

            modelBuilder.Entity("FlightBookingSystemFolder.Models.Flight", b =>
                {
                    b.Navigation("Booking");
                });

            modelBuilder.Entity("FlightBookingSystemFolder.Models.Registration", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
