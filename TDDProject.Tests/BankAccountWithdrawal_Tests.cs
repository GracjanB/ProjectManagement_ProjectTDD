using NUnit.Framework;
using System;
using TDDProject.Application;
using TDDProject.Application.Models;

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
            decimal withdrawal = 100.00m;

            // Assert
            Assert.Throws(typeof(AccountNotFoundException), () =>
            {
                Bank.Withdrawal(myAccountNumber, withdrawal);
            });
        }

        [Test]
        public void Withdrawal_AmountCheck_Test()
        {
            // Arrange
            string myAccountNumber = Bank.Accounts[0].AccountNumber;

            // Assert
            Assert.Throws(typeof(ArgumentException), () =>
            {
                decimal withdrawal = 0.00m;

                Bank.Deposit(myAccountNumber, withdrawal);
            });
        }

        [Test]
        public void PaymentOnAccount_AccountNumberCheck_Test()
        {
            // Arrange
            decimal withdrawal = 100.00m;

            // Assert
            Assert.Throws(typeof(ArgumentException), () =>
            {
                string accountNumber = "908324092384";

                Bank.Withdrawal(accountNumber, withdrawal);
            });

            Assert.Throws(typeof(ArgumentException), () =>
            {
                string accountNumber = null;

                Bank.Withdrawal(accountNumber, withdrawal);
            });

            Assert.Throws(typeof(ArgumentException), () =>
            {
                // 26 literals, account number should be 26 character (but digits) long
                string accountNumber = "QAZWSXEDCRFVTGBYHNUJMIKOLP";

                Bank.Withdrawal(accountNumber, withdrawal);
            });
        }

        [Test]
        public void Withdrawal_BalanceCheck_Test()
        {
            // Arrange
            BankAccount myAccount = Bank.Accounts[0];
            myAccount.Balance = 200.00m;

            // Assert
            Assert.Throws(typeof(InsufficientFundsException), () =>
            {
                decimal withdrawal = 300.00m;

                Bank.Deposit(myAccount.AccountNumber, withdrawal);
            });
        }
    }
}
