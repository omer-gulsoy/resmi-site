﻿using System.ComponentModel.DataAnnotations;

namespace web.Models
{
	public class LoginViewModel
	{
		public string? UserName { get; set; }
		public string? Password { get; set; }
	}
}
