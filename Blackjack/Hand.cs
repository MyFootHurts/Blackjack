using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Hand
    {
        public int handValue;

        private int numOfHighAces;

        private List<Card> hand;

        public bool bust;
        public bool blackjack;

        public Hand()
        {
            hand = new List<Card>();

            numOfHighAces = 0;

            bust = false;
            blackjack = false;
        }

        public void AddCardToHand(Card card)
        {
            hand.Add(card);

            UpdateHandValue(card);
        }

        private int CalculateCardValue(Card card)
        {
            int x = 0;

            //if is a number, return that number
            if (Int32.TryParse(card.value, out x))
            {
                return x;
            }

            else if (card.value == "A")
            {
                if ((21 - handValue) < 11)
                {
                    return 1;
                }

                else
                {
                    numOfHighAces++;
                    return 11;
                }

            }
            else
            {
                //if jack, queen or king
                return 10;
            }
        }

        private void UpdateHandValue(Card newCard)
        {
            handValue += CalculateCardValue(newCard);

            CheckForBust();
        }

        public void CheckForBlackjack()
        {
            if (hand.Count() == 2 && handValue == 21)
            {
                blackjack = true;
            }
        }

        private void CheckForBust()
        {
            if (handValue > 21)
            {
                if (numOfHighAces > 0)
                {
                    AceOverdraw();
                }

                else
                {
                    bust = true;
                }
            }
        }

        //lazy way of changing aces from 11 to 1 if player would've gone bust
        private void AceOverdraw()
        {
            handValue -= 10;

            numOfHighAces--;
        }
    }
}
