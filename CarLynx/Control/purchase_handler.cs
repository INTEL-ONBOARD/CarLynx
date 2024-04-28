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
        public bool purchase_do(String pid,String uid,String cid)
        {

            Dbhandler handler = new Dbhandler();
            String querry = "INSERT INTO purchases (purchase_id, user_id, car_id) VALUES('"+pid+"','"+uid+"','"+cid+"')";
            Console.WriteLine("====================++++++");
            if (handler.query_executer(querry)) { Console.WriteLine("++++++++++++++++++++++"); return true; } else { return false; }
        }
    }
}
