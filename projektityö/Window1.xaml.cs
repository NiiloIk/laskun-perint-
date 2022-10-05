using projektityö.Luokat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace projektityö
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private Tallentaminen tallentaminen = new Tallentaminen();
        public Window1()
        {
            InitializeComponent();
           
            this.tallentaminen.Init();   



        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainWindow pääikkuna = new MainWindow();
            pääikkuna.Show();
            this.Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Window2 vanhat = new Window2();
            vanhat.Show();
            this.Close();
        }
        public void LisääLasku(Lasku uusiLasku)
        {
            this.tallentaminen.LisääLasku(uusiLasku);

          
        }
        

        private void tallenna_Click(object sender, RoutedEventArgs e)
        {
            string etunimi = etuBox.Text;
            string sukunimi = sukuBox.Text;
            string osoite = osoiteBox.Text;
            string summa = summaBox.Text;
            string päivä = päiväBox.Text;
            Vastaanottaja vastaanottaja = new Vastaanottaja();
            vastaanottaja.Osoite = osoite;
            vastaanottaja.Etunimi = etunimi;
            vastaanottaja.Sukunimi = sukunimi;
            Lasku uusi = new Lasku();
            uusi.Vastaanottaja = vastaanottaja; 
            uusi.summa = float.Parse(summa);
            uusi.Luontipäivämäärä = (DateTime) päivämäärä.SelectedDate;
            this.LisääLasku(uusi);
        }
    }
}
