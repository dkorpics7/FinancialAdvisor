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
    }
}
