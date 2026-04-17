using System;
using System.Windows.Forms;

namespace banksystemUI
{
    public partial class MainForm : Form
    {
        private readonly bool isSuperAdmin;
        public readonly AdressForm adressForm;
        public readonly UserForm userForm;
        public readonly AdminForm adminForm;
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
            current_mainForm = this;

            // 初始化子窗体
            userForm = new UserForm();
            userForm.MdiParent = this;
            adressForm = new AdressForm();
            adressForm.MdiParent = this;

            // 超级管理员才加载管理员窗体
            if (isSuperAdmin)
            {
                adminForm = new AdminForm();
                adminForm.MdiParent = this;
            }
            else
            {
                adminForm = null;
            }
            管理员GToolStripMenuItem.Visible = isSuperAdmin;
        }

        /// <summary>
        /// 统一打开MDI子窗体（优化：直接调用子窗体BindData刷新）
        /// </summary>
        private void OpenForm(Form form)
        {
            if (form == null) return;

            // 隐藏所有子窗体
            foreach (Form child in this.MdiChildren)
            {
                child.Hide();
                child.WindowState = FormWindowState.Minimized;
            }

            // 显示目标窗体
            form.Show();
            form.WindowState = FormWindowState.Maximized;

            // 核心：调用子窗体自身的BindData刷新数据（不直接操作DAL）
            switch (form)
            {
                case UserForm userForm:
                    userForm.BindData();
                    break;
                case AdressForm adressForm:
                    adressForm.BindData();
                    break;
                case AdminForm adminForm:
                    adminForm.BindData();
                    break;
            }
        }

        #region 菜单点击事件
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
        #endregion

        #region 退出相关
        private void 退出当前账号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定要退出当前账号吗？", "退出", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
                LoginFrom loginForm = new LoginFrom();
                loginForm.ShowDialog();
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
        #endregion

        // 定时器刷新时间
        private void timer1_Tick(object sender, EventArgs e)
        {
            LabelTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        #region 工具栏快捷按钮
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            adminForm?.Btnadd_Click(sender, e);
            OpenForm(adminForm);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            userForm.Btnadd_Click(sender, e);
            OpenForm(userForm);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            adressForm.Btnadd_Click(sender, e);
            OpenForm(adressForm);
        }
        #endregion

        private void LabelTime_Click(object sender, EventArgs e) { }
    }
}