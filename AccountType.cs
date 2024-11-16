using assignment_receptionist;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace assignment_receptionist
{
    internal class AccountType
    {
        private string accountType { get; set; }
        public AccountType() { }
        public string IdentifyAccountAndLogin(string userName, string password)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CarShop"].ToString();
            string found = "not found";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Define parameterized queries for each role table
                string[] queries = {
            "SELECT COUNT(*) FROM Receptionist WHERE recepName = @userName AND recepPassword = @password",
            "SELECT COUNT(*) FROM Admin WHERE adminName = @userName AND adminPassword = @password",
            "SELECT COUNT(*) FROM Customer WHERE cusName = @userName AND cusPassword = @password",
            "SELECT COUNT(*) FROM Mechanic WHERE mecName = @userName AND mecPassword = @password"
        };

                string[] roles = { "Receptionist", "Admin", "Customer", "Mechanic" };

                for (int i = 0; i < queries.Length; i++)
                {
                    using (SqlCommand cmd = new SqlCommand(queries[i], con))
                    {
                        cmd.Parameters.AddWithValue("@userName", userName);
                        cmd.Parameters.AddWithValue("@password", password);

                        int count = (int)cmd.ExecuteScalar();
                        if (count > 0)
                        {
                            this.accountType = roles[i];
                            found = CheckAccountStatus(con, roles[i], userName, password);
                            break;
                        }
                    }
                }
            }
            return found;
        }

        // Helper method to check account status
        private string CheckAccountStatus(SqlConnection con, string role, string userName, string password)
        {
            string statusQuery = string.Empty;

            if (role == "Receptionist")
                statusQuery = "SELECT recepAccountStatus FROM Receptionist WHERE recepName = @userName AND recepPassword = @password";
            else if (role == "Admin")
                statusQuery = "SELECT adminAccountStatus FROM Admin WHERE adminName = @userName AND adminPassword = @password";
            else if (role == "Customer")
                statusQuery = "SELECT cusAccountStatus FROM Customer WHERE cusName = @userName AND cusPassword = @password";
            else if (role == "Mechanic")
                statusQuery = "SELECT mecAccountStatus FROM Mechanic WHERE mecName = @userName AND mecPassword = @password";

            using (SqlCommand statusCmd = new SqlCommand(statusQuery, con))
            {
                statusCmd.Parameters.AddWithValue("@userName", userName);
                statusCmd.Parameters.AddWithValue("@password", password);

                string accountStatus = statusCmd.ExecuteScalar()?.ToString();

                if (accountStatus == "In-Active")
                {
                    return "blocked";
                }
                else
                {
                    return "found";
                }

            }
        }
        public int VerifyUserID(string userName, string password, int accountType)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CarShop"].ToString();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = string.Empty;

                // Select the query based on account type
                if (accountType == 2)
                    query = "SELECT receptionistID FROM Receptionist WHERE recepName = @userName AND recepPassword = @password";
                else if (accountType == 1)
                    query = "SELECT adminID FROM Admin WHERE adminName = @userName AND adminPassword = @password";
                else if (accountType == 3)
                    query = "SELECT customerID FROM Customer WHERE cusName = @userName AND cusPassword = @password";
                else if (accountType == 4)
                    query = "SELECT mechanicID FROM Mechanic WHERE mecName = @userName AND mecPassword = @password";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Add parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@userName", userName);
                    cmd.Parameters.AddWithValue("@password", password);

                    try
                    {
                        con.Open(); // Open the connection to the database

                        // Execute the query and retrieve the result (first column)
                        var result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            // Cast the result to int? (nullable int)
                            return (int)result;
                        }
                        else
                        {
                            // Return null if no record is found
                            return 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any database errors (e.g., connection issues)
                        throw new Exception("Error verifying user: " + ex.Message);
                    }
                }
            }
        }

        public string getAccountType()
        {
            return accountType;
        }

    }
}
