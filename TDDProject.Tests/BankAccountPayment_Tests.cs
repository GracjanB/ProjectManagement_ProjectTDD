using NUnit.Framework;
using System;
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

        [Test]
        public void PaymentOnAccount_AccountNotFound_Test()
        {
            // Arrange
            string myAccountNumber = "1345236354764314123";
            decimal deposit = 100.00m;

            // Assert
            Assert.Throws(typeof(AccountNotFoundException), () =>
            {
                Bank.Deposit(myAccountNumber, deposit);
            });
        }


    }
}
