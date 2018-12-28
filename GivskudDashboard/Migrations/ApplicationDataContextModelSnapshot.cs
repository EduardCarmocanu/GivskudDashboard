﻿// <auto-generated />
using System;
using GivskudDashboard.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GivskudDashboard.Migrations
{
    [DbContext(typeof(MarkersDataContext))]
    partial class ApplicationDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GivskudDashboard.Models.Description", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(7168);

                    b.Property<DateTime?>("FeedingTime");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.HasKey("ID");

                    b.ToTable("Descriptions");
                });

            modelBuilder.Entity("GivskudDashboard.Models.Marker", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DescriptionID");

                    b.Property<decimal>("Lat")
                        .HasColumnType("decimal(18, 15)");

                    b.Property<decimal>("Lng")
                        .HasColumnType("decimal(18, 15)");

                    b.Property<int>("MarkerTypeID");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.HasKey("ID");

                    b.HasIndex("DescriptionID");

                    b.ToTable("Markers");
                });

            modelBuilder.Entity("GivskudDashboard.Models.MarkerType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("MarkerTypes");

                    b.HasData(
                        new { ID = 1, Name = "Animal" },
                        new { ID = 2, Name = "Shop" },
                        new { ID = 3, Name = "Accommodation" },
                        new { ID = 4, Name = "Toilet" },
                        new { ID = 5, Name = "Restaurant" },
                        new { ID = 6, Name = "Playground" },
                        new { ID = 7, Name = "Picknick" },
                        new { ID = 8, Name = "Icecream" },
                        new { ID = 9, Name = "Parking" }
                    );
                });

            modelBuilder.Entity("GivskudDashboard.Models.Marker", b =>
                {
                    b.HasOne("GivskudDashboard.Models.Description", "Description")
                        .WithMany()
                        .HasForeignKey("DescriptionID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
