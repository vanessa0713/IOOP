using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace assignment_receptionist
{
    class Payment
    {
        private int paymentID {  get; set; }
        private string paymentStatus { get; set; }
        private string date { get; set; }
        private string time { get; set; }
        private float amount { get; set; }
        private int customerID { get; set; }
        private string paymentDetail {  get; set; }

        public Payment()
        {

        }

        public void updatePayment(string paymentStatus, int paymentID)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CarShop"].ToString());

            try
            {
                con.Open();

                // Query to check if the paymentID exists
                string checkQuery = "SELECT COUNT(*) FROM Payment WHERE paymentID = @paymentID";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                {
                    checkCmd.Parameters.AddWithValue("@paymentID", paymentID);

                    int count = (int)checkCmd.ExecuteScalar();

                    // If count is 0, then paymentID does not exist
                    if (count == 0)
                    {
                        // Prompt user to re-enter paymentID if it doesn't exist
                        MessageBox.Show("The payment ID does not exist. Please re-enter a valid payment ID.", "Error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;  // Exit method if payment ID is invalid
                    }
                }

                string updateQuery = "UPDATE Payment SET paymentStatus = @paymentStatus WHERE paymentID = @paymentID";
                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@paymentStatus", paymentStatus);
                    cmd.Parameters.AddWithValue("@paymentID", paymentID);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Show success message
                        MessageBox.Show("Payment status updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No changes were made. Please verify the payment ID and status.", "No Update", MessageBoxButtons.OK, 
                            MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that may have occurred
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure the connection is closed in case of any exception
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public void addBill( float amount, string paymentStatus, int cusID, string paymentDetail)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CarShop"].ToString();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = "INSERT INTO Payment ( paymentStatus, amount, paymentDetail, customerID) " +
                                   "VALUES (@paymentStatus, @amount, @paymentDetail, @customerID)";

                    SqlCommand cmd = new SqlCommand(query, con);

                    // Add parameters and assign their values
                    cmd.Parameters.AddWithValue("@paymentStatus", paymentStatus);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@paymentDetail", paymentDetail);
                    cmd.Parameters.AddWithValue("@customerID", cusID);

                    // Execute the query (Insert the data)
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Check if rows were inserted
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Bill generated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to generate bill.");
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
        public void searcPayUseCustomerID(int customerID) // Use customerID to search
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CarShop"].ToString());
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Payment WHERE customerID = @customerID", con);
                cmd.Parameters.AddWithValue("@customerID", customerID);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count > 0)
                {
                    this.customerID = customerID;

                    SqlCommand cmd2 = new SqlCommand("SELECT paymentStatus FROM Payment WHERE customerID = @customerID", con);
                    cmd2.Parameters.AddWithValue("@customerID", customerID);
                    var payStatusResult = cmd2.ExecuteScalar();
                    if (payStatusResult != DBNull.Value)
                        this.paymentStatus = payStatusResult.ToString(); 

                    SqlCommand cmd3 = new SqlCommand("SELECT date FROM Payment WHERE customerID = @customerID", con);
                    cmd3.Parameters.AddWithValue("@customerID", customerID);
                    var dateResult = cmd3.ExecuteScalar();
                    if (dateResult != DBNull.Value)
                        this.date = dateResult.ToString();  

                    SqlCommand cmd4 = new SqlCommand("SELECT time FROM Payment WHERE customerID = @customerID", con);
                    cmd4.Parameters.AddWithValue("@customerID", customerID);
                    var timeResult = cmd4.ExecuteScalar();
                    if (timeResult != DBNull.Value)
                        this.time = timeResult.ToString(); 

                    SqlCommand cmd6 = new SqlCommand("SELECT paymentID FROM Payment WHERE customerID = @customerID", con);
                    cmd6.Parameters.AddWithValue("@customerID", customerID);
                    var serviceIDResult = cmd6.ExecuteScalar();
                    if (serviceIDResult != DBNull.Value)
                        this.paymentID = Convert.ToInt32(serviceIDResult); 

                    SqlCommand cmd7 = new SqlCommand("SELECT paymentDetail FROM Payment WHERE customerID = @customerID", con);
                    cmd7.Parameters.AddWithValue("@customerID", customerID);
                    var paymentDetailResult = cmd7.ExecuteScalar();
                    if (paymentDetailResult != DBNull.Value)
                        this.paymentDetail = paymentDetailResult.ToString();

                    SqlCommand cmd8 = new SqlCommand("SELECT paymentDetail FROM Payment WHERE paymentID = @paymentID", con);
                    cmd6.Parameters.AddWithValue("@customerID", customerID);
                    var paymentAmountResult = cmd8.ExecuteScalar();
                    if (paymentAmountResult != DBNull.Value)
                        this.amount = float.Parse(paymentAmountResult.ToString());

                    this.customerID = customerID;  // Assign the customerID as part of the search result
                }
                else
                {
                    MessageBox.Show("No appointment found for the given customerID.", "Appointment Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        public void searchPayUsePaymentID(int paymentID)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CarShop"].ToString());
            try
            {
                con.Open();

                // Check if any record exists with the given paymentID
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Payment WHERE paymentID = @paymentID", con);
                cmd.Parameters.AddWithValue("@paymentID", paymentID);

                // Execute the query and retrieve the count
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count > 0)
                {
                    SqlCommand cmd1 = new SqlCommand("SELECT customerID FROM Payment WHERE paymentID = @paymentID", con);
                    cmd1.Parameters.AddWithValue("@paymentID", paymentID);
                    var customerIDResult = cmd1.ExecuteScalar();
                    if (customerIDResult != DBNull.Value)
                        this.customerID = Convert.ToInt32(customerIDResult);

                    SqlCommand cmd2 = new SqlCommand("SELECT paymentStatus FROM Payment WHERE paymentID = @paymentID", con);
                    cmd2.Parameters.AddWithValue("@paymentID", paymentID);
                    var payStatusResult = cmd2.ExecuteScalar();
                    if (payStatusResult != DBNull.Value)
                        this.paymentStatus = payStatusResult.ToString();

                    SqlCommand cmd3 = new SqlCommand("SELECT date FROM Payment WHERE paymentID = @paymentID", con);
                    cmd3.Parameters.AddWithValue("@paymentID", paymentID);
                    var dateResult = cmd3.ExecuteScalar();
                    if (dateResult != DBNull.Value)
                        this.date = dateResult.ToString();

                    SqlCommand cmd4 = new SqlCommand("SELECT time FROM Payment WHERE paymentID = @paymentID", con);
                    cmd4.Parameters.AddWithValue("@paymentID", paymentID);
                    var timeResult = cmd4.ExecuteScalar();
                    if (timeResult != DBNull.Value)
                        this.time = timeResult.ToString();

                    SqlCommand cmd5 = new SqlCommand("SELECT paymentID FROM Payment WHERE paymentID = @paymentID", con);
                    cmd5.Parameters.AddWithValue("@paymentID", paymentID);
                    var paymentIDResult = cmd5.ExecuteScalar();
                    if (paymentIDResult != DBNull.Value)
                        this.paymentID = Convert.ToInt32(paymentIDResult);

                    SqlCommand cmd6 = new SqlCommand("SELECT paymentDetail FROM Payment WHERE paymentID = @paymentID", con);
                    cmd6.Parameters.AddWithValue("@paymentID", paymentID);
                    var paymentDetailResult = cmd6.ExecuteScalar();
                    if (paymentDetailResult != DBNull.Value)
                        this.paymentDetail = paymentDetailResult.ToString();

                    SqlCommand cmd7 = new SqlCommand("SELECT paymentDetail FROM Payment WHERE paymentID = @paymentID", con);
                    cmd6.Parameters.AddWithValue("@paymentID", paymentID);
                    var paymentAmountResult = cmd7.ExecuteScalar();
                    if (paymentAmountResult != DBNull.Value)
                        this.amount = float.Parse(paymentAmountResult.ToString());


                    this.paymentID = paymentID;
                }
                else
                {
                    MessageBox.Show("No payment found for the given paymentID.", "Payment Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        public string getPaymentID()
        {
            return (this.paymentID).ToString();

        }
        public string getCustomerID()
        {
            return (this.customerID).ToString();
        }
        public string getTime()
        {
            return this.time;
        }
        public string getDate()
        {
            return this.date;
        }
        public string getAmount()
        {
            return (this.amount).ToString();
        }
        public string getPaymentDetail()
        {
            return this.paymentDetail;
        }
        public string getPayStatus()
        {
            return this.paymentStatus;
        }

    }

}

