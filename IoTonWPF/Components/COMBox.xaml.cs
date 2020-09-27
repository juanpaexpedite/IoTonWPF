using MaterialDesignThemes.Wpf;
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

namespace IoTonWPF.Components
{
    /// <summary>
    /// Interaction logic for COMBox.xaml
    /// </summary>
    public partial class COMBox : UserControl
    {
        public COMBox()
        {
            InitializeComponent();
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RearmButton_Click(object sender, RoutedEventArgs e)
        {
            if(RearmButton.Content is PackIcon pi)
            {
                if(pi.Kind == PackIconKind.ElectricSwitch)
                {
                    pi.Kind = PackIconKind.ElectricSwitchClosed;
                }
                else
                {
                    pi.Kind = PackIconKind.ElectricSwitch;
                }
            }
        }
    }
}
