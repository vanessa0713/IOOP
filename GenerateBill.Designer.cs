namespace assignment_receptionist
{
    partial class GenerateBill
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CusIDTxtBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.DetailRichTextBox = new System.Windows.Forms.RichTextBox();
            this.payemnetStatusComboBox1 = new System.Windows.Forms.ComboBox();
            this.AmountTxtBox = new System.Windows.Forms.TextBox();
            this.DateTxtBox = new System.Windows.Forms.TextBox();
            this.TimeTxtBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GoBackButton = new System.Windows.Forms.Button();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CusIDTxtBox
            // 
            this.CusIDTxtBox.Location = new System.Drawing.Point(317, 427);
            this.CusIDTxtBox.Name = "CusIDTxtBox";
            this.CusIDTxtBox.Size = new System.Drawing.Size(151, 35);
            this.CusIDTxtBox.TabIndex = 46;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 439);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(166, 24);
            this.label8.TabIndex = 45;
            this.label8.Text = "Customer ID :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(499, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(202, 24);
            this.label7.TabIndex = 44;
            this.label7.Text = "Payment detail :";
            // 
            // DetailRichTextBox
            // 
            this.DetailRichTextBox.Location = new System.Drawing.Point(707, 147);
            this.DetailRichTextBox.Name = "DetailRichTextBox";
            this.DetailRichTextBox.Size = new System.Drawing.Size(227, 292);
            this.DetailRichTextBox.TabIndex = 43;
            this.DetailRichTextBox.Text = "";
            // 
            // payemnetStatusComboBox1
            // 
            this.payemnetStatusComboBox1.FormattingEnabled = true;
            this.payemnetStatusComboBox1.Items.AddRange(new object[] {
            "Scheduled"});
            this.payemnetStatusComboBox1.Location = new System.Drawing.Point(317, 158);
            this.payemnetStatusComboBox1.Name = "payemnetStatusComboBox1";
            this.payemnetStatusComboBox1.Size = new System.Drawing.Size(151, 32);
            this.payemnetStatusComboBox1.TabIndex = 40;
            // 
            // AmountTxtBox
            // 
            this.AmountTxtBox.Location = new System.Drawing.Point(317, 353);
            this.AmountTxtBox.Name = "AmountTxtBox";
            this.AmountTxtBox.Size = new System.Drawing.Size(151, 35);
            this.AmountTxtBox.TabIndex = 39;
            // 
            // DateTxtBox
            // 
            this.DateTxtBox.Location = new System.Drawing.Point(317, 286);
            this.DateTxtBox.Name = "DateTxtBox";
            this.DateTxtBox.Size = new System.Drawing.Size(151, 35);
            this.DateTxtBox.TabIndex = 38;
            // 
            // TimeTxtBox
            // 
            this.TimeTxtBox.Location = new System.Drawing.Point(317, 221);
            this.TimeTxtBox.Name = "TimeTxtBox";
            this.TimeTxtBox.Size = new System.Drawing.Size(151, 35);
            this.TimeTxtBox.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(250, 24);
            this.label5.TabIndex = 36;
            this.label5.Text = "Bill Genrated Date :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 364);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 24);
            this.label4.TabIndex = 35;
            this.label4.Text = "Payment Amount :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(262, 24);
            this.label3.TabIndex = 34;
            this.label3.Text = "Bill generated Time :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 24);
            this.label2.TabIndex = 33;
            this.label2.Text = "Payment Status :";
            // 
            // GoBackButton
            // 
            this.GoBackButton.Location = new System.Drawing.Point(15, 593);
            this.GoBackButton.Name = "GoBackButton";
            this.GoBackButton.Size = new System.Drawing.Size(182, 51);
            this.GoBackButton.TabIndex = 32;
            this.GoBackButton.Text = "Go Back";
            this.GoBackButton.UseVisualStyleBackColor = true;
            this.GoBackButton.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // GenerateButton
            // 
            this.GenerateButton.Location = new System.Drawing.Point(753, 593);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(219, 51);
            this.GenerateButton.TabIndex = 31;
            this.GenerateButton.Text = "Generate";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(341, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 43);
            this.label1.TabIndex = 30;
            this.label1.Text = "Bill Detail";
            // 
            // GenerateBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 689);
            this.Controls.Add(this.CusIDTxtBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.DetailRichTextBox);
            this.Controls.Add(this.payemnetStatusComboBox1);
            this.Controls.Add(this.AmountTxtBox);
            this.Controls.Add(this.DateTxtBox);
            this.Controls.Add(this.TimeTxtBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GoBackButton);
            this.Controls.Add(this.GenerateButton);
            this.Controls.Add(this.label1);
            this.Name = "GenerateBill";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CusIDTxtBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox DetailRichTextBox;
        private System.Windows.Forms.ComboBox payemnetStatusComboBox1;
        private System.Windows.Forms.TextBox AmountTxtBox;
        private System.Windows.Forms.TextBox DateTxtBox;
        private System.Windows.Forms.TextBox TimeTxtBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button GoBackButton;
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.Label label1;
    }
}