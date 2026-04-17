namespace banksystemUI
{
    partial class LoginFrom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginFrom));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.loginBtn = new System.Windows.Forms.Button();
            this.account = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.superPower = new System.Windows.Forms.CheckBox();
            this.loginState = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(259, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "账号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(259, 300);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "密码";
            // 
            // loginBtn
            // 
            this.loginBtn.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.loginBtn.Location = new System.Drawing.Point(342, 378);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(199, 56);
            this.loginBtn.TabIndex = 3;
            this.loginBtn.Text = "登录";
            this.loginBtn.UseVisualStyleBackColor = false;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // account
            // 
            this.account.Location = new System.Drawing.Point(333, 234);
            this.account.Name = "account";
            this.account.Size = new System.Drawing.Size(208, 25);
            this.account.TabIndex = 0;
            this.account.Text = "superadmin";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(333, 290);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(208, 25);
            this.password.TabIndex = 1;
            this.password.Text = "superadmin";
            this.password.TextChanged += new System.EventHandler(this.password_TextChanged);
            // 
            // superPower
            // 
            this.superPower.AutoSize = true;
            this.superPower.Checked = true;
            this.superPower.CheckState = System.Windows.Forms.CheckState.Checked;
            this.superPower.ForeColor = System.Drawing.Color.Red;
            this.superPower.Location = new System.Drawing.Point(262, 344);
            this.superPower.Name = "superPower";
            this.superPower.Size = new System.Drawing.Size(194, 19);
            this.superPower.TabIndex = 2;
            this.superPower.Text = "是否使用超级管理员账号";
            this.superPower.UseVisualStyleBackColor = true;
            // 
            // loginState
            // 
            this.loginState.AutoSize = true;
            this.loginState.ForeColor = System.Drawing.Color.Red;
            this.loginState.Location = new System.Drawing.Point(575, 300);
            this.loginState.Name = "loginState";
            this.loginState.Size = new System.Drawing.Size(0, 15);
            this.loginState.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::banksystemUI.Properties.Resources.dangyang;
            this.pictureBox1.Location = new System.Drawing.Point(300, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(255, 180);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // LoginFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 491);
            this.Controls.Add(this.loginState);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.superPower);
            this.Controls.Add(this.password);
            this.Controls.Add(this.account);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.TextBox account;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.CheckBox superPower;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label loginState;
    }
}