using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BLL;
using Model;

namespace banksystemUI.ToolForm
{
    public partial class UserAddAndChange : Form
    {
        // 实例化BLL层，仅调用BLL，禁止直接操作DAL
        private readonly UserBLL _userBLL = new UserBLL();
        private readonly bool _isEdit;

        public UserAddAndChange(bool isEdit = false)
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

            if (!Regex.IsMatch(Account.Text, @"^[a-zA-Z0-9]{3,12}$"))
            {
                MessageBox.Show("账号格式不正确，必须为3-12位字母或数字");
                Account.Focus();
                return false;
            }
            // 密码验证：6-12位字母数字
            if (!Regex.IsMatch(Password.Text, @"^[a-zA-Z0-9]{3,12}$"))
            {
                MessageBox.Show("密码格式不正确，必须为3-12位字母或数字");
                Password.Focus();
                return false;
            }
            return true;
        }
        #endregion

        private void BtnAddOrChange_Click(object sender, EventArgs e)
        {
            // 统一验证输入格式
            if (!ValidateInput()) return;

            try
            {
                if (_isEdit)
                {
                    // ============== 修改用户 ==============
                    User user = new User
                    {
                        // 获取选中行的ID
                        Id = int.Parse(MainForm.current_mainForm.userForm.dataGridView1.CurrentRow.Cells["Id"].Value.ToString()),
                        account = Account.Text,
                        password = Password.Text
                    };
                    // 调用BLL修改方法
                    bool result = _userBLL.UpdateUser(user);
                    MessageBox.Show(result ? "修改成功！" : "修改失败！");
                }
                else
                {
                    // ============== 添加用户 ==============
                    User user = new User
                    {
                        account = Account.Text,
                        password = Password.Text
                    };
                    // 调用BLL添加方法
                    bool result = _userBLL.AddUser(user);
                    MessageBox.Show(result ? "添加成功！" : "添加失败！");
                }

                // 关闭窗体，父窗体UserForm的BindData会自动刷新数据
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"操作异常：{ex.Message}");
            }
        }
    }
}