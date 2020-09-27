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
    /// Interaction logic for DataBox.xaml
    /// </summary>
    public partial class DataBox : UserControl
    {
        public DataBox()
        {
            InitializeComponent();
        }

        #region Label
        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register(nameof(Label), typeof(string), typeof(DataBox), new PropertyMetadata("###"));
        #endregion

        #region Data
        public string Data
        {
            get { return (string)GetValue(DataProperty); }
            set
            {
                SetValue(DataProperty, value);
            }
        }

        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register(nameof(Data), typeof(string), typeof(DataBox), new PropertyMetadata("0.00"));
        #endregion
    }
}
