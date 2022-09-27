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

            lasku.Eräpäivä = pvmTänään.AddDays(-35);
            lasku.Vastaanottaja = vastaanottaja;

            lasku.Maksumuistutus1.Lähetä();

            string tuloste = lasku.Tietotuloste();
            Debug.Write(tuloste);
            MessageBox.Show(tuloste);

            File.WriteAllText("lasku.json",
                JsonSerializer.Serialize(lasku , new JsonSerializerOptions { WriteIndented=true } )
            );
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

        }
    }
}
