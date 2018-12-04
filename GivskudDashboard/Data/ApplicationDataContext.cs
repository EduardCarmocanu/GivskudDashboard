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

		public ApplicationDataContext(DbContextOptions options) : base(options)
		{
			Database.EnsureCreated();
		}
	}
}
