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
        List<int> selectedServices = new List<int>();
        public string connectionString()
        {
            return ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
        }

        public void addAppointment(int appointment)
        {
            selectedServices.Add(appointment);
        }

        public void removeAppointment(int appointment)
        {
            selectedServices.Remove(appointment);
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

        public DataTable getUser(string username, string password)
        {
            NpgsqlConnection dbConn = new NpgsqlConnection(connectionString());
            DataTable dataTable = new DataTable("clients");
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter();
            dbConn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM clients WHERE email = @username AND password = @password;", dbConn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            dataAdapter.SelectCommand = cmd;

            dataAdapter.Fill(dataTable);

            //Garbage collection            
            dataAdapter.Dispose();

            return dataTable;
        }
    }
}