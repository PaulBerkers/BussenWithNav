using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussenWithNav.Classes
{
    public class Table
    {
        List<Card> _cards = new List<Card>();

        public List<Card> Cards
        {
            get { return _cards; }
        }


        public void AddCard(Card card)
        {
            _cards.Add(card);
        }

        public void RemoveCard(Card card)
        {
            _cards.Remove(card);
        }
    }
}
