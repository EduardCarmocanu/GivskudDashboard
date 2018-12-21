using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GivskudDashboard.Models;

namespace GivskudDashboard.ViewModels
{
	public class OverviewViewModel
	{
		public decimal? Lat { get; internal set; }
		public decimal? Lng { get; internal set; }
		public Marker[] Markers { get; internal set; }
		public Marker ActiveMarker { get; internal set; }
		public MarkerType[] Types { get; internal set; }
	}
}
