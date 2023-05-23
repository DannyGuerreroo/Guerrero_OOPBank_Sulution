using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPBank
{
    public class SavingsAcc : IAccount
    {
        public SavingsAcc() { }

        public string MemberName { get; set; }

        public decimal Balance { get; set; }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            // Checks if savings account $10 balance requirement is met
            if(amount <= (Balance - 10)) 
            { 
                Balance -= amount;
                Console.WriteLine("$" + amount + " was withdrawn from savings.\n");
            }
            //else { throw new Exception("Error: Withdrawal amount would exceed the $10 savings account minimum."); }
            else { Console.WriteLine("Error: Withdrawal amount would exceed the $10 savings account minimum."); }
        }
        public void SetMemberName(string name)
        {
            MemberName = name;
        }

    }
}
