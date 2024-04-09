using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ElectionAppLibrary.Models
{
	public class UserModel
	{
		public string username { get; set; }
		public string password { get; set; }
		[EmailAddress(ErrorMessage = "Characters are not allowed.")]
		public string? email { get; set; }
		public string? address { get; set; }
	}
}
