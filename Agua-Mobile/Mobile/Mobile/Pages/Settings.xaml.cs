using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Mobile.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Settings : Page
    {
        private Dictionary<string, string> definitions = new Dictionary<string, string>();

        public Settings()
        {
            this.InitializeComponent();

            List<string> glosario = new List<string>();
            glosario.Add("Aguas subterráneas");
            glosario.Add("Ciclo hidrológico");
            glosario.Add("Conservación del agua");
            glosario.Add("Consumo responsable del agua");
            glosario.Add("Deforestación");
            glosario.Add("Precipitación");
            glosario.Add("Preservación del agua");
            glosario.Add("Recurso hídrico");
            glosario.Add("Reforestación");
            glosario.Add("Temperatura");
            myListView1.ItemsSource = glosario;

            definitions.Add("Aguas subterráneas", "son las aguas que se hallan bajo la superficie de la tierra acumulando mantos acuíferos. ");
            definitions.Add("Recurso hídrico", "Cuerpos de agua existentes en el planeta (océano, ríos, lagos, arroyos, lagunas, etc.)  ");
            definitions.Add("Ciclo hidrológico", "movimiento de agua que es evapora en el océano y otras cuerpos de agua la cual es condensada última puede subir a la atmósfera mediante la evaporación o transpiración, como a su vez regresar al océano a través de las aguas superficiales o subterráneas");
            definitions.Add("Temperatura", "calor medible mediante un termómetro. ");
            definitions.Add("Precipitación", "a caída de agua, ya sea sólida o líquida debido al proceso de condensación del vapor sobre la superficie terrestre. ");
            definitions.Add("Conservación del agua", "esfuerzos para proteger y preservar el agua.");
            definitions.Add("Preservación del agua", "proteger y conservar el agua para evitar un daño");
            definitions.Add("Reforestación", "repoblar con bosques (árboles) zonas degradadas e impactadas para conservar el recurso hídrico y la ecología en general. ");
            definitions.Add("Deforestación", "tala o corta de árboles provocada por los seres humanos.");
            definitions.Add("Consumo responsable del agua", "administrar, suministrar y utilizar eficientemente el agua en la vida cotidiana e industrial. ");

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

        private void myListView1_ItemClick(object sender, ItemClickEventArgs e)
        {
            System.Diagnostics.Debug.Write("yes");
        }

        private void myListView1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var listview =  sender as ListView;
            string item = listview.SelectedItem as string;
            string respuesta;
            definitions.TryGetValue(item, out respuesta);

            var dialog = new  MessageDialog(respuesta);
            dialog.ShowAsync();
            
        }
    }
}
