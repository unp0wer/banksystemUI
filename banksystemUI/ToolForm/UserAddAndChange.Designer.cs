namespace banksystemUI.ToolForm
{
    partial class UserAddAndChange
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnAddOrChange = new System.Windows.Forms.Button();
            this.Password = new System.Windows.Forms.TextBox();
            this.Account = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "密码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "账号";
            // 
            // BtnAddOrChange
            // 
            this.BtnAddOrChange.Location = new System.Drawing.Point(163, 270);
            this.BtnAddOrChange.Name = "BtnAddOrChange";
            this.BtnAddOrChange.Size = new System.Drawing.Size(127, 57);
            this.BtnAddOrChange.TabIndex = 7;
            this.BtnAddOrChange.Text = "button1";
            this.BtnAddOrChange.UseVisualStyleBackColor = true;
            this.BtnAddOrChange.Click += new System.EventHandler(this.BtnAddOrChange_Click);
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(153, 154);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(162, 25);
            this.Password.TabIndex = 6;
            // 
            // Account
            // 
            this.Account.Location = new System.Drawing.Point(153, 96);
            this.Account.Name = "Account";
            this.Account.Size = new System.Drawing.Size(162, 25);
            this.Account.TabIndex = 5;
            // 
            // UserAddAndChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 397);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnAddOrChange);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Account);
            this.Name = "UserAddAndChange";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button BtnAddOrChange;
        public System.Windows.Forms.TextBox Password;
        public System.Windows.Forms.TextBox Account;
    }
}