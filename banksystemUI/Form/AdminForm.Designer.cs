namespace banksystemUI
{
    partial class AdminForm
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
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "AdminForm";
            this.Text = "管理员";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}