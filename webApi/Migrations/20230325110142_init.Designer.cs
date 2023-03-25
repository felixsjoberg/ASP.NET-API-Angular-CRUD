﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webApi.Data;

#nullable disable

namespace webApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230325110142_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("webApi.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AccountId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("accounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountType = "Domestic",
                            DateCreated = new DateTime(2003, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OwnerId = 1
                        },
                        new
                        {
                            Id = 2,
                            AccountType = "Domestic",
                            DateCreated = new DateTime(1996, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OwnerId = 2
                        },
                        new
                        {
                            Id = 3,
                            AccountType = "Domestic",
                            DateCreated = new DateTime(1999, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OwnerId = 3
                        },
                        new
                        {
                            Id = 4,
                            AccountType = "Savings",
                            DateCreated = new DateTime(1999, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OwnerId = 3
                        },
                        new
                        {
                            Id = 5,
                            AccountType = "Domestic",
                            DateCreated = new DateTime(2010, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OwnerId = 4
                        },
                        new
                        {
                            Id = 6,
                            AccountType = "Foreign",
                            DateCreated = new DateTime(1999, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OwnerId = 3
                        },
                        new
                        {
                            Id = 7,
                            AccountType = "Foreign",
                            DateCreated = new DateTime(1996, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OwnerId = 2
                        },
                        new
                        {
                            Id = 8,
                            AccountType = "Foreign",
                            DateCreated = new DateTime(2010, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OwnerId = 4
                        });
                });

            modelBuilder.Entity("webApi.Models.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OwnerId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("owners");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Main St",
                            DateOfBirth = new DateTime(1978, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "John Doe"
                        },
                        new
                        {
                            Id = 2,
                            Address = "456 Elm St",
                            DateOfBirth = new DateTime(1985, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Jane Smith"
                        },
                        new
                        {
                            Id = 3,
                            Address = "789 Oak St",
                            DateOfBirth = new DateTime(1970, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Bob Johnson"
                        },
                        new
                        {
                            Id = 4,
                            Address = "1010 Maple Ave",
                            DateOfBirth = new DateTime(1992, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Sarah Lee"
                        });
                });

            modelBuilder.Entity("webApi.Models.Account", b =>
                {
                    b.HasOne("webApi.Models.Owner", "Owner")
                        .WithMany("Accounts")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("webApi.Models.Owner", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
