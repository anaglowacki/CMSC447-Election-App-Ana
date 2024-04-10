using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectionAppLibrary.Models
{
    public class RepModelDB
    {
        public string name { get; set; }
        public string party { get; set; }
        public string? phones { get; set;}
        public string? urls { get; set; }
        public string? emails { get; set;}
        public string office { get; set;}
        public string? photoURL {  get; set;}
        public string divisionId { get; set; }

        public List<RepModelDB> ConvertRep(RepresentativeModel representative)
        {
            List<RepModelDB> repModels = new List<RepModelDB>();
            for (int j = 0; j < representative.offices.Length; ++j)
            {
                for (int i = 0; i < representative.offices[j].officialIndices.Length; ++i)
                {
                    string phone = "", url = "", email = "";
                    if (representative.officials[i].phones != null)
                    {
                        phone = String.Join("\n", representative.officials[i].phones);
                    }
                    if (representative.officials[i].urls != null)
                    {
                        url = String.Join("\n", representative.officials[i].urls);
                    }
                    if (representative.officials[i].emails != null)
                    {
                        email = String.Join("\n", representative.officials[i].emails);
                    }
                    repModels.Add(new RepModelDB
                    {
                        name = representative.officials[representative.offices[j].officialIndices[i]].name,
                        party = representative.officials[representative.offices[j].officialIndices[i]].party,
                        phones = phone,
                        urls = url,
                        emails = email,
                        office = representative.offices[j].name,
                        photoURL = representative.officials[representative.offices[j].officialIndices[i]].photoUrl,
                        divisionId = representative.offices[i].divisionId
                    });
                }
            }
            

            return repModels;
        }
    }
}
