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
        private IAccount checkingAcc;
        private IAccount savingsAcc;
        private decimal combinedBalance;

        private IAccount _checkingAcc = new CheckingAcc();
        private IAccount _savingsAcc = new SavingsAcc();

        public Customer(IAccount checking, IAccount savings)
        {
            _checkingAcc = checking;
            _savingsAcc = savings;
        }

        public void DepositToChecking()
        {
            decimal amount;
            Console.WriteLine("Input the amount you would like to deposit to checking:\n");
            string dcinput = Console.ReadLine();

            if (decimal.TryParse(dcinput, out amount))
            {
                checkingAcc.Deposit(amount);
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
                savingsAcc.Deposit(amount);
                Console.WriteLine("$" + amount + " was deposited into savings.\n");
            }
            else { Console.WriteLine("Invalid amount entered.\n"); }
        }

        public void WithdrawFromChecking(decimal amount)
        {
            combinedBalance = checkingAcc.Balance + savingsAcc.Balance;
            if(amount > (combinedBalance - 10)) // Checks if withdrawal amount would be too high
            {
                Console.WriteLine("Error: Withdrawal amount would exceed the combined checking and savings accounts' balances.");
            }
            else if (amount > checkingAcc.Balance) // Checks if the savings account needs to be used to cover the withdrawal
            {
                decimal overamount = amount - checkingAcc.Balance; // Calculates how much to withdraw from savings to cover for the checking withdrawal
                Console.WriteLine("$" + checkingAcc.Balance + " was withdrawn from checking &");
                checkingAcc.Withdraw(checkingAcc.Balance);
                savingsAcc.Withdraw(overamount);

            } else // A normal withdrawal if the checking balance can handle the withdrawal
            {
                checkingAcc.Withdraw(amount);
            }
        }
        public void WithdrawFromSavings(decimal amount)
        {
            savingsAcc.Withdraw(amount);
        }

        public void CheckBalances()
        {
            Console.WriteLine("Checking Balance: $" + _checkingAcc.Balance + "\n Savings Balance: $" + _savingsAcc.Balance);
        }

        public void SetMemberName(string name)
        {
            _checkingAcc.SetMemberName(name + ".Checking");
            _savingsAcc.SetMemberName(name + ".Savings");
        }
    }
}
