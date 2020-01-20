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
    public sealed partial class GuesInBetweenpagina : Page
    {
        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        Deck _deck = new Deck();
        Table _table = new Table();
        DispatcherTimer dt = new DispatcherTimer();
        DropStack _dropstack;
        int Timer = 0;
        int Bedrag;
        Card card;
        public GuesInBetweenpagina()
        {
            this.InitializeComponent();
            dt.Tick += Dt_Tick;
            dt.Interval = TimeSpan.FromSeconds(1);

            ShowPlayer();
        }

        private void Dt_Tick(object sender, object e)
        {
            Timer++;
            if (Timer == 2)
            {
                tbResultaatTussenBuiten.Text = "Resultaat";
                Timer = 0;
                ResetGame();
                dt.Stop();
            }
        }

        private void ShowPlayer()
        {
            _dropstack = new DropStack(_deck.DrawCard());
            card = _deck.DrawCard();

            imgDropstackOldCard.Source = _dropstack.GetTopCard().Image;
            imgDropstackOldCard2.Source = card.Image;
        }

        private void BtnTussen_Click(object sender, RoutedEventArgs e)
        {
            Card newcard = _deck.DrawCard();

            //Kijk eerst wat de grootste kaart is
            if (card.Value > _dropstack.GetTopCard().Value)
            {
                if (card.Value > newcard.Value)
                {
                    if (newcard.Value > _dropstack.GetTopCard().Value)
                    {
                        imgDropstackNewCard.Source = newcard.Image;
                        tbResultaatTussenBuiten.Text = "Goed gedaan het zit ertussenin!";
                        dt.Start();

                        Bedrag += 10;
                        tbWinOrLose.Text = "+10";
                        tbWinOrLose.Foreground = new SolidColorBrush(Colors.Green);
                        tbBedrag.Text = Bedrag.ToString();
                    }
                }
                else
                {
                    imgDropstackNewCard.Source = newcard.Image;
                    tbResultaatTussenBuiten.Text = "Goed geprobeerd..";
                    dt.Start();

                    Bedrag -= 10;
                    tbWinOrLose.Text = "-10";
                    tbWinOrLose.Foreground = new SolidColorBrush(Colors.Red);
                    tbBedrag.Text = Bedrag.ToString();
                }
            }
            else
            {
                if (_dropstack.GetTopCard().Value > newcard.Value)
                {
                    if (newcard.Value > card.Value)
                    {
                        imgDropstackNewCard.Source = newcard.Image;
                        tbResultaatTussenBuiten.Text = "Goed gedaan het zit ertussenin!";
                        dt.Start();

                        Bedrag += 10;
                        tbWinOrLose.Text = "+10";
                        tbWinOrLose.Foreground = new SolidColorBrush(Colors.Green);
                        tbBedrag.Text = Bedrag.ToString();
                    }
                }
                else
                {
                    imgDropstackNewCard.Source = newcard.Image;
                    tbResultaatTussenBuiten.Text = "Goed geprobeerd..";
                    dt.Start();

                    Bedrag -= 10;
                    tbWinOrLose.Text = "-10";
                    tbWinOrLose.Foreground = new SolidColorBrush(Colors.Red);
                    tbBedrag.Text = Bedrag.ToString();
                }
            }
        }

        private void BtnBuiten_Click(object sender, RoutedEventArgs e)
        {
            Card newcard = _deck.DrawCard();

            //Kijk eerst wat de grootste kaart is
            if (card.Value > _dropstack.GetTopCard().Value)
            {
                if (card.Value < newcard.Value)
                {
                    imgDropstackNewCard.Source = newcard.Image;
                    tbResultaatTussenBuiten.Text = "Goed gedaan het zit er inderdaad buiten!";
                    dt.Start();

                    Bedrag += 10;
                    tbWinOrLose.Text = "+10";
                    tbWinOrLose.Foreground = new SolidColorBrush(Colors.Green);
                    tbBedrag.Text = Bedrag.ToString();
                }
                else
                {
                    if (newcard.Value < _dropstack.GetTopCard().Value)
                    {
                        imgDropstackNewCard.Source = newcard.Image;
                        tbResultaatTussenBuiten.Text = "Goed gedaan hij zit er inderdaad buiten!";
                        dt.Start();

                        Bedrag += 10;
                        tbWinOrLose.Text = "+10";
                        tbWinOrLose.Foreground = new SolidColorBrush(Colors.Green);
                        tbBedrag.Text = Bedrag.ToString();
                    }
                    else
                    {
                        imgDropstackNewCard.Source = newcard.Image;
                        tbResultaatTussenBuiten.Text = "Goed geprobeerd..";
                        dt.Start();

                        Bedrag -= 10;
                        tbWinOrLose.Text = "-10";
                        tbWinOrLose.Foreground = new SolidColorBrush(Colors.Red);
                        tbBedrag.Text = Bedrag.ToString();
                    }
                }
            }
            else
            {
                if (_dropstack.GetTopCard().Value < newcard.Value)
                {
                    imgDropstackNewCard.Source = newcard.Image;
                    tbResultaatTussenBuiten.Text = "Goed gedaan het zit er inderdaad buiten!";
                    dt.Start();

                    Bedrag += 10;
                    tbWinOrLose.Text = "+10";
                    tbWinOrLose.Foreground = new SolidColorBrush(Colors.Green);
                    tbBedrag.Text = Bedrag.ToString();
                }
                else
                {
                    if (newcard.Value < card.Value)
                    {
                        imgDropstackNewCard.Source = newcard.Image;
                        tbResultaatTussenBuiten.Text = "Goed gedaan het zit er inderdaad buiten!";
                        dt.Start();

                        Bedrag += 10;
                        tbWinOrLose.Text = "+10";
                        tbWinOrLose.Foreground = new SolidColorBrush(Colors.Green);
                        tbBedrag.Text = Bedrag.ToString();
                    }
                    else
                    {
                        imgDropstackNewCard.Source = newcard.Image;
                        tbResultaatTussenBuiten.Text = "Goed geprobeerd..";
                        dt.Start();

                        Bedrag -= 10;
                        tbWinOrLose.Text = "-10";
                        tbWinOrLose.Foreground = new SolidColorBrush(Colors.Green);
                        tbBedrag.Text = Bedrag.ToString();
                    }
                }
            }
        }

        private void ResetGame()
        {
            imgDropstackNewCard.Source = null;
            imgDropstackOldCard.Source = null;
            imgDropstackOldCard2.Source = null;

            ShowPlayer();
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
