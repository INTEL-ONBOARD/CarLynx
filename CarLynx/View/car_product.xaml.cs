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

        public String car_id { get; set; }
        public String Company { get; set; }
        public String model { get; set; }
        public String info { get; set; }
        public String price { get; set; }
        public String range { get; set; }
        public String speed { get; set; }
        public String mph { get; set; }
        public String year { get; set; }

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
    }
}
