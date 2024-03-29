﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GivskudDashboard.ViewModels
{
	public class LoginViewModel
	{
		[Required]
		[EmailAddress, MaxLength(500)]
		[Display(Name = "Email Address")]
		public string EmailAddress { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "Remember me")]
		public bool RememberMe { get; set; }

	}
}
