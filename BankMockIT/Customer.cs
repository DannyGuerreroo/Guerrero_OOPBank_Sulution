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
        private decimal combinedBalance;

        private IAccount _checkingAcc = new CheckingAcc();
        private IAccount _savingsAcc = new SavingsAcc();

        public Customer(IAccount checking, IAccount savings)
        {
            _checkingAcc = checking;
            _savingsAcc = savings;
        }

        public decimal ParseAmount(string input) // Parses input into decimal
        {
            decimal amount;
            if (decimal.TryParse(input, out amount))
            {
                return amount;
            }
            else
            {
                amount = 0;
                return amount;
            }
        }

        public void DepositToChecking()
        {
            decimal amount;
            Console.WriteLine("Input the amount you would like to deposit to checking:\n");
            string dcinput = Console.ReadLine();
            amount = ParseAmount(dcinput);
            if (amount > 0)
            {
                _checkingAcc.Deposit(amount);
                Console.WriteLine("$" + amount + " was deposited into checking.\n");
            }
            else { Console.WriteLine("Invalid amount entered.\n"); }
        }
        public void DepositToSavings() 
        {
            decimal amount;
            Console.WriteLine("Input the amount you would like to deposit to savings:\n");
            string dsinput = Console.ReadLine();
            amount = ParseAmount(dsinput);
            if (amount > 0)
            {
                _savingsAcc.Deposit(amount);
                Console.WriteLine("$" + amount + " was deposited into savings.\n");
            }
            else { Console.WriteLine("Invalid amount entered.\n"); }
        }

        public void WithdrawFromChecking(decimal amount)
        {
            combinedBalance = _checkingAcc.Balance + _savingsAcc.Balance;
            if(amount > (combinedBalance - 10)) // Checks if withdrawal amount would be too high
            {
                Console.WriteLine("Error: Withdrawal amount would exceed the combined checking and savings accounts' balances.");
            }
            else if (amount > _checkingAcc.Balance) // Checks if the savings account needs to be used to cover the withdrawal
            {
                decimal overamount = amount - _checkingAcc.Balance; // Calculates how much to withdraw from savings to cover for the checking withdrawal
                _checkingAcc.Withdraw(_checkingAcc.Balance);
                _savingsAcc.Withdraw(overamount);

            } else // A normal withdrawal if the checking balance can handle the withdrawal
            {
                _checkingAcc.Withdraw(amount);
            }
        }
        public void WithdrawFromSavings(decimal amount)
        {
            _savingsAcc.Withdraw(amount);
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
