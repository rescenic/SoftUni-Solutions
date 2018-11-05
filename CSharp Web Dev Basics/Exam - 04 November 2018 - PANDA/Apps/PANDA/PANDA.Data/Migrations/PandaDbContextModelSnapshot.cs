﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PANDA.Data;

namespace PANDA.Data.Migrations
{
    [DbContext(typeof(PandaDbContext))]
    partial class PandaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PANDA.Models.Package", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime?>("EstimatedDeliveryDate");

                    b.Property<string>("RecipientId");

                    b.Property<string>("ShippingAddress");

                    b.Property<int>("Status");

                    b.Property<decimal>("Weight");

                    b.HasKey("Id");

                    b.HasIndex("RecipientId");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("PANDA.Models.Receipt", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Fee");

                    b.Property<DateTime>("IssuedOn");

                    b.Property<string>("PackageId");

                    b.Property<string>("RecipientId");

                    b.HasKey("Id");

                    b.HasIndex("PackageId")
                        .IsUnique()
                        .HasFilter("[PackageId] IS NOT NULL");

                    b.HasIndex("RecipientId");

                    b.ToTable("Receipts");
                });

            modelBuilder.Entity("PANDA.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<int>("Role");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PANDA.Models.Package", b =>
                {
                    b.HasOne("PANDA.Models.User", "Recipient")
                        .WithMany("Packages")
                        .HasForeignKey("RecipientId");
                });

            modelBuilder.Entity("PANDA.Models.Receipt", b =>
                {
                    b.HasOne("PANDA.Models.Package", "Package")
                        .WithOne("Receipt")
                        .HasForeignKey("PANDA.Models.Receipt", "PackageId");

                    b.HasOne("PANDA.Models.User", "Recipient")
                        .WithMany("Receipts")
                        .HasForeignKey("RecipientId");
                });
#pragma warning restore 612, 618
        }
    }
}
