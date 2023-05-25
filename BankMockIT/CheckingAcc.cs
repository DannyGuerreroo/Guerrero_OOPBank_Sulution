using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPBank
{
    public class CheckingAcc : IAccount
    {
        public CheckingAcc() { }

        public string MemberName { get; set; }

        public virtual decimal Balance { get; set; }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            Balance -= amount;
            Console.WriteLine("$" + amount + " was withdrawn from checking.\n");
        }

        public void SetMemberName(string name)
        {
            MemberName = name;
        }

    }
}
