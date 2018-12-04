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
		public string Title { get; set; }
		[Required]
		public decimal Lat { get; set; }
		[Required]
		public decimal Lng { get; set; }
		[Required]
		public Description Description { get; set; }
		[Required]
		public int MarkerTypeID { get; set; }
	}
}
