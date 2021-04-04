using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02RepositoryPattern_Repository
{
    public class ClaimsRepository
    {
        private Queue<Claim> _listOfClaim = new Queue<Claim>();
        

        //CREATE
        public void AddClaimToList(Claim claim)
        {
            _listOfClaim.Enqueue(claim);
        }


        //READ
        public Queue<Claim> GetClaimLists()
        {

            return _listOfClaim;
        }

        public Claim GetNextClaim()
        {
            return _listOfClaim.Peek();
        }

        //UPDATE
        public bool UpdateExistingClaim(int originalClaim, Claim newClaims) //pulls all the property.ClaimsContent.
        {
            //Find the content
            Claim oldClaims = GetClaimsByID(originalClaim);

            if (oldClaims != null)
            {
                oldClaims.ClaimID = newClaims.ClaimID;
                oldClaims.ClaimType = newClaims.ClaimType;
                oldClaims.Description = newClaims.Description;
                oldClaims.ClaimAmount = newClaims.ClaimAmount;
                oldClaims.DateOfIncident = newClaims.DateOfIncident;
                oldClaims.DateOfClaim = newClaims.DateOfClaim;
                oldClaims.DealWithClaim = newClaims.DealWithClaim;
                oldClaims.IsValid = newClaims.IsValid;
                
                return true;
            }
            else
            {
                return false;
            }
        }


        //DELETE
        public Claim RemoveTheClaim()
        {
           return _listOfClaim.Dequeue();
        }
        

        //Helper method. Help other methods. Really important calss.
        public Claim GetClaimsByID(int claimid)
        {
            foreach(Claim claim in _listOfClaim)
            {
                if(claim.ClaimID == claimid)
                {
                    return claim;
                }
            }

            return null;
        }


        
    }
  
}
