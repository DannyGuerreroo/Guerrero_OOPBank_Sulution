﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMockIT
{
    internal class CheckingAcc : IAccount
    {
        public CheckingAcc() { }

        public decimal Balance { get; set; }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            Balance -= amount;
        }

    }
}
