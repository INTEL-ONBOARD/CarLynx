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
                    uname.BorderBrush = Brushes.Red;
                    pwd.BorderBrush = Brushes.Red;
                    error_box.Visibility = Visibility.Visible;
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
            stock_handler handler = new stock_handler();
            panelView.Children.Clear();
            handler.stock_view(panelView);

            //SetBinding defauult filter propertiers
            manufacture_type.SelectedIndex = 0;
            vehicle_type.SelectedIndex = 0;


        }

        private void backEvent(object sender, RoutedEventArgs e)
        {
            store_view.Visibility = Visibility.Hidden;
            home_default_admin.Visibility= Visibility.Visible;
            
        }

        private void recheck(object sender, TextChangedEventArgs e)
        {
            uname.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD2D2D2"));
            pwd.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD2D2D2"));
            error_box.Visibility = Visibility.Hidden;
        }

        private void filterCarAction(object sender, RoutedEventArgs e)
        {
            String man_type = manufacture_type.Text;
            String veh_type = vehicle_type.Text;
            String saletag = "";
            String stocktag = "";

            itemView.Content = panelView;
            stock_handler handler = new stock_handler();
            panelView.Children.Clear();


            if (issale.IsChecked == true){Console.WriteLine("yes");}else { Console.WriteLine("no"); }
            if (isstock.IsChecked == true) { Console.WriteLine("yes"); } else { Console.WriteLine("no"); }

            if (man_type != "All" && veh_type != "All") { handler.stock_view_filtered(this,panelView, "select * FROM car_stock WHERE company = '" + man_type + "' AND type = '"+veh_type+"'"); }
            else if(man_type == "All" && veh_type == "All") { handler.stock_view_filtered(this,panelView, "select * FROM car_stock"); }
            else if (man_type != "All" ) { handler.stock_view_filtered(this, panelView, "select * FROM car_stock WHERE company = '" + man_type + "'"); }
            else if (veh_type != "All") { handler.stock_view_filtered(this,panelView, "select * FROM car_stock WHERE type = '" + veh_type + "'"); }
            
            else if (isstock.IsChecked == true) { handler.stock_view_filtered(this, panelView, "select * FROM car_stock WHERE availability ='1'"); }
            //man_type != "All" && veh_type != "All" &&
            //"select * FROM car_stock WHERE company = '" + man_type + "' AND type = '" + veh_type + "' AND availability = '" + "1" + "'"


        }

        private void viewProfileAction(object sender, RoutedEventArgs e)
        {
            home_default_admin.Visibility = Visibility.Hidden;
            profile_view.Visibility = Visibility.Visible;
        }

        private void backEvent_profile(object sender, RoutedEventArgs e)
        {
            home_default_admin.Visibility = Visibility.Visible;
            profile_view.Visibility = Visibility.Hidden;
        }

        private void manageView(object sender, RoutedEventArgs e)
        {
            home_default_admin.Visibility = Visibility.Hidden;
            manage_view.Visibility = Visibility.Visible;
        }

        private void backEvent_manage(object sender, RoutedEventArgs e)
        {
            home_default_admin.Visibility = Visibility.Visible;
            manage_view.Visibility = Visibility.Hidden;
        }
    }
}
