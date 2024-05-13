using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectionAppLibrary.Models;
//uses voterInfoQuery - candidate only obtainable with address

public class CandidateModel
{
	public Election election { get; set; }
	public Normalizedinput normalizedInput { get; set; }
	public Pollinglocation[] pollingLocations { get; set; }
	public Earlyvotesite[] earlyVoteSites { get; set; }
	public Dropofflocation[] dropOffLocations { get; set; }
	public Contest[] contests { get; set; }
	public State[] state { get; set; }
	public string kind { get; set; }
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
	public float latitude { get; set; }
	public float longitude { get; set; }
	public string startDate { get; set; }
	public string endDate { get; set; }
	public Source[] sources { get; set; }
}

public class Address
{
	public string locationName { get; set; }
	public string line1 { get; set; }
	public string city { get; set; }
	public string state { get; set; }
	public string zip { get; set; }
}

public class Source
{
	public string name { get; set; }
	public bool official { get; set; }
}

public class Earlyvotesite
{
	public Address1 address { get; set; }
	public string pollingHours { get; set; }
	public float latitude { get; set; }
	public float longitude { get; set; }
	public string startDate { get; set; }
	public string endDate { get; set; }
	public Source1[] sources { get; set; }
}

public class Address1
{
	public string locationName { get; set; }
	public string line1 { get; set; }
	public string city { get; set; }
	public string state { get; set; }
	public string zip { get; set; }
}

public class Source1
{
	public string name { get; set; }
	public bool official { get; set; }
}

public class Dropofflocation
{
	public Address2 address { get; set; }
	public string pollingHours { get; set; }
	public float latitude { get; set; }
	public float longitude { get; set; }
	public string startDate { get; set; }
	public string endDate { get; set; }
	public Source2[] sources { get; set; }
}

public class Address2
{
	public string locationName { get; set; }
	public string line1 { get; set; }
	public string line2 { get; set; }
	public string city { get; set; }
	public string state { get; set; }
	public string zip { get; set; }
}

public class Source2
{
	public string name { get; set; }
	public bool official { get; set; }
}

public class Contest
{
	public string type { get; set; }
	public string office { get; set; }
	public District district { get; set; }
	public string numberVotingFor { get; set; }
	public string ballotPlacement { get; set; }
	public Source3[] sources { get; set; }
	public Candidate[] candidates { get; set; }
	public string[] level { get; set; }
}

public class District
{
	public string name { get; set; }
	public string scope { get; set; }
}

public class Source3
{
	public string name { get; set; }
	public bool official { get; set; }
}

public class Candidate
{
	public string name { get; set; }
}

public class State
{
	public string name { get; set; }
	public Electionadministrationbody electionAdministrationBody { get; set; }
	public Local_Jurisdiction local_jurisdiction { get; set; }
	public Source5[] sources { get; set; }
}

public class Electionadministrationbody
{
	public string name { get; set; }
	public string electionInfoUrl { get; set; }
	public string electionRegistrationUrl { get; set; }
	public string electionRegistrationConfirmationUrl { get; set; }
	public string absenteeVotingInfoUrl { get; set; }
	public string votingLocationFinderUrl { get; set; }
	public string ballotInfoUrl { get; set; }
	public string electionRulesUrl { get; set; }
	public Physicaladdress physicalAddress { get; set; }
}

public class Physicaladdress
{
	public string locationName { get; set; }
	public string line1 { get; set; }
	public string city { get; set; }
	public string state { get; set; }
	public string zip { get; set; }
}

public class Local_Jurisdiction
{
	public string name { get; set; }
	public Electionadministrationbody1 electionAdministrationBody { get; set; }
	public Source4[] sources { get; set; }
}

public class Electionadministrationbody1
{
	public string name { get; set; }
	public string electionInfoUrl { get; set; }
	public string electionRegistrationUrl { get; set; }
	public string electionRegistrationConfirmationUrl { get; set; }
	public string absenteeVotingInfoUrl { get; set; }
	public string votingLocationFinderUrl { get; set; }
	public string ballotInfoUrl { get; set; }
	public string electionRulesUrl { get; set; }
	public Physicaladdress1 physicalAddress { get; set; }
}

public class Physicaladdress1
{
	public string locationName { get; set; }
	public string line1 { get; set; }
	public string city { get; set; }
	public string state { get; set; }
	public string zip { get; set; }
}

public class Source4
{
	public string name { get; set; }
	public bool official { get; set; }
}

public class Source5
{
	public string name { get; set; }
	public bool official { get; set; }
}


