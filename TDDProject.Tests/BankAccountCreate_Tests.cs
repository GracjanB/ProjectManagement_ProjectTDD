using NUnit.Framework;
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
            Assert.AreNotEqual(null, Bank.Accounts);
            Assert.AreEqual(1, Bank.Accounts.Count);
        }
    }
}
