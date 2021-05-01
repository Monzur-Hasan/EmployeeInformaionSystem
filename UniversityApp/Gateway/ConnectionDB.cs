using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UniversityApp.Gateway
{
    public class ConnectionDB
    {

        private SqlConnection con;
        public SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectString"].ConnectionString;

            con = new SqlConnection(connectionString);         //from Web config in connection
            
            if(con.State == ConnectionState.Open)
            {
                con.Close();
                con.Open();
            }

            else
            {
                con.Open();
            }
            return con;
        }

        public void GetColse()
        {
            if(con != null)            //or if(con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}