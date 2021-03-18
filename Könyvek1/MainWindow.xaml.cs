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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Könyvek1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Könyv> könyvek = new List<Könyv>();
        public MainWindow()
        {
            InitializeComponent();

            Betoltes();


        }

        private void Betoltes()
        {
            string[] sorok = File.ReadAllLines("konyvek.txt");
            datagrid.ItemsSource = könyvek;
            foreach (var item in sorok)
            {
                könyvek.Add(new Könyv(item));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            könyvek.Add(new Könyv(könyvek.Count() + 1,szerzotext.Text, cimtext.Text, kiadotext.Text, kiadastext.Text, true ));
            datagrid.Items.Refresh();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Könyv kivalasztott = (Könyv)datagrid.SelectedItem;
            könyvek.Remove(kivalasztott);
            datagrid.Items.Refresh();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Könyv kivalasztott = (Könyv)datagrid.SelectedItem;
            kivalasztott.Szerzo = szerzotext.Text;
            kivalasztott.Cim = cimtext.Text;
            kivalasztott.Kiado = kiadotext.Text;
            kivalasztott.Kiadasiev = kiadastext.Text;
            datagrid.Items.Refresh();
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Könyv kivalasztott = (Könyv)datagrid.SelectedItem;
            szerzotext.Text = kivalasztott.Szerzo;
            cimtext.Text = kivalasztott.Cim;
            kiadotext.Text = kivalasztott.Kiado;
            kiadastext.Text = kivalasztott.Kiadasiev;
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string input = search.Text;
            if (input == "")
            {
                datagrid.ItemsSource = könyvek;
            }
            else
            {
                datagrid.ItemsSource = könyvek.Where(x => x.Cim.Contains(input));
            }
        }
    }
}
