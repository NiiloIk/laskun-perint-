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
using static System.Net.Mime.MediaTypeNames;

namespace projektityö
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();

            //Haetaan tiedot tallennuskansiosta, eli tässä kohtaa hae lista Vastaanottajista
            Vastaanottaja vastaanottaja = new Vastaanottaja("Matti", "Meikäläinen", "Matintie 1A, 00100 MATTILA");
            Vastaanottaja vastaanottaja2 = new Vastaanottaja("Vatti", "Eeikäläinen", "Säkintie 1A, 13400 SÄKKILÄ");
            listBox.DataContext = vastaanottaja;
            listBox.DisplayMemberPath = "kokoNimi";
            listBox.Items.Add(vastaanottaja);
            listBox.Items.Add(vastaanottaja2);
            // Tässä kohtaa tee foreach, joka käy haetun listan läpi, ja lisää nimet yksi kerrallaan listBoxiin
            //foreach(var jäbä in vastaanottajat){
            //  listBox.Items.Add(jäbä);
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
            if (e.AddedItems.Count > 0 && e.AddedItems[0] != null)
            {
                Vastaanottaja vastaanottaja = (Vastaanottaja)e.AddedItems[0];
                nameBox.Text = vastaanottaja.kokoNimi;
                adressBox.Text = vastaanottaja.Osoite;
                //amountBox.Text = vastaanottaja.laskunsumma
            }


            //listBox.ItemsSource = Tallentaminen.Laskut;
        }


    }
}

