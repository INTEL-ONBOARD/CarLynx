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
            String querry = "SELECT * FROM users WHERE Username = '" + username + "' AND Password = '" + password + "'";
            if (handler.loginquery(querry)) { return true; }else { return false; }  
        }
    }
}
