using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace assignment_receptionist
{
    class InventoryRequest
    {
        private int requestID { get; set; }
        private string reqTool { get; set; }
        private string requestDescription { get; set; }
        private string requestStatus { get; set; }
        private string mechanicID { get; set; }
        public InventoryRequest()
        {

        }
        public void searchRequestListUseMechaicID(string mechanicID) //search using mechanicID only
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CarShop"].ToString());

            try
            {
                con.Open();

                // SqlCommand objectName = new constructor(sqlQuery,connectionString);
                // Correcting SQL query and using parameterized queries
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM InventoryRequest WHERE mechanicID = @mechanicID", con);

                // Add the parameter with the mechanicID value
                cmd.Parameters.AddWithValue("@mechanicID", mechanicID);

                // Execute the query and get the count
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count > 0)
                {
                    // Retrieve requestID for the given mechanicID
                    SqlCommand cmd1 = new SqlCommand("SELECT requestID FROM InventoryRequest WHERE mechanicID = @mechanicID", con);
                    cmd1.Parameters.AddWithValue("@mechanicID", mechanicID);
                    this.requestID = (int)cmd1.ExecuteScalar();
                    // Retrieve reqTool for the given mechanicID
                    SqlCommand cmd2 = new SqlCommand("SELECT reqTool FROM InventoryRequest WHERE mechanicID = @mechanicID", con);
                    cmd2.Parameters.AddWithValue("@mechanicID", mechanicID);
                    this.reqTool = cmd2.ExecuteScalar()?.ToString();

                    // Retrieve description for the given mechanicID
                    SqlCommand cmd3 = new SqlCommand("SELECT requestDescription FROM InventoryRequest WHERE mechanicID = @mechanicID", con);
                    cmd3.Parameters.AddWithValue("@mechanicID", mechanicID);
                    this.requestDescription = cmd3.ExecuteScalar()?.ToString();

                    // Retrieve requestStatus for the given mechanicID
                    SqlCommand cmd4 = new SqlCommand("SELECT requestStatus FROM InventoryRequest WHERE mechanicID = @mechanicID", con);
                    cmd4.Parameters.AddWithValue("@mechanicID", mechanicID);
                    this.requestStatus = cmd4.ExecuteScalar()?.ToString();

                    this.mechanicID = mechanicID;
                }
                else
                {
                    // Display an error message if no matching record is found
                    MessageBox.Show("No inventory requests found for the provided mechanic ID.", "No Records Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            {
                // Handle SQL exceptions (e.g., connection issues, query errors)
                MessageBox.Show("An error occurred while querying the database: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Handle general exceptions (e.g., connection issues, other unexpected errors)
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();  // Ensure the connection is always closed
            }
        }

        public void searchRequestUseStatus(string status) // search using only requestStatus
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CarShop"].ToString());
            con.Open();
            // SqlCommand objectName = new constructor(sqlQuery,connectionString);
            // Use parameterized queries to prevent SQL injection
            SqlCommand cmd = new SqlCommand("SELECT count(*) FROM InventoryRequest WHERE requestStatus = @status", con);

            // Add the parameter with the 'status' value
            cmd.Parameters.AddWithValue("@status", status);

            // Execute the query and retrieve the count
            int count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count > 0)
            {
                // Retrieve requestID for the given requestStatus
                SqlCommand cmd1 = new SqlCommand("SELECT requestID FROM InventoryRequest WHERE requestStatus = @status", con);
                cmd1.Parameters.AddWithValue("@status", status);
                this.requestID = (int)cmd1.ExecuteScalar();

                // Retrieve reqTool for the given requestStatus
                SqlCommand cmd2 = new SqlCommand("SELECT reqTool FROM InventoryRequest WHERE requestStatus = @status", con);
                cmd2.Parameters.AddWithValue("@status", status);
                this.reqTool = cmd2.ExecuteScalar()?.ToString();

                // Retrieve description for the given requestStatus
                SqlCommand cmd3 = new SqlCommand("SELECT requestDescription FROM InventoryRequest WHERE requestStatus = @status", con);
                cmd3.Parameters.AddWithValue("@status", status);
                this.requestDescription = cmd3.ExecuteScalar()?.ToString();

                // Retrieve mechanicID for the given requestStatus
                SqlCommand cmd4 = new SqlCommand("SELECT mechanicID FROM InventoryRequest WHERE requestStatus = @status", con);
                cmd4.Parameters.AddWithValue("@status", status);
                this.mechanicID = cmd4.ExecuteScalar()?.ToString();

                this.requestStatus = status;
            }
            else
            {
                // Display an error message if no matching record is found
                MessageBox.Show("No inventory requests found with the provided request status.", "No Records Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            con.Close();
        }

    
    public void searchUseStatusAndMecID(string mechanicID, string status) //search using both mechanicID and status
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CarShop"].ToString());
            con.Open();
            // SqlCommand objectName = new constructor(sqlQuery,connectionString);
            // Use parameterized queries to prevent SQL injection
            SqlCommand cmd = new SqlCommand("SELECT count(*) FROM InventoryRequest WHERE mechanicID = @mechanicID AND requestStatus = @status", con);

            // Add parameters and assign their values
            cmd.Parameters.AddWithValue("@mechanicID", mechanicID);
            cmd.Parameters.AddWithValue("@status", status);

            // Execute the query and get the result
            int count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count > 0)
            {
                // Use parameterized queries to prevent SQL injection
                SqlCommand cmd1 = new SqlCommand("SELECT requestID FROM InventoryRequest WHERE mechanicID = @mechanicID AND requestStatus = @status", con);
                cmd1.Parameters.AddWithValue("@mechanicID", mechanicID);
                cmd1.Parameters.AddWithValue("@status", status);
                this.requestID = this.requestID = (int)cmd1.ExecuteScalar();

                SqlCommand cmd2 = new SqlCommand("SELECT reqTool FROM InventoryRequest WHERE mechanicID = @mechanicID AND requestStatus = @status", con);
                cmd2.Parameters.AddWithValue("@mechanicID", mechanicID);
                cmd2.Parameters.AddWithValue("@status", status);
                this.reqTool = cmd2.ExecuteScalar().ToString();

                SqlCommand cmd3 = new SqlCommand("SELECT requestDescription FROM InventoryRequest WHERE mechanicID = @mechanicID AND requestStatus = @status", con);
                cmd3.Parameters.AddWithValue("@mechanicID", mechanicID);
                cmd3.Parameters.AddWithValue("@status", status);
                this.requestDescription = cmd3.ExecuteScalar().ToString();

                this.mechanicID = mechanicID;
                this.requestStatus = status;
            }
            else
            {
                // Display an error message if no matching record is found
                MessageBox.Show("No inventory request found with the provided mechanicID and status.", "No Records Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public void UpdateInventoryRequest(int requestID, string requestStatus)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CarShop"].ToString();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Modify the query to update the InventoryRequest table
                string query = "UPDATE InventoryRequest SET requestStatus = @requestStatus WHERE requestID = @requestID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Add parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@requestStatus", requestStatus);
                    cmd.Parameters.AddWithValue("@requestID", requestID);

                    try
                    {
                        // Open the connection and execute the query
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No record found with the specified request ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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



        public string getReqTool()
        {
            return this.reqTool;
        }
        public string getRequestDescription()
        {
            return this.requestDescription;
        }
        public string getMechanicID()
        {
            return this.mechanicID;
        }
        public string getRequestStatus() {
            return this.requestStatus;
        }
    }
}
