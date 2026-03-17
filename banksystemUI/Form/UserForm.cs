using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using banksystemUI.ToolForm;

namespace banksystemUI
{
    public partial class UserForm : BaseForm
    {
        public UserAddAndChange addForm;
        public DAL.UserDAL userDAL = new DAL.UserDAL();
        public UserForm()
        {
            InitializeComponent();
            dataGridView1.DataSource = userDAL.GetAllUser();
        }

        public void Btnadd_Click(object sender, EventArgs e)
        {
            addForm = new UserAddAndChange();
            addForm.Text = "添加账户";
            addForm.BtnAddOrChange.Text = "添加";
            addForm.ShowDialog();
            MainForm.current_mainForm.userForm.dataGridView1.Refresh();
        }

        private void BtbDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要删除的账户");
                return;
            }
            userDAL.Delete((int)dataGridView1.SelectedRows[0].Cells[0].Value);
            MainForm.current_mainForm.userForm.dataGridView1.DataSource = null;
            dataGridView1.DataSource = userDAL.GetAllUser();
        }

        private void BtnChange_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要修改的账户");
                return;
            }
            addForm = new UserAddAndChange(true);
            addForm.Text = "修改账户";
            addForm.BtnAddOrChange.Text = "修改";
            addForm.Account.Text = MainForm.current_mainForm.userForm.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            addForm.Password.Text = MainForm.current_mainForm.userForm.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            addForm.ShowDialog();

            MainForm.current_mainForm.userForm.dataGridView1.Refresh();
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            List<User> findUsers = new List<User>();
            MainForm.current_mainForm.userForm.dataGridView1.DataSource = userDAL.GetAllUser();
            findUsers = userDAL.GetAllUser();
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                findUsers = findUsers.FindAll(a => a.Id == int.Parse(textBox1.Text));
            }
            if (!string.IsNullOrWhiteSpace(textBox2.Text))
            {
                findUsers = findUsers.FindAll(a => a.account.Contains(textBox2.Text));
            }
            if(!string.IsNullOrWhiteSpace(StarTime.Text)&&!string.IsNullOrWhiteSpace(EndTime.Text))
            {
                findUsers = findUsers.FindAll(a => a.CreatTime >= StarTime.Value && a.CreatTime <= EndTime.Value);
            }

            MainForm.current_mainForm.userForm.dataGridView1.DataSource = findUsers;
        }

        private void StarTime_ValueChanged(object sender, EventArgs e)
        {
           StarTime.CustomFormat = "yyyy-MM-dd";
        }

        private void EndTime_ValueChanged(object sender, EventArgs e)
        {
            EndTime.CustomFormat = "yyyy-MM-dd";
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            StarTime.CustomFormat = " ";
            EndTime.CustomFormat = " ";
        }
    }
}
