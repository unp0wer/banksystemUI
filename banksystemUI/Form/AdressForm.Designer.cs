namespace banksystemUI
{
    partial class AdressForm
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
            this.TxtAdress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Size = new System.Drawing.Size(896, 159);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(214, 182);
            this.label2.Size = new System.Drawing.Size(0, 18);
            this.label2.Text = "";
            // 
            // textAccount
            // 
            this.textAccount.Location = new System.Drawing.Point(778, 109);
            this.textAccount.Size = new System.Drawing.Size(10, 25);
            this.textAccount.Visible = false;
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
            // TxtAdress
            // 
            this.TxtAdress.Location = new System.Drawing.Point(600, 100);
            this.TxtAdress.Name = "TxtAdress";
            this.TxtAdress.Size = new System.Drawing.Size(100, 25);
            this.TxtAdress.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(550, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 18);
            this.label3.TabIndex = 13;
            this.label3.Text = "地址";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(18, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "ID";
            // 
            // AdressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 610);
            this.Controls.Add(this.TxtAdress);
            this.Controls.Add(this.label3);
            this.Name = "AdressForm";
            this.Text = "地址";
            this.Load += new System.EventHandler(this.AdressForm_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.textAccount, 0);
            this.Controls.SetChildIndex(this.Btnadd, 0);
            this.Controls.SetChildIndex(this.BtbDel, 0);
            this.Controls.SetChildIndex(this.BtnChange, 0);
            this.Controls.SetChildIndex(this.BtnFind, 0);
            this.Controls.SetChildIndex(this.textID, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.TxtAdress, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumJumpPage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtAdress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}