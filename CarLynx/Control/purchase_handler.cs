using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLynx.Model;

namespace CarLynx.Control
{
    internal class purchase_handler
    {
        public bool purchase_do(String pid,String uid,String cid,String car_model,String car_manu,String car_year,String car_price,String username,String name,String contact,String addr)
        {

            Dbhandler handler = new Dbhandler();
            String query = "INSERT INTO report_ (purchase_id, user_id, car_id, car_model, car_manufacture, car_year, car_price, username, name, contact, address) VALUES ('" + pid + "','" + uid + "','" + cid + "','" + car_model + "','" + car_manu + "','" + car_year + "','" + car_price + "','" + username + "','" + name + "','" + contact + "','" + addr + "')";
            Console.WriteLine(query);
            if (handler.query_executer(query)) { return true; } else { return false; }
        }
    }
}
