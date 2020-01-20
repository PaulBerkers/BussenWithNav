using BussenWithNav.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BussenWithNav.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GuessColorpagina : Page
    {
        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        Deck _deck = new Deck();
        DispatcherTimer dt = new DispatcherTimer();
        DropStack _dropStack;
        int Bedrag;
        int Counter;
        public GuessColorpagina()
        {
            this.InitializeComponent();
            dt.Tick += Dt_Tick;
            dt.Interval = TimeSpan.FromSeconds(1);
            _dropStack = new DropStack(_deck.DrawCard());
        }

        private void Dt_Tick(object sender, object e)
        {
            Counter++;
            if (Counter == 2)
            {
                btnRood.IsEnabled = true;
                btnZwart.IsEnabled = true;
                imgDropstackOldCard.Source = null;
                Counter = 0;
                dt.Stop();
            }
            else
            {
                btnRood.IsEnabled = false;
                btnZwart.IsEnabled = false;
            }
        }

        private void BtnRood_Click(object sender, RoutedEventArgs e)
        {
            Card card = _deck.DrawCard();
            if (card.Color.ToString() == "red")
            {
                tbResult.Text = "Goed geraden het is inderdaad rood";
                imgDropstackOldCard.Source = card.Image;

                Bedrag += 10;
                tbWinOrLose.Text = "+10";
                tbWinOrLose.Foreground = new SolidColorBrush(Colors.Green);
                tbBedrag.Text = Bedrag.ToString();
                dt.Start();

            }
            else
            {
                tbResult.Text = "Goed geprobeerd..";
                imgDropstackOldCard.Source = card.Image;

                Bedrag -= 10;
                tbWinOrLose.Text = "-10";
                tbWinOrLose.Foreground = new SolidColorBrush(Colors.Red);
                tbBedrag.Text = Bedrag.ToString();
                dt.Start();
            }
        }

        private void BtnZwart_Click(object sender, RoutedEventArgs e)
        {
            Card card = _deck.DrawCard();

            if (card.Color.ToString() == "black")
            {
                tbResult.Text = "Goed geraden het is inderdaad zwart";
                imgDropstackOldCard.Source = card.Image;

                Bedrag += 10;
                tbWinOrLose.Text = "+10";
                tbWinOrLose.Foreground = new SolidColorBrush(Colors.Green);
                tbBedrag.Text = Bedrag.ToString();
                dt.Start();
            }
            else
            {
                tbResult.Text = "Goed geprobeerd..";
                imgDropstackOldCard.Source = card.Image;

                Bedrag -= 10;
                tbWinOrLose.Text = "-10";
                tbWinOrLose.Foreground = new SolidColorBrush(Colors.Red);
                tbBedrag.Text = Bedrag.ToString();
                dt.Start();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            tbName.Text = localSettings.Values["waarde"].ToString();
            tbBedrag.Text = localSettings.Values["bedrag"].ToString();

            Int32.TryParse(localSettings.Values["bedrag"].ToString(), out Bedrag);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            localSettings.Values["waarde"] = tbName.Text;
            localSettings.Values["bedrag"] = tbBedrag.Text;
        }
    }
}
