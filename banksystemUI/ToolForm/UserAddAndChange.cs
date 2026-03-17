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

namespace banksystemUI.ToolForm
{
    public partial class UserAddAndChange : Form
    {
        private bool _isEdit;
        public UserAddAndChange(bool isEdit = false)
        {
            this._isEdit = isEdit;
            InitializeComponent();
        }
        public void BtnAddOrChange_Click(object sender, EventArgs e)
        {
            if (_isEdit)
            {
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
                MainForm.current_mainForm.userForm.userDAL.Change(
                    new Model.User
                    {
                        Id = int.Parse(MainForm.current_mainForm.userForm.dataGridView1.CurrentRow.Cells[0].Value.ToString()),
                        account = Account.Text,
                        password = Password.Text
                    }
                    );
                MessageBox.Show("修改成功");

            }
            else
            {
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
                MainForm.current_mainForm.userForm.userDAL.Add(new Model.User
                {
                    Id = MainForm.current_mainForm.userForm.userDAL.GetAllUser().Count + 1,
                    account = Account.Text,
                    password = Password.Text
                });
                MessageBox.Show("添加成功");

            }

            MainForm.current_mainForm.userForm.dataGridView1.DataSource = null;//重新绑定数据源才会时时更新修改后的数据
            MainForm.current_mainForm.userForm.dataGridView1.DataSource = MainForm.current_mainForm.userForm.userDAL.GetAllUser();

            this.Close();
        }

    }
}
