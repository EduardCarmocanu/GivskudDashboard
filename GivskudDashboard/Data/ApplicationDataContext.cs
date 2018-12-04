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
		}

		public ApplicationDataContext(DbContextOptions options) : base(options)
		{
			Database.EnsureCreated();
		}
	}
}
