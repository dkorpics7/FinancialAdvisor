using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAdvisor
{
    public class Client
 // class Client
    {
        //fields
        private string fName;
        private string lName;
        private int clientNumber;
        private string address1;
        private string address2;
        private string city;
        private string state;
        private string zip;
        private string cellPhone;
        private string homePhone;

        //properties
        public string FName
        {
            get { return this.fName; }
            set { this.fName = value; }
        }
        public string LName
        {
            get { return this.lName; }
            set { this.lName = value; }
        }
        public int ClientNumber
        {
            get { return this.clientNumber; }
            set { this.clientNumber = value; }
        }
        public string Address1
        {
            get { return this.address1; }
            set { this.address1 = value; }
        }
        public string City
        {
            get { return this.city; }
            set { this.city = value; }
        }
        public string State
        {
            get { return this.state; }
            set { this.state = value; }
        }
        public string Zip
        {
            get { return this.zip; }
            set { this.zip = value; }
        }
        public string HomePhone
        {
            get { return this.homePhone; }
            set { this.homePhone = value; }
        }
        public string CellPhone
        {
            get { return this.cellPhone; }
            set { this.cellPhone = value; }
        }


        //constructors
        public Client()
        {

        }
        public Client(string fName, string lName, int clientNumber)
        {
            this.fName = fName;
            this.lName = lName;
            this.clientNumber = clientNumber;
        }
        public Client (string fName, string lName, int clientNumber, string address1, string address2, string city, string state, string zip, string homePhone, string cellPhone)
        {
            this.fName = fName;
            this.lName = lName;
            this.clientNumber = clientNumber;
            this.address1 = address1;
            this.address2 = address2;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.homePhone = homePhone;
            this.cellPhone = cellPhone;
        }

        //methods
        public bool EnterClientInfo(int clientNumber, Client newclient)
        {
            //This method prompts a new client for their general information

            string input;                   //user input string
            bool valid = false;             //indicates whether user input is a valid entry
            bool exit = true;
            string[] prompt = { };

            exit = GetClientAddress(clientNumber, newclient);
            if (exit) exit = GetClientCity(clientNumber, newclient);
            if (exit) exit = GetClientState(clientNumber, newclient);
            if (exit) exit = GetClientZip(clientNumber, newclient);
            if (exit) exit = GetClientPhone(clientNumber, newclient);
            if (exit) exit = GetClientCell(clientNumber, newclient);

            return exit;
        }

        public bool GetClientAddress(int clientNumber, Client newclient)
        {
            bool exit = true;                //indicates whether user wants to exit the program
            bool valid = false;              //indicates whether user input is a valid entry
            string input;                    //user input string

            while (exit && !valid)          //get street address
            {
                Console.WriteLine("\r\n\tEnter street adress or P.O Box (e.g. 123 Main St.");
                Console.Write("\r\n\tAddress:             ");
                input = Console.ReadLine().Trim();
                if (input.ToLower() == "exit")
                {
                    exit = false;
                }
                else
                {
                    newclient.address1 = input;
                    valid = true;
                }
            }

            return exit;
        }

        public bool GetClientCity(int clientNumber, Client newclient)
        {
            bool exit = true;                //indicates whether user wants to exit the program
            bool valid = false;              //indicates whether user input is a valid entry
            string input;                    //user input string

            while (exit && !valid)          //get city
            {
                Console.Write("\r\n\tEnter city:          ");
                input = Console.ReadLine().Trim();
                if (input.ToLower() == "exit")
                {
                    exit = false;
                }
                else
                {
                    newclient.city = input;
                    valid = true;
                }
            }

            return exit;
        }

        public bool GetClientState(int clientNumber, Client newclient)
        {
            bool exit = true;                //indicates whether user wants to exit the program
            bool valid = false;              //indicates whether user input is a valid entry
            string input;                    //user input string

            while (exit && !valid)          //get state
            {
                Console.Write("\r\n\tEnter state:         ");
                input = Console.ReadLine().Trim();
                if (input.ToLower() == "exit")
                {
                    exit = false;
                }
                else
                {
                    newclient.state = input;
                    valid = true;
                }
            }

            return exit;
        }

        public bool GetClientZip(int clientNumber, Client newclient)
        {
            bool exit = true;                //indicates whether user wants to exit the program
            bool valid = false;              //indicates whether user input is a valid entry
            string input;                    //user input string

            while (exit && !valid)          //get zip code
            {
                Console.Write("\r\n\tEnter zip code:      ");
                input = Console.ReadLine().Trim();
                if (input.ToLower() == "exit")
                {
                    exit = false;
                }
                else
                {
                    newclient.zip = input;
                    valid = true;
                }
            }

            return exit;
        }

        public bool GetClientPhone(int clientNumber, Client newclient)
        {
            bool exit = true;                //indicates whether user wants to exit the program
            bool valid = false;              //indicates whether user input is a valid entry
            string input;                    //user input string

            while (exit && !valid)          //get home phone
            {
                Console.Write("\r\n\tEnter home phone:    ");
                input = Console.ReadLine().Trim();
                if (input.ToLower() == "exit")
                {
                    exit = false;
                }
                else
                {
                    newclient.homePhone = input;
                    valid = true;
                }
            }

            return exit;
        }

        public bool GetClientCell(int clientNumber, Client newclient)
        {
            bool exit = true;                //indicates whether user wants to exit the program
            bool valid = false;              //indicates whether user input is a valid entry
            string input;                    //user input string

            while (exit && !valid)          //get cell phone number
            {
                Console.Write("\r\n\tEnter cell phone:    ");
                input = Console.ReadLine().Trim();
                if (input.ToLower() == "exit")
                {
                    exit = false;
                }
                else
                {
                    newclient.cellPhone = input;
                    valid = true;
                }
            }

            return exit;
        }

        public bool ViewClientInfo(int clientNumber, Client client)
        {
            //This method displays Client information and allows them to update their information

            int menuOption;                  //user menu choice
            bool exit = true;                //indicates whether user wants to exit the program
            bool valid = false;              //indicates whether user input is a valid entry
            string input;                    //user input string

            while (exit && !valid)
            {
                //Display Client Information
                Console.Clear();
                Console.WriteLine("\r\n\t\t\tProfile for {0} {1}", client.FName, client.LName);
                Console.WriteLine("\t\t==================================================\r\n\r\n");
                Console.WriteLine("\t\tAddress:          " + client.Address1);
                Console.WriteLine("\t\t                  {0}, {1}  {2}", client.City, client.State, client.Zip);
                Console.WriteLine("\r\n\t\tHome Phone:       " + client.HomePhone);
                Console.WriteLine("\t\tCell Phone:       " + client.CellPhone + "\r\n");

                //Update Client Information
                Console.Write("\r\n\tWould you like to update your information (y or n)?  ");
                input = Console.ReadLine().Trim().ToLower();

                if (input == "y" || input == "yes")                   //Display menu for updating info
                {
                    Console.Clear();
                    Console.WriteLine("\r\n\t\t\tUPDATE MENU");
                    Console.WriteLine("\t\t     ================\r\n\r\n");
                    Console.WriteLine("\t1.  Update street address");
                    Console.WriteLine("\t2.  Update city");
                    Console.WriteLine("\t3.  Update state");
                    Console.WriteLine("\t4.  Update zip code");
                    Console.WriteLine("\t5.  Update home phone");
                    Console.WriteLine("\t6.  Update cell phone");
                    Console.WriteLine("\t7.  Exit");

                    Console.Write("\r\n\r\n\tEnter menu choice:  ");  
                    input = Console.ReadLine().Trim().ToLower();      //Get user menu choice
                    menuOption = GetInput(input);
                    if (menuOption == -2) menuOption = 7;

                    switch (menuOption)
                    {
                        case 1:
                            exit = GetClientAddress(clientNumber, client);
                            break;
                        case 2:
                            exit = GetClientCity(clientNumber, client);
                            break;
                        case 3:
                            exit = GetClientState(clientNumber, client);
                            break;
                        case 4:
                            exit = GetClientZip(clientNumber, client);
                            break;
                        case 5:
                            exit = GetClientPhone(clientNumber, client);
                            break;
                        case 6:
                            exit = GetClientCell(clientNumber, client);
                            break;
                        case 7:
                            exit = false;
                            break;
                        default:
                            Console.WriteLine("\r\n*** Invalid Entry.");
                            break;
                    }

                }
                else if (input.Substring(0, 1) == "e")
                {
                    exit = false;
                }
                else
                {
                    valid = true;
                }
            }
            return exit;
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
