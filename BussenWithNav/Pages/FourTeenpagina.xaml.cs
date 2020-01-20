using BussenWithNav.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
    public sealed partial class FourTeenpagina : Page
    {
        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        Deck _deck = new Deck();
        Table _table = new Table();
        private Brush transparant;
        DispatcherTimer dt;
        Button btn;
        int Bedrag;
        int Timer = 0;
        int ResultaatInt = 0;

        public FourTeenpagina()
        {
            this.InitializeComponent();
            dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += Dt_Tick;

            CreateCard();
        }

        private void Dt_Tick(object sender, object e)
        {
            tbResultaat.Text = Timer.ToString();
            btnAddCard.IsEnabled = false;
            if (Timer == 2)
            {
                tbResultaat.Text = "Resultaat";
                tbWin.Text = "";
                tbLose.Text = "";
                Timer = 0;
                btnAddCard.IsEnabled = true;
                dt.Stop();
                CreateCard();
            }
            else
            {
                Timer++;
                foreach (Card card in _table.Cards.ToList())
                {
                    _table.RemoveCard(card);
                    gvPlayer.Items.Clear();
                    imgIngezetteKaart.Source = null;
                }
            }
        }

        private void CreateCard()
        {
            int i;
            for (i = 0; i < 5; i++)
            {
                _table.AddCard(_deck.DrawCard());

            }
            if (i == 5)
            {
                ShowPlayer();
            }

        }

        private void ShowPlayer()
        {
            foreach (Card card in _table.Cards)
            {
                btn = new Button()
                {
                    Width = 100,
                    Background = transparant,
                    Content = new Image()
                    {
                        Height = 100,
                        Width = 100,
                        Source = card.Image
                    },
                    Tag = card
                };
                btn.Click += Btn_Click; ;
                gvPlayer.Items.Add(btn);
            }
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Card card = btn.Tag as Card;

            ResultaatInt = Convert.ToInt32(card.Value);
            ResultaatInt += 1;

            if (tbResultaat.Text != "Resultaat")
            {
                int NewInt = int.Parse(tbResultaat.Text);
                NewInt += ResultaatInt;
                tbResultaat.Text = "";
                tbResultaat.Text += NewInt.ToString();

                if (NewInt == 14)
                {
                    btn.IsEnabled = false;
                    tbWin.Text = "Het is gelukt! +10";
                    Bedrag += 10;
                    tbBedrag.Text = Bedrag.ToString();
                    dt.Start();
                }
                else if (NewInt > 14)
                {
                    btn.IsEnabled = false;
                    tbLose.Text = "Het is niet gelukt! -10";
                    Bedrag -= 10;
                    tbBedrag.Text = Bedrag.ToString();
                    dt.Start();
                }
            }
            else
            {
                tbResultaat.Text = ResultaatInt.ToString();
            }

            imgIngezetteKaart.Source = card.Image;
            gvPlayer.Items.Remove(btn);
        }

        private void BtnAddCard_Click(object sender, RoutedEventArgs e)
        {
            Card newcard = _deck.DrawCard();
            Button btn = new Button()
            {
                Width = 100,
                Background = transparant,
                Content = new Image()
                {
                    Height = 100,
                    Width = 100,
                    Source = newcard.Image
                },
                Tag = newcard
            };
            btn.Click += Btn_Click;
            gvPlayer.Items.Add(btn);
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
