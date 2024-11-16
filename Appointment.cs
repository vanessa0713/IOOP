using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace assignment_receptionist
{
    class Appointment
    {
        private int appointmentID { get; set; }
        private string vehicleID { get; set; }
        private string appStatus { get; set; }
        private string appDate {  get; set; }
        private string appTime { get; set; }
        private string appDescription {  get; set; }
        private int customerID { get; set; } 
        private int mechanicID { get; set; }
        private int serviceID {  get; set; }
        public Appointment() // overload
        {

        }
        public Appointment(int appointmentID, string vehicleID, string appStatus, string appDate, string appTime,
                       string appDescription, int customerID, int mechanicID, int serviceID)  //contractor with values 
        {
            this.appointmentID = appointmentID;
            this.vehicleID = vehicleID;
            this.appStatus = appStatus;
            this.appDate = appDate;
            this.appTime = appTime;
            this.appDescription = appDescription;
            this.customerID = customerID;
            this.mechanicID = mechanicID;
            this.serviceID = serviceID;
        }
        public void searchAppUseAppointmentID(int appointmentID) // Use only appointmentID to search
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CarShop"].ToString());
            try
            {
                con.Open();

                // query to check for the appointment with the given appointmentID
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Appointment WHERE appointmentID = @appointmentID", con);
                cmd.Parameters.AddWithValue("@appointmentID", appointmentID);

                // qery executed and count is renturned after execution
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count > 0)
                {
                    // retrive customerID
                    SqlCommand cmd1 = new SqlCommand("SELECT customerID FROM Appointment WHERE appointmentID = @appointmentID", con);
                    cmd1.Parameters.AddWithValue("@appointmentID", appointmentID);
                    var customerIDResult = cmd1.ExecuteScalar();
                    if (customerIDResult != DBNull.Value)
                        this.customerID = Convert.ToInt32(customerIDResult); // Convert to int since customerID is an int

                    // retrive vehicleID
                    SqlCommand cmd2 = new SqlCommand("SELECT vehicleID FROM Appointment WHERE appointmentID = @appointmentID", con);
                    cmd2.Parameters.AddWithValue("@appointmentID", appointmentID);
                    var vehicleIDResult = cmd2.ExecuteScalar();
                    if (vehicleIDResult != DBNull.Value)
                        this.vehicleID = vehicleIDResult.ToString();

                    // retrive appDate
                    SqlCommand cmd3 = new SqlCommand("SELECT appDate FROM Appointment WHERE appointmentID = @appointmentID", con);
                    cmd3.Parameters.AddWithValue("@appointmentID", appointmentID);
                    var appDateResult = cmd3.ExecuteScalar();
                    if (appDateResult != DBNull.Value)
                        this.appDate = appDateResult.ToString();

                    //retrive appTime
                    SqlCommand cmd4 = new SqlCommand("SELECT appTime FROM Appointment WHERE appointmentID = @appointmentID", con);
                    cmd4.Parameters.AddWithValue("@appointmentID", appointmentID);
                    var appTimeResult = cmd4.ExecuteScalar();
                    if (appTimeResult != DBNull.Value)
                        this.appTime = appTimeResult.ToString();

                    // retrive mechanicID (convert to int)
                    SqlCommand cmd5 = new SqlCommand("SELECT mechanicID FROM Appointment WHERE appointmentID = @appointmentID", con);
                    cmd5.Parameters.AddWithValue("@appointmentID", appointmentID);
                    var mechanicIDResult = cmd5.ExecuteScalar();
                    if (mechanicIDResult != DBNull.Value)
                        this.mechanicID = Convert.ToInt32(mechanicIDResult); 

                    // retrive serviceID (convert to int)
                    SqlCommand cmd6 = new SqlCommand("SELECT serviceID FROM Appointment WHERE appointmentID = @appointmentID", con);
                    cmd6.Parameters.AddWithValue("@appointmentID", appointmentID);
                    var serviceIDResult = cmd6.ExecuteScalar();
                    if (serviceIDResult != DBNull.Value)
                        this.serviceID = Convert.ToInt32(serviceIDResult); 

                    // appointment is returve as the parameter passed in the method
                    this.appointmentID = appointmentID;
                }
                else
                {
                    MessageBox.Show("No appointment found for the given appointmentID.", "Appointment Not Found", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }



        public void searchAppUseVehicleID(string vehicleID) // Use only vehicleID to search
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CarShop"].ToString());
            try
            {
                con.Open();

                //  query to check for the appointment with the given vehicleID
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM Appointment WHERE vehicleID = @vehicleID", con);
                cmd.Parameters.AddWithValue("@vehicleID", vehicleID);

                // Execute the query and retrieve the count
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count > 0)
                {
                    // Query for customerID (convert to int)
                    SqlCommand cmd1 = new SqlCommand("SELECT customerID FROM Appointment WHERE vehicleID = @vehicleID", con);
                    cmd1.Parameters.AddWithValue("@vehicleID", vehicleID);
                    var customerIDResult = cmd1.ExecuteScalar();
                    if (customerIDResult != DBNull.Value)
                        this.customerID = Convert.ToInt32(customerIDResult); // Convert to int since customerID is an int

                    // Query for appointmentID (convert to int)
                    SqlCommand cmd2 = new SqlCommand("SELECT appointmentID FROM Appointment WHERE vehicleID = @vehicleID", con);
                    cmd2.Parameters.AddWithValue("@vehicleID", vehicleID);
                    var appointmentIDResult = cmd2.ExecuteScalar();
                    if (appointmentIDResult != DBNull.Value)
                        this.appointmentID = Convert.ToInt32(appointmentIDResult); // Convert to int since appointmentID is an int

                    // Query for appDate
                    SqlCommand cmd3 = new SqlCommand("SELECT appDate FROM Appointment WHERE vehicleID = @vehicleID", con);
                    cmd3.Parameters.AddWithValue("@vehicleID", vehicleID);
                    var appDateResult = cmd3.ExecuteScalar();
                    if (appDateResult != DBNull.Value)
                        this.appDate = appDateResult.ToString();

                    // Query for appTime
                    SqlCommand cmd4 = new SqlCommand("SELECT appTime FROM Appointment WHERE vehicleID = @vehicleID", con);
                    cmd4.Parameters.AddWithValue("@vehicleID", vehicleID);
                    var appTimeResult = cmd4.ExecuteScalar();
                    if (appTimeResult != DBNull.Value)
                        this.appTime = appTimeResult.ToString();

                    // Query for mechanicID (convert to int)
                    SqlCommand cmd5 = new SqlCommand("SELECT mechanicID FROM Appointment WHERE vehicleID = @vehicleID", con);
                    cmd5.Parameters.AddWithValue("@vehicleID", vehicleID);
                    var mechanicIDResult = cmd5.ExecuteScalar();
                    if (mechanicIDResult != DBNull.Value)
                        this.mechanicID = Convert.ToInt32(mechanicIDResult);

                    // Query for serviceID (convert to int)
                    SqlCommand cmd6 = new SqlCommand("SELECT serviceID FROM Appointment WHERE vehicleID = @vehicleID", con);
                    cmd6.Parameters.AddWithValue("@vehicleID", vehicleID);
                    var serviceIDResult = cmd6.ExecuteScalar();
                    if (serviceIDResult != DBNull.Value)
                        this.serviceID = Convert.ToInt32(serviceIDResult);

                    this.vehicleID = vehicleID;
                }
                else
                {
                    MessageBox.Show("No appointment found for the given vehicleID.", "Appointment Not Found", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }


        public void searchAppUseCustomerID(int customerID) // Use customerID to search for appooitment
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CarShop"].ToString());
            try
            {
                con.Open();
                //query  for checking their is the coressponding row for the data 
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Appointment WHERE customerID = @customerID", con);
                cmd.Parameters.AddWithValue("@customerID", customerID);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count > 0)
                {
                    SqlCommand cmd1 = new SqlCommand("SELECT appointmentID FROM Appointment WHERE customerID = @customerID", con);
                    cmd1.Parameters.AddWithValue("@customerID", customerID);
                    var appointmentIDResult = cmd1.ExecuteScalar();
                    if (appointmentIDResult != DBNull.Value)
                        this.appointmentID = Convert.ToInt32(appointmentIDResult); 

                    SqlCommand cmd2 = new SqlCommand("SELECT appStatus FROM Appointment WHERE customerID = @customerID", con);
                    cmd2.Parameters.AddWithValue("@customerID", customerID);
                    var appStatusResult = cmd2.ExecuteScalar();
                    if (appStatusResult != DBNull.Value)
                        this.appStatus = appStatusResult.ToString(); 

                    SqlCommand cmd3 = new SqlCommand("SELECT appDate FROM Appointment WHERE customerID = @customerID", con);
                    cmd3.Parameters.AddWithValue("@customerID", customerID);
                    var appDateResult = cmd3.ExecuteScalar();
                    if (appDateResult != DBNull.Value)
                        this.appDate = appDateResult.ToString();

                    SqlCommand cmd4 = new SqlCommand("SELECT appTime FROM Appointment WHERE customerID = @customerID", con);
                    cmd4.Parameters.AddWithValue("@customerID", customerID);
                    var appTimeResult = cmd4.ExecuteScalar();
                    if (appTimeResult != DBNull.Value)
                        this.appTime = appTimeResult.ToString(); 

                    SqlCommand cmd5 = new SqlCommand("SELECT mechanicID FROM Appointment WHERE customerID = @customerID", con);
                    cmd5.Parameters.AddWithValue("@customerID", customerID);
                    var mechanicIDResult = cmd5.ExecuteScalar();
                    if (mechanicIDResult != DBNull.Value)
                        this.mechanicID = Convert.ToInt32(mechanicIDResult); 

                    SqlCommand cmd6 = new SqlCommand("SELECT serviceID FROM Appointment WHERE customerID = @customerID", con);
                    cmd6.Parameters.AddWithValue("@customerID", customerID);
                    var serviceIDResult = cmd6.ExecuteScalar();
                    if (serviceIDResult != DBNull.Value)
                        this.serviceID = Convert.ToInt32(serviceIDResult);

                    SqlCommand cmd7 = new SqlCommand("SELECT vehicleID FROM Appointment WHERE customerID = @customerID", con);
                    cmd7.Parameters.AddWithValue("@customerID", customerID);
                    var vehicleIDResult = cmd7.ExecuteScalar();
                    if (vehicleIDResult != DBNull.Value)
                        this.vehicleID = vehicleIDResult.ToString(); 

                    this.customerID = customerID;  
                }
                else
                {
                    MessageBox.Show("No appointment found for the given customerID.", "Appointment Not Found",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }


        public void UpdateAppointment(int appointmentID, string appStatus, int mechanicID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CarShop"].ToString();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Appointment SET appStatus = @appStatus, mechanicID = @mechanicID WHERE appointmentID = @appointmentID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@appStatus", appStatus);
                    cmd.Parameters.AddWithValue("@mechanicID", mechanicID);
                    cmd.Parameters.AddWithValue("@appointmentID", appointmentID);

                    try
                    {
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No record found with the specified appointment ID.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("SQL Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        public string getAppointmentID()
        {
            return this.appointmentID.ToString();
        }
        public string getVehicleID()
        {
            return this.vehicleID;
        }
        public string getAppiontmentStatus()
        {
            return this.appStatus;
        }
        public string getAppDescription()
        {
            return this.appDescription;
        }
        public string getCustomerID()
        {
            return (this.customerID).ToString();
        }
        public string getMechanicID()
        {
            return (this.mechanicID).ToString();
        }
        public string getAppDate()
        {
            return this.appDate;
        }
        public string getAppTime()
        {
            return this.appTime;
        }
        public string getServiceID()
        {
            return (this.serviceID).ToString();
        }

    }
}
