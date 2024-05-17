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
    /// Interaction logic for stockwindow.xaml
    /// </summary>
    public partial class stockwindow : Window
    {
        public stockwindow()
        {
            InitializeComponent();
        }

        private void closeEvnt(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
