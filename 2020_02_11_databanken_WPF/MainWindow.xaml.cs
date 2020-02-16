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
using _2020_02_11_databanken.Business;

namespace _2020_02_11_databanken_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Controller _controller;
        public MainWindow()
        {
            _controller = new Controller();
            InitializeComponent();
            lbxOudleerlingen.ItemsSource = _controller.getOudleerlingen();
            lbxOudleerlingen.Items.Refresh();
            lbxStudierichtingen.ItemsSource = _controller.getStudierichtingen();
            lbxStudierichtingen.Items.Refresh();
        }

        private void LbxOudleerlingen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Oudleerling oll = (Oudleerling)lbxOudleerlingen.SelectedItem;
            List<string> _lijstGevolgdeOpleidingen = _controller.getGevolgdeOpleidingenFromOudleerling(oll);
            lbxGevolgdeOpleidingenFromSelectedOLL.ItemsSource = _lijstGevolgdeOpleidingen;
        }

        private void BtnVoegStudieRichtingToe_Click(object sender, RoutedEventArgs e)
        {
            Oudleerling oll;
            Studierichting studierichting;
            oll = (Oudleerling)lbxOudleerlingen.SelectedItem;
            studierichting = (Studierichting)lbxStudierichtingen.SelectedItem;
            if (oll==null)
            {
                MessageBox.Show("Selecteer een oudleerling!");
                return;
            }
            else if(studierichting == null)
            {
                MessageBox.Show("Selecteer een studierichting!");
                return;
            }
            else
            {
                _controller.addStudierichtingToOudleerling(oll.IDOudleerling, studierichting.IDStudieRichting, DateTime.Today);
            }
        }

        

        private void BtnAddOudleerling_Click(object sender, RoutedEventArgs e)
        {
            //nog implementeren
        }

        private void BtnAddStudierichting_Click(object sender, RoutedEventArgs e)
        {
            //nog implementeren
        }
        private void BtnAfstuderen_Click(object sender, RoutedEventArgs e)
        {
            //nog implementeren
        }
    }
}
