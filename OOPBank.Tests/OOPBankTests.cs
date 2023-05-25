using Moq;
using OOPBank;
using System.Runtime.CompilerServices;

namespace OOPBank.Tests
{
    [TestClass]
    public class OOPBankTests
    {
        [TestMethod]
        public void CustomerCheckBalancesSuccess() // Asserts that the console output matches the actual balances
        {
            var amount = 1000;
            var MockChecking = new Mock<CheckingAcc>();
            MockChecking.SetupProperty(c => c.Balance, amount);
            var MockSavings = new Mock<SavingsAcc>();
            MockSavings.SetupProperty(s => s.Balance, amount);
            Customer customer = new Customer(MockChecking.Object, MockSavings.Object);
            var sw = new StringWriter();
            Console.SetOut(sw);
            customer.CheckBalances();
            var output = sw.ToString().Trim();
            Assert.AreEqual("Checking Balance: $" + amount + "\n Savings Balance: $" + amount, output);
        }
        [TestMethod]
        public void CustomerSetMemberNameSuccess() // Asserts that the member's names are accurately being set
        {
            var MockChecking = new Mock<CheckingAcc>();
            var MockSavings = new Mock<SavingsAcc>();
            Customer customer = new Customer(MockChecking.Object, MockSavings.Object);
            customer.SetMemberName("John");
            Assert.AreEqual("John.Checking", MockChecking.Object.MemberName);
            Assert.AreEqual("John.Savings", MockSavings.Object.MemberName);
        }
        [TestMethod]
        public void DepositToCheckingSuccess() // Asserts that depositing to checking functions
        {
            var amount = 4000;
            var check = new CheckingAcc();
            var saving = new SavingsAcc();
            Customer customer = new Customer(check, saving);
            Console.SetIn(new StringReader(amount.ToString()));
            customer.DepositToChecking();
            Assert.AreEqual(amount, check.Balance);
        }
        [TestMethod]
        public void DepositToCheckingError() // Asserts that incorrect amounts are caught
        {
            var MockChecking = new Mock<CheckingAcc>();
            var MockSavings = new Mock<SavingsAcc>();
            Customer customer = new Customer(MockChecking.Object, MockSavings.Object);
            Console.SetIn(new StringReader("letters")); // The input for the DepositToChecking() method
            var sw = new StringWriter();
            Console.SetOut(sw);
            customer.DepositToChecking();
            var output = sw.ToString().Trim();
            Assert.AreEqual("Input the amount you would like to deposit to checking:\n\r\nInvalid amount entered.", output);
        }
        [TestMethod]
        public void DepositToSavingsSuccess() // Asserts that depositing to savings functions
        {
            var check = new CheckingAcc();
            var saving = new SavingsAcc();
            Customer customer = new Customer(check, saving);
            Console.SetIn(new StringReader("6000"));
            customer.DepositToSavings();
            Assert.AreEqual(6000, saving.Balance);
        }
        [TestMethod]
        public void DepositToSavingsError() // Asserts that incorrect amounts are caught
        {
            var MockChecking = new Mock<CheckingAcc>();
            var MockSavings = new Mock<SavingsAcc>();
            Customer customer = new Customer(MockChecking.Object, MockSavings.Object);
            Console.SetIn(new StringReader("letters")); // The input for the DepositToSavings() method
            var sw = new StringWriter();
            Console.SetOut(sw);
            customer.DepositToSavings();
            var output = sw.ToString().Trim();
            Assert.AreEqual("Input the amount you would like to deposit to savings:\n\r\nInvalid amount entered.", output);
        }
        [TestMethod]
        public void WithdrawFromCheckingNormalSuccess() // Asserts that withdrawing from checking functions for normal amounts
        {
            var MockChecking = new Mock<CheckingAcc>();
            MockChecking.SetupProperty(c => c.Balance, 5000);
            var MockSavings = new Mock<SavingsAcc>();
            Customer customer = new Customer(MockChecking.Object, MockSavings.Object);
            customer.WithdrawFromChecking(1000);
            Assert.AreEqual(4000, MockChecking.Object.Balance);
        }
        [TestMethod]
        public void WithdrawFromCheckingOverdrawSuccess() // Asserts that withdrawing from checking properly draws from savings for high amounts
        {
            var MockChecking = new Mock<CheckingAcc>();
            MockChecking.SetupProperty(c => c.Balance, 2000);
            var MockSavings = new Mock<SavingsAcc>();
            MockSavings.SetupProperty(s => s.Balance, 2000);
            Customer customer = new Customer(MockChecking.Object, MockSavings.Object);
            customer.WithdrawFromChecking(3000);
            Assert.AreEqual(0, MockChecking.Object.Balance);
            Assert.AreEqual(1000, MockSavings.Object.Balance);
        }
        [TestMethod]
        public void WithdrawFromCheckingTooHighError() // Asserts that an error is given when inputting too large of an amount
        {
            var MockChecking = new Mock<CheckingAcc>();
            MockChecking.SetupProperty(c => c.Balance, 2000);
            var MockSavings = new Mock<SavingsAcc>();
            MockSavings.SetupProperty(s => s.Balance, 2000);
            Customer customer = new Customer(MockChecking.Object, MockSavings.Object);
            var sw = new StringWriter();
            Console.SetOut(sw);
            customer.WithdrawFromChecking(5000);
            var output = sw.ToString().Trim();
            Assert.AreEqual("Error: Withdrawal amount would exceed the combined checking and savings accounts' balances.", output);
        }
        [TestMethod]
        public void WithdrawFromSavingsSuccess() // Asserts that withdrawing from savings functions
        {
            var MockChecking = new Mock<CheckingAcc>();
            var MockSavings = new Mock<SavingsAcc>();
            MockSavings.SetupProperty(s => s.Balance, 5000);
            Customer customer = new Customer(MockChecking.Object, MockSavings.Object);
            customer.WithdrawFromSavings(3000);
            Assert.AreEqual(2000, MockSavings.Object.Balance);
        }
        [TestMethod]
        public void WithdrawFromSavingsError() // Asserts that an error is given when inputting too large of an amount
        {
            var MockChecking = new Mock<CheckingAcc>();
            var MockSavings = new Mock<SavingsAcc>();
            MockSavings.SetupProperty(s => s.Balance, 500);
            Customer customer = new Customer(MockChecking.Object, MockSavings.Object);
            var sw = new StringWriter();
            Console.SetOut(sw);
            customer.WithdrawFromSavings(495);
            var output = sw.ToString().Trim();
            Assert.AreEqual("Error: Withdrawal amount would exceed the $10 savings account minimum.", output);
        }


        [TestMethod]
        public void BankAddMembersSuccess() // Asserts that accounts are properly added to members list
        {
            var MockAccount = new Mock<IAccount>();
            Bank bank = new Bank();
            bank.AddMember(MockAccount.Object);
            Assert.IsTrue(bank.members.Contains(MockAccount.Object));
        }
        [TestMethod]
        public void CheckVaultBalanceSuccess()
        {
            var MockChecking = new Mock<CheckingAcc>();
            MockChecking.SetupProperty(c => c.Balance, 2000);
            var MockSavings = new Mock<SavingsAcc>();
            MockSavings.SetupProperty(s => s.Balance, 5000);
            var MockBank = new Mock<Bank>();
            MockBank.Object.AddMember(MockChecking.Object);
            MockBank.Object.AddMember(MockSavings.Object);
            Vault vault = new Vault(MockBank.Object);
            vault.CheckVaultBalance(MockBank.Object.members);
            Assert.AreEqual(7000, vault.VaultBalance);
        }
    }
}