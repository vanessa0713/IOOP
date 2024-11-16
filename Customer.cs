using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment_receptionist
{
    class Customer
    {
        private int customerID { get; set; }
        private string customerName { get; set; }
        private string cusPassword { get; set; }
        private string cusEmail { get; set; }
        private string cusAccStatus { get; set; }
        public Customer()
        {

        }
        public void searchAccount(int customerID)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CarShop"].ToString());
            con.Open();

            SqlCommand cmd1 = new SqlCommand("SELECT count(*) FROM Customer WHERE customerID = @customerID", con);

            // Add parameter and assign its value
            cmd1.Parameters.AddWithValue("@customerID", customerID);

            // Execute and retrieve the result
            int count = Convert.ToInt32(cmd1.ExecuteScalar());

            if (count > 0)
            {
                // Query for customerID
                SqlCommand cmd2 = new SqlCommand("SELECT cusName FROM Customer WHERE customerID = @customerID", con);
                cmd2.Parameters.AddWithValue("@customerID", customerID);
                var customerIDResult = cmd2.ExecuteScalar();
                if (customerIDResult != DBNull.Value)
                    this.customerName = customerIDResult.ToString();
                this.customerID = customerID;
            }
            con.Close();
        }
        public string diaplayCusInfor(string customerID)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CarShop"].ToString());
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT cusName FROM Customer WHERE customerID = @customerID", con);

            cmd.Parameters.AddWithValue("@customerID", customerID);

            this.customerName = cmd.ExecuteScalar().ToString();

            con.Close();
            return this.customerName;
        }
        public void deactivateAccount(int customerID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CarShop"].ToString();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;
                try
                {
                    con.Open();
                    transaction = con.BeginTransaction();

                    // Update cusAccStatus in Customer table for the given customerID
                    SqlCommand cmdUpdateCustomer = new SqlCommand(
                        "UPDATE Customer SET cusAccStatus = @cusAccStatus WHERE customerID = @customerID", con, transaction);
                    cmdUpdateCustomer.Parameters.AddWithValue("@customerID", customerID);
                    cmdUpdateCustomer.Parameters.AddWithValue("@cusAccStatus", "In-Active");

                    cmdUpdateCustomer.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("Account status updated to 'Inactive' successfully.");
                }
                catch (Exception ex)
                {
                    // Rollback the transaction if an error occurs
                    transaction?.Rollback();
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }


        public void addAccount(string userName, string password, string email)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CarShop"].ToString();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = "INSERT INTO Customer (cusName, cusPassword, cusEmail, cusAccStatus,accountTypeID) " +
                                   "VALUES (@cusName, @cusPassword, @cusEmail, @cusAccStatus,accountTypeID)";

                    SqlCommand cmd = new SqlCommand(query, con);

                    // Add parameters and assign their values
                    cmd.Parameters.AddWithValue("@cusName", userName);
                    cmd.Parameters.AddWithValue("@cusPassword", password);
                    cmd.Parameters.AddWithValue("@cusEmail", email);
                    cmd.Parameters.AddWithValue("@cusAccStatus", "ACTIVE");
                    cmd.Parameters.AddWithValue("@accountTypeID", 3); //3 is the code for customer account

                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Check if rows were inserted
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Account added successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to add account.");
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Log the exception (you can log it to a file, or use a logging library)
                MessageBox.Show("Database error: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                // Catch any other general exceptions
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        public string getCusID()
        {
            return (this.customerID).ToString();
        }
        public string getCusName()
        {
            return this.customerName;
        }

        public Boolean VerifyUserName(string userName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CarShop"].ToString();
            Boolean found;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT COUNT(customerName) FROM Customer WHERE cusName = @cusName";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@cusName", userName);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 0)
                    {
                        found = false;  // User does not exist
                    }
                    else
                    {
                        found = true;   // User exists
                    }
                }
                catch (Exception ex)
                {
                    // Handle the exception (log or display an error message)
                    MessageBox.Show("Error: " + ex.Message);
                    found = true;  // Return ture whenn error occured
                }
            }
            return found;
        }

    }
}
