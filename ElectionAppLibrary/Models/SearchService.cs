using BlazorUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectionAppLibrary.Models
{
	public class SearchService
	{
		public string? SearchData { get; set; }
		public UserAddress UserAddress { get; set; }

        public SearchService()
        {
            UserAddress = new UserAddress();
        }

        public void ParseAddress()
		{

			if (!string.IsNullOrWhiteSpace(SearchData))
			{
				string[] parts = SearchData.Split(',');

				if (parts.Length == 2)
				{
					UserAddress.userStreetAddress = parts[0].Trim();
					int zipCode;
					if (int.TryParse(parts[1].Trim(), out zipCode))
					{
						UserAddress.userZipCode = zipCode;
					}
					else
					{
						throw new ArgumentException("Invalid zip code format");
					}
				}
				else
				{
					throw new ArgumentException("Invalid address format");
				}
			}
			else
			{
				throw new ArgumentNullException(nameof(SearchData), "Search data cannot be null or empty");
			}
		}
	}
}
