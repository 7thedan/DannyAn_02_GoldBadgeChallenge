using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02RepositoryPattern_Repository
{
    public enum ClaimType
    {
        Car = 1,
        Home = 2,
        Theft = 3

    }

    public class Claim
    {
        public int ClaimID { get; set; }
        public string ClaimType { get; set; }
        public string Description { get; set; }
        public string ClaimAmount { get; set; }
        public string DateOfIncident { get; set; }
        public string DateOfClaim { get; set; }
        public bool IsValid { get; set; }
        public bool DealWithClaim {get; set; }

        public Claim() { }

        public Claim(int claim_id, string claim_type, string description, string claimamount, string dateofincident, string dateofclaim, bool dealwithclaim,bool isvalid)
        {
            ClaimID = claim_id;
            ClaimType = claim_type;
            Description = description;
            ClaimAmount = claimamount;
            DateOfIncident = dateofincident;
            DateOfClaim = dateofclaim;
            DealWithClaim = dealwithclaim;
            IsValid = isvalid;

        }
    }

    // Claim represent the abstract mould -> 1 single claim object
    // ClaimRepositoryy (list of Claims)
    // Claim class -> 
    // var claim1 = new Claim(....);

    // Queue<Claim> listOfClaims = 
    // listOfClaims.Add(claim)
    // Queue : First-in, First-Out
    // Stack : First-in, Last-Out
    // List<Queue>  {   }

   




        


}
