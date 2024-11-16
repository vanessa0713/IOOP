using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Runtime.InteropServices;


namespace assignment_receptionist
{
    public partial class Form2 : Form
    {
        Customer customer = new Customer();
        Appointment appointment = new Appointment();
        Receptionist receptionist = new Receptionist();
        InventoryRequest inventoryRequest = new InventoryRequest();
        Mechanic mechanic = new Mechanic();
        Payment payment = new Payment();
        int recepID;
        public Form2(int receptionistID)
        {
            InitializeComponent();
            recepIDTxtBox.Text = receptionistID.ToString();
        }



        private void button15_Click(object sender, EventArgs e)
        {
            
        }

        private void button17_Click(object sender, EventArgs e)
        {
            GenerateBill form4 = new GenerateBill(recepID);

            // Hide Form4
            this.Hide();

            //Show Form4
            form4.Show();

        }

        private void button16_Click(object sender, EventArgs e)
        {
            //Create an instance of Form4
            SearchApp form5 = new SearchApp(recepID);

            // Hide Form2
            this.Hide();

            //Show Form5
            form5.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CarShop"].ToString();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Appointment"; // Modify query to suit your needs

                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Bind the data to the DataGridView
                    dataGridView1.DataSource = dt;
                }
            }
        }

       

        private void button22_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if ComboBox selection is made
                if (comboBox3.SelectedItem == null)
                {
                    MessageBox.Show("Please select a valid status from the ComboBox.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string status = comboBox3.SelectedItem.ToString();  // Get the status from ComboBox

                // Validate paymentID input
                if (string.IsNullOrEmpty(textBox15.Text) || !int.TryParse(textBox15.Text, out int paymentID))
                {
                    MessageBox.Show("Please enter a valid payment ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if payment object is initialized
                if (payment == null)
                {
                    MessageBox.Show("Payment object is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Call method to update only the payment status
                payment.updatePayment(status, paymentID);  // Assuming updatePaymentStatus is the method for updating status only
                                                           // Rebind and refresh the DataGridView displaying payments
                ReloadPaymentDataGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        // Helper method to reload and refresh payment data
        private void ReloadPaymentDataGrid()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CarShop"].ToString();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Payment";
                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Rebind and refresh
                    dataGridView7.DataSource = null;  // Clear old data
                    dataGridView7.DataSource = dt;   // Assign new data
                    dataGridView7.Refresh();
                    MessageBox.Show("Data grid refreshed successfully.");
                }
            }
        }

        private void RecpIDTxtBox_TextChanged(object sender, EventArgs e)
        {
            RecpIDTxtBox.ReadOnly = true;
        }


        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox17_Enter(object sender, EventArgs e)
        {

        }

        private void CusNLbl_Click(object sender, EventArgs e)
        {

        }


        private void button15_Click_1(object sender, EventArgs e)
        {

        }


        private void button21_Click_1(object sender, EventArgs e)
        {
            int customerID;

            // Check if the text box input is a valid integer
            if (int.TryParse(CusIDTxtBox1.Text, out customerID))
            {
                customer.searchAccount(customerID);
                CusIDTxtBox3.Text = customer.getCusID();
                CusNameTxtBox2.Text = customer.getCusName();
            }
            else
            {
                MessageBox.Show("Please enter a valid customer ID as an integer!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            int cusID;
            if (CusIDTxtBox1.Text == "")
            {
                MessageBox.Show("please search before delete");
            }
            else
            {
                if (!int.TryParse(CusIDTxtBox3.Text, out cusID))
                {
                    MessageBox.Show("Invalid request ID format.");
                    return;
                }
                string requestStatus = CusNameTxtBox2.Text;

                // Update the request status using the requestID
                try
                {
                    customer.deactivateAccount(cusID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating request status: " + ex.Message);
                }
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Boolean found = customer.VerifyUserName(CusIDTxtBox1.Text);
            if (found == false) {
                string passowrd = PasswordTxtBox2.Text;
                string cusName = CusNameTxtBox4.Text;
                string emailAddress = CusEmailTxtBox.Text;
                customer.addAccount(cusName, passowrd, emailAddress);
            }
            else
            {
                MessageBox.Show("name been used by other account, please re-enter");
                CusNameTxtBox4.Text = string.Empty;
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            int requestID;

            // Check if request ID is valid
            if (!int.TryParse(RequestIDTxtBox1.Text, out requestID))
            {
                MessageBox.Show("Invalid request ID format.");
                return;
            }

            string requestStatus = RequestStatusComboBox.Text; 

            // Update the request status using the requestID
            try
            {
                inventoryRequest.UpdateInventoryRequest(requestID, requestStatus);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating request status: " + ex.Message);
            }
        }

        private void groupBox26_Enter(object sender, EventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
        {
            int appID;

            // Check if appointment ID is valid
            if (!int.TryParse(AppIDTxtBox1.Text, out appID))
            {
                MessageBox.Show("Invalid appointment ID format.");
                return;
            }

            string appStatus = AppStatusComboBox.Text; 
            int mechanicID = int.Parse(MecIDTxtBox1.Text); 

            // Update the appointment with new status and mechanic ID
            try
            {
                appointment.UpdateAppointment(appID, appStatus, mechanicID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating appointment: " + ex.Message);
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            GenerateBill form4 = new GenerateBill(recepID);

            // Hide Form2
            this.Hide();

            //Show Form4
            form4.Show();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            SearchApp form5 = new SearchApp(recepID);

            // Hide Form2
            this.Hide();

            //Show Form5
            form5.Show();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if ComboBox selection is made
                if (PaymentStatusComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Please select a valid status from the ComboBox.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string status = PaymentStatusComboBox.SelectedItem.ToString();  

                // Validate paymentID input
                if (string.IsNullOrEmpty(PaymentIDTxtBox.Text) || !int.TryParse(PaymentIDTxtBox.Text, out int paymentID))
                {
                    MessageBox.Show("Please enter a valid payment ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (payment == null)
                {
                    MessageBox.Show("Payment object is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Call method to update only the payment status
                payment.updatePayment(status, paymentID); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            SearchPayment form6 = new SearchPayment(recepID);

            // Hide this form 
            this.Hide();

            //Show Form6
            form6.Show();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            int receptionistID;

            // Check if receptionist ID is valid
            if (!int.TryParse(recepIDTxtBox.Text, out receptionistID))
            {
                MessageBox.Show("Invalid receptionist ID format.");
                return;
            }
            Boolean found = customer.VerifyUserName(RecepNameTxtBox2.Text);
            if (found == false)
            {
                string recepEmail = EmailTxtButton.Text;       
                string recepPassword = PasswordTxtBox1.Text;    
                string recepName = RecepNameTxtBox2.Text;   


                // Update the receptionist details using the receptionist ID
                try
                {
                    receptionist.UpdateReceptionist(receptionistID, recepEmail, recepPassword, recepName); ;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating receptionist details: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("name been used , re-enetr another name");
            }
        }
        private void button33_Click(object sender, EventArgs e)
        {
            Login Login = new Login();
            this.Hide();
            Login.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                this.paymentTableAdapter1.Fill(this.paymentDataSet1.Payment);
            }
            catch (ConstraintException ex)
            {
                // Log the error or display a message with the exception details
                MessageBox.Show("Constraint exception: " + ex.Message);
            }
            // TODO: 这行代码将数据加载到表“carShopDataSet.Appointment”中。您可以根据需要移动或移除它。
            this.appointmentTableAdapter.Fill(this.carShopDataSet.Appointment);
            // TODO: 这行代码将数据加载到表“inventoryDataSet1.InventoryRequest”中。您可以根据需要移动或移除它。
            this.inventoryRequestTableAdapter1.Fill(this.inventoryDataSet1.InventoryRequest);

        }

        private void tabPage19_Click(object sender, EventArgs e)
        {

        }

        private void recepIDTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage23_Click(object sender, EventArgs e)
        {

        }
    }
}
