using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GivskudApi.Models
{
	public class Description
	{
		public int ID { get; set; }

		[Required]
		[MaxLength(64, ErrorMessage = "Title can be maximum 64 characters long")]
		public string Title { get; set; }

		[Required]
		[MaxLength(255, ErrorMessage = "Title can be maximum 255 characters long")]
		public string Location { get; set; }

		[DataType(DataType.DateTime)]
		public DateTime? FeedingTime { get; set; }

		[Required]
		[MaxLength(7168, ErrorMessage = "Body can be maximum 7168 characters long")]
		public string Body { get; set; }
	}
}
