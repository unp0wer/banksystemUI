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
            this.BtnFind = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnChange = new System.Windows.Forms.Button();
            this.BtbDel = new System.Windows.Forms.Button();
            this.Btnadd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 134);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 100;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dataGridView1.RowTemplate.Height = 40;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.Size = new System.Drawing.Size(904, 414);
            this.dataGridView1.TabIndex = 0;
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(74, 103);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 25);
            this.textBox1.TabIndex = 8;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(266, 100);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 25);
            this.textBox2.TabIndex = 9;
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
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 548);
            this.ControlBox = false;
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnFind);
            this.Controls.Add(this.BtnChange);
            this.Controls.Add(this.BtbDel);
            this.Controls.Add(this.Btnadd);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "BaseForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BaseForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Button Btnadd;
        protected System.Windows.Forms.Button BtbDel;
        protected System.Windows.Forms.Button BtnChange;
        protected System.Windows.Forms.Button BtnFind;
        protected System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.DataGridView dataGridView1;
    }
}