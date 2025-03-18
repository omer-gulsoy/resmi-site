﻿using entity.Concrate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using web.Models;

namespace web.Controllers
{
    public class LoginController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;
		private readonly UserManager<AppUser> _userManager;
		public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
		{
			_signInManager = signInManager;
			_userManager = userManager;
		}
		[HttpGet]
		public IActionResult Index()
        {
            return View();
		}
		[HttpGet]
		public IActionResult Uncheck()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(LoginViewModel loginViewModel)
		{
			var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, false, false);
			if (result.Succeeded)
			{
				var user = await _userManager.FindByNameAsync(loginViewModel.UserName);
				var roles = await _userManager.GetRolesAsync(user);
				if (roles.Contains("ADMIN"))
				{
					return RedirectToAction("Index", "Home", new { area = "Admin" });
				}
				else
				{
					return RedirectToAction("Index", "Login");
				}
			}
			return View();
		}
	}
}
