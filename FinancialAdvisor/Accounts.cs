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
            Console.WriteLine("\r\n\t     Acct. No.   Acct. Type           Current Balance");
            Console.WriteLine("    \t    ==========   ==========         ===================\r\n");
        }
        public bool Deposit(int clientNumber, Client client, Accounts account)
        {
            double deposit = 0d;
            string input;
            bool exit = true;
            bool valid = false;

            while (exit && !valid)         //ask user for deposit amount
            {
                Console.Write("\r\n\r\n\tEnter amount to deposit:  ");
                input = Console.ReadLine().Trim().ToLower();
                if (input == "exit" || input == "e" || input == "quit") exit = false;
                valid = double.TryParse(input, out deposit);
                if (deposit < 0) valid = false;
                //initial savings deposit must be $1500 or more
                if(account.AcctType==0 && (account.Balance+deposit)<1500)
                {
                    Console.WriteLine("\r\n\a*** A minimum balance of $1500 is required for a savings account");
                    valid = false;
                }
            }
            if (exit)                      //give user new balance
            {
                Console.WriteLine("\r\n\tThank you for your deposit of {0:C}", deposit);
                account.Balance += deposit;
                if (account.AcctType == 0) Console.WriteLine("\r\n\tYour new checking account balance is {0:C}", account.Balance);
                if (account.AcctType == 1) Console.WriteLine("\r\n\tYour new savings account balance is {0:C}", account.Balance);
            }

            return exit; 
        }

        public bool Withdraw(int clientNumber, Client client, Accounts account, Accounts saving)
        {
            double withdraw = 0d;
            double overdraft = 0d;
            string input;
            bool exit = true;
            bool valid = false;

            while (exit && !valid)         //ask user for withdrawal amount
            {
                Console.Write("\r\n\r\n\tEnter amount to withdraw:  ");
                input = Console.ReadLine().Trim().ToLower();
                if (input == "exit" || input == "e" || input == "quit") exit = false;
                valid = double.TryParse(input, out withdraw);
                
                //must leave at least $1500 in a savings account
                if(account.AcctType==1 && withdraw>(account.Balance-1500))
                {
                    Console.WriteLine("\r\n\a*** The most you may withdraw is {0:C}", (account.Balance-1500));
                    Console.WriteLine("     in order to maintain a minimum balance of $1500 in savings");
                    valid = false;
                }
                //cannot generate negative balance in checking without a savings account
                else if(account.AcctType==0 && withdraw>account.Balance && saving.AcctNumber==-1)
                {
                    Console.WriteLine("\r\n\a*** You cannot withdraw more than your current balance of {0:C}", account.Balance);
                    valid = false;
                }
                //cannot enact overdraft protection if there is not enough in savings account
                else if(account.AcctType==0 && withdraw>account.Balance && (saving.Balance+account.Balance-withdraw)<1500)
                {
                    Console.WriteLine("\r\n\a*** You are trying to withdraw more than your current balance of {0:C}", account.Balance);
                    Console.WriteLine("     and do not have enough in your savings to cover the difference");
                    Console.WriteLine("     and maintain a minimum balance of $1500 in your savings account.");
                    valid = false;
                }
                //enact overdraft protection if there is enough in savings account
                else if (account.AcctType==0 && withdraw>account.Balance && (saving.Balance+account.Balance-withdraw)>=1500)
                {
                    overdraft = withdraw - account.Balance;
                    Console.WriteLine("\r\n\a*** Warning:  You have overdrafted your checking account by {0:C}", overdraft);
                    Console.WriteLine("               This amount will be taken out of your savings account.");
                    saving.Balance -= overdraft;
                }

            }

            if (exit)                      //give user new balance
            {
                Console.WriteLine("\r\n\tAmount to be withdrawn is {0:C}", withdraw);
                if (overdraft > 0)
                {
                    account.Balance = 0d;
                    Console.WriteLine("\r\n\tYour new checking account balance is {0:C}", account.Balance);
                    Console.WriteLine("\r\n\tYour new savings account balance is {0:C}", account.Balance);
                }
                else
                {
                    account.Balance -= withdraw;
                    if (account.AcctType == 0) Console.WriteLine("\r\n\tYour new checking account balance is {0:C}", account.Balance);
                    if (account.AcctType == 1) Console.WriteLine("\r\n\tYour new savings account balance is {0:C}", account.Balance);
                }
            }
            return exit;
        }
    }
}
