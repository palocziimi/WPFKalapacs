using System;
using System.Collections.Generic;
using System.IO;
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

namespace Pars2012GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Versenyzo> list = new List<Versenyzo>();
        public MainWindow()
        {
            InitializeComponent();
            StreamReader sr = new StreamReader("Source\\Selejtezo2012.txt");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                list.Add(new Versenyzo(sr.ReadLine()));
            }
            sr.Close();

            foreach (var versenyzo in list)
            {
                ComboBoxItem comboBoxItem = new ComboBoxItem();
                comboBoxItem.Content = versenyzo.Name;
                cbNames.Items.Add(comboBoxItem);
                cbNames.SelectedIndex = list.FindIndex(x => x.Name == "Pars Krisztián");

            }

        }

        private void cbNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = list.FindIndex(x => x.Name == cbNames);
            Versenyzo vs = list[index];
            lblGroup.Content = $"Csoport: {vs.Group}";
            lblCountry.Content = $"Nemzet: {vs.Country}";
            lblCountryCode.Content = $"Nemzet kód: {vs.CountryCode}";
            string row = "";
            foreach (var item in vs.Results)
            {
                if (item == -1)
                {
                    row += $"X;";
                }
                else if (item == -2)
                {
                    row += $"-;";
                }
                else
                    row += $"{item};";
            }
            lblResults.Content = $"Sorozat: {row.Substring(0, row.Length-1)}";
            lblResult.Content = $"Nemzet: {vs.Result}";
            //imgFlag.Source = new ImageSource($"Images\\{vs.CountryCode}.png");
        }
    }
}
