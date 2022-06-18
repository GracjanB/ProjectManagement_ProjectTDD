using NUnit.Framework;
using System;
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

        [Test]
        public void CreateAccount_EmptyName_Test()
        {
            // Arrange
            string name = string.Empty;
            string surname = "Bryt";

            // Assert
            Assert.Throws(typeof(ArgumentException), () =>
            {
                Bank.CreateAccount(name, surname);
            });
        }

        [Test]
        public void CreateAccount_EmptySurname_Test()
        {
            // Arrange
            string name = "Gracjan";
            string surname = string.Empty;

            // Assert
            Assert.Throws(typeof(ArgumentException), () =>
            {
                Bank.CreateAccount(name, surname);
            });
        }

        [Test]
        public void CreateAccount_CheckIfAccountNumberCorrect_Test()
        {
            // Arrange
            var localBank = new Bank();
            string name = "Gracjan";
            string surname = "Bryt";

            // Act
            localBank.CreateAccount(name, surname);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(localBank.Accounts[0].AccountNumber));
            Assert.AreEqual(26, localBank.Accounts[0].AccountNumber.Length);
        }
    }
}
