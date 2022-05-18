using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Npgsql;
using System.Configuration;

namespace Salon_CRM
{
    public class DataAccessModule
    {
        
        public string connectionString()
        {
            return ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
        }

        public DataTable getAllServices()
        {
            NpgsqlConnection dbConn = new NpgsqlConnection(connectionString());            
            DataTable dataTable = new DataTable("services"); 
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter();            
            dbConn.Open();
            dataAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM services;", dbConn);
            dataAdapter.Fill(dataTable);

            //Garbage collection            
            dataAdapter.Dispose();

            return dataTable;
        }
    }
}