using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using ElectionAppLibrary.Models;

namespace ElectionAppLibrary.DataAccess
{
	public class VoterInfoAPI : IVoterInfoAPI
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public VoterInfoAPI(IHttpClientFactory httpClientFactory) =>
		_httpClientFactory = httpClientFactory;

		public async Task<CandidateModel?> getVoterInfo(string address)
		{
			address = address.Replace(",", "%2C");
			address = address.Replace(" ", "%20");
			var httpClient = _httpClientFactory.CreateClient("VoterInfo");
			try
			{
				var info = await httpClient.GetFromJsonAsync<CandidateModel>($"?address={address}&key=AIzaSyDRPOb2Wy4TIGZ2HcSuXLxxuIoNytPGIzE");
				return info;

			}
			catch (Exception ex)
			{
				return null;
			}

		}
	}
}
