using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace assignment_receptionist
{
    public partial class GenerateBill : Form
    {
        Payment payment = new Payment();
        int recepID;
        public GenerateBill(int receptionistID)
        {
            InitializeComponent();
            recepID = receptionistID;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int customerID;
            float amount;

            // Check for invalid inputs by verifying that parsing is successful
            if (!int.TryParse(CusIDTxtBox.Text, out customerID) ||
                !float.TryParse(AmountTxtBox.Text, out amount))
            {
                MessageBox.Show("Invalid format, please check the input values.");
                return;
            }

            string paymentDetail = DetailRichTextBox.Text;
            string paymentStatus = payemnetStatusComboBox1.Text;

            // Add bill details into the table
            try
            {
                payment.addBill( amount, paymentStatus, customerID, paymentDetail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating payment details: " + ex.Message);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(recepID);

            // Hide Form4
            this.Hide();

            //Show Form2
            form2.Show();
        }
    }
}
