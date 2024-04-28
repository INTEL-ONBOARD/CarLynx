using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLynx.Model;

namespace CarLynx.Control
{
    internal class login_process
    {
        public bool login_check(String username, String password)
        {
            
            Dbhandler handler = new Dbhandler();
            String querry = "SELECT * FROM users WHERE username = '" + username + "' AND password = '" + password + "'";
            if (handler.loginquery(querry)) { return true; }else { return false; }  
        }
        public String get_user_id(String username, String password)
        {
            Dbhandler handler = new Dbhandler();
            String querry = "SELECT * FROM users WHERE username = '" + username + "' AND password = '" + password + "'";
            String get_id = handler.get_id(querry);
            return get_id;
        }
        
    }
}
