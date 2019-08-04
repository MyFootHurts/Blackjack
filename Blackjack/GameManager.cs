using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class GameManager
    {
        private Deck deck;
        private Hand playerHand;
        private Hand dealerHand;
        private Money money;
        private Hand[] hands;

        private bool canHit;

        public GameManager()
        {
            deck = new Deck();
            playerHand = new Hand();
            dealerHand = new Hand();
            money = new Money();
            hands = new Hand[] { playerHand, dealerHand };
            canHit = true;

            deck.Shuffle();
        }

        private void InitialDeal()
        {
            if (money.stake != 0)
            {
                PlayPhase();

                for (int i = 0; i < hands.Count(); i++)
                {
                    for (int x = 0; x < 2; x++)
                    {
                        Hit(hands[i]);
                    }

                    hands[i].CheckForBlackjack();
                }

                if (playerHand.blackjack == true && dealerHand.blackjack == false)
                {
                    money.WinStake();
                }

                else if (playerHand.blackjack == true && dealerHand.blackjack == true)
                {
                    money.ReturnStake();
                }

                else if (playerHand.blackjack == false && dealerHand.blackjack == true)
                {
                    money.LoseStake();
                }
            }   
        }

        private void PlayPhase()
        {
            money.HideBetUI();
        }

        private void BetPhase()
        {

        }

        private void Hit(Hand hand)
        {
            if (canHit)
            {
                hand.AddCardToHand(deck.Draw());

                if (hand.bust == true)
                {
                    Bust(hand);
                }
            }
        }

        private void Stand()
        {
            canHit = false;

            DealerTurn();
        }

        private void DealerTurn()
        {
            while (dealerHand.handValue <= 16)
            {
                Hit(dealerHand);
            }
        }

        private void Bust(Hand whichHand)
        {
            if (whichHand == playerHand)
            {
                money.LoseStake();
            }

            else if (whichHand == dealerHand)
            {
                money.WinStake();
            }
        }
    }
}
