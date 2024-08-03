﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelAgency.Data;

#nullable disable

namespace TravelAgency.Migrations
{
    [DbContext(typeof(TravelAgencyContext))]
    [Migration("20240803063800_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TravelAgency.Data.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("BookingDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<int>("TourPackageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerID");

                    b.HasIndex("TourPackageId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("TravelAgency.Data.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("TravelAgency.Data.Models.Guide", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Language")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Guide");
                });

            modelBuilder.Entity("TravelAgency.Data.Models.TourPackage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PackageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("TourPackage");
                });

            modelBuilder.Entity("TravelAgency.Data.Models.TourPackageGuide", b =>
                {
                    b.Property<int>("GuideId")
                        .HasColumnType("int");

                    b.Property<int>("TourPackageId")
                        .HasColumnType("int");

                    b.HasKey("GuideId", "TourPackageId");

                    b.HasIndex("GuideId")
                        .IsUnique();

                    b.HasIndex("TourPackageId");

                    b.ToTable("TourPackageGuide");
                });

            modelBuilder.Entity("TravelAgency.Data.Models.Booking", b =>
                {
                    b.HasOne("TravelAgency.Data.Models.Customer", "Customer")
                        .WithMany("Bookings")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAgency.Data.Models.TourPackage", "TourPackage")
                        .WithMany("Bookings")
                        .HasForeignKey("TourPackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("TourPackage");
                });

            modelBuilder.Entity("TravelAgency.Data.Models.TourPackageGuide", b =>
                {
                    b.HasOne("TravelAgency.Data.Models.Guide", "Guide")
                        .WithOne("TourPackageGuide")
                        .HasForeignKey("TravelAgency.Data.Models.TourPackageGuide", "GuideId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAgency.Data.Models.TourPackage", "TourPackage")
                        .WithMany("TourPackageGuides")
                        .HasForeignKey("TourPackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guide");

                    b.Navigation("TourPackage");
                });

            modelBuilder.Entity("TravelAgency.Data.Models.Customer", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("TravelAgency.Data.Models.Guide", b =>
                {
                    b.Navigation("TourPackageGuide")
                        .IsRequired();
                });

            modelBuilder.Entity("TravelAgency.Data.Models.TourPackage", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("TourPackageGuides");
                });
#pragma warning restore 612, 618
        }
    }
}
