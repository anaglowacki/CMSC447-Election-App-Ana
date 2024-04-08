using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectionAppLibrary.Models;
//uses electionQuery
public class ElectionModel
{
	public Election[] elections { get; set; }
	public string kind { get; set; }
}

public class Election
{
	public string id { get; set; }
	public string name { get; set; }
	public string electionDay { get; set; }
	public string ocdDivisionId { get; set; }
}
