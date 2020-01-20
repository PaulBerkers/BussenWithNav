using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussenWithNav.Classes
{
    public class DropStack
    {
        List<Card> _cards = new List<Card>();

        public DropStack(Card firstCard)
        {
            _cards.Add(firstCard);
        }

        public Card[] GetUnusedCards()
        {
            return null;
        }

        public Card GetTopCard()
        {
            return _cards[_cards.Count - 1];
        }
    }
}
