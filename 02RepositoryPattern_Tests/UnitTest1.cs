using _02RepositoryPattern_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _02RepositoryPattern_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestClaimConstructor()
        {
            //Arrange
            int claim_id = 1;
            string claim_type = "2";
            string description = "Kitchen fire";
            string claimamount = "$5000";
            string dateofincident = "12/25/20";
            string dateofclaim = "12/26/20";
            bool dealwithclaim = true;
            bool isvalid = true;

            //Act
            Claim testclaim = new Claim(claim_id, claim_type, description, claimamount, dateofincident, dateofclaim, dealwithclaim, isvalid);

            //Assert
            Assert.AreEqual(1, testclaim.ClaimID);
            Assert.AreEqual("2", testclaim.ClaimType);
            Assert.AreEqual("Kitchen fire", testclaim.Description);
            Assert.AreEqual("$5000", testclaim.ClaimAmount);
            Assert.AreEqual("12/25/20", testclaim.DateOfIncident);
            Assert.AreEqual("12/26/20", testclaim.DateOfClaim);
            Assert.AreEqual(true, testclaim.DealWithClaim);
            Assert.AreEqual(true, testclaim.IsValid);
        }

        [TestMethod]
        public void AddClaimToRepo_Test()
        {
            
            // Arrange
            int claim_id = 1;
            string claim_type = "2";
            string description = "Kitchen fire";
            string claimamount = "$5000";
            string dateofincident = "12/25/20";
            string dateofclaim = "12/26/20";
            bool dealwithclaim = true;
            bool isvalid = true;
            Claim testclaim = new Claim(claim_id, claim_type, description, claimamount, dateofincident, dateofclaim, dealwithclaim, isvalid);
            ClaimsRepository testrepo = new ClaimsRepository();

            //Act
            testrepo.AddClaimToList(testclaim);

            //Assert
            Assert.AreEqual(1, testrepo.GetClaimLists().Count);
        }

        [TestMethod]
        public void AddClaimToRepo_Test2()
        {
            // Arrange            
            ClaimsRepository testrepo = new ClaimsRepository();

            //Act
            testrepo.AddClaimToList(new Claim());
            testrepo.AddClaimToList(new Claim());
            testrepo.AddClaimToList(new Claim());
            testrepo.AddClaimToList(new Claim());

            //Assert
            Assert.AreEqual(4, testrepo.GetClaimLists().Count);
        }
        [TestMethod]
        public void RemoveClaimFromRepo_Test()
        {
            // Arrange            
            ClaimsRepository testrepo = new ClaimsRepository();

            testrepo.AddClaimToList(new Claim());
            testrepo.AddClaimToList(new Claim());
            testrepo.AddClaimToList(new Claim());
            testrepo.AddClaimToList(new Claim());

            //Act
            testrepo.RemoveTheClaim();
            testrepo.RemoveTheClaim();
            testrepo.RemoveTheClaim();
            testrepo.RemoveTheClaim();

            //Assert
            Assert.AreEqual(0, testrepo.GetClaimLists().Count);
        }
    }
}
