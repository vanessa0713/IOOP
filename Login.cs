using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment_receptionist
{
    public partial class Login : Form
    {
        Receptionist receptionist = new Receptionist();
        AccountType user = new AccountType();
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string found;
            int userID = 0;
            if (userNameTextBox.Text != null && passwordTextBox.Text != null) {
                found = user.IdentifyAccountAndLogin(userNameTextBox.Text, passwordTextBox.Text);
                if (found =="found" )
                {
                    if(user.getAccountType() == "Receptionist") {
                        userID = user.VerifyUserID(userNameTextBox.Text, passwordTextBox.Text,2);
                        MessageBox.Show("login as Receptionist sucessfully !");
                        // Hide Form1
                        this.Hide();
                        // Create and show Form2
                        Form2 form2 = new Form2(userID);
                        form2.Show();
                    }
                    else if(user.getAccountType() == "Admin")
                    {
                        userID = user.VerifyUserID(userNameTextBox.Text, passwordTextBox.Text, 1);
                        MessageBox.Show("login as admin sucessfully !");
                    }
                    else if(user.getAccountType() == "Customer")
                    {
                        userID = user.VerifyUserID(userNameTextBox.Text, passwordTextBox.Text, 3);
                        MessageBox.Show("login as customer sucessfully !");
                    }
                    else  //login as Mechanic
                    {
                        userID = user.VerifyUserID(userNameTextBox.Text, passwordTextBox.Text, 4);
                        MessageBox.Show("login as mechanic sucessfully !");
                    }
                  
                }
                else if (found == "not found")
                {
                    MessageBox.Show("invalid password or userID,please try again!");
                    userNameTextBox.Clear();
                    passwordTextBox.Clear();
                }
                else
                {
                    MessageBox.Show("account has been deleted can not login!");
                    userNameTextBox.Clear();
                    passwordTextBox.Clear();
                }
            }
            else
            {
                MessageBox.Show("please input username and password first!");
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
