namespace banksystemUI
{
    partial class BaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.delect = new System.Windows.Forms.DataGridViewButtonColumn();
            this.change = new System.Windows.Forms.DataGridViewButtonColumn();
            this.BtnFind = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textID = new System.Windows.Forms.TextBox();
            this.textAccount = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnChange = new System.Windows.Forms.Button();
            this.BtbDel = new System.Windows.Forms.Button();
            this.Btnadd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboxLineNumber = new System.Windows.Forms.ComboBox();
            this.NumJumpPage = new System.Windows.Forms.NumericUpDown();
            this.btnGoTOPage = new System.Windows.Forms.Button();
            this.btnLastPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.txtEveryPage = new System.Windows.Forms.Label();
            this.LabelCurrentPage = new System.Windows.Forms.Label();
            this.btnPerviousPage = new System.Windows.Forms.Button();
            this.btnFirstPage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumJumpPage)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.delect,
            this.change});
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 134);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 100;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dataGridView1.RowTemplate.Height = 40;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.Size = new System.Drawing.Size(904, 352);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // delect
            // 
            this.delect.HeaderText = "删除";
            this.delect.MinimumWidth = 6;
            this.delect.Name = "delect";
            this.delect.ReadOnly = true;
            this.delect.Text = "删除本行";
            this.delect.UseColumnTextForButtonValue = true;
            // 
            // change
            // 
            this.change.HeaderText = "修改";
            this.change.MinimumWidth = 6;
            this.change.Name = "change";
            this.change.ReadOnly = true;
            this.change.Text = "修改本行";
            this.change.UseColumnTextForButtonValue = true;
            // 
            // BtnFind
            // 
            this.BtnFind.Image = global::banksystemUI.Properties.Resources.chaxun;
            this.BtnFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFind.Location = new System.Drawing.Point(596, 31);
            this.BtnFind.Name = "BtnFind";
            this.BtnFind.Size = new System.Drawing.Size(104, 37);
            this.BtnFind.TabIndex = 4;
            this.BtnFind.Text = "查找";
            this.BtnFind.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(19, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(206, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "账户";
            // 
            // textID
            // 
            this.textID.Location = new System.Drawing.Point(74, 103);
            this.textID.Name = "textID";
            this.textID.Size = new System.Drawing.Size(100, 25);
            this.textID.TabIndex = 8;
            // 
            // textAccount
            // 
            this.textAccount.Location = new System.Drawing.Point(266, 100);
            this.textAccount.Name = "textAccount";
            this.textAccount.Size = new System.Drawing.Size(100, 25);
            this.textAccount.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(904, 134);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户操作";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // BtnChange
            // 
            this.BtnChange.Image = global::banksystemUI.Properties.Resources.yonghu;
            this.BtnChange.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnChange.Location = new System.Drawing.Point(423, 31);
            this.BtnChange.Name = "BtnChange";
            this.BtnChange.Size = new System.Drawing.Size(91, 37);
            this.BtnChange.TabIndex = 3;
            this.BtnChange.Text = "修改";
            this.BtnChange.UseVisualStyleBackColor = true;
            // 
            // BtbDel
            // 
            this.BtbDel.Image = global::banksystemUI.Properties.Resources.quxiao;
            this.BtbDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtbDel.Location = new System.Drawing.Point(209, 31);
            this.BtbDel.Name = "BtbDel";
            this.BtbDel.Size = new System.Drawing.Size(97, 37);
            this.BtbDel.TabIndex = 2;
            this.BtbDel.Text = "删除";
            this.BtbDel.UseVisualStyleBackColor = true;
            // 
            // Btnadd
            // 
            this.Btnadd.Image = ((System.Drawing.Image)(resources.GetObject("Btnadd.Image")));
            this.Btnadd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btnadd.Location = new System.Drawing.Point(22, 31);
            this.Btnadd.Name = "Btnadd";
            this.Btnadd.Size = new System.Drawing.Size(92, 37);
            this.Btnadd.TabIndex = 1;
            this.Btnadd.Text = "增加";
            this.Btnadd.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboxLineNumber);
            this.panel1.Controls.Add(this.NumJumpPage);
            this.panel1.Controls.Add(this.btnGoTOPage);
            this.panel1.Controls.Add(this.btnLastPage);
            this.panel1.Controls.Add(this.btnNextPage);
            this.panel1.Controls.Add(this.txtEveryPage);
            this.panel1.Controls.Add(this.LabelCurrentPage);
            this.panel1.Controls.Add(this.btnPerviousPage);
            this.panel1.Controls.Add(this.btnFirstPage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 486);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(904, 62);
            this.panel1.TabIndex = 11;
            // 
            // comboxLineNumber
            // 
            this.comboxLineNumber.FormattingEnabled = true;
            this.comboxLineNumber.Items.AddRange(new object[] {
            "5",
            "10",
            "20",
            "30",
            "40"});
            this.comboxLineNumber.Location = new System.Drawing.Point(573, 20);
            this.comboxLineNumber.Name = "comboxLineNumber";
            this.comboxLineNumber.Size = new System.Drawing.Size(66, 23);
            this.comboxLineNumber.TabIndex = 4;
            this.comboxLineNumber.Text = "5";
            // 
            // NumJumpPage
            // 
            this.NumJumpPage.Location = new System.Drawing.Point(684, 19);
            this.NumJumpPage.Name = "NumJumpPage";
            this.NumJumpPage.Size = new System.Drawing.Size(92, 25);
            this.NumJumpPage.TabIndex = 3;
            // 
            // btnGoTOPage
            // 
            this.btnGoTOPage.Location = new System.Drawing.Point(795, 11);
            this.btnGoTOPage.Name = "btnGoTOPage";
            this.btnGoTOPage.Size = new System.Drawing.Size(97, 40);
            this.btnGoTOPage.TabIndex = 1;
            this.btnGoTOPage.Text = "跳转";
            this.btnGoTOPage.UseVisualStyleBackColor = true;
            // 
            // btnLastPage
            // 
            this.btnLastPage.Location = new System.Drawing.Point(372, 11);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(97, 40);
            this.btnLastPage.TabIndex = 1;
            this.btnLastPage.Text = "尾页";
            this.btnLastPage.UseVisualStyleBackColor = true;
            // 
            // btnNextPage
            // 
            this.btnNextPage.Location = new System.Drawing.Point(269, 11);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(97, 40);
            this.btnNextPage.TabIndex = 1;
            this.btnNextPage.Text = "下一页";
            this.btnNextPage.UseVisualStyleBackColor = true;
            // 
            // txtEveryPage
            // 
            this.txtEveryPage.AutoSize = true;
            this.txtEveryPage.Location = new System.Drawing.Point(500, 24);
            this.txtEveryPage.Name = "txtEveryPage";
            this.txtEveryPage.Size = new System.Drawing.Size(67, 15);
            this.txtEveryPage.TabIndex = 2;
            this.txtEveryPage.Text = "每页条数";
            // 
            // LabelCurrentPage
            // 
            this.LabelCurrentPage.AutoSize = true;
            this.LabelCurrentPage.Location = new System.Drawing.Point(215, 24);
            this.LabelCurrentPage.Name = "LabelCurrentPage";
            this.LabelCurrentPage.Size = new System.Drawing.Size(31, 15);
            this.LabelCurrentPage.TabIndex = 2;
            this.LabelCurrentPage.Text = "0/0";
            // 
            // btnPerviousPage
            // 
            this.btnPerviousPage.Location = new System.Drawing.Point(112, 11);
            this.btnPerviousPage.Name = "btnPerviousPage";
            this.btnPerviousPage.Size = new System.Drawing.Size(97, 40);
            this.btnPerviousPage.TabIndex = 1;
            this.btnPerviousPage.Text = "上一页";
            this.btnPerviousPage.UseVisualStyleBackColor = true;
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.Location = new System.Drawing.Point(12, 12);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Size = new System.Drawing.Size(85, 39);
            this.btnFirstPage.TabIndex = 0;
            this.btnFirstPage.Text = "首页";
            this.btnFirstPage.UseVisualStyleBackColor = true;
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 548);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textAccount);
            this.Controls.Add(this.textID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnFind);
            this.Controls.Add(this.BtnChange);
            this.Controls.Add(this.BtbDel);
            this.Controls.Add(this.Btnadd);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "BaseForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BaseForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumJumpPage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Button Btnadd;
        protected System.Windows.Forms.Button BtbDel;
        protected System.Windows.Forms.Button BtnChange;
        protected System.Windows.Forms.Button BtnFind;
        protected System.Windows.Forms.TextBox textID;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textAccount;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btnNextPage;
        public System.Windows.Forms.Label LabelCurrentPage;
        public System.Windows.Forms.Button btnPerviousPage;
        public System.Windows.Forms.Button btnFirstPage;
        public System.Windows.Forms.ComboBox comboxLineNumber;
        public System.Windows.Forms.NumericUpDown NumJumpPage;
        public System.Windows.Forms.Button btnGoTOPage;
        public System.Windows.Forms.Button btnLastPage;
        public System.Windows.Forms.Label txtEveryPage;
        public System.Windows.Forms.DataGridViewButtonColumn delect;
        public System.Windows.Forms.DataGridViewButtonColumn change;
    }
}