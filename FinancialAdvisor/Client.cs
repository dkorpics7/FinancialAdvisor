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
            bool quit = true;
            string[] prompt = { };

            quit = GetClientAddress(clientNumber, newclient);
            if (quit) quit = GetClientCity(clientNumber, newclient);
            if (quit) quit = GetClientState(clientNumber, newclient);
            if (quit) quit = GetClientZip(clientNumber, newclient);
            if (quit) quit = GetClientPhone(clientNumber, newclient);
            if (quit) quit = GetClientCell(clientNumber, newclient);

            return quit;
        }

        public bool GetClientAddress(int clientNumber, Client newclient)
        {
            bool quit = true;                //indicates whether user wants to quit the program
            bool valid = false;              //indicates whether user input is a valid entry
            string input;                    //user input string

            while (quit && !valid)          //get street address
            {
                Console.WriteLine("\r\n\tEnter street adress or P.O Box (e.g. 123 Main St.");
                Console.Write("\r\n\tAddress:             ");
                input = Console.ReadLine().Trim();
                if (input.ToLower() == "quit")
                {
                    quit = false;
                }
                else
                {
                    newclient.address1 = input;
                    valid = true;
                }
            }

            return quit;
        }

        public bool GetClientCity(int clientNumber, Client newclient)
        {
            bool quit = true;                //indicates whether user wants to quit the program
            bool valid = false;              //indicates whether user input is a valid entry
            string input;                    //user input string

            while (quit && !valid)          //get city
            {
                Console.Write("\r\n\tEnter city:          ");
                input = Console.ReadLine().Trim();
                if (input.ToLower() == "quit")
                {
                    quit = false;
                }
                else
                {
                    newclient.city = input;
                    valid = true;
                }
            }

            return quit;
        }

        public bool GetClientState(int clientNumber, Client newclient)
        {
            bool quit = true;                //indicates whether user wants to quit the program
            bool valid = false;              //indicates whether user input is a valid entry
            string input;                    //user input string

            while (quit && !valid)          //get state
            {
                Console.Write("\r\n\tEnter state:         ");
                input = Console.ReadLine().Trim();
                if (input.ToLower() == "quit")
                {
                    quit = false;
                }
                else
                {
                    newclient.state = input;
                    valid = true;
                }
            }

            return quit;
        }

        public bool GetClientZip(int clientNumber, Client newclient)
        {
            bool quit = true;                //indicates whether user wants to quit the program
            bool valid = false;              //indicates whether user input is a valid entry
            string input;                    //user input string

            while (quit && !valid)          //get zip code
            {
                Console.Write("\r\n\tEnter zip code:      ");
                input = Console.ReadLine().Trim();
                if (input.ToLower() == "quit")
                {
                    quit = false;
                }
                else
                {
                    newclient.zip = input;
                    valid = true;
                }
            }

            return quit;
        }

        public bool GetClientPhone(int clientNumber, Client newclient)
        {
            bool quit = true;                //indicates whether user wants to quit the program
            bool valid = false;              //indicates whether user input is a valid entry
            string input;                    //user input string

            while (quit && !valid)          //get home phone
            {
                Console.Write("\r\n\tEnter home phone:    ");
                input = Console.ReadLine().Trim();
                if (input.ToLower() == "quit")
                {
                    quit = false;
                }
                else
                {
                    newclient.homePhone = input;
                    valid = true;
                }
            }

            return quit;
        }

        public bool GetClientCell(int clientNumber, Client newclient)
        {
            bool quit = true;                //indicates whether user wants to quit the program
            bool valid = false;              //indicates whether user input is a valid entry
            string input;                    //user input string

            while (quit && !valid)          //get cell phone number
            {
                Console.Write("\r\n\tEnter cell phone:    ");
                input = Console.ReadLine().Trim();
                if (input.ToLower() == "quit")
                {
                    quit = false;
                }
                else
                {
                    newclient.cellPhone = input;
                    valid = true;
                }
            }

            return quit;
        }


    }
}
