﻿using NUnit.Framework;
using TDDProject.Application;

namespace TDDProject.Tests
{
    public class BankAccountWithdrawal_Tests
    {
        private Bank Bank { get; set; }

        [SetUp]
        public void Setup()
        {
            this.Bank = new Bank();
            Bank.CreateAccount("Gracjan", "Bryt");
            Bank.Accounts[0].Balance = 1000.00m;
        }

        [Test]
        public void Withdrawal_Test()
        {
            // Arrange
            string myAccountNumber = Bank.Accounts[0].AccountNumber;
            decimal withdrawal = 100.00m;

            // Act
            Bank.Withdrawal(myAccountNumber, withdrawal);

            // Assert
            Assert.AreEqual(900.00, Bank.Accounts[0].Balance);
        }

        [Test]
        public void Withdrawal_AccountNotFound_Test()
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
