using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Mobile.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Mobile.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Comunidad : Page
    {
        public Comunidad()
        {
            this.InitializeComponent();

            List<IEvent> events = new List<IEvent>();

            Evento evt = new Evento();
            evt.Nombre = "Morgan";
            evt.result = 1;
            evt.prec = 150;
            evt.temp = 24;
            evt.cant = 80;
            evt.getColor();
            events.Add(evt);

            Evento evt1 = new Evento();
            evt1.Nombre = "Hamilton";
            evt1.result = 0;
            evt1.prec = 150;
            evt1.temp = 24;
            evt1.cant = 80;
            evt1.getColor();
            events.Add(evt1);

            Evento evt2 = new Evento();
            evt2.Nombre = "Bartholomew";
            evt2.result = 2;
            evt2.prec = 150;
            evt2.temp = 24;
            evt2.cant = 80;
            evt2.getColor();
            events.Add(evt2);

            myListVIew.ItemsSource = events;

            
        }


        #region Menu
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Pages.Settings));
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Pages.Mapa));
        }

        private void AppBarButton_Click_2(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Pages.Perfil));
        }

        private void AppBarButton_Click_3(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Pages.Comunidad));
        }

        #endregion
    }
}
