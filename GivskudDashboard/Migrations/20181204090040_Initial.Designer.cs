// <auto-generated />
using System;
using GivskudDashboard.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GivskudDashboard.Migrations
{
    [DbContext(typeof(ApplicationDataContext))]
    [Migration("20181204090040_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<decimal>("Lat");

                    b.Property<decimal>("Lng");

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
