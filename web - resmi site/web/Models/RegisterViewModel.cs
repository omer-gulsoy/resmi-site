using System.ComponentModel.DataAnnotations;

namespace web.Models
{
	public class RegisterViewModel
	{

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[StringLength(100, ErrorMessage = "Şifre en az {2} karakter olmalı.", MinimumLength = 6)]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Şifreler uyuşmuyor.")]
		public string ConfirmPassword { get; set; }
	}
}
