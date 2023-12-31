﻿// <auto-generated />
using CarApiApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarApiApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarApiApp.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Gear")
                        .HasColumnType("int");

                    b.Property<double>("Km")
                        .HasColumnType("float");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Gear = 3,
                            Km = 5.0,
                            Model = "2023",
                            Year = 2023
                        });
                });

            modelBuilder.Entity("CarApiApp.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CarApiApp.Models.Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.ToTable("Parts");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Name = "Moo",
                            Price = 90.0,
                            Quantity = 9,
                            SupplierId = 1
                        });
                });

            modelBuilder.Entity("CarApiApp.Models.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("total")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarId")
                        .IsUnique();

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("CarApiApp.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Idlib/Syria",
                            Name = "Yasmin"
                        });
                });

            modelBuilder.Entity("CarPart", b =>
                {
                    b.Property<int>("CarsId")
                        .HasColumnType("int");

                    b.Property<int>("PartsId")
                        .HasColumnType("int");

                    b.HasKey("CarsId", "PartsId");

                    b.HasIndex("PartsId");

                    b.ToTable("CarPart");
                });

            modelBuilder.Entity("CarApiApp.Models.Part", b =>
                {
                    b.HasOne("CarApiApp.Models.Supplier", null)
                        .WithMany("Part")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarApiApp.Models.Sale", b =>
                {
                    b.HasOne("CarApiApp.Models.Car", "Car")
                        .WithOne("Sale")
                        .HasForeignKey("CarApiApp.Models.Sale", "CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarApiApp.Models.Customer", "Customer")
                        .WithOne("Sale")
                        .HasForeignKey("CarApiApp.Models.Sale", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("CarPart", b =>
                {
                    b.HasOne("CarApiApp.Models.Car", null)
                        .WithMany()
                        .HasForeignKey("CarsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarApiApp.Models.Part", null)
                        .WithMany()
                        .HasForeignKey("PartsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarApiApp.Models.Car", b =>
                {
                    b.Navigation("Sale");
                });

            modelBuilder.Entity("CarApiApp.Models.Customer", b =>
                {
                    b.Navigation("Sale");
                });

            modelBuilder.Entity("CarApiApp.Models.Supplier", b =>
                {
                    b.Navigation("Part");
                });
#pragma warning restore 612, 618
        }
    }
}
