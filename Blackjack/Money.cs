using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Money
    {
        private int startMoney;
        private int currentMoney;
        private int stakeAdjustmentValue;

        public int stake;

        public Money()
        {
            startMoney = 1000;
            currentMoney = startMoney;
            stakeAdjustmentValue = 50;
        }

        public void HideBetUI()
        {

        }

        public void IncreaseStake()
        {
            if (currentMoney >= stakeAdjustmentValue)
            {
                stake += stakeAdjustmentValue;

                currentMoney -= stakeAdjustmentValue;
            }  
        }

        public void DecreaseStake()
        {
            if (stake != 0)
            {
                stake -= stakeAdjustmentValue;

                currentMoney += stakeAdjustmentValue;
            }
        }

        public void ReturnStake()
        {
            currentMoney += stake;

            stake = 0;
        }

        public void WinStake()
        {
            currentMoney += stake * 2;

            stake = 0;
        }

        public void LoseStake()
        {
            stake = 0;
        }
    }
}
