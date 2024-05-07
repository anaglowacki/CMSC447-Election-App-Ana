using ElectionAppLibrary.Models;

namespace ElectionAppLibrary.DataAccess
{
	public interface IVoterInfoAPI
	{
		Task<CandidateModel?> getVoterInfo(string address);
	}
}