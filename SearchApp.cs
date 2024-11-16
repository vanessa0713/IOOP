using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;


namespace assignment_receptionist
{
    public partial class SearchApp : Form
    {
        Appointment appointment = new Appointment();
        int recepID;
        public SearchApp(int receptionistID)
        {
            InitializeComponent();
            recepID = receptionistID;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(recepID);

            // Hide Form4
            this.Hide();

            //Show Form2
            form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (VehicleIDRadioButton.Checked)//search with vehicle id only
            {
                appointment.searchAppUseVehicleID(VehicleTxtBox.Text);
                SetAppointDetailsToUI();

            }
            else if (CusIDRadioButton.Checked)//search with customerID
            {
                int cusID = int.Parse(CusIDTxtBox.Text);
                appointment.searchAppUseCustomerID(cusID);
                SetAppointDetailsToUI();
            }
            else if(AppIDRadioButton.Checked)//search using appointment id
            {
                int appID = int.Parse(AppTxtBox.Text );
                appointment.searchAppUseAppointmentID(appID);
                SetAppointDetailsToUI();
            }
            else
            {
                MessageBox.Show("Invalid search condition seleted please try again");
                VehicleIDRadioButton.Checked = false;
                CusIDRadioButton.Checked = false;
                AppIDRadioButton.Checked = false;  
            }

        }
        private void SetAppointDetailsToUI()
        {
            // Set all the payment details from the payment object to the UI controls
            AppIDTxtBox1.Text = appointment.getAppointmentID();
            CusIDTxtBox1.Text = appointment.getCustomerID();
            VehicleTxtBox1.Text = appointment.getVehicleID();
            ServiceIDTxt1.Text = appointment.getServiceID();
            MechanicIDTxtBox1.Text = appointment.getMechanicID();
            AppStatusComboBox.Text = appointment.getAppiontmentStatus();
            AppDateTxtBox1.Text = appointment.getAppDate();
            AppTimeTxtBox1.Text = appointment.getAppTime();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int appointmentID = int.Parse(AppIDTxtBox1.Text); 
                string appStatus = AppStatusComboBox.SelectedItem.ToString(); 
                int mechanicID = int.Parse(MechanicIDTxtBox1.Text); 

                // Call method to update the database
                appointment.UpdateAppointment(appointmentID, appStatus, mechanicID);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            AppIDTxtBox1.ReadOnly = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            CusIDTxtBox1.ReadOnly = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            VehicleTxtBox1.ReadOnly = true;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            ServiceIDTxt1.ReadOnly = true;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            AppDateTxtBox1.ReadOnly = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            AppTimeTxtBox1.ReadOnly = true;
        }

        private void SearchApp_Load(object sender, EventArgs e)
        {

        }
    }
}
