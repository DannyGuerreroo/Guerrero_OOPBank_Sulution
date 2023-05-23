using Moq;
using OOPBank;

namespace OOPBank.Tests
{
    [TestClass]
    public class OOPBankTests
    {
        [TestMethod]
        public void CustomerCheckBalancesSuccess()
        {

            Customer cust = new Customer();
            cust.checkingAccount.Deposit(2000);
            cust.savingsAccount.Deposit(3000);
            Assert.AreEqual(2000, cust.checkingAccount.Balance);
            Assert.AreEqual(3000, cust.savingsAccount.Balance);
        }
    }
}