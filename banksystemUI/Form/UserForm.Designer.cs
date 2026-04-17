namespace banksystemUI
{
    partial class UserForm
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
            this.StarTime = new System.Windows.Forms.DateTimePicker();
            this.EndTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.Clear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumJumpPage)).BeginInit();
            this.SuspendLayout();
            // 
            // Btnadd
            // 
            this.Btnadd.Click += new System.EventHandler(this.Btnadd_Click);
            // 
            // BtbDel
            // 
            this.BtbDel.Click += new System.EventHandler(this.BtbDel_Click);
            // 
            // BtnChange
            // 
            this.BtnChange.Click += new System.EventHandler(this.BtnChange_Click);
            // 
            // BtnFind
            // 
            this.BtnFind.Click += new System.EventHandler(this.BtnFind_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Clear);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.EndTime);
            this.groupBox1.Controls.Add(this.StarTime);
            this.groupBox1.Size = new System.Drawing.Size(908, 134);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // btnPerviousPage
            // 
            this.btnPerviousPage.Click += new System.EventHandler(this.btnPerviousPage_Click);
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.Click += new System.EventHandler(this.btnFirstPage_Click);
            // 
            // comboxLineNumber
            // 
            this.comboxLineNumber.SelectedIndexChanged += new System.EventHandler(this.comboxLineNumber_SelectedIndexChanged);
            // 
            // btnGoTOPage
            // 
            this.btnGoTOPage.Click += new System.EventHandler(this.btnGoTOPage_Click);
            // 
            // btnLastPage
            // 
            this.btnLastPage.Click += new System.EventHandler(this.btnLastPage_Click);
            // 
            // StarTime
            // 
            this.StarTime.CustomFormat = " ";
            this.StarTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.StarTime.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.StarTime.Location = new System.Drawing.Point(383, 101);
            this.StarTime.Name = "StarTime";
            this.StarTime.Size = new System.Drawing.Size(154, 25);
            this.StarTime.TabIndex = 11;
            this.StarTime.ValueChanged += new System.EventHandler(this.StarTime_ValueChanged);
            // 
            // EndTime
            // 
            this.EndTime.CustomFormat = " ";
            this.EndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EndTime.Location = new System.Drawing.Point(571, 101);
            this.EndTime.Name = "EndTime";
            this.EndTime.Size = new System.Drawing.Size(133, 25);
            this.EndTime.TabIndex = 12;
            this.EndTime.ValueChanged += new System.EventHandler(this.EndTime_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(543, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "至";
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(711, 100);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(83, 34);
            this.Clear.TabIndex = 14;
            this.Clear.Text = "清除日期";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 549);
            this.Name = "UserForm";
            this.Text = "用户";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumJumpPage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker StarTime;
        private System.Windows.Forms.DateTimePicker EndTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Clear;
    }
}