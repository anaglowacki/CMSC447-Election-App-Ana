using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace BlazorUI
{
	public class UserAddress
	{
		[Required]
		[RegularExpression(@"^[a-zA-Z''-'\s\d]{1,100}$",
		 ErrorMessage = "Characters are not allowed.")]
		public string userStreetAddress { get; set; }

		[Required]
		[Range(20601, 21930,
		ErrorMessage = "Must be a Maryland zip code.")]
		public int userZipCode { get; set; }
	}
}
