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

            int menuOption;
            string input;                   //user input
            string fName = "";              //user first name
            string lName = "";              //user last name
            string timeOfDay;               //morning, afternoon, or evening
            bool quit = true;               //if quit==false, user wants to end program
            bool valid = false;             //tests user input to see if it is a valid 

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
                    if (input.Substring(0, 1) == "y") valid = true;
                    if (input.Substring(0, 1) == "q") quit = false;
                }
            }

            while (quit)
            {

                //Determine if the user is an existing client  (retrieve or assign client number)

                //If a new client, get client information and display



                //valid = false;
                //while (quit && !valid)
                //{
                //  //  DisplayMenuOptions();

                //}

                //If an existing client, greet client
                Console.Clear();
                Console.WriteLine("\r\n\t\tWecome back {0} and good {1}!", fName, timeOfDay);

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
