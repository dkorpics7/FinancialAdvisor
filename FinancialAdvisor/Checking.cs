using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAdvisor
{
    class Checking : Accounts
    {
        //constructors
        public Checking(int clientNumber, int acctNumber, double balance)
        {
            this.clientNumber = clientNumber;
            this.acctNumber = acctNumber;
            this.balance = balance;
            this.acctType = 0;
        }

        //method to view balance of checking account
        public override void GetBalance(int clientNumber, Client client, Accounts account)
        {
            base.GetBalance(clientNumber, client, account);
            if (account.AcctNumber == -1)
            {
                Console.WriteLine("\t\tN/A\t\t  No checking account");
            }
            else
            {
                Console.WriteLine("\t\t{0}\t\t\t{1}",account.AcctNumber,account.Balance.ToString("#.00"));
            }
        }

    }
}
