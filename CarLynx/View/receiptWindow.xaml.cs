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

namespace CarLynx.View
{
    /// <summary>
    /// Interaction logic for receiptWindow.xaml
    /// </summary>
    public partial class receiptWindow : Window
    {
        public receiptWindow()
        {
            InitializeComponent();
        }

        private void reportViewer_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void EXIT(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
