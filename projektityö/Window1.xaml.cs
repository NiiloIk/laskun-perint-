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

namespace projektityö
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainWindow pääikkuna = new MainWindow();
            pääikkuna.Show();
            this.Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Window2 vanhatLaskut = new Window2();
            vanhatLaskut.Show();
            this.Close();
        }
        private void hkTiedot_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void tallennaBtn_Click(object sender, RoutedEventArgs e)
        {
            if (hkTiedot)
            {
                textBlock.Text = "*Tiedot puuttuu";
            }
          
        }

       
    }
}
