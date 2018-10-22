using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class NullAccount : iAccount
    {

        public decimal Balance { get; set; }
        public int RewardPoints { get; set; }

        /// <summary>
        /// 0 points
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int CalculateRewardPoints(decimal amount)
        {
            return 0;
        }

        public void AddTransaction(decimal amount)
        {

        }
    }
}
