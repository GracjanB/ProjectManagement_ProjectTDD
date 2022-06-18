using NUnit.Framework;
using System.Linq;
using TDDProject.Application;

namespace TDDProject.Tests
{
    public class BankAccountRemove_Tests
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
        public void DeleteAccount()
        {
            // Arrange
            string accountNumber = Bank.Accounts[0].AccountNumber;
            string name = "Gracjan";
            string surname = "Bryt";

            // Act
            Bank.DeleteAccount(name, surname, accountNumber);

            // Assert
            Assert.IsNull(Bank.Accounts.SingleOrDefault(x => x.AccountNumber == accountNumber));
        }

        [Test]
        public void DeleteAccount_AccountNotFound()
        {
            // Arrange
            string accountNumber = "327439842389";
            string name = "Gracjan";
            string surname = "Bryt";

            Assert.Throws(typeof(AccountNotFoundException), () =>
            {
                Bank.DeleteAccount(name, surname, accountNumber);
            });
        }
    }
}
