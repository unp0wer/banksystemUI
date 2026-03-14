namespace banksystemUI
{
    partial class AdminAddAndChange
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
            this.Account = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.BtnAddOrChange = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Account
            // 
            this.Account.Location = new System.Drawing.Point(169, 121);
            this.Account.Name = "Account";
            this.Account.Size = new System.Drawing.Size(162, 25);
            this.Account.TabIndex = 0;
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(169, 179);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(162, 25);
            this.Password.TabIndex = 1;
            // 
            // BtnAddOrChange
            // 
            this.BtnAddOrChange.Location = new System.Drawing.Point(179, 295);
            this.BtnAddOrChange.Name = "BtnAddOrChange";
            this.BtnAddOrChange.Size = new System.Drawing.Size(127, 57);
            this.BtnAddOrChange.TabIndex = 2;
            this.BtnAddOrChange.Text = "button1";
            this.BtnAddOrChange.UseVisualStyleBackColor = true;
            this.BtnAddOrChange.Click += new System.EventHandler(this.BtnAddOrChange_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "账号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "密码";
            // 
            // AddAndChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 455);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnAddOrChange);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Account);
            this.Name = "AddAndChange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox Account;
        public System.Windows.Forms.TextBox Password;
        public System.Windows.Forms.Button BtnAddOrChange;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
    }
}