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

    public partial class LoginFrom : Form
    {
        AdminDAL adminDAL = new AdminDAL();
        SuperDAL superDAL = new SuperDAL();
        public LoginFrom()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            bool loginSucess;
            if (superPower.Checked)
            {
                loginSucess = superDAL.Login(account.Text, password.Text);
               
            }
            else
            {
                loginSucess = adminDAL.Login(account.Text, password.Text);
            }
            if (!loginSucess)
            {
                loginState.Text = "登录失败，请检查账号密码";
            }
            else
            {
                if (superPower.Checked)
                {
                   MessageBox.Show("超级管理员登录成功！");
                   SuperDAL.CurrentSuperAdmin = superDAL.find(account.Text);
                }
                else
                {
                    MessageBox.Show("管理员登录成功");
                    AdminDAL.CurrentAdmin = adminDAL.Find(account.Text, password.Text);
                }
               
                this.Hide();
                MainForm.ToNewMainForm(superPower.Checked);
                this.Close();
            }
        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
