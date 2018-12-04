using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GivskudDashboard.Models
{
	public class Marker
	{
		public int ID { get; set; }
		[Required]
		[MaxLength(64)]
		[Display(Name = "Marker Title")]
		public string Title { get; set; }
		[Required]
		[Display(Name = "Latitude")]
		public decimal Lat { get; set; }
		[Required]
		[Display(Name = "Longitude")]
		public decimal Lng { get; set; }
		[Required]
		public Description Description { get; set; }
		[Required]
		[Display(Name = "Marker Type")]
		public int MarkerTypeID { get; set; }
	}
}
