using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMockIT
{
    class Customer
    {
        private IAccount checkingAccount;
        private IAccount savingsAccount;

        public Customer()
        {
            checkingAccount = new CheckingAcc();
            savingsAccount = new SavingsAcc();
        }

        public void DepositToChecking(decimal amount)
        {
            checkingAccount.Deposit(amount);
        }
        public void DepositToSavings(decimal amount) 
        {
            savingsAccount.Deposit(amount);
        }

        public void WithdrawFromChecking(decimal amount)
        {
            checkingAccount.Withdraw(amount);
        }
        public void WithdrawFromSavings(decimal amount)
        {
            savingsAccount.Withdraw(amount);
        }

        public void CheckBalances()
        {
            Console.WriteLine("Checking Balance: $" + checkingAccount.Balance + "\n Savings Balance: $" + savingsAccount.Balance);
        }
    }
}
