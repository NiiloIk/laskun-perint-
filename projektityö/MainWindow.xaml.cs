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

            DateOnly pvmTänään = DateOnly.FromDateTime(DateTime.Now);

            Lasku lasku = new Lasku();
            lasku.summa = 30f;

            Vastaanottaja vastaanottaja = new Vastaanottaja("Matti", "Meikäläinen", "Matintie 1A, 00100 MATTILA");

            lasku.Eräpäivä = pvmTänään.AddDays(-35);
            lasku.Vastaanottaja = vastaanottaja;

            lasku.Maksumuistutus1.Lähetä();
            lasku.Maksumuistutus2.Lähetä();

            string tuloste = lasku.Tietotuloste();
            Debug.Write(tuloste);
            MessageBox.Show(tuloste);

            //lasku.Maksumuistutus2.lähetä();
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
