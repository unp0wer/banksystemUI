using banksystemUI.ToolForm;
using Model;
using BLL;
using System;
using System.Windows.Forms;

namespace banksystemUI
{
    public partial class AdressForm : BaseForm
    {
        public readonly AdressBLL adressBLL = new AdressBLL();
        public AdressAddAndChange addForm;

        public AdressForm()
        {
            InitializeComponent();
            BindData();
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;

            dataGridView1.BringToFront();
        }


        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 确保点击的是操作列
            if (e.RowIndex >= 0 && (dataGridView1.Columns[e.ColumnIndex].Name == "change" || dataGridView1.Columns[e.ColumnIndex].Name == "delect"))
            {
                int userId = (int)dataGridView1.Rows[e.RowIndex].Cells["id"].Value; // 获取ID列的值
                if (dataGridView1.Columns[e.ColumnIndex].Name == "change")
                {
                    // 修改操作
                    var row = dataGridView1.Rows[e.RowIndex];
                    addForm = new AdressAddAndChange(true);
                    addForm.Text = "修改地址";
                    addForm.BtnAdressChange.Text = "修改";
                    addForm.CbbProvince.Text = row.Cells["Province"].Value.ToString();
                    addForm.CbbCity.Text = row.Cells["City"].Value.ToString();
                    addForm.CbbCounty.Text = row.Cells["County"].Value.ToString();
                    addForm.TxtRoad.Text = row.Cells["Road"].Value.ToString();
                    addForm.TxtNumber.Text = row.Cells["Number"].Value.ToString();
                    addForm.ShowDialog();
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "delect")
                {
                    // 删除操作
                    var confirmResult = MessageBox.Show("确定要删除这个地址吗？", "确认删除", MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        bool result = adressBLL.DeleteAdress(userId);
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

        #region 绑定数据 + SQL条件拼接
        public void BindData()
        {
            dataGridView1.DataSource = null;
            string where = " where 1=1 ";
            bool idParsed = int.TryParse(textID.Text.Trim(), out int id);
            if (!string.IsNullOrEmpty(textID.Text.Trim()) && idParsed)
            {
                where += " and Id = @ID";
            }
            if (!string.IsNullOrEmpty(TxtAdress.Text.Trim()))
            {
                where += " and (Province + City + County + Road + Number) Like  '%' + @Account + '%'";
            }
            dataGridView1.DataSource = adressBLL.GetAllAdress(where, id, TxtAdress.Text.Trim());
            dataGridView1.Columns["change"].DisplayIndex = dataGridView1.Columns.Count - 1;
            dataGridView1.Columns["delect"].DisplayIndex = dataGridView1.Columns.Count - 1;
            LabelCurrentPage.Text = $"{adressBLL.currentPage}/{adressBLL.totalPage}";
        }
        #endregion

        #region 添加地址
        public void Btnadd_Click(object sender, EventArgs e)
        {
            addForm = new AdressAddAndChange();
            addForm.Text = "添加地址";
            addForm.BtnAdressChange.Text = "添加";
            addForm.ShowDialog();
            BindData();
        }
        #endregion

        #region 删除地址
        public void BtbDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("请选择要删除的地址！");
                    return;
                }
                int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                bool result = adressBLL.DeleteAdress(id);
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

        #region 修改地址
        public void BtnChange_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要修改的地址！");
                return;
            }
            var row = dataGridView1.CurrentRow;
            addForm = new AdressAddAndChange(true);
            addForm.Text = "修改地址";
            addForm.BtnAdressChange.Text = "修改";
            addForm.CbbProvince.Text = row.Cells[1].Value.ToString();
            addForm.CbbCity.Text = row.Cells[2].Value.ToString();
            addForm.CbbCounty.Text = row.Cells[3].Value.ToString();
            addForm.TxtRoad.Text = row.Cells[4].Value.ToString();
            addForm.TxtNumber.Text = row.Cells[5].Value.ToString();
            addForm.ShowDialog();
            BindData();
        }
        #endregion

        #region 查询按钮（直接调用BindData，统一逻辑）
        public void BtnFind_Click(object sender, EventArgs e)
        {
            // 重置页码+查询
            adressBLL.currentPage = 1;
            BindData();

            if (dataGridView1.Rows.Count == 1)
            {
                MessageBox.Show("未查询到匹配数据！");
            }
        }
        #endregion

        #region 分页按钮
        public void btnFirstPage_Click(object sender, EventArgs e)
        {
            adressBLL.currentPage = 1;
            BindData();
        }

        public void btnPerviousPage_Click(object sender, EventArgs e)
        {
            if (adressBLL.currentPage > 1)
                adressBLL.currentPage--;
            BindData();
        }

        public void btnNextPage_Click(object sender, EventArgs e)
        {
            if (adressBLL.currentPage < adressBLL.totalPage)
                adressBLL.currentPage++;
            BindData();
        }

        public void btnLastPage_Click(object sender, EventArgs e)
        {
            adressBLL.currentPage = adressBLL.totalPage;
            BindData();
        }

        public void comboxLineNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(comboxLineNumber.SelectedItem.ToString(), out int size))
            {
                adressBLL.pageSize = size;
                adressBLL.currentPage = 1;
                BindData();
            }
        }

        public void btnGoTOPage_Click(object sender, EventArgs e)
        {
            adressBLL.currentPage = int.TryParse(NumJumpPage.Value.ToString(), out int page) ? page : 1;
            if (adressBLL.currentPage < 1) adressBLL.currentPage = 1;
            if (adressBLL.currentPage > adressBLL.totalPage) adressBLL.currentPage = adressBLL.totalPage;
            BindData();
        }
        #endregion

        public void AdressForm_Load(object sender, EventArgs e) { }
    }
}