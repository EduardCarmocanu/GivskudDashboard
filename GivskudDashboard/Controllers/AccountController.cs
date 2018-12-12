using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GivskudDashboard.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GivskudDashboard.Controllers
{
    public class AccountController : Controller
    {
		private readonly SignInManager<IdentityUser> _signInManager;

		public AccountController(
			SignInManager<IdentityUser> signInManager
		)
		{
			_signInManager = signInManager;
		}
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginViewModel login, string returnUrl = null)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			var result = await _signInManager.PasswordSignInAsync(
					login.EmailAddress, 
					login.Password, 
					login.RememberMe, 
					false
				);

			if (!result.Succeeded)
			{
				ModelState.AddModelError("", "Login Error");
				return View();
			}

			if (string.IsNullOrWhiteSpace(returnUrl))
			{
				return RedirectToAction("Index", "Markers");
			}

			return Redirect(returnUrl);
		}

		[HttpPost]
		public async Task<IActionResult> Logout(string returnUrl = null)
		{
			await _signInManager.SignOutAsync();

			if (string.IsNullOrWhiteSpace(returnUrl))
			{
				return RedirectToAction("Index", "Markers");
			}

			return Redirect(returnUrl);
		}
    }
}