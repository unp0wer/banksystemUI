using banksystemUI.ToolForm;
using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace banksystemUI
{
    public partial class AdminForm : BaseForm
    {
        // 仅保留BLL对象，UI绝不直接调用DAL
        public readonly AdminBLL adminBLL = new AdminBLL();
        public AdminAddAndChange addForm;

        public AdminForm()
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
                    addForm = new AdminAddAndChange(true);
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
                        bool result = adminBLL.DeleteAdmin(userId);
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

        #region 核心：统一绑定数据 + 刷新页码
        /// <summary>
        /// 绑定DataGridView数据并更新分页标签
        /// </summary>
        public void BindData()
        {
            dataGridView1.DataSource = null;
            string where = " where 1=1 "; // 可以根据需要构造查询条件
            bool idParsed = int.TryParse(textID.Text.Trim(), out int id);
            if (!string.IsNullOrEmpty(textID.Text.Trim()) && idParsed)
            {
                where += " and Id = @ID";
            }
            if (!string.IsNullOrEmpty(textAccount.Text.Trim()))
            {
                where += " and Account Like  '%' + @Account + '%'";
            }
            dataGridView1.DataSource = adminBLL.GetAllAdmin(where, id, textAccount.Text.Trim());
            dataGridView1.Columns["change"].DisplayIndex = dataGridView1.Columns.Count - 1;
            dataGridView1.Columns["delect"].DisplayIndex = dataGridView1.Columns.Count - 1;
            LabelCurrentPage.Text = $"{adminBLL.currentPage}/{adminBLL.totalPage}";
        }
        #endregion

        #region 1. 添加账户
        public void Btnadd_Click(object sender, EventArgs e)
        {
            addForm = new AdminAddAndChange();
            addForm.Text = "添加账户";
            addForm.BtnAddOrChange.Text = "添加";
            addForm.ShowDialog();
            // 添加完成后刷新数据
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

                int adminId = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                bool result = adminBLL.DeleteAdmin(adminId);

                if (result)
                {
                    MessageBox.Show("删除成功！");
                    BindData(); // 刷新数据
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

            // 直接用当前行数据，无需跨窗体调用
            var row = dataGridView1.CurrentRow;
            addForm = new AdminAddAndChange(true);
            addForm.Text = "修改账户";
            addForm.BtnAddOrChange.Text = "修改";
            addForm.Account.Text = row.Cells[1].Value.ToString();
            addForm.Password.Text = row.Cells[2].Value.ToString();
            addForm.ShowDialog();

            // 修改完成后刷新
            BindData();
        }
        #endregion

        #region 4. 条件查询
        public void BtnFind_Click(object sender, EventArgs e)
        {
            // 安全转换ID
            int? searchId = null;
            if (int.TryParse(textID.Text.Trim(), out int id))
                searchId = id;

            string searchAccount = textAccount.Text.Trim();
            // 调用BLL的查询方法
            var searchList = adminBLL.SearchAdmin(searchId, searchAccount);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = searchList;

            if (searchList.Count == 0)
                MessageBox.Show("未查询到匹配数据！");
        }
        #endregion

        #region 5. 分页按钮
        // 首页
        public void btnFirstPage_Click(object sender, EventArgs e)
        {
            adminBLL.currentPage = 1;
            BindData();
        }

        // 上一页（增加边界判断）
        public void btnPerviousPage_Click(object sender, EventArgs e)
        {
            if (adminBLL.currentPage > 1)
                adminBLL.currentPage--;
            BindData();
        }

        // 下一页（增加边界判断）
        public void btnNextPage_Click(object sender, EventArgs e)
        {
            if (adminBLL.currentPage < adminBLL.totalPage)
                adminBLL.currentPage++;
            BindData();
        }

        // 尾页
        public void btnLastPage_Click(object sender, EventArgs e)
        {
            adminBLL.currentPage = adminBLL.totalPage;
            BindData();
        }

        // 每页条数修改
        public void comboxLineNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(comboxLineNumber.SelectedItem.ToString(), out int size))
            {
                adminBLL.pageSize = size;
                adminBLL.currentPage = 1;
                BindData();
            }
        }

        // 跳转页码（修复：跳转后必须刷新数据！）
        public void btnGoTOPage_Click(object sender, EventArgs e)
        {
            adminBLL.currentPage = int.TryParse(NumJumpPage.Value.ToString(), out int page) ? page : 1;

            // 边界校验
            if (adminBLL.currentPage < 1) adminBLL.currentPage = 1;
            if (adminBLL.currentPage > adminBLL.totalPage) adminBLL.currentPage = adminBLL.totalPage;

            BindData();
        }
        #endregion

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }
    }
}