using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GivskudDashboard.Data
{
	public static class IdentityDbInitializer
	{
		public static void SeedUsers(UserManager<IdentityUser> userManger)
		{
			if (userManger.FindByEmailAsync("staff@givskud.zoo").Result == null)
			{
				IdentityUser user = new IdentityUser
				{
					UserName = "staff@givskud.zoo",
					Email = "staff@givskud.zoo"
				};

				IdentityResult result = userManger.CreateAsync(user, "Givskud2018!").Result;
			}
		}
	}
}
