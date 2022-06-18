using NUnit.Framework;
using System;
using TDDProject.Application;

namespace TDDProject.Tests
{
    public class BankAccountTransfer_Tests
    {
        private Bank Bank { get; set; }

        [SetUp]
        public void Setup()
        {
            this.Bank = new Bank();

            Bank.CreateAccount("Gracjan", "Bryt");
            Bank.CreateAccount("Jan", "Kowalski");
            Bank.CreateAccount("Jan", "Nowak");
        }

        [Test]
        public void Transfer_Test()
        {
            // Arrange
            string sourceAccountNumber = Bank.Accounts[0].AccountNumber;
            string destinationAccountNumber = Bank.Accounts[1].AccountNumber;
            Bank.Accounts[0].Balance = 1000.00m;
            Bank.Accounts[1].Balance = 500.00m;
            decimal moneyToSend = 200.00m;

            // Act
            Bank.Transfer(sourceAccountNumber, destinationAccountNumber, moneyToSend);

            // Assert
            Assert.AreEqual(800.00m, Bank.Accounts[0].Balance);
            Assert.AreEqual(700.00m, Bank.Accounts[1].Balance);
        }

        [Test]
        public void Transfer_AccountsNotFound_Test()
        {
            // Arrange
            string sourceAccountNumber = Bank.Accounts[0].AccountNumber;
            string destinationAccountNumber = Bank.Accounts[1].AccountNumber;
            string fakeAccount = "03759364017364592745001836";
            Bank.Accounts[0].Balance = 1000.00m;
            Bank.Accounts[1].Balance = 500.00m;
            decimal moneyToSend = 200.00m;

            // Assert
            Assert.Throws(typeof(AccountNotFoundException), () =>
            {
                Bank.Transfer(fakeAccount, destinationAccountNumber, moneyToSend);
            });

            Assert.Throws(typeof(AccountNotFoundException), () =>
            {
                Bank.Transfer(sourceAccountNumber, fakeAccount, moneyToSend);
            });
        }

        [Test]
        public void Transfer_MoneyToSendCheck_Test()
        {
            // Arrange
            string sourceAccountNumber = Bank.Accounts[0].AccountNumber;
            string destinationAccountNumber = Bank.Accounts[1].AccountNumber;
            Bank.Accounts[0].Balance = 1000.00m;
            Bank.Accounts[1].Balance = 500.00m;
            decimal moneyToSend = 0.00m;

            // Assert
            Assert.Throws(typeof(AccountNotFoundException), () =>
            {
                Bank.Transfer(sourceAccountNumber, destinationAccountNumber, moneyToSend);
            });
        }
    }
}
