using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace BussenWithNav.Classes
{
    public enum CardValue
    {
        aas,
        two,
        three,
        four,
        five,
        six,
        seven,
        eight,
        nine,
        ten,
    }

    public enum CardColor
    {
        black,
        red
    }
    public class Card { 
        private CardColor _color;

        public CardColor Color
        {
            get { return _color; }
            set { _color = value; }
        }

        private CardValue _value;

        public CardValue Value
        {
            get { return _value; }
            set { _value = value; }
        }

        private ImageSource _image;

        public ImageSource Image
        {
            get { return _image; }
            set { _image = value; }
        }

        public Card(CardColor color, CardValue value)
        {
            _color = color;
            _value = value;
            _image = new BitmapImage(new Uri("ms-appx:///Assets/cards/" + $"{color}-{value}" + ".png"));
        }
    }
}
