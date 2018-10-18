﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

    internal class SilverAccount : iAccount
    {
        private const int SilverTransactionCostPerPoint = 10;

        public decimal Balance { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int RewardPoints { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// 1 point for each $10 deposited
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int CalculateRewardPoints(decimal amount)
        {
            return (int)decimal.Floor(amount / SilverTransactionCostPerPoint);
        }

        public void AddTransaction(decimal amount)
        {
            // only award reward points on deposit
            if (amount > 0) RewardPoints += CalculateRewardPoints(amount);
            // always update balance
            Balance += amount;
        }

    }
}
