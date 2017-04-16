using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAdvisor
{
    class Client
    {
        //fields
        private string fName;
        private string lName;
        private int clientNumber;
        private int checkingAcct;
        private int savingsAcct;
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

        //constructors
        public Client()
        {

        }

        public Client (string fName, string lName, int clientNumber, int checkingAcct, int savingsAcct, string address1, string address2, string city, string state, string zip, string homePhone, string cellPhone)
        {
            this.fName = fName;
            this.lName = lName;
            this.clientNumber = clientNumber;
            this.checkingAcct = checkingAcct;
            this.savingsAcct = savingsAcct;
            this.address1 = address1;
            this.address2 = address2;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.homePhone = homePhone;
            this.cellPhone = cellPhone;
        }

        //methods
        public int GetClientNumber(string fName, string lName)
        {

            return clientNumber;
        }

    }
}
