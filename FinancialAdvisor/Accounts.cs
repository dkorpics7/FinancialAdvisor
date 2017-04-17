using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAdvisor
{
    class Accounts
    {
        //fields
        protected int clientNumber;
        protected int acctNumber;
        protected double balance;
        protected int acctType;              //Type is 0 for checking and 1 for savings

        //properties
        public int ClientNumber
        {
            get { return this.clientNumber; }
            set { this.clientNumber = value; }
        }
        public int AcctNumber
        {
            get { return this.acctNumber; }
            set { this.acctNumber = value; }
        }
        public double Balance
        {
            get { return this.balance; }
            set { this.balance = value; }
        }
        public int AcctType
        {
            get { return this.acctType; }
            set { this.acctType = value; }
        }

        //constructors
        public Accounts()
        {

        }
        public Accounts(int acctType)
        {
            this.acctType = acctType;
        }
        public Accounts(int clientNumber, int acctNumber, double balance, int acctType)
        {
            this.acctNumber = acctNumber;
            this.balance = balance;
            this.acctType = acctType;
        }

        //methods
        public virtual void GetBalance(int clientNumber, Client client, Accounts account)
        {
            Console.Clear();
            Console.WriteLine("\r\n\t\tAccount Balance for {0} {1}", client.FName, client.LName);
            Console.WriteLine("\r\t =====================================================\r\n");
            Console.WriteLine("\r\n\t     Acct. No.              Current Balance");
            Console.WriteLine("    \t    ==========            ===================\r\n");
        }
        public virtual void Deposit()
        {

        }
        public virtual void Withdraw()
        {

        }
    }
}
