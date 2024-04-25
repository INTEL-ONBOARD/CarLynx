using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace CarLynx.Model
{

    internal class Dbhandler
    {
        SqlConnection con;
        String authString = "DATA Source=VitaminC\\SQLEXPRESS;Initial catalog=carLynxDB;Integrated Security=True";

        public Dbhandler()
        {
            try
            {
                con = new SqlConnection(authString);
                con.Open();
                Console.WriteLine("database connected!");
            }catch (Exception ex) { 
                Console.WriteLine(ex.Message);
            }
        }
        public bool loginquery(String qu)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(qu, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows) { return true; } else { return false; }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
