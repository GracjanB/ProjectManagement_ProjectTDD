using System;
using System.Collections.Generic;
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

            Accounts.Add(new BankAccount()
            {
                Balance = 0.00m,
                Owner = new Owner()
                {
                    Name = name,
                    Surname = surname
                }
            });
        }
    }
}
