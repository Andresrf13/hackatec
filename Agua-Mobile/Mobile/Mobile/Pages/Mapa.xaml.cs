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
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls.Maps;
using Windows.Storage.Streams;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Mobile.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Mapa : Page
    {
        public Mapa()
        {
            this.InitializeComponent();
            this.myMap.MapServiceToken = "0Sd7FKHdNxUhEw3d79R0~FtLUcaQcsOEfJ3Lybun3bA~Aj3nEXVsiWp5z6Uou3EbC6GimA-H8U0o15Re0sCLopp26vW_a1vsdQc-KfIG7hIJ";
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

        private void myMap_Loading(FrameworkElement sender, object args)
        {
            this.myMap.Center = new Windows.Devices.Geolocation.Geopoint(new Windows.Devices.Geolocation.BasicGeoposition()
            {
                Latitude = 39.815429,
                Longitude = -86.162906
            });
            this.myMap.ZoomLevel = 7;
            this.myMap.Style = Windows.UI.Xaml.Controls.Maps.MapStyle.Aerial;

            loadPOI();
        }

        private async void loadPOI()
        {
            var file = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///geolocation.csv"));
            

            using (var inputStream = await file.OpenReadAsync())
            using (var classicStream = inputStream.AsStreamForRead())
            using (var streamReader = new StreamReader(classicStream))
            {
                bool first = true;
                while (streamReader.Peek() >= 0)
                {
                    if (first)
                    {
                        first = false;
                        string line = streamReader.ReadLine();
                        continue;
                    }
                    else
                    {
                        string line = streamReader.ReadLine();
                        string[] splitLine = line.Split('\t');
                        Locations location = new Locations(splitLine[0], splitLine[1], splitLine[2], splitLine[3]);

                        BasicGeoposition snPosition = new BasicGeoposition() { Latitude = location.lan, Longitude = location.lon };
                        Geopoint snPoint = new Geopoint(snPosition);

                        // Create a MapIcon.
                        MapIcon mapIcon1 = new MapIcon();
                        mapIcon1.Location = snPoint;
                        mapIcon1.NormalizedAnchorPoint = new Point(0.5, 0.5);
                        mapIcon1.Title = "";
                        mapIcon1.ZIndex = 0;
                        mapIcon1.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Images/water-150.png"));

                        // Add the MapIcon to the map.
                        myMap.MapElements.Add(mapIcon1);

                    }

                }
            }

        }
    }
}
