using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace OOPBank
{
    public class Customer
    {
        public IAccount checkingAccount;
        public IAccount savingsAccount;
        private decimal combinedBalance;

        public Customer()
        {
            checkingAccount = new CheckingAcc();
            savingsAccount = new SavingsAcc();
        }

        public void DepositToChecking()
        {
            decimal amount;
            Console.WriteLine("Input the amount you would like to deposit to checking:\n");
            string dcinput = Console.ReadLine();

            if (decimal.TryParse(dcinput, out amount))
            {
                checkingAccount.Deposit(amount);
                Console.WriteLine("$" + amount + " was deposited into checking.\n");
            }
            else { Console.WriteLine("Invalid amount entered.\n"); }
        }
        public void DepositToSavings() 
        {
            decimal amount;
            Console.WriteLine("Input the amount you would like to deposit to savings:\n");
            string dsinput = Console.ReadLine();

            if (decimal.TryParse(dsinput, out amount))
            {
                savingsAccount.Deposit(amount);
                Console.WriteLine("$" + amount + " was deposited into savings.\n");
            }
            else { Console.WriteLine("Invalid amount entered.\n"); }
        }

        public void WithdrawFromChecking(decimal amount)
        {
            combinedBalance = checkingAccount.Balance + savingsAccount.Balance;
            if(amount > (combinedBalance - 10)) // Checks if withdrawal amount would be too high
            {
                Console.WriteLine("Error: Withdrawal amount would exceed the combined checking and savings accounts' balances.");
            }
            else if (amount > checkingAccount.Balance) // Checks if the savings account needs to be used to cover the withdrawal
            {
                decimal overamount = amount - checkingAccount.Balance; // Calculates how much to withdraw from savings to cover for the checking withdrawal
                Console.WriteLine("$" + checkingAccount.Balance + " was withdrawn from checking &");
                checkingAccount.Withdraw(checkingAccount.Balance);
                savingsAccount.Withdraw(overamount);

            } else // A normal withdrawal if the checking balance can handle the withdrawal
            {
                checkingAccount.Withdraw(amount);
            }
        }
        public void WithdrawFromSavings(decimal amount)
        {
            savingsAccount.Withdraw(amount);
        }

        public void CheckBalances()
        {
            Console.WriteLine("Checking Balance: $" + checkingAccount.Balance + "\n Savings Balance: $" + savingsAccount.Balance);
        }

        public void SetMemberName(string name)
        {
            checkingAccount.SetMemberName(name + ".Checking");
            savingsAccount.SetMemberName(name + ".Savings");
        }

        //public void AddMembersToBank()
        //{
        //    OOPBank.Bank bank = new OOPBank.Bank();
        //    bank.AddMember(checkingAccount);
        //    bank.AddMember(savingsAccount);
        //}
    }
}
