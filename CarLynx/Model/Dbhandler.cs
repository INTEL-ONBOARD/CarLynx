using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

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

                Console.WriteLine("database connected!");
            }catch (Exception ex) { 
                Console.WriteLine(ex.Message);
            }
        }
        public bool loginquery(String qu)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(qu, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows) { return true; } else { return false; }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet getstock_querry(String qu)
        {
            DataSet ds = new DataSet(); 

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(qu, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    Console.WriteLine("Data retrieved successfully! Exiting method.");
                    return ds;
                }
                else
                {
                    Console.WriteLine("No data found.");
                    return null; 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null; 
            }
            finally
            {
                con.Close();
            }
        }


    }
}
