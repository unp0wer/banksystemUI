using System;
using System.Windows.Forms;
using BLL;

namespace banksystemUI
{
    public partial class LoginFrom : Form
    {
        // 实例化BLL，UI绝不直接调用DAL
        private readonly AdminBLL _adminBLL = new AdminBLL();
        private readonly SuperBLL _superBLL = new SuperBLL();

        public LoginFrom()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 登录按钮点击事件
        /// </summary>
        private void loginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // 输入非空验证
                if (string.IsNullOrWhiteSpace(account.Text) || string.IsNullOrWhiteSpace(password.Text))
                {
                    loginState.Text = "账号/密码不能为空！";
                    return;
                }

                bool loginSuccess;
                // 区分超级管理员/普通管理员登录
                if (superPower.Checked)
                {
                    loginSuccess = _superBLL.Login(account.Text, password.Text);
                }
                else
                {
                    loginSuccess = _adminBLL.Login(account.Text, password.Text);
                }

                // 登录失败
                if (!loginSuccess)
                {
                    loginState.Text = "登录失败，请检查账号密码";
                    return;
                }

                // 登录成功
                if (superPower.Checked)
                {
                    MessageBox.Show("超级管理员登录成功！");
                    SuperBLL.CurrentSuperAdmin = _superBLL.FindSuper(account.Text);
                }
                else
                {
                    MessageBox.Show("管理员登录成功！");
                    AdminBLL.CurrentAdmin = _adminBLL.FindAdmin(account.Text, password.Text);
                }

                // 跳转到主窗体
                this.Hide();
                MainForm.ToNewMainForm(superPower.Checked);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"登录异常：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 无用事件，保留空方法
        private void password_TextChanged(object sender, EventArgs e) { }
    }
}