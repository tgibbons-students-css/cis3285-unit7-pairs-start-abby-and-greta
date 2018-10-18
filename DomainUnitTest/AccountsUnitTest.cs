﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;

namespace DomainUnitTest
{
    [TestClass]
    public class AccountsUnitTest
    {
        [TestMethod]
        public void CreateAccountSetsBalanceToZero()
        {
            // Arrange    
            iAccount testAccount = accountFactory.CreateAccount(AccountType.Silver);
            // Act
            decimal balance = testAccount.Balance;
            // Assert
            Assert.AreEqual(balance, 0.00M);
        }
        [TestMethod]
        public void DepositToAccountBalance()
        {
            // Arrange    
            iAccount testAccount = accountFactory.CreateAccount(AccountType.Silver);
            // Act
            testAccount.AddTransaction(+123.45M);
            decimal balance = testAccount.Balance;
            // Assert
            Assert.AreEqual(balance, +123.45M);
        }
        [TestMethod]
        public void WithdrawalToAccountBalance()
        {
            // Arrange    
            iAccount testAccount = accountFactory.CreateAccount(AccountType.Silver);
            // Act
            testAccount.AddTransaction(+200M);
            testAccount.AddTransaction(-100M);
            decimal balance = testAccount.Balance;
            // Assert
            Assert.AreEqual(balance, +100M);
        }
        [TestMethod]
        public void NegativeBalanceAllowed()
        {
            // Arrange    
            iAccount testAccount = accountFactory.CreateAccount(AccountType.Silver);
            // Act
            testAccount.AddTransaction(+200M);
            testAccount.AddTransaction(-500M);
            decimal balance = testAccount.Balance;
            // Assert
            Assert.AreEqual(balance, -300M);
        }

        ///
        ///   =================== Reward Points
        ///
        [TestMethod]
        public void RewardPoints_Silver_Deposit()
        {
            // Arrange    
            iAccount testAccount = accountFactory.CreateAccount(AccountType.Silver);
            // Act
            testAccount.AddTransaction(1000M);
            testAccount.AddTransaction(1000M);
            int points = testAccount.RewardPoints;
            // Assert
            Assert.AreEqual(points, 200);
        }
        [TestMethod]
        public void RewardPoints_Silver_Withdrawal()
        {
            // Arrange    
            iAccount testAccount = accountFactory.CreateAccount(AccountType.Silver);
            // Act
            testAccount.AddTransaction(1000M);
            testAccount.AddTransaction(1000M);
            testAccount.AddTransaction(-1000M);
            int points = testAccount.RewardPoints;
            // Assert
            Assert.AreEqual(points, 200);
        }
        [TestMethod]
        public void RewardPoint_Gold_Deposit()
        {
            // Arrange    
            iAccount testAccount = accountFactory.CreateAccount(AccountType.Gold);
            // Act
            testAccount.AddTransaction(4000M);
            testAccount.AddTransaction(4000M);
            int points = testAccount.RewardPoints;
            // Assert
            Assert.AreEqual(points, 800 + 2 + 800);
        }
        [TestMethod]
        public void RewardPoints_Gold_Withdrawal()
        {
            // Arrange    
            iAccount testAccount = accountFactory.CreateAccount(AccountType.Gold);
            // Act
            testAccount.AddTransaction(4000M);
            testAccount.AddTransaction(4000M);
            testAccount.AddTransaction(-1000M);
            int points = testAccount.RewardPoints;
            // Assert
            Assert.AreEqual(points, 800 + 2 + 800);
        }
        [TestMethod]
        public void RewardPoints_Platinum_Deposit()
        {
            // Arrange    
            iAccount testAccount = accountFactory.CreateAccount(AccountType.Platinum);
            // Act
            testAccount.AddTransaction(4000M);
            testAccount.AddTransaction(4000M);
            int points = testAccount.RewardPoints;
            // Assert
            Assert.AreEqual(points, 2000 + 4 + 2000);
        }
        [TestMethod]
        public void RewardPoints_Platinum_Withdrawal()
        {
            // Arrange    
            iAccount testAccount = accountFactory.CreateAccount(AccountType.Platinum);
            // Act
            testAccount.AddTransaction(4000M);
            testAccount.AddTransaction(4000M);
            testAccount.AddTransaction(-1000M);
            int points = testAccount.RewardPoints;
            // Assert
            Assert.AreEqual(points, 2000 + 4 + 2000);
        }
    }
}
