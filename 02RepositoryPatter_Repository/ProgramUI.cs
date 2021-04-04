using _02RepositoryPattern_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02RepositoryPatter_Repository
{
    class ProgramUI
    {
        private ClaimsRepository _claimsRepo = new ClaimsRepository();
        
        public void Run()
        {
            SeedClaimList();
            Menu();
        }
        //Menu 
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Choose a Claims menu: \n" +
                    "1. See all claims  \n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit");

                //Get the user's input

                string input = Console.ReadLine();

                //Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        //See all claims
                        DisplayAllClaims();
                        break;
                    case "2":
                        //View claim by ID

                        DisplayNextClaim();
                        break;
                    case "3":
                        //Create a new claim
                        CreateNewClaim();
                        break;
                    case "4":
                        //Exit
                        keepRunning = false;
                        break;


                    default:
                        Console.WriteLine("This is not a valid command.\n" +
                            "Please enter 1, 2, 3, or 4.");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                
            }
        }
       
        private void CreateNewClaim()
        {
            Claim newClaim = new Claim();

            //id
            Console.WriteLine("Enter the ID for the Claim: ");
            newClaim.ClaimID = int.Parse(Console.ReadLine());

            //type
            Console.WriteLine("Enter the Type of Claim: \n" +
                " 1. Car\n" +
                " 2. Home \n" +
                " 3. Theft" );
            string typeOfClaim = Console.ReadLine();
            //newClaim.ClaimType = 

            _claimsRepo.AddClaimToList(newClaim);

            //description
            Console.WriteLine("Enter the description of the Claim");
            newClaim.Description = Console.ReadLine().ToLower();

            //amount
            Console.WriteLine("Enter the Amount of the loss/damage");
            newClaim.ClaimAmount = Console.ReadLine().ToLower();

            //date of accident
            Console.WriteLine("Enter the Date of the Accident");
            newClaim.DateOfIncident = Console.ReadLine();


            //date of claim
            Console.WriteLine("Enter the Date of the Claim");
            newClaim.DateOfIncident = Console.ReadLine().ToLower();

            Console.WriteLine("Is this Claim valid? (y/n)");
            string IsValid = Console.ReadLine().ToLower();

            if(IsValid == "y")
            {
                newClaim.IsValid = true;
                
            }
            else
            {
                Console.WriteLine("Sorry this Claim is not Valid");
            }

            Console.WriteLine("Do you want to deal with this claim now? (y/n)");
            string DealWithClaim = Console.ReadLine();

            if(DealWithClaim == "y")
            {
                newClaim.DealWithClaim = true;
            }
            else
            {
                Menu(); 
            }

        }

        //View current claims

        private void DisplayAllClaims()
        {
            Console.Clear();
            Queue<Claim> listOfClaim = _claimsRepo.GetClaimLists();
            if (listOfClaim.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Your claims list is empty! Press any key to go back to the menu.");
                Console.ReadLine();
                Console.Clear();
                Menu();
            }
            else 
            { 
                foreach (Claim claim in listOfClaim)
                {
                    Console.WriteLine($"Claim ID: {claim.ClaimID}\n" +
                        $" Type: {claim.ClaimType}\n" +
                        $" Claim Description: {claim.Description}\n" +
                        $" Amount of Damage: { claim.ClaimAmount}\n" +
                        $" Date Of Accident: {claim.DateOfIncident}\n" +
                        $" Date Of Claim: {claim.DateOfIncident}\n" +
                        $" Is Valid: {claim.IsValid}\n");
                }            
            }
        }

        private void UpdateExistingClaim()
        {
            
        }

        private void DisplayNextClaim()
        {
            Queue<Claim> listOfClaim = _claimsRepo.GetClaimLists();
            if (listOfClaim.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Your claims list is empty! Press any key to go back to the menu.");
                Console.ReadLine();
                Console.Clear();
                Menu();                
            }
            else
            {
                Console.Clear();
                //display the next claim
                Claim claim = _claimsRepo.GetNextClaim();
                Console.WriteLine($"Claim ID: {claim.ClaimID}\n" +
                       $" Type: {claim.ClaimType}\n" +
                       $" Claim Description: {claim.Description}\n" +
                       $" Amount of Damage: { claim.ClaimAmount}\n" +
                       $" Date Of Accident: {claim.DateOfIncident}\n" +
                       $" Date Of Claim: {claim.DateOfIncident}\n" +
                       $" Is Valid: { claim.IsValid}\n" +
                       $" Do You Want to Deal With This Claim Now? (y/n)");

                string next = Console.ReadLine();
                if (next == "y")
                {
                    _claimsRepo.RemoveTheClaim();
                    Console.WriteLine("You have dealt with this Claim.\n" +
                        "Press any key to go back to the menu.");
                    Console.ReadLine();
                    Console.Clear();
                    Menu();
                }
                else
                {
                    Console.Clear();
                    Menu();
                }
            }
            

            //have the console.readline that makes the user go to the next claim if they want to display next claim.
        }

        //View Existing Claims by ClaimsID

        //See method
        private void SeedClaimList()
        {
            Claim firstclaim = new Claim(1, "Car", "Car accident on 465.", "$400.00", "4/25/18", "4/27/18", true, false);
            Claim secondclaim = new Claim(2, "Home", "House fire in the kitchen.", "$4000.00", "4/11/18", "4/12/18", true, true);
            Claim thirdclaim = new Claim(3, "Theft", "Stolen pancakes.", "$4.00", "4/27/18", "06/01/18", false, false);

            _claimsRepo.AddClaimToList(firstclaim);
            _claimsRepo.AddClaimToList(secondclaim);
            _claimsRepo.AddClaimToList(thirdclaim);
        }
    }
}
