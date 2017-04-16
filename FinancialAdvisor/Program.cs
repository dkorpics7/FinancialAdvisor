using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAdvisor
{
    class Program
    {
        static void Main(string[] args)
        {
            //This program keeps track of clients and their account balances
            //Clients can have checking and/or savings accounts

            int menuOption;                 //user's menu option entered
            int lastChecking = 0;           //last checking account number assigned
            int lastSavings = 0;            //last savings account number assigned
            int clientNumber = -1;          //client identification number (used internally)
            string input;                   //user input
            string fName = "";              //user first name
            string lName = "";              //user last name
            string timeOfDay;               //morning, afternoon, or evening
            bool quit = true;               //if quit==false, user wants to end program
            bool valid = false;             //tests user input to see if it is a valid 


            //instantiate some existing clients into a list
            List<Client> clientList = new List<Client>();
            clientList.Add(new Client("Diane","Korpics",1,"941 Westhaven Drive","","Hudson","Ohio","44236","(330) 687-2486","(330) 687-2486)"));
            clientList.Add(new Client("Daniel", "Vivacqua", 2));
            clientList.Add(new Client("Jarryd", "Hurtley", 3));
            clientList.Add(new Client("Dave", "Kolar", 4));


            //instantiate existing accounts
            Checking DianeChecking = new Checking(1, 0101, 2325.89);
            Checking DanielChecking = new Checking(2, 0102, 4352.13);
            Checking JarrydChecking = new Checking(3, 0103, 4791.22);
            Checking DaveChecking = new FinancialAdvisor.Checking(4, 0104, 17325.09);
            Savings DianeSavings = new FinancialAdvisor.Savings(1, 1234, 8732.84);
            Savings DanielSavings = new FinancialAdvisor.Savings(2, 1235, 12375.32);

            //Determine if it is morning, afternoon, or evening
            timeOfDay = GetTimeOfDay();

            //Greet the user
            Console.WriteLine("\r\n\r\n\t\t!!!!! Welcome to Financial Solutions !!!!!");
            Console.WriteLine("\r\n\t\t    We help make your dreams come true.");
 
            //Ask them to "login".  Store their first and last name.
            while (quit && !valid)
            {
                Console.Write("\r\n\r\n\r\n\tPlease login (e.g., John Smith):  ");
                input = Console.ReadLine().Trim();
                fName = GetFirstName(input);
                lName = GetLastName(input);
                if (input.ToLower() == "quit") quit = false;     //determine if user wants to quit
                if (fName == "" || lName == "")                  //user must enter BOTH a first and last name
                {
                    Console.Clear();
                    Console.WriteLine("\r\n\r\n\a*** Invalid Entry:  You must enter a first and last name.\r\n");
                }
                else
                {
                    Console.Write("\r\n\r\n\tYou entered {0} {1}.  Is this Correct (y or n)? ", fName, lName);
                    input = Console.ReadLine().Trim();
                    if (input.Substring(0, 1).ToLower() == "y") valid = true;
                    if (input.Substring(0, 1).ToLower() == "q") quit = false;
                }
            }

            while (quit)
            {

                //Determine if the user is an existing client  (retrieve or assign client number)
                foreach (Client c in clientList)
                {
                    if (c.FName.ToLower() == fName.ToLower() && c.LName.ToLower() == lName.ToLower()) clientNumber = c.ClientNumber;
                }

                //If a new client, get client information and display
                if(clientNumber<1)
                {
                    Console.Clear();
                    Console.WriteLine("\r\n\t\t{0}, Welcome to Financial Solutions!",fName);
                    Console.WriteLine("\r\n\r\n\tPlease follow the prompts below to set up your account(s).");
                    Console.WriteLine("\tNOTE: You may enter \"quit\" at any time to leave our site.\r\n");
                    clientNumber = clientList.Count + 1;
                    clientList.Add(new Client(fName, lName, clientNumber));
                    quit = clientList[clientList.Count-1].EnterClientInfo(clientNumber, clientList[clientNumber-1]);
                    Console.ReadKey();
                }
                else
                //If an existing client, greet client
                {
                    Console.Clear();
                    Console.WriteLine("\r\n\t\tWelcome back {0} and good {1}!", fName, timeOfDay);
                }
                foreach (Client c in clientList)
                {
                    Console.WriteLine("\r\n" + c.FName);
                    Console.WriteLine(c.Address1);
                    Console.WriteLine(c.City);
                    Console.WriteLine(c.State);
                    Console.WriteLine(c.Zip);
                    Console.WriteLine(c.HomePhone);
                    Console.WriteLine(c.CellPhone);

                }

                Console.ReadKey();
                quit = false;

            }
            //Get menu option from user

            //view account balances

            //make a deposit

            //make a withdrawal

            Console.WriteLine("\r\n\r\nPress any key to continue ...");
            Console.ReadKey();
        }

    static string GetTimeOfDay()              // gets time of day (morning, afternoon or evening)
        {
            string timeOfDay;

            if (DateTime.Now.Hour > 3 && DateTime.Now.Hour < 12)
            {
                timeOfDay = "morning";
            }
            else if(DateTime.Now.Hour >= 12 && DateTime.Now.Hour < 5)
            {
                timeOfDay = "afternoon";
            }
            else
            {
                timeOfDay = "evening";
            }
            return timeOfDay;
        }

        static string GetFirstName(string input)  // Parses user input to get first name
        {
            string firstName;

            //Get the first name from the input string
            if(input.Length<1 || input.IndexOf(" ")<1)
            {
                firstName = "";
            }
            else
            {
                firstName = input.Substring(0, input.IndexOf(" "));
            }

            return firstName;
        }

        static string GetLastName(string input)  // Parses user input to get last name
        {
            string lastName;

            //Get the last name from the input string
            if (input.Length < 1 || input.IndexOf(" ") < 1 || (input.Length - input.IndexOf(" "))<2)
            {
                lastName = "";
            }
            else
            {
                lastName = input.Substring(input.LastIndexOf(" ")+1,(input.Length-input.LastIndexOf(" ")-1));
            }

            return lastName;
        }

        static int GetInput(string input) // parses input string to return a valid user-selected menu option
        {
            int selectedOption;
            double decimalNumber;
            bool validInt = false;
            bool validDouble = false;

            validInt = int.TryParse(input, out selectedOption);
            validDouble = double.TryParse(input, out decimalNumber);

            if (validInt)
            {
                return selectedOption;                       // a valid integer was entered
            }
            else if (validDouble)                             // a decimal number was entered
            {
                selectedOption = Convert.ToInt32(decimalNumber);  // convert to an integer
                return selectedOption;
            }
            else if (input == "quit" || input == "exit" || input == "q")
            {
                selectedOption = 6;
                return selectedOption;
            }
            else
            {
                selectedOption = -1;
                return selectedOption;
            }
        }
        static string GetPetName(string userName)  //Asks the user for the pet name
        {
            string petName;

            Console.Write("\r\n\r\n\r\n\t{0}, What would you like to call your pet?\r\n\t(if you hit return, we will pick a name for you):  ", userName);
            petName = Console.ReadLine().Trim();

            if (petName == "") Console.WriteLine("\r\n\r\n\tYour pet's name is George, and he is lucky to have such a \r\n\tconscientious owner.", petName);
            Console.WriteLine("\r\n\r\n\r\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();

            return petName;
        }
    }
}
