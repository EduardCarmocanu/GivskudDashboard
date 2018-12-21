using System.Collections.Generic;
using GivskudDashboard.Models;

namespace GivskudDashboard.ViewModels
{
	public class CreateMarkerViewModel
	{
		public List<MarkerType> Types { get; set; }
		public Marker Marker { get; set; }
	}
}