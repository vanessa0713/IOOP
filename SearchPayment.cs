using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace assignment_receptionist
{
    public partial class SearchPayment : Form
    {
        Payment payment = new Payment();
        int recepID;
        public SearchPayment(int receptionistID)
        {
            InitializeComponent();
            recepID = receptionistID;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate the paymentID
                int paymentID = int.Parse(PaymentIDTxtBox.Text);  // TextBox for payment ID

                // Ensure a valid payment status is selected
                string paymentStatus = PaymentComboBox.ToString();  // ComboBox for paymentStatus

                // Call method to update the payment status in the database
                payment.updatePayment(paymentStatus, paymentID);

            }
            catch (Exception ex)
            {
                // Show error message in case of any exceptions
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void SetPaymentDetailsToUI()
            {
                // Set all the payment details from the payment object to the UI controls
                PaymentIDTxtBox.Text = payment.getPaymentID();
                CusIDTxtBox1.Text = payment.getCustomerID();
                AmountTxtBox1.Text = payment.getAmount();
                DateTxtBox.Text = payment.getDate();
                TimeTxtBox.Text = payment.getTime();
                PaymentComboBox.Text = payment.getPayStatus();
                DeatailRichTextBox1.Text = payment.getPaymentDetail();
            }



        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(recepID);

            // Hide this form
            this.Hide();

            //Show Form4
            form2.Show(); ;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            PaymentIDTxtBox.ReadOnly = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            CusIDTxtBox1.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (PayIDRadioButton.Checked) // Search with paymentID only
            {
                int paymentID;

                // Check if payment ID is valid using TryParse
                if (string.IsNullOrEmpty(PayIDTextBox.Text) || !int.TryParse(PayIDTextBox.Text, out paymentID))
                {
                    MessageBox.Show("Please enter a valid payment ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                payment.searchPayUsePaymentID(paymentID);

                SetPaymentDetailsToUI();
            }
            else if (CusIDRadioButton.Checked)
            {
                int customerID;

                // Check if customer ID is valid
                if (string.IsNullOrEmpty(CusIDTxtBox.Text) || !int.TryParse(CusIDTxtBox.Text, out customerID))
                {
                    MessageBox.Show("Please enter a valid customer ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Call method to search using customerID
                payment.searcPayUseCustomerID(customerID);

                // Set values to text boxes and controls
                SetPaymentDetailsToUI();
            }
            else
            {
                // If no radio button is selected
                MessageBox.Show("Invalid search condition selected. Please try again.");
                PayIDRadioButton.Checked = false;
                CusIDRadioButton.Checked = false;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            AmountTxtBox1.ReadOnly = true;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            DateTxtBox.ReadOnly = true;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            TimeTxtBox.ReadOnly = true;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            DeatailRichTextBox1.ReadOnly = true;
        }

        private void SearchPayment_Load(object sender, EventArgs e)
        {

        }
    }
}
