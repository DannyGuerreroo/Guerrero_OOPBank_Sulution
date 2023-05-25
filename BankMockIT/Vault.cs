
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPBank
{
    public class Vault : IVault // Vault intended to display combined balances of all bank members
    {
        private Bank _bank = new Bank();  
        public Vault(Bank bank)
        {
            _bank = bank;
        }
        public decimal VaultBalance { get; set; }

        public void CheckVaultBalance(List<IAccount> memberList)
        {
            foreach(IAccount member in memberList)
            {
                VaultBalance += member.Balance;
            }
            Console.WriteLine("Vault Balance: $" + VaultBalance);
        }
    }
}
