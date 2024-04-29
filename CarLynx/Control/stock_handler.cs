using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CarLynx.Model;
using CarLynx.View;
using CarLynx;
using System.Security.Cryptography;
using System.Windows.Controls.Primitives;
using System.IO;
using System.Runtime.CompilerServices;

namespace CarLynx.Control
{
    internal class stock_handler
    {
        Dbhandler handler;

        public stock_handler() { 

            handler = new Dbhandler();
        }
        public void stock_view(StackPanel view, MainWindow win)
        {
            DataSet stock = new DataSet();
            stock = handler.getstock_querry("select * FROM car_stock");
            foreach (DataRow row in stock.Tables[0].Rows)
            {
                car_product car = new car_product();
                car.getframe(win);
                car.car_id = row["car_id"].ToString();
                car.Company = row["company"].ToString();
                car.model = row["brand"].ToString();
                car.info = row["info"].ToString();
                car.price = "$ "+row["price"].ToString();
                car.range = row["range"].ToString();
                car.speed = row["top_speed"].ToString();
                car.mph = row["mph"].ToString();
                car.year = row["year"].ToString();
                if (row["availability"].ToString() == "0"){car.status = "Pre order"; } else { car.status = "Available"; }

                try
                {
                    car.ChangeImageSource_car("C:/Users/wenuj/source/repos/CarLynx/CarLynx/Resources/Car_models/" + row["brand"].ToString() + ".jpg");
                    car.ChangeImageSource_logo("C:/Users/wenuj/source/repos/CarLynx/CarLynx/Resources/car_logos/" + row["company"].ToString() + ".png");
                }
                catch(FileNotFoundException )
                {
                    car.ChangeImageSource_car("C:/Users/wenuj/source/repos/CarLynx/CarLynx/Resources/Car_models/NONE.jpg");
                    car.ChangeImageSource_logo("C:/Users/wenuj/source/repos/CarLynx/CarLynx/Resources/car_logos/" + row["company"].ToString() + ".png");
                }


                view.Children.Add(car);
            }
        }
        public void stock_view_filtered(MainWindow win, StackPanel view ,String runtime_query)
        {
            DataSet stock = new DataSet();
            stock = handler.getstock_querry(runtime_query);
            try
            {
                if (stock != null) {
                    win.notfound_img.Visibility = System.Windows.Visibility.Hidden;
                    win.notfound_text.Visibility = System.Windows.Visibility.Hidden;
                    foreach (DataRow row in stock.Tables[0].Rows)
                    {
                        car_product car = new car_product();
                        car.getframe(win);
                        car.car_id = row["car_id"].ToString();
                        car.Company = row["company"].ToString();
                        car.model = row["brand"].ToString();
                        car.info = row["info"].ToString();
                        car.price = "$ " + row["price"].ToString();
                        car.range = row["range"].ToString();
                        car.speed = row["top_speed"].ToString();
                        car.mph = row["mph"].ToString();
                        car.year = row["year"].ToString();
                        if (row["availability"].ToString() == "0") { car.status = "Pre order"; } else { car.status = "Available"; }


                        try
                        {
                            car.ChangeImageSource_car("C:/Users/wenuj/source/repos/CarLynx/CarLynx/Resources/Car_models/" + row["brand"].ToString() + ".jpg");
                            car.ChangeImageSource_logo("C:/Users/wenuj/source/repos/CarLynx/CarLynx/Resources/car_logos/" + row["company"].ToString() + ".png");
                        }
                        catch (FileNotFoundException)
                        {
                            car.ChangeImageSource_car("C:/Users/wenuj/source/repos/CarLynx/CarLynx/Resources/Car_models/NONE.jpg");
                            car.ChangeImageSource_logo("C:/Users/wenuj/source/repos/CarLynx/CarLynx/Resources/car_logos/" + row["company"].ToString() + ".png");
                        }

                        view.Children.Add(car);
                    }
                }
                else
                {
                   win.notfound_img.Visibility = System.Windows.Visibility.Visible;
                   win.notfound_text.Visibility = System.Windows.Visibility.Visible;
                }

            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public bool add_stock(MainWindow win)
        {
            String query = "INSERT INTO car_stock (car_id,company,brand,info,range,top_speed,mph,price,year,availability,type) VALUES (" + (get_stock_count() + 1).ToString() +",'"+ win.select_vehicle_manufacture.Text.ToString() + "','" + win.select_vehicle_model.Text.ToString() + "','" + win.selecet_vehicle_info.Text.ToString() + "'," + win.select_vehicle_range.Text.ToString()+ "," + win.select_vehicle_speed.Text.ToString() + "," + win.select_vehicle_mph.Text.ToString() + "," + win.select_vehicle_price.Text.ToString() + "," + win.select_vehicle_year.Text.ToString() + "," + "1"+ ",'" + win.select_vehicle_type.Text.ToString() + "')";
            Console.WriteLine(query);
            bool isaccpeted = handler.query_executer(query);
            if (isaccpeted) { return true; } else { return false; }
        }
        // this is for to get the latest id from the database : stock
        public int get_stock_count()
        {
            int last_id = handler.query_executer_reader_id("SELECT TOP 1 * FROM car_stock ORDER BY car_id DESC;");

            if (last_id >= 0) { return last_id; }else{  return 0; }

        }
        // this is for to get the latest id from the database : purchases
        public int get_purchase_count()
        {
            int last_id_purchase = handler.query_executer_reader_id("SELECT TOP 1 * FROM purchases ORDER BY purchase_id DESC;");

            if (last_id_purchase >= 0) { return last_id_purchase; } else { return 0; }

        }

        public void user_dump(String id ,MainWindow win)
        {
            DataSet stock = new DataSet();
            stock = handler.getstock_querry("select * FROM users WHERE UserID = '"+id+"'");
            foreach (DataRow row in stock.Tables[0].Rows)
            {
                win.uid_ = row["UserID"].ToString();
                win.username_ = row["username"].ToString();
                win.password_ = row["password"].ToString();
                win.name_ = row["name"].ToString();
                win.contact_ = row["contact"].ToString();
                win.address_ = row["address"].ToString();
                win.age_ = row["age"].ToString();

                Console.WriteLine(win.username_);
            }
        }



    }
}
