using System.Collections.Generic;
using GivskudDashboard.Models;

namespace GivskudDashboard.ViewModels
{
	public class AllMarkersViewModel
	{	
		public List<Marker> Markers { get; internal set; }
		public MarkerType[] Types { get; internal set; }
		public string[] ColumnTitles { get; internal set; }
	}
}