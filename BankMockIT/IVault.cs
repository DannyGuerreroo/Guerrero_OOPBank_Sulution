
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPBank
{
    interface IVault // Vault intended to display combined balances of all bank members
    {
        decimal VaultBalance { get; }

        void CheckVaultBalance(List<IAccount> members);
    }
}
