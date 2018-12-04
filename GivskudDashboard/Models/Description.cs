using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GivskudDashboard.Models
{
	public class Description
	{
		public int ID { get; set; }

		[Required]
		[MaxLength(64, ErrorMessage = "Title can be maximum 64 characters long")]
		[Display(Name = "Description Title")]
		public string Title { get; set; }

		[Required]
		[MaxLength(255, ErrorMessage = "Title can be maximum 255 characters long")]
		[Display(Name = "Marker Location")]
		public string Location { get; set; }

		[DataType(DataType.DateTime)]
		[Display(Name = "Feeding Time")]
		public DateTime? FeedingTime { get; set; }

		[Required]
		[MaxLength(7168, ErrorMessage = "Body can be maximum 7168 characters long")]
		[Display(Name = "Description Body")]
		public string Body { get; set; }
	}
}
