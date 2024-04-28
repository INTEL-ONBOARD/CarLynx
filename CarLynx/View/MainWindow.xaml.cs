﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private bool isdone = false;
        stock_handler handler;
        public MainWindow()
        {
            InitializeComponent();
            handler = new stock_handler();
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

            manage_category_view.Visibility = Visibility.Hidden;
            manage_car_stock_view.Visibility = Visibility.Visible;
            manage_user_view.Visibility = Visibility.Hidden;
        }

        private void backEvent_manage(object sender, RoutedEventArgs e)
        {
            home_default_admin.Visibility = Visibility.Visible;
            manage_view.Visibility = Visibility.Hidden;
        }

        private void gotocatAction(object sender, RoutedEventArgs e)
        {
            manage_category_view.Visibility = Visibility.Visible;
            manage_car_stock_view.Visibility = Visibility.Hidden;
            manage_user_view.Visibility = Visibility.Hidden;
        }

        private void gotostockAction(object sender, RoutedEventArgs e)
        {
            manage_category_view.Visibility = Visibility.Hidden;
            manage_car_stock_view.Visibility = Visibility.Visible;
            manage_user_view.Visibility = Visibility.Hidden;
        }

        private void gotousersAction(object sender, RoutedEventArgs e)
        {
            manage_category_view.Visibility = Visibility.Hidden;
            manage_car_stock_view.Visibility = Visibility.Hidden;
            manage_user_view.Visibility = Visibility.Visible;
        }



        private void ModeSwapAction(object sender, RoutedEventArgs e)
        {
            if (view_mode_view.Visibility == Visibility.Visible)
            {
                view_mode_view.Visibility = Visibility.Hidden;
                edit_mode_view.Visibility= Visibility.Visible;
                mode_titile.Content = "UPDATE STOCK";
                mode_swapperBtn.Content = "Switch to View mode";
            }
            else
            {
                view_mode_view.Visibility = Visibility.Visible;
                edit_mode_view.Visibility = Visibility.Hidden;
                mode_titile.Content = "VIEW STOCK";
                mode_swapperBtn.Content = "Switch to Update mode";
            }
        }

        private void Addcar_action(object sender, RoutedEventArgs e)
        {
            bool iserrorpopped = false;

            try
            {
                success_box_manage.Visibility = Visibility.Collapsed;
                error_box_manage.Visibility = Visibility.Collapsed;
                UIElement[] inputElements = new UIElement[] { select_vehicle_type, select_vehicle_manufacture, select_vehicle_model,select_vehicle_model, select_vehicle_range,select_vehicle_year,select_vehicle_speed,select_vehicle_price,select_vehicle_mph,selecet_vehicle_info };
                foreach (var element in inputElements)
                {
                    if (element is TextBox textBox)
                    {
                        if (textBox.Text == "")
                        {
                            error_box_manage_content.Content = "All input feilds must be filled. Try again!";
                            success_box_manage.Visibility = Visibility.Collapsed;
                            error_box_manage.Visibility = Visibility.Visible;
                            iserrorpopped = true;
                            break; 
                        }
                    }
                    else if (element is ComboBox comboBox)
                    {
                        if (comboBox.Text == "")
                        {
                            error_box_manage_content.Content = "All input feilds must be filled. Try again!";
                            success_box_manage.Visibility = Visibility.Collapsed;
                            error_box_manage.Visibility = Visibility.Visible;
                            iserrorpopped = true;
                            break;
                        }
                    }
                }

                if (iserrorpopped != true)
                {
                    foreach (var element in inputElements)
                    {
                        if (element is TextBox textBox)
                        {
                            if (textBox.Name == "select_vehicle_year")
                            {
                                string pattern = @"^[1-9]\d{3}(\.\d+)?$";
                                if (!Regex.IsMatch(textBox.Text, pattern))
                                {
                                    error_box_manage_content.Content = "Vehicle year must be a valid number. Try again!";
                                    success_box_manage.Visibility = Visibility.Collapsed;
                                    error_box_manage.Visibility = Visibility.Visible;
                                    isdone = false;
                                    break;
                                }
                            }
                            else if (textBox.Name == "select_vehicle_range")
                            {
                                string pattern = @"^[-+]?[0-9]+(\.[0-9]+)?([eE][-+]?[0-9]+)?$";
                                if (!Regex.IsMatch(textBox.Text, pattern))
                                {
                                    error_box_manage_content.Content = "Vehicle range must be a valid number. Try again!";
                                    success_box_manage.Visibility = Visibility.Collapsed;
                                    error_box_manage.Visibility = Visibility.Visible;
                                    isdone = false;
                                    break;
                                }
                            }
                            else if (textBox.Name == "select_vehicle_speed")
                            {
                                string pattern = @"^[1-9][0-9]*(\.[0-9]+)?$";
                                if (!Regex.IsMatch(textBox.Text, pattern))
                                {
                                    error_box_manage_content.Content = "Vehicle Top speed must be a valid number. Try again!";
                                    success_box_manage.Visibility = Visibility.Collapsed;
                                    error_box_manage.Visibility = Visibility.Visible;
                                    isdone = false;
                                    break;
                                }
                            }
                            else if (textBox.Name == "select_vehicle_price")
                            {
                                string pattern = @"^[-+]?[0-9]+(\.[0-9]+)?([eE][-+]?[0-9]+)?$";
                                if (!Regex.IsMatch(textBox.Text, pattern))
                                {
                                    error_box_manage_content.Content = "Vehicle Price must be a number. Try again!";
                                    success_box_manage.Visibility = Visibility.Collapsed;
                                    error_box_manage.Visibility = Visibility.Visible;
                                    isdone = false;
                                    break;
                                }
                            }
                            else if (textBox.Name == "select_vehicle_mph")
                            {
                                string pattern = @"^[-+]?[0-9]+(\.[0-9]+)?([eE][-+]?[0-9]+)?$";
                                if (!Regex.IsMatch(textBox.Text, pattern))
                                {
                                    error_box_manage_content.Content = "Vehicle Mph must be a number. Try again!";
                                    success_box_manage.Visibility = Visibility.Collapsed;
                                    error_box_manage.Visibility = Visibility.Visible;
                                    isdone = false;
                                    break;
                                }
                            }
                            else
                            {
                                isdone = true;
                            }
                        }
                    }
                }


                if (isdone != false)
                {
                    handler.add_stock(this);
                    this.clear_Action();
                    success_box_manage.Visibility = Visibility.Visible;
                    error_box_manage.Visibility = Visibility.Collapsed;
                    Console.WriteLine("All SET CALLING DB UPDATE");
                    isdone = false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured > "+ ex.Message);

            }
        }

        private void clear_Action()
        {
            UIElement[] inputElements = new UIElement[] { select_vehicle_type, select_vehicle_manufacture, select_vehicle_model, select_vehicle_model, select_vehicle_range, select_vehicle_year, select_vehicle_speed, select_vehicle_price, select_vehicle_mph, selecet_vehicle_info };
            success_box_manage.Visibility = Visibility.Collapsed;
            foreach (var element in inputElements)
            {
                if (element is TextBox textBox)
                {
                    if (textBox.Text != "")
                    {
                        textBox.Text = "";
                    }

                }
                else if (element is ComboBox comboBox)
                {
                    if (comboBox.Text != "")
                    {
                        comboBox.Text = "";

                    }
                }
            }
        }

        private void clear_Action(object sender, RoutedEventArgs e)
        {
            UIElement[] inputElements = new UIElement[] { select_vehicle_type, select_vehicle_manufacture, select_vehicle_model, select_vehicle_model, select_vehicle_range, select_vehicle_year, select_vehicle_speed, select_vehicle_price, select_vehicle_mph, selecet_vehicle_info };
            error_box_manage.Visibility = Visibility.Collapsed;
            foreach (var element in inputElements)
            {
                if (element is TextBox textBox)
                {
                    if (textBox.Text != "")
                    {
                        textBox.Text = "";
                    }
                }
                else if (element is ComboBox comboBox)
                {
                    if (comboBox.Text != "")
                    {
                        comboBox.Text = "";

                    }
                }
            }
        }
        private void get_stock_id()
        {

        }
    }
}
