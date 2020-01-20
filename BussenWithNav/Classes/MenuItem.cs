using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace BussenWithNav.Classes
{
    public class MenuItem
    {
        private Type _page;

        public Type Page
        {
            get { return _page; }
        }

        private string _text;

        public string Text
        {
            get { return _text; }
        }

        private Symbol _icon;

        public IconElement Icon
        {
            get { return new SymbolIcon(_icon); }
        }

        public MenuItem(Type page, string text, Symbol icon)
        {
            _page = page;
            _text = text;
            _icon = icon;
        }

    }
}
