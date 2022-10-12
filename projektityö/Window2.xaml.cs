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
        private Window2 _window2;
        private Window1 uusiIkkuna;
        private Tallentaminen tallentaminen;
        private Lasku valittulasku = new Lasku();

        public Window2()
        {
            InitializeComponent();
            this._window2 = this;
            maksumuistuta_Btn.Visibility = Visibility.Hidden;


            //Haetaan tiedot tallennuskansiosta, eli tässä kohtaa hae lista Vastaanottajista
            //Vastaanottaja vastaanottaja = new Vastaanottaja("Matti", "Meikäläinen", "Matintie 1A, 00100 MATTILA");
            //Vastaanottaja vastaanottaja2 = new Vastaanottaja("Vatti", "Eeikäläinen", "Säkintie 1A, 13400 SÄKKILÄ");
            //listBox.DataContext = vastaanottaja;
            //listBox.DisplayMemberPath = "kokoNimi";
            //listBox.Items.Add(vastaanottaja);
            //listBox.Items.Add(vastaanottaja2);
            this.tallentaminen = new Tallentaminen();
            tallentaminen.Init();

            this.AsetaLaskulistat();
        }

        private void AsetaLaskulistat()
        {

            // Tarkistetaan onko lasku maksettu vai ei ja siirretään ne omiin laatikoihinsa.
            List<Lasku> lasku = new List<Lasku>();
            List<Lasku> lasku2 = new List<Lasku>();

            listBox.Items.Clear();
            listBox2.Items.Clear();

            for (int i = 0; tallentaminen.Laskut.Count > i; i++)
            {
                if (tallentaminen.Laskut[i].OnkoMaksettu())
                {
                    lasku.Add(tallentaminen.Laskut[i]);
                }
                else
                {
                   lasku2.Add(tallentaminen.Laskut[i]);
                }
                listBox2.ItemsSource = lasku.OrderByDescending(i => i.Eräpäivä);
                listBox.ItemsSource = lasku2.OrderByDescending(i => i.Maksumuistutus1.voikoLähettää() || i.Maksumuistutus2.voikoLähettää());
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainWindow pääikkuna = new MainWindow();
            pääikkuna.Show();
            this.Close();
        }

        // maksamattoman laskun valitseminen
        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            maksumuistuta_Btn.Visibility = Visibility.Hidden;
            if (e.AddedItems.Count > 0 && e.AddedItems[0] != null)
            {
                valittulasku = (Lasku)listBox.SelectedItem;
                Vastaanottaja valittuVastaanottaja = valittulasku.Vastaanottaja;

                nameBox.Text = valittuVastaanottaja.Etunimi + " " + valittuVastaanottaja.Sukunimi;
                adressBox.Text = valittuVastaanottaja.Osoite;

                amountBox.Text = valittulasku.summa.ToString();
                lisäBox.Text = valittulasku.MaksulisienSumma().ToString();
                pmBox.Text = valittulasku.Eräpäivä.ToString("dd/MM/yyyy");

                maksumuistus1_Box.Text = valittulasku.Maksumuistutus1.LähetysPvm.ToString();
                maksumuistus2_Box.Text = valittulasku.Maksumuistutus2.LähetysPvm.ToString();

                if (valittulasku.Maksumuistutus1.voikoLähettää() || valittulasku.Maksumuistutus2.voikoLähettää())
                {
                    maksumuistuta_Btn.Visibility = Visibility.Visible;
                }

            }
            listBox2.SelectedIndex = -1;
        }

        

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            this.uusiIkkuna = new Window1();
            this.uusiIkkuna.Show();
            this._window2.Close();
        }

        private void poistaBtn_Click(object sender, RoutedEventArgs e)
        {
            // poistaa valitun laskun muistista
            tallentaminen.PoistaLasku(valittulasku);
            MessageBox.Show("lasku poistettu");
            Refresh();
        }

        private void maksettuBtn_Click(object sender, RoutedEventArgs e)
        {
            // asettaa valitun laskun maksetuksi
            if (!valittulasku.OnkoMaksettu())
            {
                DateTime nyt = DateTime.Now;
                valittulasku.AsetaMaksupäivä(nyt);
                tallentaminen.PoistaLasku(valittulasku);
                tallentaminen.LisääLasku(valittulasku);
                MessageBox.Show("lasku tallennettu");
                Refresh();
            }
        }

        // maksetun laskun valitseminen
        private void listBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            maksumuistuta_Btn.Visibility = Visibility.Hidden;

            if (e.AddedItems.Count > 0 && e.AddedItems[0] != null)
            {
                valittulasku = (Lasku)listBox2.SelectedItem;
                Vastaanottaja valittuVastaanottaja = valittulasku.Vastaanottaja;

                nameBox.Text = valittuVastaanottaja.Etunimi + " " + valittuVastaanottaja.Sukunimi;
                adressBox.Text = valittuVastaanottaja.Osoite;

                amountBox.Text = valittulasku.summa.ToString();
                lisäBox.Text = valittulasku.MaksulisienSumma().ToString();
                pmBox.Text = valittulasku.Eräpäivä.ToString("dd/MM/yyyy");

                maksumuistus1_Box.Text = valittulasku.Maksumuistutus1.LähetysPvm.ToString();
                maksumuistus2_Box.Text = valittulasku.Maksumuistutus2.LähetysPvm.ToString();
            }

            listBox.SelectedIndex = -1;
        }
        private void Refresh()
        {
            // päivittää tallennetut tiedot.
            Window2 window = new Window2();
            _window2.Close();
            window.Show();
        }

        private void maksumuistuta_Btn_Click(object sender, RoutedEventArgs e)
        {
            Lasku valittulasku = (Lasku)listBox.SelectedItem;
            if (valittulasku.Maksumuistutus1.voikoLähettää())
            {
                valittulasku.Maksumuistutus1.Lähetä();
            } else
            {
                valittulasku.Maksumuistutus2.Lähetä();
            }
            tallentaminen.TallennaKanta();
            Refresh();
        }
    }
    
}

