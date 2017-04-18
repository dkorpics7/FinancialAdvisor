using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAdvisor
{
    class Savings: Accounts
    {
        //fields
        private double minBalance = 2500;
        private double intRate;

        //constructors
        public Savings(int clientNumber, int acctNumber, double balance)
        {
            this.clientNumber = clientNumber;
            this.acctNumber = acctNumber;
            this.balance = balance;
            this.acctType = 1;
        }

        //method to view balance of savings acct
        public override void GetBalance(int clientNumber, Client client, Accounts account)
        {
            if (account.AcctNumber == -1)
            {
                Console.WriteLine("\t\tN/A\t\t\t     No savings account");
            }
            else
            {
                Console.WriteLine("\t\t{0}\t  Savings \t\t{1:C}", account.AcctNumber, account.Balance);
            }

        }
    }
}
