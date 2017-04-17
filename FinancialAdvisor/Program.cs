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

            int menuOption = 0;             //user's menu option entered
            int clientNumber = -1;          //client identification number (used internally)
            int lnum = -1;                  //list location associated with client number (clientNumber-1)
            int acctType = 0;               //Account type is 0 for checking and 1 for savings
            string input = "";              //user input
            string fName = "";              //user first name
            string lName = "";              //user last name
            string timeOfDay;               //morning, afternoon, or evening
            bool exit = true;               //if exit==false, user wants to end program
            bool valid = false;             //tests user input to see if it is a valid 


            //instantiate some existing clients into a list
            List<Client> clientList = new List<Client>();
            clientList.Add(new Client("Diane","Korpics",1,"941 Westhaven Drive","","Hudson","Ohio","44236","(330) 687-2486","(330) 687-2486"));
            clientList.Add(new Client("Daniel", "Vivacqua", 2));
            clientList.Add(new Client("Jarryd", "Huntley", 3));
            clientList.Add(new Client("Dave", "Kolar", 4));


            //instantiate existing checking accounts
            List<Checking> checkingAccts = new List<Checking>();
            checkingAccts.Add(new Checking(1, 0101, 2325.89));
            checkingAccts.Add(new Checking(2, 0102, 4352.13));
            checkingAccts.Add(new Checking(3, 0103, 4791.22));
            checkingAccts.Add(new Checking(4, 0104, 17325.09));

            //instantiate existing savings accounts
            List<Savings> savingsAccts = new List<Savings>();
            savingsAccts.Add(new Savings(1, 10001, 8732.84));
            savingsAccts.Add(new Savings(2, -1, 0));       //account number = -1 means an account was not opened yet
            savingsAccts.Add(new Savings(3, -1, 0));       //account number = -1 means an account was not opened yet
            savingsAccts.Add(new Savings(4, 10004, 52375.32));

            //Determine if it is morning, afternoon, or evening
            timeOfDay = GetTimeOfDay();

            //Greet the user
            Console.WriteLine("\r\n\r\n\t\t!!!!! Welcome to Financial Solutions !!!!!");
            Console.WriteLine("\r\n\t\t    We help make your dreams come true.");
 
            //Ask user to "login".  Store their first and last name.
            while (exit && !valid)
            {
                Console.Write("\r\n\r\n\r\n\tPlease login (e.g., John Smith):  ");
                input = Console.ReadLine().Trim();
                fName = GetFirstName(input);
                lName = GetLastName(input);
                if (input.ToLower() == "exit") exit = false;     //determine if user wants to exit
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
                    if (input.Substring(0, 1).ToLower() == "e") exit = false;
                }
            }

            if (exit)
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
                    Console.WriteLine("\tNOTE: You may enter \"exit\" at any time to leave our site.\r\n");
                    clientNumber = clientList.Count + 1;
                    clientList.Add(new Client(fName, lName, clientNumber));
                    exit = clientList[clientList.Count-1].EnterClientInfo(clientNumber, clientList[clientNumber-1]);
                    checkingAccts.Add(new Checking(clientNumber, -1, 0));       
                    savingsAccts.Add(new Savings(clientNumber, -1, 0));      

                }
                else
                //If an existing client, greet client
                {
                    Console.Clear();
                    Console.WriteLine("\r\n\t\tWelcome back {0} and good {1}!", fName, timeOfDay);
                }
                lnum = clientNumber - 1;
            }

            while(exit && menuOption !=5)
            {
                //Main Menu -- keeps returning here until user asks to exit program
                DisplayMainMenu();

                //Get menu option from user
                menuOption = GetInput();
                if (menuOption == -2) menuOption = 5;

                switch (menuOption)
                {
                    case 1:                         //View Client Info
                        exit = clientList[lnum].ViewClientInfo(clientNumber, clientList[lnum]);
                        break;
                    case 2:                         //View Account Balance(s)
                        checkingAccts[lnum].GetBalance(clientNumber, clientList[lnum], checkingAccts[lnum]);
                        savingsAccts[lnum].GetBalance(clientNumber, clientList[lnum], savingsAccts[lnum]);
                        break;
                    case 3:                         //Make a Deposit
                        acctType = GetInput();
                        if (acctType == 0)
                        {
   //                         exit = checkingAccts[lnum].Deposit(clientNumber, clientList[lnum], checkingAccts[lnum]);
                        }
                        else if (acctType == 1)
                        {
     //                       exit = savingsAccts[lnum].Deposit(clientNumber, clientList[lnum], savingsAccts[lnum]);
                        }
                        else if (acctType == -2)
                        {
                            exit = false;
                        }
                        else
                        {
                            Console.WriteLine("\r\n*** Invalid Entry.");
                        }
                        break;
                    case 4:                         //Make a Withdrawal
       //                 exit = Withdraw();
                        break;
                    case 5:                         //Exit
                        exit = false;
                        break;
                    default:                        //Invalid input
                        Console.WriteLine("\r\n*** Invalid Input Option.\r\n");
                        break;
                }

                //foreach (Client c in clientList)
                //{
                //    Console.WriteLine("\r\n" + c.FName);
                //    Console.WriteLine(c.Address1);
                //    Console.WriteLine(c.City);
                //    Console.WriteLine(c.State);
                //    Console.WriteLine(c.Zip);
                //    Console.WriteLine(c.HomePhone);
                //    Console.WriteLine(c.CellPhone);
                //}

                Console.ReadKey();

                //view account balances

                //make a deposit

                //make a withdrawal



            } // end Main Menu loop

            //Thank user for their business and exit program
            Console.Clear();
            Console.WriteLine("\r\n\r\n\t!!!!!   Thank you for your business   !!!!!");
            Console.WriteLine("\r\nWe hope your experience was a pleasant one. Have a nice {0}.", timeOfDay);
            Console.WriteLine("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\nPress any key to continue ...");
            Console.ReadKey();
        }

    static string GetTimeOfDay()              // gets time of day (morning, afternoon or evening)
        {
            string timeOfDay;

            if (DateTime.Now.Hour > 3 && DateTime.Now.Hour < 12)
            {
                timeOfDay = "morning";
            }
            else if(DateTime.Now.Hour >= 12 && DateTime.Now.Hour < 17)
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

        static void DisplayMainMenu()  //displays main menu
        {
            Console.Clear();
            Console.WriteLine("\r\n\r\n\t\t\tMAIN MENU");
            Console.WriteLine("\t\t    ================\r\n\r\n");
            Console.WriteLine("\t1.  View/Update your information.");
            Console.WriteLine("\t2.  View Account Balance.");
            Console.WriteLine("\t3.  Deposit Funds.");
            Console.WriteLine("\t4.  Withdraw Funds.");
            Console.WriteLine("\t5.  Exit.");
        }

        static int GetInput() // parses input string to return a valid user-selected menu option
        {
            int selectedOption;
            double decimalNumber;
            string input;
            bool validInt = false;
            bool validDouble = false;

            //prompt user to enter menu option
            Console.Write("\r\n\r\n\tEnter menu option:  ");
            input = Console.ReadLine().Trim().ToLower();

            validInt = int.TryParse(input, out selectedOption);
            validDouble = double.TryParse(input, out decimalNumber);

            if (validInt)
            {
                return selectedOption;                       // a valid integer was entered
            }
            else if (validDouble)                             // a decimal number was entered
            {
                selectedOption = Convert.ToInt32(decimalNumber);  // convert it to an integer
                return selectedOption;
            }
            else if (input == "exit" || input == "quit" || input == "e")
            {
                selectedOption = -2;                           // user wants to exit program
                return selectedOption;
            }
            else
            {
                selectedOption = -1;
                return selectedOption;
            }
        }
    }
}
