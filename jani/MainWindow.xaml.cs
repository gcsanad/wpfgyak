using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnBetolt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog betoltes = new OpenFileDialog();
            betoltes.Title = "Kérem válassza ki a betöltendő fájlt!";
            if (betoltes.ShowDialog()==false)
            {
                return;
            }
            StreamReader fajlOlvaso = new StreamReader(betoltes.FileName);
            String? olvasottSor;
            while (!fajlOlvaso.EndOfStream)
            {
                olvasottSor = fajlOlvaso.ReadLine();
                if (olvasottSor!="")
                {
                    lbForras.Items.Add(olvasottSor);
                }

                
            }
            fajlOlvaso.ReadLine();

            fajlOlvaso.Close();
        }

        private void btnValogat_Click(object sender, RoutedEventArgs e)
        {
            lbMódosított.Items.Clear();
            foreach (object aktObjektum in lbForras.Items)
            {
                if (chkNincsKulonbseg.IsChecked==true)
                {
                    if (aktObjektum.ToString().ToLower().Contains(txtSzoveg.Text.ToLower()))
                    {
                        lbMódosított.Items.Add(aktObjektum.ToString());
                    }
                }
                else
                {
                    if (aktObjektum.ToString().Contains(txtSzoveg.Text))
                    {
                        lbMódosított.Items.Add(aktObjektum.ToString());
                    }
                }
                
            }
        }

        private void btnElment_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog mentes = new SaveFileDialog();
            if (mentes.ShowDialog()==true)
            {
                StreamWriter fajlIro = new StreamWriter(mentes.FileName);
                foreach (object aktObjektum in lbMódosított.Items)
                {
                    fajlIro.WriteLine(aktObjektum.ToString());
                }
                
                fajlIro.Close();
            }
        }
    }
}
