﻿using System;
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
        public Savings():base(1)
        {
             
        }

    }
}