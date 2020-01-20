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
    public sealed partial class Resultpagina : Page
    {
        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
        public Resultpagina()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            tbResult.Text = localSettings.Values["waarde"].ToString();
            tbBedragResult.Text = localSettings.Values["bedrag"].ToString();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            localSettings.Values["waarde"] = tbResult.Text;
            localSettings.Values["bedrag"] = tbBedragResult.Text;
        }
    }
}
