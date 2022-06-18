using NUnit.Framework;
using TDDProject.Application;

namespace TDDProject.Tests
{
    public class BankAccountPayment_Tests
    {
        private Bank Bank { get; set; }

        [SetUp]
        public void Setup()
        {
            this.Bank = new Bank();
            Bank.CreateAccount("Gracjan", "Bryt");
        }

        [Test]
        public void PaymentOnAccount_Test()
        {
            // Arrange
            string myAccountNumber = Bank.Accounts[0].AccountNumber;
            decimal deposit = 100.00m;

            // Act
            Bank.Deposit(myAccountNumber, deposit);

            // Assert
            Assert.AreEqual(100.00, Bank.Accounts[0].Balance);
        }


    }
}
