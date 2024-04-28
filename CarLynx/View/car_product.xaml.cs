using CarLynx.Control;
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


namespace CarLynx.View
{
    /// <summary>
    /// Interaction logic for car_product.xaml
    /// </summary>
    public partial class car_product : UserControl
    {
        public car_product()
        {
            InitializeComponent();
            this.DataContext = this;

        }
        public MainWindow win;
        public void getframe(MainWindow win_)
        {
            win = win_;
        }
        public String car_id { get; set; }
        public String Company { get; set; }
        public String model { get; set; }
        public String info { get; set; }
        public String price { get; set; }
        public String range { get; set; }
        public String speed { get; set; }
        public String mph { get; set; }
        public String year { get; set; }
        public String status { get; set; }



        public void ChangeImageSource_car(string imagePath)
        {
            // Create a new BitmapImage with the provided image path
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath, UriKind.RelativeOrAbsolute);
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();

            // Set the BitmapImage as the source of the Image control
            this.car_img.Source = bitmap;
        }
        public void ChangeImageSource_logo(string imagePath)
        {
            // Create a new BitmapImage with the provided image path
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath, UriKind.RelativeOrAbsolute);
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();

            // Set the BitmapImage as the source of the Image control
            this.logo.Source = bitmap;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void purchaseThis(object sender, RoutedEventArgs e)
        {
            win.store_view.Visibility = Visibility.Collapsed;
            login_process ps = new login_process();
            String uid = ps.get_user_id(win.uname.Text,win.pwd.Text);
            win.car_id_rented = car_id;

            stock_handler sh = new stock_handler();
            sh.user_dump(uid ,win);
            

            win.binder("C:/Users/wenuj/source/repos/CarLynx/CarLynx/Resources/Car_models/" + model + ".jpg",Company,model,price,year );
            



            win.pValue.Visibility = Visibility.Visible;
            win.p_lbl.Visibility = Visibility.Visible;
            win.image_fill.Visibility = Visibility.Visible;
            win.comf.Visibility = Visibility.Visible;
            win.modf.Visibility = Visibility.Visible;
            win.purchase_info2.Visibility = Visibility.Hidden;
            win.purchase_info1.Visibility = Visibility.Visible;
            win.purchase_view.Visibility = Visibility.Visible;
        }
    }
}