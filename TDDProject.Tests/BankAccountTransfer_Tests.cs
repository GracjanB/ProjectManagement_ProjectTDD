using NUnit.Framework;
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

        private void Transfer_Test()
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
    }
}
