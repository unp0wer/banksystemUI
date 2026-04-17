using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BLL;
using Model;

namespace banksystemUI
{
    public partial class AdminAddAndChange : Form
    {
        // 实例化BLL，仅调用BLL，不直接操作DAL
        private readonly AdminBLL _adminBLL = new AdminBLL();
        private readonly bool _isEdit;

        // 构造函数
        public AdminAddAndChange(bool isEdit = false)
        {
            this._isEdit = isEdit;
            InitializeComponent();
        }

        #region 抽离重复的输入验证（代码复用）
        /// <summary>
        /// 验证账号密码格式
        /// </summary>
        private bool ValidateInput()
        {
            // 账号验证：5-12位字母数字
            if (!Regex.IsMatch(Account.Text, @"^[a-zA-Z0-9]{3,12}$"))
            {
                MessageBox.Show("账号格式不正确，必须为5-12位字母或数字");
                Account.Focus();
                return false;
            }
            // 密码验证：6-12位字母数字
            if (!Regex.IsMatch(Password.Text, @"^[a-zA-Z0-9]{3,12}$"))
            {
                MessageBox.Show("密码格式不正确，必须为6-12位字母或数字");
                Password.Focus();
                return false;
            }
            return true;
        }
        #endregion

        private void BtnAddOrChange_Click(object sender, EventArgs e)
        {
            // 统一验证，不通过直接返回
            if (!ValidateInput()) return;

            try
            {
                if (_isEdit)
                {
                    // ============== 修改操作 ==============
                    Admin admin = new Admin
                    {
                        // 从父窗体获取当前选中行的ID（保留原有逻辑）
                        Id = int.Parse(MainForm.current_mainForm.adminForm.dataGridView1.CurrentRow.Cells["Id"].Value.ToString()),
                        account = Account.Text,
                        password = Password.Text
                    };

                    // 调用BLL修改方法
                    bool result = _adminBLL.UpdateAdmin(admin);
                    if (result)
                    {
                        MessageBox.Show("修改成功！");
                    }
                    else
                    {
                        MessageBox.Show("修改失败！");
                    }
                }
                else
                {
                    // ============== 添加操作 ==============
                    Admin admin = new Admin
                    {
                        account = Account.Text,
                        password = Password.Text
                    };

                    // 调用BLL添加方法
                    bool result = _adminBLL.AddAdmin(admin);
                    if (result)
                    {
                        MessageBox.Show("添加成功！");
                    }
                    else
                    {
                        MessageBox.Show("添加失败！");
                    }
                }

                // 关闭当前窗体，父窗体已封装BindData会自动刷新
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"操作异常：{ex.Message}");
            }
        }
    }
}