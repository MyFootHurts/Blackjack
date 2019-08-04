using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    enum Suit
    {
        Spades,
        Diamonds,
        Clubs,
        Hearts
    }

    class Deck
    {
        private List<Card> cards;

        public Deck()
        {
            cards = new List<Card>();

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                cards.Add(new Card(suit, "A"));

                for (int i = 2; i < 11; i++)
                {
                    cards.Add(new Card(suit, i.ToString()));
                }

                cards.Add(new Card(suit, "J"));
                cards.Add(new Card(suit, "Q"));
                cards.Add(new Card(suit, "K"));
            }
        }

        public Card Draw()
        {
            Card tempCardHolder = cards[0];

            cards.RemoveAt(0);

            return tempCardHolder;
        }

        public void Shuffle()
        {
            cards.OrderBy(x => Guid.NewGuid()).ToList();
        }

    }
}
