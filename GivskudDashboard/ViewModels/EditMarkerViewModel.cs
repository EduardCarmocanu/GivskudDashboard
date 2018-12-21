using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GivskudDashboard.Models;

namespace GivskudDashboard.ViewModels
{
	public class EditMarkerViewModel
	{
		public Marker Marker { get; internal set; }
		public List<MarkerType> Types { get; internal set; }
	}
}
