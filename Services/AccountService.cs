﻿ 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Services
{
    public class AccountService : IAccountServices
    {
        // store the accounts in a dictionary indexed by the account name
        private Dictionary<string, iAccount> accountsDictionary;

        /// <summary>
        /// instantiate the dictionary for accounts
        /// </summary>
        public AccountService()
        {
            accountsDictionary = new Dictionary<string, iAccount>();
        }
        /// <summary>
        /// create a new account
        /// </summary>
        /// <param name="accountName"></param>
        /// <param name="accountType"></param>
        public void CreateAccount(string accountName, AccountType accountType)
        {
            iAccount newAccount = accountFactory.CreateAccount(accountType);
            accountsDictionary.Add(accountName, newAccount);
        }
        /// <summary>
        /// find the balance of the given account
        /// </summary>
        /// <param name="accountName"></param>
        /// <returns></returns>
        public decimal GetAccountBalance(string accountName)
        {
            iAccount acc = FindAccount(accountName);
            return acc.Balance;
        }
        /// <summary>
        /// find the reward points of the given account
        /// </summary>
        /// <param name="accountName"></param>
        /// <returns></returns>
        public int GetRewardPoints(string accountName)
        {
            iAccount acc = FindAccount(accountName);
            return acc.RewardPoints;
        }
        /// <summary>
        /// deposit the given account into the account named
        /// </summary>
        /// <param name="accountName"></param>
        /// <param name="amount"></param>
        public void Deposit(string accountName, decimal amount)
        {
            iAccount acc = FindAccount(accountName);
            acc.AddTransaction(amount);
        }
        /// <summary>
        /// withdrawal the given account into the account named
        /// </summary>
        /// <param name="accountName"></param>
        /// <param name="amount"></param>
        public void Withdrawal(string accountName, decimal amount)
        {
            iAccount acc = FindAccount(accountName);
            // for withdrawal, subtract amount
            acc.AddTransaction(-1*amount);
        }
        /// <summary>
        /// Look up the account by name in the dictionar
        /// </summary>
        /// <param name="accountName"></param>
        /// <returns>returns null if name not found</returns>
        private iAccount FindAccount(string accountName)
        {
            if (accountsDictionary.ContainsKey(accountName))
            {
                return accountsDictionary[accountName];
            }
            return null;
        }

    }
}
