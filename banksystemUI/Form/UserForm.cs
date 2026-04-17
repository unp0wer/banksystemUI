using banksystemUI.ToolForm;
using BLL;
using Model;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace banksystemUI
{
    public partial class UserForm : BaseForm
    {
        // 仅保留BLL对象，UI绝不直接调用DAL
        public readonly UserBLL userBLL = new UserBLL();
        public UserAddAndChange addForm;

        public UserForm()
        {
            InitializeComponent();
            // 初始化绑定数据
            BindData();
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;


        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 确保点击的是操作列
            if (e.RowIndex >= 0 && (dataGridView1.Columns[e.ColumnIndex].Name == "change" || dataGridView1.Columns[e.ColumnIndex].Name == "delect"))
            {
                int userId = (int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value; // 获取ID列的值
                if (dataGridView1.Columns[e.ColumnIndex].Name == "change")
                {
                    // 修改操作
                    var row = dataGridView1.Rows[e.RowIndex];
                    addForm = new UserAddAndChange(true);
                    addForm.Text = "修改账户";
                    addForm.BtnAddOrChange.Text = "修改";
                    addForm.Account.Text = row.Cells["Account"].Value.ToString();
                    addForm.Password.Text = row.Cells["Password"].Value.ToString();
                    addForm.ShowDialog();
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "delect")
                {
                    // 删除操作
                    var confirmResult = MessageBox.Show("确定要删除这个账户吗？", "确认删除", MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        bool result = userBLL.DeleteUser(userId);
                        if (result)
                        {
                            MessageBox.Show("删除成功！");
                            BindData();
                        }
                        else
                        {
                            MessageBox.Show("删除失败！");
                        }
                    }
                }
            }
            

        }

        #region BindData 核心方法（支持ID+账号+时间范围查询）
        public void BindData()
        {
            dataGridView1.DataSource = null;
            string where = " where 1=1 ";
            // ID精确查询
            bool idParsed = int.TryParse(textID.Text.Trim(), out int id);
            if (!string.IsNullOrEmpty(textID.Text.Trim()) && idParsed)
            {
                where += " and Id = @ID";
            }
            // 账号模糊查询
            if (!string.IsNullOrEmpty(textAccount.Text.Trim()))
            {
                where += " and account Like  '%' + @Account + '%'";
            }
            // 时间范围查询
            DateTime? startTime = null;
            DateTime? endTime = null;
            if (!string.IsNullOrWhiteSpace(StarTime.Text) && StarTime.Text != " ")
            {
                startTime = StarTime.Value;
            }
            if (!string.IsNullOrWhiteSpace(EndTime.Text) && EndTime.Text != " ")
            {
                endTime = EndTime.Value;
            }
            if (startTime.HasValue)
            {
                where += " and Created_Time >= @StartTime";
            }
            if (endTime.HasValue)
            {
                where += " and Created_Time <= @EndTime";
            }

            // 绑定数据
            dataGridView1.DataSource = userBLL.GetAllUser(where, id, textAccount.Text.Trim(), startTime, endTime);
            dataGridView1.Columns["change"].DisplayIndex = dataGridView1.Columns.Count - 1;
            dataGridView1.Columns["delect"].DisplayIndex = dataGridView1.Columns.Count - 1;
            LabelCurrentPage.Text = $"{userBLL.currentPage}/{userBLL.totalPage}";
        }
        #endregion

        #region 1. 添加账户
        public void Btnadd_Click(object sender, EventArgs e)
        {
            addForm = new UserAddAndChange();
            addForm.Text = "添加账户";
            addForm.BtnAddOrChange.Text = "添加";
            addForm.ShowDialog();
            // 刷新数据
            BindData();
        }
        #endregion

        #region 2. 删除账户
        public void BtbDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("请选择要删除的账户！");
                    return;
                }

                int userId = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                bool result = userBLL.DeleteUser(userId);

                if (result)
                {
                    MessageBox.Show("删除成功！");
                    BindData();
                }
                else
                {
                    MessageBox.Show("删除失败！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"删除异常：{ex.Message}");
            }
        }
        #endregion

        #region 3. 修改账户
        public void BtnChange_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要修改的账户！");
                return;
            }

            // 直接获取当前行数据，无需跨窗体调用
            var row = dataGridView1.CurrentRow;
            addForm = new UserAddAndChange(true);
            addForm.Text = "修改账户";
            addForm.BtnAddOrChange.Text = "修改";
            addForm.Account.Text = row.Cells[1].Value.ToString();
            addForm.Password.Text = row.Cells[2].Value.ToString();
            addForm.ShowDialog();

            // 刷新数据
            BindData();
        }
        #endregion

        #region 4. 查询账户（直接调用BindData，统一逻辑）
        public void BtnFind_Click(object sender, EventArgs e)
        {
            // 重置为第一页并查询
            userBLL.currentPage = 1;
            BindData();
        }
        #endregion

        #region 时间选择器格式化
        public void StarTime_ValueChanged(object sender, EventArgs e)
        {
            StarTime.CustomFormat = "yyyy-MM-dd";
        }

        public void EndTime_ValueChanged(object sender, EventArgs e)
        {
            EndTime.CustomFormat = "yyyy-MM-dd";
        }
        #endregion

        #region 清空时间
        public void Clear_Click(object sender, EventArgs e)
        {
            StarTime.CustomFormat = " ";
            EndTime.CustomFormat = " ";
            BindData(); // 清空后刷新数据
        }
        #endregion

        #region 5. 分页功能
        // 首页
        public void btnFirstPage_Click(object sender, EventArgs e)
        {
            userBLL.currentPage = 1;
            BindData();
        }

        // 上一页
        public void btnPerviousPage_Click(object sender, EventArgs e)
        {
            if (userBLL.currentPage > 1)
                userBLL.currentPage--;
            BindData();
        }

        // 下一页
        public void btnNextPage_Click(object sender, EventArgs e)
        {
            if (userBLL.currentPage < userBLL.totalPage)
                userBLL.currentPage++;
            BindData();
        }

        // 尾页
        public void btnLastPage_Click(object sender, EventArgs e)
        {
            userBLL.currentPage = userBLL.totalPage;
            BindData();
        }

        // 切换每页条数
        public void comboxLineNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(comboxLineNumber.SelectedItem.ToString(), out int size))
            {
                userBLL.pageSize = size;
                userBLL.currentPage = 1;
                BindData();
            }
        }

        // 页码跳转
        public void btnGoTOPage_Click(object sender, EventArgs e)
        {
            userBLL.currentPage = int.TryParse(NumJumpPage.Value.ToString(), out int page) ? page : 1;

            // 边界校验
            if (userBLL.currentPage < 1) userBLL.currentPage = 1;
            if (userBLL.currentPage > userBLL.totalPage) userBLL.currentPage = userBLL.totalPage;

            BindData();
        }
        #endregion
    }
}