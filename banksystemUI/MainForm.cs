using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace banksystemUI
{
    public partial class MainForm : Form
    {
        bool isSuperAdmin;
        public AdressForm adressForm;
        public UserForm userForm;
        public AdminForm adminForm;
        public static MainForm current_mainForm;


        public static void ToNewMainForm(bool isSuperAdmin)
        {

            current_mainForm = new MainForm(isSuperAdmin);
            current_mainForm.ShowDialog();
        }
        public MainForm(bool isSuperAdmin)
        {
            InitializeComponent();
            LabelTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.isSuperAdmin = isSuperAdmin;

            if (isSuperAdmin)
            {
                this.Text = $"{SuperDAL.CurrentSuperAdmin}";
                adminForm = new AdminForm();
                adminForm.MdiParent = this;


            }
            else
            {
                this.Text = $"{AdminDAL.CurrentAdmin}";
            }
            管理员GToolStripMenuItem.Visible = isSuperAdmin;
            userForm = new UserForm();
            userForm.MdiParent = this;
            adressForm = new AdressForm();
            adressForm.MdiParent = this;

        }

        private void 管理员GToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(adminForm);
        }

        private void 用户UToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(userForm);
        }

        private void 地址ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(adressForm);

        }
        private void OpenForm(Form form)
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Visible = false;
                child.WindowState = FormWindowState.Minimized;
            }
            form.Visible = true;
            form.WindowState = FormWindowState.Maximized;
            foreach (Form child in current_mainForm.MdiChildren)
            {
                if (child.Visible)
                {
                    if (child is UserForm)
                    {
                        userForm.dataGridView1.DataSource = UserDAL.GetAllUser();
                    }
                    else if (child is AdressForm)
                    {
                        var addressList = AdressDAL.GetAllAdress();
                        adressForm.dataGridView1.BringToFront();
                        //设置表头高度以适应多行表头
                        adressForm.dataGridView1.DataSource = addressList;
                    }
                    else if (child is AdminForm)
                    {

                        adminForm.dataGridView1.DataSource = AdminDAL.GetAllAdmin();


                    }
                }
            }
        }

        private void 退出当前账号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定要退出当前账号吗？", "退出", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                this.Close();
                LoginFrom loginForm = new LoginFrom();
                loginForm.ShowDialog();
                this.Close();
            }
        }

        private void 推出应用程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定要退出应用程序吗？", "退出应用程序", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LabelTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            adminForm.Btnadd_Click(sender, e);
            OpenForm(adminForm);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            userForm.Btnadd_Click(sender, e);
            OpenForm(userForm);

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            adressForm.BtnChange_Click(sender, e);
            OpenForm(adressForm);
        }



    }

}
