using projektityö.Luokat;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Text.Json;

namespace projektityö
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //DateOnly pvmTänään = DateOnly.FromDateTime(DateTime.Now);
            DateTime pvmTänään = DateTime.Now;

            Lasku lasku = new Lasku();
            lasku.summa = 30f;

            Vastaanottaja vastaanottaja = new Vastaanottaja("Matti", "Meikäläinen", "Matintie 1A, 00100 MATTILA");
            
            Tallentaminen tallentaminen = new Tallentaminen();

            tallentaminen.Init();
            tallentaminen.ListaaLaskut();

            lasku.Eräpäivä = pvmTänään.AddDays(-35);
            lasku.Vastaanottaja = vastaanottaja;

            lasku.Maksumuistutus1.Lähetä();

            //tring tuloste = lasku.Tietotuloste();
            //Debug.Write(tuloste);
            //MessageBox.Show(tuloste);
            string text = tallentaminen.ListaaLaskut();
            Debug.Write(text);
            MessageBox.Show(text);

            //tallentaminen.LisääLasku(lasku);


            
            // Kommentoitu osuus kokeilua joka näyttää toimivan.
            /*
            File.WriteAllText("lasku.json",
                JsonSerializer.Serialize(lasku, new JsonSerializerOptions { WriteIndented = true })
            );
            lasku = null;
            Lasku palautettuLasku = JsonSerializer.Deserialize<Lasku>(File.ReadAllText("lasku.json"));
            if (palautettuLasku == null)
            {
                throw new Exception("Tallennettua laskua ei löytynyt!");
            }

            palautettuLasku.Maksumuistutus1.AsetaIsäntälasku(palautettuLasku);
            palautettuLasku.Maksumuistutus2.AsetaIsäntälasku(palautettuLasku);

            palautettuLasku.Maksumuistutus2.Lähetä();

            string palautetunTuloste = palautettuLasku.Tietotuloste();
            MessageBox.Show(palautetunTuloste);
            File.WriteAllText("lasku.json",
                JsonSerializer.Serialize(palautettuLasku, new JsonSerializerOptions { WriteIndented = true })
            );
            */
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 mywindow = new Window1(); 
            mywindow.Show();
            this.Close();
            
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window2 mywindow = new Window2(); 
            mywindow.Show();
            this.Close();
            

        }
    }
}
