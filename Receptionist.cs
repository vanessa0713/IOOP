using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;



namespace assignment_receptionist
{
    class Receptionist
    {
        private int receptionistID { get; set; }
        private string recepName { get; set; }
        private string recepPassword { get; set; }

        private string recepEmailAddress { get; set; }
        private string recepAccountStatus { get; set; }
        private string serviceID { get; set; }
        public Receptionist()
        {
        }


        public void UpdateReceptionist(int receptionistID, string recepEmail, string recepPassword, string recepName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CarShop"].ToString();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Receptionist SET recepEmail = @recepEmail, recepPassword = @recepPassword, recepName = " +
                    "@recepName WHERE receptionistID = @receptionistID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@recepEmail", recepEmail);
                    cmd.Parameters.AddWithValue("@recepPassword", recepPassword);
                    cmd.Parameters.AddWithValue("@recepName", recepName);
                    cmd.Parameters.AddWithValue("@receptionistID", receptionistID);

                    try
                    {
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Receptionist record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No record found with the specified receptionist ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (SqlException ex)
                    {
                        // Log detailed SQL exception information
                        MessageBox.Show("SQL Error: " + ex.Message + "\nError Code: " + ex.ErrorCode, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        // Log other exceptions
                        MessageBox.Show("General Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
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
                    string query = "SELECT COUNT(recepName) FROM Receptionist WHERE recepName = @receptName";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@receptName", userName);

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
        public string getReceptionistID()
        {
            return (this.receptionistID).ToString();
        }
        public string getRecepPassword()
        {
            return this.recepPassword;
        }
        public string getReceptionsitName()
        {
            return recepName;
        }
        public void setReceptionistID(int receptionist)
        {
            this.receptionistID = receptionist;
        }
    }
}
