namespace assignment_receptionist
{
    partial class Login
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pleaseLoginLabel = new System.Windows.Forms.Label();
            this.userIDlbl = new System.Windows.Forms.Label();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordlbl = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pleaseLoginLabel
            // 
            this.pleaseLoginLabel.AutoSize = true;
            this.pleaseLoginLabel.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pleaseLoginLabel.Location = new System.Drawing.Point(232, 95);
            this.pleaseLoginLabel.Name = "pleaseLoginLabel";
            this.pleaseLoginLabel.Size = new System.Drawing.Size(376, 62);
            this.pleaseLoginLabel.TabIndex = 0;
            this.pleaseLoginLabel.Text = "PLEASE LOGIN ";
            this.pleaseLoginLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // userIDlbl
            // 
            this.userIDlbl.AutoSize = true;
            this.userIDlbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.userIDlbl.Location = new System.Drawing.Point(239, 212);
            this.userIDlbl.Name = "userIDlbl";
            this.userIDlbl.Size = new System.Drawing.Size(154, 24);
            this.userIDlbl.TabIndex = 1;
            this.userIDlbl.Text = "User Name : ";
            this.userIDlbl.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(481, 201);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(127, 35);
            this.userNameTextBox.TabIndex = 2;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(481, 312);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(127, 35);
            this.passwordTextBox.TabIndex = 3;
            // 
            // passwordlbl
            // 
            this.passwordlbl.AutoSize = true;
            this.passwordlbl.Location = new System.Drawing.Point(239, 312);
            this.passwordlbl.Name = "passwordlbl";
            this.passwordlbl.Size = new System.Drawing.Size(142, 24);
            this.passwordlbl.TabIndex = 4;
            this.passwordlbl.Text = "Password : ";
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(359, 408);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(121, 58);
            this.loginButton.TabIndex = 5;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 543);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.passwordlbl);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.userNameTextBox);
            this.Controls.Add(this.userIDlbl);
            this.Controls.Add(this.pleaseLoginLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pleaseLoginLabel;
        private System.Windows.Forms.Label userIDlbl;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label passwordlbl;
        private System.Windows.Forms.Button loginButton;
    }
}

