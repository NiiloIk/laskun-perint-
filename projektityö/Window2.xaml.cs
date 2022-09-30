using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.Json;
using System.IO;
using projektityö.Luokat;

namespace projektityö
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            // void Init()
            //{
            //    try
            //    {
            //        var raakaJson = File.ReadAllText(tiedostoNimi);
            //        if (raakaJson.Length > 5)
            //        {
            //            var henkilöt = JsonSerializer.Deserialize<Tallentaminen>(raakaJson);
            //            if (henkilöt != null)
            //            {
            //                this.Laskut = henkilöt.Laskut;
            //            }
            //        }
            //        Console.WriteLine("Tietokannan luku onnistui");
            //    }
            //    catch
            //    {
            //        Console.WriteLine("Tietokanta tiedostoa ei voitu lukea");
            //    }
            //}

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainWindow pääikkuna = new MainWindow();
            pääikkuna.Show();
            this.Close();
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //listBox.ItemsSource = Tallentaminen.Laskut;
        }
    }
}
