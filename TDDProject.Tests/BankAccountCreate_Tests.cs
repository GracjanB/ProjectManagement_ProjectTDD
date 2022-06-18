using NUnit.Framework;
using System.Linq;
using TDDProject.Application;

namespace TDDProject.Tests
{
    public class BankAccountCreate_Tests
    {
        private Bank Bank { get; set; }

        [SetUp]
        public void Setup()
        {
            this.Bank = new Bank();
        }

        [Test]
        public void CreateAccount_Test()
        {
            // Arrange
            string name = "Gracjan";
            string surname = "Bryt";

            // Act
            Bank.CreateAccount(name, surname);

            // Assert
            Assert.AreNotEqual(null, Bank.Accounts);
            Assert.AreEqual(1, Bank.Accounts.Count);
            Assert.AreEqual(name, Bank.Accounts[0].Owner.Name);
            Assert.AreEqual(surname, Bank.Accounts[0].Owner.Surname);
        }
    }
}
