using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ecommerce.Models
{
    public class Sql
    {
        public static DataTable Exec(string sorgu)
        {
            string connectionString = @"Data Source=DESKTOP-M5BK3NF\SQLEXPRESS;Initial Catalog=Restoran; Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionString);
            sqlcon.Open();
            SqlCommand srg = new SqlCommand(sorgu, sqlcon);
            SqlDataAdapter adapter = new SqlDataAdapter(srg);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            sqlcon.Close();
            return dt;

        }
    }
}