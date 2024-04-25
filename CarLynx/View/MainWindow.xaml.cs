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

using CarLynx.Control;
using CarLynx.View;

namespace CarLynx
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

        private void exitEvent(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void loginAction(object sender, RoutedEventArgs e)
        {
            login_process ps = new login_process();
            if (uname.Text != "" && pwd.Text != "")
            {
                if (ps.login_check(uname.Text, pwd.Text)) {
                    login_window.Visibility = Visibility.Hidden;
                    home_default_admin.Visibility = Visibility.Visible;
                }
                else
                {
                    login_window.Visibility = Visibility.Visible;
                    home_default_admin.Visibility = Visibility.Hidden;
                }
            }
        }

        private void logoutAction(object sender, RoutedEventArgs e)
        {
            login_window.Visibility = Visibility.Visible;
            home_default_admin.Visibility = Visibility.Hidden;
        }

        private void gostoreAction(object sender, RoutedEventArgs e)
        {
            store_view.Visibility = Visibility.Visible;
            home_default_admin.Visibility = Visibility.Hidden;
            itemView.Content = panelView;
            for (int i=0; i < 5; i++)
            {
                car_product car = new car_product();
                panelView.Children.Add(car);
            }



        }

        private void backEvent(object sender, RoutedEventArgs e)
        {
            store_view.Visibility = Visibility.Hidden;
            home_default_admin.Visibility= Visibility.Visible;
            
        }
    }
}
