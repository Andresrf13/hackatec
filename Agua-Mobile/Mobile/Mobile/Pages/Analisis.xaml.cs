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
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Mobile.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Analisis : Page
    {
        private string provincia;
        private Dictionary<string, List<IEvent>> data;
        Dictionary<string, string> dictips = new Dictionary<string, string>();

        public Analisis()
        {
            this.InitializeComponent();
        }

        private async void loadData()
        {
            data = new Dictionary<string, List<IEvent>>();
            var file = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///variables.csv"));
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
                        string[] splitLine = line.Split(',');
                        Evento evt = new Evento();
                        evt.Nombre = splitLine[4];
                        evt.result = Int32.Parse(splitLine[3]);
                        evt.cant = Double.Parse(splitLine[2]);
                        evt.temp = Double.Parse(splitLine[1]);
                        evt.prec = Double.Parse(splitLine[0]);
                        List<IEvent> evtlist;
                        if(data.TryGetValue(evt.Nombre, out evtlist))
                        {
                            evtlist.Add(evt);
                        }
                        else
                        {
                            evtlist = new List<IEvent>();
                            evtlist.Add(evt);
                            data.Add(evt.Nombre, evtlist);
                        }                    
                    }                   

                }
            }
            if(provincia != null && provincia.Trim() != "")
            {
                myslider.Visibility = Visibility.Visible;
                SetValue();
            }
            else
            {
                myslider.Visibility = Visibility.Collapsed;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
                
            base.OnNavigatedTo(e);
            provincia = e.Parameter as string;
            if(provincia == null || provincia == "")
            {
                var msg = new MessageDialog("Por favor inserte un valor valido");
                 msg.ShowAsync();
                
            }
            loadData();
        }

        private void SetValue()
        {
            List<IEvent> listevent;
            provincia = provincia.Trim();
            if (data.TryGetValue(provincia, out listevent))
            {
                int red =0, yellow=0, green = 0;
                foreach (var item in listevent)
                {
                    switch (item.result)
                    {
                        case 0:
                            red += 1;
                            break;
                        case 1:
                            yellow += 1;
                            break;
                            
                        case 2:
                            green += 1;
                            break;
                    }
                }


                if(red >= 1)
                {
                    myslider.Value = 20;
                    redtips();
                }
               else if(yellow >= 1)
                {
                    myslider.Value = 50;
                    yellowtips();
                }
                else
                {
                    myslider.Value = 80;
                    greentips();
                }
            }
        }

        private void redtips()
        {
            dictips.Clear();
            dictips = new Dictionary<string, string>();
            dictips.Add("Tip 1", "Reforestar zonas degradadas para mantener la temperatura y humedad idónea en áreas cercanas a las aguas subterráneas.");
            dictips.Add("Tip 2", "Utilizar en lo menos posible químicos sintéticos en los suelos de producción agrícola para que no haya infiltración de agua.");
            dictips.Add("Tip 3", "Reciclar y evitar la contaminación de fuentes de agua.");
            dictips.Add("Tip 4", "Administrar adecuadamente el agua potable mediante un uso y consumo responsable. ");
            dictips.Add("Tip 5", "cerrar las tuberías cuando no están en uso.");
            dictips.Add("Tip 6", "detectar fugas de agua");
            dictips.Add("Tip 7", "Reciclar el agua de lluvia para actividades agropecuarias e industriales. ");
            dictips.Add("Tip 8", "Buscar técnicas eficientes para un manejo adecuado del recurso agua");


            List<string> tips = new List<string>();
            tips.Add("Tip 1");
            tips.Add("Tip 2");
            tips.Add("Tip 3");
            tips.Add("Tip 4");
            tips.Add("Tip 5");
            tips.Add("Tip 6");
            tips.Add("Tip 7");
            tips.Add("Tip 8");

            listviewtips.ItemsSource = tips;
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

        private void listviewtips_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var item = (ListView)sender;
            string ms = item.SelectedItem.ToString();
            string result;
            dictips.TryGetValue(ms, out result);
            var msg = new MessageDialog(result);
            msg.ShowAsync();
        }

        private void yellowtips()
        {
            dictips.Clear();
            dictips = new Dictionary<string, string>();
            dictips.Add("Tip 1", "Reforestar zonas degradadas para mantener la temperatura y humedad idónea en áreas cercanas a las aguas subterráneas.");
            dictips.Add("Tip 2", "No utilizar o en la medida de lo posible químicos sintéticos en los suelos de producción agrícola para que no haya infiltración de agua.");
            dictips.Add("Tip 3", "Reciclar y evitar la contaminación de fuentes de agua.");
            dictips.Add("Tip 4", "Administrar adecuadamente el agua potable mediante un uso y consumo responsable.  ");
            dictips.Add("Tip 5", "cerrar las tuberías cuando no están en uso.");
            dictips.Add("Tip 6", "detectar fugas de agua");
            dictips.Add("Tip 7", "Reciclar el agua de lluvia para actividades agropecuarias e industriales. ");
            dictips.Add("Tip 8", "Buscar técnicas eficientes para un manejo adecuado del recurso agua");


            List<string> tips = new List<string>();
            tips.Add("Tip 1");
            tips.Add("Tip 2");
            tips.Add("Tip 3");
            tips.Add("Tip 4");
            tips.Add("Tip 5");
            tips.Add("Tip 6");
            tips.Add("Tip 7");
            tips.Add("Tip 8");

            listviewtips.ItemsSource = tips;
        }

        private void greentips()
        {
            dictips.Clear();
            dictips = new Dictionary<string, string>();
            dictips.Add("Tip 1", "Conservar los parches de bosques para evitar su deforestación y la irregularidad de las temperaturas, precipitaciones y humedad de la zona.");
            dictips.Add("Tip 2", "No utilizar o en la medida de lo posible químicos sintéticos en los suelos de producción agrícola para que no haya infiltración de agua");
            dictips.Add("Tip 3", "Reciclar y evitar la contaminación de fuentes de agua.");
            dictips.Add("Tip 4", "Administrar adecuadamente el agua potable mediante un uso y consumo responsable.  ");
            dictips.Add("Tip 5", "cerrar las tuberías cuando no están en uso.");
            dictips.Add("Tip 6", "detectar fugas de agua");
            dictips.Add("Tip 7", "Reciclar el agua de lluvia para actividades agropecuarias e industriales. ");
            dictips.Add("Tip 8", "Concientizar a la población de que el recurso agua se encuentra en peligro y necesita ser preservado con urgencia.");


            List<string> tips = new List<string>();
            tips.Add("Tip 1");
            tips.Add("Tip 2");
            tips.Add("Tip 3");
            tips.Add("Tip 4");
            tips.Add("Tip 5");
            tips.Add("Tip 6");
            tips.Add("Tip 7");
            tips.Add("Tip 8");

            listviewtips.ItemsSource = tips;
        }
    }
}
