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
    public partial class AdminAddAndChange : Form
    {
        private bool _isEdit;
        public AdminAddAndChange(bool isEdit = false)
        {
            this._isEdit = isEdit;
            InitializeComponent();
        }
        private void BtnAddOrChange_Click(object sender, EventArgs e)
        {
            if (_isEdit)
            {
                //添加正则表达式验证输入的账号和密码是否合法
                if (!System.Text.RegularExpressions.Regex.IsMatch(Account.Text, @"^[a-zA-Z0-9]{5,12}$"))
                {
                    MessageBox.Show("账号格式不正确，必须为5-12位字母或数字");
                    return;
                }
                if (!System.Text.RegularExpressions.Regex.IsMatch(Password.Text, @"^[a-zA-Z0-9]{6,12}$"))
                {
                    MessageBox.Show("密码格式不正确，必须为6-12位字母或数字");
                    return;
                }

                MainForm.current_mainForm.adminForm.adminDAL.Change(
                    new Model.Admin
                    {
                        Id = int.Parse(MainForm.current_mainForm.adminForm.dataGridView1.CurrentRow.Cells[0].Value.ToString()),
                        account = Account.Text,
                        password = Password.Text
                    }
                    );
                MessageBox.Show("修改成功");

            }
            else
            {
                //添加正则表达式验证输入的账号和密码是否合法
                if (!System.Text.RegularExpressions.Regex.IsMatch(Account.Text, @"^[a-zA-Z0-9]{5,12}$"))
                {
                    MessageBox.Show("账号格式不正确，必须为5-12位字母或数字");
                    return;
                }
                if (!System.Text.RegularExpressions.Regex.IsMatch(Password.Text, @"^[a-zA-Z0-9]{6,12}$"))
                {
                    MessageBox.Show("密码格式不正确，必须为6-12位字母或数字");
                    return;
                }
                MainForm.current_mainForm.adminForm.adminDAL.Add(new Model.Admin
                {
                    Id = AdminDAL.GetAllAdmin().Count + 1,
                    account = Account.Text,
                    password = Password.Text
                });
                MessageBox.Show("添加成功");

            }

            MainForm.current_mainForm.adminForm.dataGridView1.DataSource = null;//重新绑定数据源才会时时更新修改后的数据
            MainForm.current_mainForm.adminForm.dataGridView1.DataSource = AdminDAL.GetAllAdmin();

            this.Close();
        }
    }
}
