﻿using System.Collections.Generic;
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


        public void CreateAccount()
        {
            Accounts.Add(new BankAccount());
        }
    }
}
