using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectionAppLibrary.Models;
//Uses representativeByDivision
public class RepresentativeModel
{
	public Office[] offices { get; set; }
	public Official[] officials { get; set; }
	public Divisions divisions { get; set; }
}

public class Divisions
{
	public OcdDivisionCountryUsStateMd ocddivisioncountryusstatemd { get; set; }
}

public class OcdDivisionCountryUsStateMd
{
	public string name { get; set; }
	public int[] officeIndices { get; set; }
}

public class Office
{
	public string name { get; set; }
	public string divisionId { get; set; }
	public string[] levels { get; set; }
	public string[] roles { get; set; }
	public int[] officialIndices { get; set; }
}

public class Official
{
	public string name { get; set; }
	public string party { get; set; }
	public string[] phones { get; set; }
	public string[] urls { get; set; }
	public string photoUrl { get; set; }
	public Channel[] channels { get; set; }
	public string[] emails { get; set; }
}


public class Channel
{
	public string type { get; set; }
	public string id { get; set; }
}

