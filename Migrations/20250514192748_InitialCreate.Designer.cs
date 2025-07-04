﻿
// This code file was auto-generated by Entity Framework Core as part of the migration process.
// It defines the model snapshot for the current state of the application's database schema.

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
    // This attribute links the migration to the AppDbContext
    [DbContext(typeof(AppDbContext))]
    
    // This class represents the model snapshot after applying the "InitialCreate" migration
    [Migration("20250514192748_InitialCreate")]
    partial class InitialCreate
    {
        /// <summary>
        /// This method builds the target model using Fluent API configuration to define entity structure and relationships.
        /// </summary>
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            // Add metadata about EF Core version and PostgreSQL max identifier length
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            // Configure default identity generation strategy for PostgreSQL (serial/identity columns)
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            // Define the Employee entity model
            modelBuilder.Entity("AgriEnergyConnectWebApp.Models.Employee", b =>
                {
                    // Primary key with auto-increment
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EmployeeId"));

                    // Required email field
                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    // Required full name field
                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    // Required password hash field
                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    // Set primary key
                    b.HasKey("EmployeeId");

                    // Map to table "Employees"
                    b.ToTable("Employees");
                });

            // Define the Farmer entity model
            modelBuilder.Entity("AgriEnergyConnectWebApp.Models.Farmer", b =>
                {
                    b.Property<int>("FarmerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FarmerId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("FarmerId");

                    b.ToTable("Farmers");
                });

            // Define the Product entity model
            modelBuilder.Entity("AgriEnergyConnectWebApp.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProductId"));

                    // Required product category
                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text");

                    // Foreign key to Farmer
                    b.Property<int>("FarmerId")
                        .HasColumnType("integer");

                    // Required product name
                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    // Production date (with time zone support)
                    b.Property<DateTime>("ProductionDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ProductId");

                    // Index on foreign key for optimized queries
                    b.HasIndex("FarmerId");

                    b.ToTable("Products");
                });

            // Define the relationship: each Product is linked to one Farmer
            modelBuilder.Entity("AgriEnergyConnectWebApp.Models.Product", b =>
                {
                    b.HasOne("AgriEnergyConnectWebApp.Models.Farmer", "Farmer")
                        .WithMany("Products") // One-to-many: a farmer can have many products
                        .HasForeignKey("FarmerId")
                        .OnDelete(DeleteBehavior.Cascade) // Cascade delete
                        .IsRequired();

                    b.Navigation("Farmer");
                });

            // Navigation property configuration: A Farmer has many Products
            modelBuilder.Entity("AgriEnergyConnectWebApp.Models.Farmer", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
