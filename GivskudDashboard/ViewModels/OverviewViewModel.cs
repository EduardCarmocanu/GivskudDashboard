using GivskudDashboard.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GivskudDashboard.ViewModels
{
	public class OverviewViewModel
	{
		public MarkerType ActiveMarkerType { get; set; }
		public Marker ActiveMarker { get; set; }
		public Marker[] MarkersList { get; set; }
	}
}
