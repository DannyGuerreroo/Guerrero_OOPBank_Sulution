using Moq;
using OOPBank;
using System.Runtime.CompilerServices;

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
            cust.CheckBalances();
            Assert.AreEqual(2000, cust.checkingAccount.Balance);
            Assert.AreEqual(3000, cust.savingsAccount.Balance);
        }
        [TestMethod]
        public void CustomerSetMemberNameSuccess()
        {
            Customer cust = new Customer();
            cust.SetMemberName("John");
            Assert.AreEqual("John.Checking", cust.checkingAccount.MemberName);
            Assert.AreEqual("John.Savings", cust.savingsAccount.MemberName);
        }
        [TestMethod]
        public void DepositToCheckingSuccess()
        {
            Customer cust = new Customer();
            Console.SetIn(new StringReader("4000"));
            cust.DepositToChecking();
            Assert.AreEqual(4000, cust.checkingAccount.Balance);
        }
        [TestMethod]
        public void DepositToCheckingError()
        {
            Customer cust = new Customer();
            Console.SetIn(new StringReader("letters"));
            cust.DepositToChecking();
            Assert.AreEqual(0, cust.checkingAccount.Balance);
        }
        [TestMethod]
        public void DepositToSavingsSuccess()
        {
            Customer cust = new Customer();
            Console.SetIn(new StringReader("6000"));
            cust.DepositToSavings();
            Assert.AreEqual(6000, cust.savingsAccount.Balance);
        }
        [TestMethod]
        public void DepositToSavingsError()
        {
            Customer cust = new Customer();
            Console.SetIn(new StringReader("let.ters"));
            cust.DepositToSavings();
            Assert.AreEqual(0, cust.savingsAccount.Balance);
        }
        [TestMethod]
        public void WithdrawFromCheckingNormalSuccess()
        {
            Customer cust = new Customer();
            Console.SetIn(new StringReader("2000"));
            cust.DepositToChecking();
            cust.WithdrawFromChecking(1000);
            Assert.AreEqual(1000, cust.checkingAccount.Balance);
        }
        [TestMethod]
        public void WithdrawFromCheckingOverdrawSuccess()
        {
            Customer cust = new Customer();
            Console.SetIn(new StringReader("2000"));
            cust.DepositToChecking();
            Console.SetIn(new StringReader("2000"));
            cust.DepositToSavings();
            cust.WithdrawFromChecking(3000);
            Assert.AreEqual(0, cust.checkingAccount.Balance);
            Assert.AreEqual(1000, cust.savingsAccount.Balance);
        }
        [TestMethod]
        public void WithdrawFromCheckingTooHighError()
        {
            Customer cust = new Customer();
            Console.SetIn(new StringReader("2000"));
            cust.DepositToChecking();
            Console.SetIn(new StringReader("2000"));
            cust.DepositToSavings();
            cust.WithdrawFromChecking(5000);
            Assert.AreEqual(2000, cust.checkingAccount.Balance);
            Assert.AreEqual(2000, cust.savingsAccount.Balance);
        }
        [TestMethod]
        public void WithdrawFromSavingsSuccess()
        {
            Customer cust = new Customer();
            Console.SetIn(new StringReader("2000"));
            cust.DepositToSavings();
            cust.WithdrawFromSavings(500);
            Assert.AreEqual(1500, cust.savingsAccount.Balance);
        }
        [TestMethod]
        public void WithdrawFromSavingsError()
        {
            Customer cust = new Customer();
            Console.SetIn(new StringReader("2000"));
            cust.DepositToSavings();
            cust.WithdrawFromSavings(3000);
            Assert.AreEqual(2000, cust.savingsAccount.Balance);
        }


        [TestMethod]
        public void BankAddMembersSuccess()
        {
            Customer cust = new Customer();
            Bank bank = new Bank();
            bank.AddMember(cust.checkingAccount);
            Assert.IsTrue(bank.members.Contains(cust.checkingAccount));
        }
        [TestMethod]
        public void CheckVaultBalanceSuccess()
        {
            Customer cust = new Customer();
            Bank bank = new Bank();
            Vault vault = new Vault();
            cust.checkingAccount.Deposit(2000);
            cust.savingsAccount.Deposit(5000);
            bank.AddMember(cust.checkingAccount);
            bank.AddMember(cust.savingsAccount);
            vault.CheckVaultBalance(bank.members);
            Assert.AreEqual(7000, vault.VaultBalance);
        }
    }
}