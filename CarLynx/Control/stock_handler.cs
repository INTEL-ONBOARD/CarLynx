﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CarLynx.Model;
using CarLynx.View;

namespace CarLynx.Control
{
    internal class stock_handler
    {
        Dbhandler handler;
        public stock_handler() { 
            handler = new Dbhandler();
        }
        public void stock_view(StackPanel view)
        {
            DataSet stock = new DataSet();
            stock = handler.getstock_querry("select * FROM car_stock");
            foreach (DataRow row in stock.Tables[0].Rows)
            {
                car_product car = new car_product();

                car.car_id = row["car_id"].ToString();
                car.Company = row["company"].ToString();
                car.model = row["brand"].ToString();
                car.info = row["info"].ToString();
                car.price = "$ "+row["price"].ToString();
                car.range = row["range"].ToString();
                car.speed = row["top_speed"].ToString();
                car.mph = row["mph"].ToString();
                car.year = row["year"].ToString();

                car.ChangeImageSource_car("C:/Users/wenuj/source/repos/CarLynx/CarLynx/Resources/Car_models/" + row["brand"].ToString()+".jpg");
                car.ChangeImageSource_logo("C:/Users/wenuj/source/repos/CarLynx/CarLynx/Resources/car_logos/" + row["company"].ToString() + ".png");

                view.Children.Add(car);
            }
        }
    }
}