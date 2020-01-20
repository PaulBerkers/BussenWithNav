using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussenWithNav.Classes
{
    public class Deck
    {
        List<Card> _cards = new List<Card>();
        Random _random = new Random();

        public Deck()
        {
            foreach (CardColor color in Enum.GetValues(typeof(CardColor)))
            {
                foreach (CardValue value in Enum.GetValues(typeof(CardValue)))
                {
                    Card c = new Card(color, value);
                    _cards.Add(c);
                    _cards.Add(c);
                }
            }
        }

        public Card DrawCard()
        {
            Card c = _cards[_random.Next(_cards.Count)];

            _cards.Remove(c);

            return c;
        }
    }
}
