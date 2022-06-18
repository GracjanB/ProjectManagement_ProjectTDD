using System;
using System.Collections.Generic;
using System.Linq;
using TDDProject.Application.Models;

namespace TDDProject.Application
{
    public class Bank
    {
        private List<BankAccount> _accounts;
        public List<BankAccount> Accounts
        {
            get 
            { 
                return _accounts; 
            }
            private set 
            { 
                _accounts = value; 
            }
        }


        public Bank()
        {
            Accounts = new List<BankAccount>();
        }


        public void CreateAccount(string name, string surname)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"Parameter '{nameof(name)}' cannot be empty");

            if (string.IsNullOrEmpty(surname) || string.IsNullOrWhiteSpace(surname))
                throw new ArgumentException($"Parameter '{nameof(surname)}' cannot be empty");

            Accounts.Add(new BankAccount()
            {
                Balance = 0.00m,
                AccountNumber = GenerateAccountNumber(),
                Owner = new Owner()
                {
                    Name = name,
                    Surname = surname
                }
            });
        }

        public void Deposit(string accountNumber, decimal deposit)
        {
            ValidateAccountNumber(ref accountNumber);

            var account = Accounts.SingleOrDefault(x => x.AccountNumber == accountNumber);

            if (account is null)
                throw new AccountNotFoundException($"Account number '{accountNumber}' does not exists.");

            if (deposit <= 0.00m)
                throw new ArgumentException($"Deposit cannot be smaller than 0.00");

            account.Balance += deposit;
        }

        private string GenerateAccountNumber()
        {
            string number = string.Empty;
            Random rand = new Random();

            for (int i = 0; i <= 26; i++)
            {
                number += rand.Next(0, 9);
            }

            return number;
        }

        private void ValidateAccountNumber(ref string number)
        {
            if (string.IsNullOrEmpty(number))
                throw new ArgumentException("Incorrect format of account number.");

            if (number.Length != 26)
                throw new ArgumentException("Incorrect format of account number. Should be 26 characters long.");

            if (!number.ToCharArray().All(c => char.IsDigit(c)))
                throw new ArgumentException("Account number contains forbidden characters.");
        }
    }
}
