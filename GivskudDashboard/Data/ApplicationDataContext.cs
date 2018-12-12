using GivskudDashboard.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GivskudDashboard.Data
{
	public class ApplicationDataContext : DbContext
	{
		public DbSet<Marker> Markers { get; set; }
		public DbSet<Description> Descriptions { get; set; }
		public DbSet<MarkerType> MarkerTypes { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Marker>(e =>
			{
				e.Property(m => m.Lat).HasColumnType("decimal(18, 15)");
				e.Property(m => m.Lng).HasColumnType("decimal(18, 15)");
			});
			modelBuilder.Entity<MarkerType>().HasData(
					new MarkerType() { ID = 1, Name = "Animal" },
					new MarkerType() { ID = 2, Name = "Shop" },
					new MarkerType() { ID = 3, Name = "Accommodation" },
					new MarkerType() { ID = 4, Name = "Toilet" },
					new MarkerType() { ID = 5, Name = "Restaurant" },
					new MarkerType() { ID = 6, Name = "Playground" },
					new MarkerType() { ID = 7, Name = "Picknick" },
					new MarkerType() { ID = 8, Name = "Icecream" },
					new MarkerType() { ID = 9, Name = "Parking" }
				);
		}

		public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
		{
			Database.EnsureCreated();
		}
	}
}
