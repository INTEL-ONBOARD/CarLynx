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
        public bool query_executer(String qu) 
        {

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(qu, con);
                int rowssAffected = cmd.ExecuteNonQuery();
                if (rowssAffected > 0) { Console.WriteLine("Execution success! Data injected!"); return true; } else { Console.WriteLine("Execution faild with errors!"); return false; }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Error occured!");
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        //this is special method to ge the id of record you request only return the record -
        public int query_executer_reader_id(String qu)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(qu, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    int id = Convert.ToInt32(dr["car_id"]);
                    Console.WriteLine(id);
                    return id;
                }
                else
                {
                    return 0;
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            finally
            {
                con.Close();
            }
        }

    }
}
