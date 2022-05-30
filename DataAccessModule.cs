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
            dbConn.Close();            
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
            dbConn.Close();
            DataTable dataTable = new DataTable("appointments");
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter();
            dbConn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM appointment WHERE clientid = @clientId AND appointmentdate > @date;", dbConn);
            cmd.Parameters.AddWithValue("@clientId", clientId);
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
            dataAdapter.SelectCommand = cmd;
            dataAdapter.Fill(dataTable);

            //Garbage collection            
            dataAdapter.Dispose();

            return dataTable;
        }

        public DataTable getBookingServices(List<int> bookingID)
        {
            NpgsqlConnection dbConn = new NpgsqlConnection(connectionString());
            dbConn.Close();
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

        public DataTable getDashboardAppointmentForToday()
        {
            NpgsqlConnection dbConn = new NpgsqlConnection(connectionString());
            dbConn.Close();
            DataTable dataTable = new DataTable();
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter();
            dbConn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT a.id, CONCAT(c.firstname,' ',c.lastname) AS clientname, a.appointmenttime FROM" +
                " clients AS c, appointment AS a WHERE a.appointmentdate = @date AND c.id = a.clientid AND a.completed = 0;", dbConn);
            cmd.Parameters.AddWithValue("@date", DateTime.Today);
            dataAdapter.SelectCommand = cmd;
            dataAdapter.Fill(dataTable);
            //Garbage collection            
            dataAdapter.Dispose();

            return dataTable;
        }

        public DataTable getAllDashboardAppointment()
        {
            NpgsqlConnection dbConn = new NpgsqlConnection(connectionString());
            dbConn.Close();
            DataTable dataTable = new DataTable();
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter();
            dbConn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT a.id, CONCAT(c.firstname,' ',c.lastname) AS clientname, a.appointmentdate, a.appointmenttime FROM" +
                " clients AS c, appointment AS a WHERE c.id = a.clientid AND a.appointmentdate > @date ORDER BY a.appointmentdate;", dbConn);
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
            dataAdapter.SelectCommand = cmd;
            dataAdapter.Fill(dataTable);
            //Garbage collection            
            dataAdapter.Dispose();

            return dataTable;
        }
        
        public DataTable getAllServicesFromAppointment(int appid)
        {
            NpgsqlConnection dbConn = new NpgsqlConnection(connectionString());
            dbConn.Close();
            DataTable dataTable = new DataTable();
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter();
            dbConn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT s.servicename FROM services as s, appointment_services as b where s.id = b.serviceid and b.appointmentid = @appid;", dbConn);
            cmd.Parameters.AddWithValue("@appid", appid);
            dataAdapter.SelectCommand = cmd;
            dataAdapter.Fill(dataTable);

            //Garbage collection            
            dataAdapter.Dispose();

            return dataTable;
        }
        

        public void setClientAppointment(int clientId, string appointmentdate, string appointmenttime)
        {
            NpgsqlConnection dbConn = new NpgsqlConnection(connectionString());
            dbConn.Close();
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

        public void addNewUser(string firstname, string lastname, string email, string password)
        {
            NpgsqlConnection dbConn = new NpgsqlConnection(connectionString());
            dbConn.Close();
            dbConn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO clients (firstname, lastname, email, password) VALUES (@fname,@lname,@email, @password);", dbConn);
            cmd.Parameters.AddWithValue("@fname", firstname);
            cmd.Parameters.AddWithValue("@lname", lastname);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.ExecuteNonQuery();
            cmd = new NpgsqlCommand("SELECT id FROM clients ORDER BY id DESC LIMIT 1;", dbConn);
            NpgsqlDataReader dataReader = cmd.ExecuteReader();
            dataReader.Read();
            Global.user = new User(int.Parse(dataReader.GetValue(0).ToString()), firstname, lastname, email);            
        }

        public void setAppointmentComplete(int appid)
        {
            NpgsqlConnection dbConn = new NpgsqlConnection(connectionString());
            dbConn.Close();
            dbConn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("UPDATE appointment SET completed = 1 WHERE id = @appid;", dbConn);
            cmd.Parameters.AddWithValue("@appid", appid);           
            cmd.ExecuteNonQuery();
        }
       
    }
}