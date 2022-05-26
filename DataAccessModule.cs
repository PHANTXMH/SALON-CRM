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
        

        public DataTable getPendingAppointments(int clientId)
        {
            NpgsqlConnection dbConn = new NpgsqlConnection(connectionString());
            DataTable dataTable = new DataTable("appointments");
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter();
            dbConn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM appointment WHERE clientid = @clientId;", dbConn);
            cmd.Parameters.AddWithValue("@clientId", clientId);
            dataAdapter.SelectCommand = cmd;
            dataAdapter.Fill(dataTable);

            //Garbage collection            
            dataAdapter.Dispose();

            return dataTable;
        }

        public DataTable getBookingServices(List<int> bookingID)
        {
            NpgsqlConnection dbConn = new NpgsqlConnection(connectionString());
            DataTable dataTable = new DataTable("services");
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter();
            dbConn.Open();            

            if(Global.selectedServices.Count == 1)  //if there is one service selected
            {
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM services WHERE id= @serviceId;", dbConn);
                cmd.Parameters.AddWithValue("@serviceId", bookingID[0]);
                dataAdapter.SelectCommand = cmd;
                dataAdapter.Fill(dataTable);
            }
            else if(Global.selectedServices.Count == 2) //if there are two services selected
            {
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM services WHERE id = @serviceId1 OR id = @serviceId2;", dbConn);
                cmd.Parameters.AddWithValue("@serviceId1", bookingID[0]);
                cmd.Parameters.AddWithValue("@serviceId2", bookingID[1]);
                dataAdapter.SelectCommand = cmd;
                dataAdapter.Fill(dataTable);
            }
            else if(Global.selectedServices.Count == 3)     // if there are three services selected
            {
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM services WHERE id = @serviceId1 OR id = @serviceId2 OR id = @serviceId3;", dbConn);
                cmd.Parameters.AddWithValue("@serviceId1", bookingID[0]);
                cmd.Parameters.AddWithValue("@serviceId2", bookingID[1]);
                cmd.Parameters.AddWithValue("@serviceId3", bookingID[2]);
                dataAdapter.SelectCommand = cmd;
                dataAdapter.Fill(dataTable);
            }           

            //Garbage collection            
            dataAdapter.Dispose();

            return dataTable;
        }  
        
        public void setClientAppointment(int clientId, string appointmentdate, string appointmenttime)
        {
            NpgsqlConnection dbConn = new NpgsqlConnection(connectionString());            
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter();
            dbConn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO appointment (appointmentdate,appointmenttime,clientid) VALUES (@appdate,@apptime,@clientid);", dbConn);
            cmd.Parameters.AddWithValue("@appdate", DateTime.Parse(appointmentdate).Date);
            cmd.Parameters.AddWithValue("@apptime", DateTime.Parse(appointmenttime));
            cmd.Parameters.AddWithValue("@clientid", clientId);
            cmd.ExecuteNonQuery();            
            cmd = new NpgsqlCommand("SELECT id FROM appointment ORDER BY id DESC LIMIT 1;",dbConn);
            NpgsqlDataReader dataReader = cmd.ExecuteReader();
            dataReader.Read();
            int currentAppointment = int.Parse(dataReader.GetValue(0).ToString());
            dbConn.Close();
            dbConn.Open();

            if(Global.selectedServices.Count == 1)
            {                
                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO appointment_services (appointmentid,serviceid) VALUES (@appid, @serviceid);",dbConn);
                command.Parameters.AddWithValue("@appid", currentAppointment);
                command.Parameters.AddWithValue("@serviceid", Global.selectedServices[0]);
                command.ExecuteNonQuery();
            }else if(Global.selectedServices.Count == 2)
            {                
                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO appointment_services (appointmentid,serviceid) VALUES (@appid, @serviceid), (@appid, @serviceid2);",dbConn);
                command.Parameters.AddWithValue("@appid", currentAppointment);
                command.Parameters.AddWithValue("@serviceid", Global.selectedServices[0]);                
                command.Parameters.AddWithValue("@serviceid2", Global.selectedServices[1]);
                command.ExecuteNonQuery();
            }else if(Global.selectedServices.Count == 3)
            {                
                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO appointment_services (appointmentid,serviceid) VALUES (@appid, @serviceid), (@appid, @serviceid2),(@appid, @serviceid3);",dbConn);
                command.Parameters.AddWithValue("@appid", currentAppointment);
                command.Parameters.AddWithValue("@serviceid", Global.selectedServices[0]);
                command.Parameters.AddWithValue("@serviceid2", Global.selectedServices[1]);
                command.Parameters.AddWithValue("@serviceid3", Global.selectedServices[2]);
                command.ExecuteNonQuery();
            }

            dbConn.Close();
        }
       
    }
}