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
    public sealed partial class GuessHighLowpagina : Page
    {
        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        Deck _deck = new Deck();
        DispatcherTimer dt = new DispatcherTimer();
        DropStack _dropStack;
        Table _table = new Table();
        Card card;
        int Timer;
        int Bedrag;
        public GuessHighLowpagina()
        {
            this.InitializeComponent();

            dt.Tick += Dt_Tick;
            dt.Interval = TimeSpan.FromSeconds(1);
            _dropStack = new DropStack(_deck.DrawCard());

            ShowPlayer();
        }

        private void Dt_Tick(object sender, object e)
        {
            btnHoger.IsEnabled = false;
            btnLager.IsEnabled = false;
            Timer++;
            if (Timer == 2)
            {
                tbResultaat.Text = "Resultaat";
                btnHoger.IsEnabled = true;
                btnLager.IsEnabled = true;
                Timer = 0;
                tbWinOrLose.Text = "";
                ResetTopCard();
                dt.Stop();
            }
        }

        private void ShowPlayer()
        {
            imgDropstackOldCard.Source = _dropStack.GetTopCard().Image;
        }

        private void BtnLager_Click(object sender, RoutedEventArgs e)
        {
            card = _deck.DrawCard();
            if (_dropStack.GetTopCard().Value > card.Value)
            {
                tbResultaat.Text = "Goed gedaan de kaart is lager";
                imgDropstackNewCard.Source = card.Image;
                dt.Start();

                Bedrag += 10;
                tbWinOrLose.Text = "+10";
                tbWinOrLose.Foreground = new SolidColorBrush(Colors.Green);
                tbBedrag.Text = Bedrag.ToString();
            }
            else
            {
                tbResultaat.Text = "Dat ging niet zo goed..";
                imgDropstackNewCard.Source = card.Image;
                dt.Start();

                Bedrag -= 10;
                tbWinOrLose.Text = "-10";
                tbWinOrLose.Foreground = new SolidColorBrush(Colors.Red);
                tbBedrag.Text = Bedrag.ToString();
            }
        }

        private void BtnHoger_Click(object sender, RoutedEventArgs e)
        {
            card = _deck.DrawCard();
            if (_dropStack.GetTopCard().Value < card.Value)
            {
                tbResultaat.Text = "Goed gedaan de kaart is hoger";
                imgDropstackNewCard.Source = card.Image;
                dt.Start();

                Bedrag += 10;
                tbWinOrLose.Text = "+10";
                tbWinOrLose.Foreground = new SolidColorBrush(Colors.Green);
                tbBedrag.Text = Bedrag.ToString();
            }
            else
            {
                tbResultaat.Text = "Dat ging niet zo goed..";
                imgDropstackNewCard.Source = card.Image;
                dt.Start();

                Bedrag -= 10;
                tbWinOrLose.Text = "-10";
                tbWinOrLose.Foreground = new SolidColorBrush(Colors.Red);
                tbBedrag.Text = Bedrag.ToString();
            }
        }

        private void ResetTopCard()
        {
            _dropStack.GetTopCard().Value = card.Value;

            imgDropstackOldCard.Source = imgDropstackNewCard.Source;
            imgDropstackNewCard.Source = null;
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
