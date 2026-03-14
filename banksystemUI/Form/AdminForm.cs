using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Model;
namespace banksystemUI
{

    public partial class AdminForm : BaseForm
    {
        public AdminAddAndChange addForm;
        public DAL.AdminDAL adminDAL = new DAL.AdminDAL();
        public AdminForm()
        {
            InitializeComponent();
        }

        public void Btnadd_Click(object sender, EventArgs e)
        {
            addForm = new AdminAddAndChange();
            addForm.Text = "添加账户";
            addForm.BtnAddOrChange.Text = "添加";
            addForm.ShowDialog();
            MainForm.current_mainForm.adminForm.dataGridView1.Refresh();
        }

        private void BtbDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要删除的账户");
                return;
            }
            adminDAL.Delete((int)dataGridView1.SelectedRows[0].Cells[0].Value);
            MainForm.current_mainForm.adminForm.dataGridView1.DataSource = null;
            dataGridView1.DataSource = AdminDAL.GetAllAdmin();
        }

        private void BtnChange_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要修改的账户");
                return;
            }
            addForm = new AdminAddAndChange(true);
            addForm.Text = "修改账户";
            addForm.BtnAddOrChange.Text = "修改";
            addForm.Account.Text = MainForm.current_mainForm.adminForm.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            addForm.Password.Text = MainForm.current_mainForm.adminForm.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            addForm.ShowDialog();

            MainForm.current_mainForm.adminForm.dataGridView1.Refresh();
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            List<Admin> findAdmins = new List<Admin>();
            MainForm.current_mainForm.adminForm.dataGridView1.DataSource = AdminDAL.GetAllAdmin();
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                findAdmins = AdminDAL.GetAllAdmin().FindAll(a => a.Id == int.Parse(textBox1.Text));
            }
            if (!string.IsNullOrWhiteSpace(textBox2.Text))
            {
                findAdmins = findAdmins.FindAll(a => a.account.Contains(textBox2.Text));
            }

            MainForm.current_mainForm.adminForm.dataGridView1.DataSource = findAdmins;
        }
    }
}
