using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLynx.Model;

namespace CarLynx.Control
{
    internal class login_process

    {
        public String usernameSt;
        public String passwordSt;// Stored usrname and password;
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


        public string userNAme,passwd,name,conNumber,address;
        public void user_retrive() 
        
        {
            Dbhandler handler = new Dbhandler();
            String querry = "SELECT * FROM users WHERE username = '" + usernameSt +"'";
            DataSet ds = new DataSet();
            ds = handler.getstock_querry(querry);
            userNAme = ds.Tables[0].Rows[0]["Username"].ToString();
            name = ds.Tables[0].Rows[0]["Username"].ToString();





        }
        
    }
}
