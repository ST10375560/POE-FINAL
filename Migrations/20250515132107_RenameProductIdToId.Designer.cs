using System;
using AgriEnergyConnectWebApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AgriEnergyConnectWebApp.Migrations
{
    // Associates this migration snapshot with the AppDbContext
    [DbContext(typeof(AppDbContext))]
    [Migration("20250515132107_RenameProductIdToId")]
    partial class RenameProductIdToId
    {
        /// <summary>
        /// Describes the target model for the application after the migration is applied.
        /// This method is used by EF Core to track schema changes.
        /// </summary>
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            // Add general model annotations
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            // Use PostgreSQL identity columns (auto-incrementing primary keys)
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            // ------------------ Employee Entity ------------------
            modelBuilder.Entity("AgriEnergyConnectWebApp.Models.Employee", b =>
                {
                    // Primary key for Employee
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");
                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EmployeeId"));

                    // Required Email field
                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    // Required Full Name field
                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    // Required hashed password
                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    // Set primary key
                    b.HasKey("EmployeeId");

                    // Map to "Employees" table
                    b.ToTable("Employees");
                });

            // ------------------ Farmer Entity ------------------
            modelBuilder.Entity("AgriEnergyConnectWebApp.Models.Farmer", b =>
                {
                    // Primary key for Farmer
                    b.Property<int>("FarmerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");
                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FarmerId"));

                    // Required Email field
                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    // Required Full Name field
                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    // Required hashed password
                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    // Set primary key
                    b.HasKey("FarmerId");

                    // Map to "Farmers" table
                    b.ToTable("Farmers");
                });

            // ------------------ Product Entity ------------------
            modelBuilder.Entity("AgriEnergyConnectWebApp.Models.Product", b =>
                {
                    // Primary key renamed from ProductId to Id
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");
                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    // Category field with max length 50
                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    // Foreign key referencing the Farmer
                    b.Property<int>("FarmerId")
                        .HasColumnType("integer");

                    // Product Name with max length 100
                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    // Production date with timezone
                    b.Property<DateTime>("ProductionDate")
                        .HasColumnType("timestamp with time zone");

                    // Set primary key
                    b.HasKey("Id");

                    // Add index on FarmerId for faster lookups
                    b.HasIndex("FarmerId");

                    // Map to "Products" table
                    b.ToTable("Products");
                });

            // ------------------ Product -> Farmer Relationship ------------------
            modelBuilder.Entity("AgriEnergyConnectWebApp.Models.Product", b =>
                {
                    // Establish relationship: Each Product belongs to one Farmer
                    b.HasOne("AgriEnergyConnectWebApp.Models.Farmer", "Farmer")
                        .WithMany("Products") // A Farmer can have many Products
                        .HasForeignKey("FarmerId")
                        .OnDelete(DeleteBehavior.Cascade) // Cascade delete behavior
                        .IsRequired();

                    // Navigation property
                    b.Navigation("Farmer");
                });

            // ------------------ Farmer Navigation ------------------
            modelBuilder.Entity("AgriEnergyConnectWebApp.Models.Farmer", b =>
                {
                    // Navigation collection: A Farmer has many Products
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
