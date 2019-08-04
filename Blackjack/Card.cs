using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Card
    {
        Suit suit { get; set; }

        public string value { get; set; }

        public Card(Suit s, string v)
        {
            suit = s;
            value = v;
        }
    }
}
