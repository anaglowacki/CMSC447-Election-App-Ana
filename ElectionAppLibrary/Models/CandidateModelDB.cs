using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectionAppLibrary.Models
{
	public class CandidateModelDB
	{
		public int Id { get; }
		public string OfficeName { get; set; }
		public string DistrictNameAndNumber { get; set; }
		public string CandidateLastName { get; set; }
		public string CandidateFirstName { get; set; }
		public string PoliticalParty { get; set; }
		public string CandidateStatus { get; set; }
		public string? PublicPhone { get; set; }
		public string? Email { get; set; }
		public string? Website { get; set; }
		public string? Facebook { get; set; }
		public string? Twitter { get; set; }
		public string? Other { get; set; }
	}
}
