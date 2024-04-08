using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectionAppLibrary.Models;
//uses voterInfoQuery - candidate only obtainable with address
public class CandidateModel
{
	public string kind { get; set; }
	public string status { get; set; }
	public Election election { get; set; }
	public Normalizedinput normalizedInput { get; set; }
	public Pollinglocation[] pollingLocations { get; set; }
	public Contest[] contests { get; set; }
	public State[] state { get; set; }
}


public class Normalizedinput
{
	public string line1 { get; set; }
	public string city { get; set; }
	public string state { get; set; }
	public string zip { get; set; }
}

public class Pollinglocation
{
	public Address address { get; set; }
	public string pollingHours { get; set; }
}

public class Address
{
	public string locationName { get; set; }
	public string line1 { get; set; }
	public string line2 { get; set; }
	public string line3 { get; set; }
	public string city { get; set; }
	public string state { get; set; }
	public string zip { get; set; }
}

public class Contest
{
	public string type { get; set; }
	public string office { get; set; }
	public District district { get; set; }
	public Candidate[] candidates { get; set; }
}

public class District
{
	public string name { get; set; }
	public string scope { get; set; }
	public string id { get; set; }
}

public class Candidate
{
	public string name { get; set; }
	public string party { get; set; }
	public string email { get; set; }
	public string candidateUrl { get; set; }
	public string phone { get; set; }
}

public class State
{
	public string name { get; set; }
	public Electionadministrationbody electionAdministrationBody { get; set; }
	public Local_Jurisdiction local_jurisdiction { get; set; }
}

public class Electionadministrationbody
{
	public string name { get; set; }
	public Electionofficial[] electionOfficials { get; set; }
}

public class Electionofficial
{
	public string name { get; set; }
	public string title { get; set; }
	public string officePhoneNumber { get; set; }
	public string emailAddress { get; set; }
}

public class Local_Jurisdiction
{
	public string name { get; set; }
	public Electionadministrationbody1 electionAdministrationBody { get; set; }
}

public class Electionadministrationbody1
{
	public string name { get; set; }
	public string electionInfoUrl { get; set; }
	public Electionofficial1[] electionOfficials { get; set; }
}

public class Electionofficial1
{
	public string name { get; set; }
	public string title { get; set; }
	public string officePhoneNumber { get; set; }
	public string emailAddress { get; set; }
}

