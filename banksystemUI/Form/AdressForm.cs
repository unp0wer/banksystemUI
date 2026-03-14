using banksystemUI.ToolForm;
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

namespace banksystemUI
{
    public partial class AdressForm : BaseForm
    {
        public AdressAddAndChange addForm;
        public DAL.AdressDAL adressDAL = new DAL.AdressDAL();
        public AdressForm()
        {
            InitializeComponent();
        }

        private void AdressForm_Load(object sender, EventArgs e)
        {

        }

        private void Btnadd_Click(object sender, EventArgs e)
        {
            addForm = new AdressAddAndChange();
            addForm.Text = "添加地址";
            addForm.BtnAdressChange.Text = "添加";
            addForm.ShowDialog();
            MainForm.current_mainForm.adressForm.dataGridView1.Refresh();
        }

        private void BtbDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要删除的地址");
                return;
            }
            adressDAL.Delete((int)dataGridView1.SelectedRows[0].Cells[0].Value);
            MainForm.current_mainForm.adressForm.dataGridView1.DataSource = null;
            dataGridView1.DataSource = AdressDAL.GetAllAdress();


        }

        public void BtnChange_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要修改的地址");
                return;
            }
            addForm = new AdressAddAndChange(true);
            addForm.Text = "修改地址";
            addForm.BtnAdressChange.Text = "修改";
            addForm.Txtprovince.Text = MainForm.current_mainForm.adressForm.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            addForm.TxtCity.Text = MainForm.current_mainForm.adressForm.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            addForm.TxtCounty.Text = MainForm.current_mainForm.adressForm.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            addForm.TxtRoad.Text = MainForm.current_mainForm.adressForm.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            addForm.TxtNumber.Text = MainForm.current_mainForm.adressForm.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            addForm.ShowDialog();
            MainForm.current_mainForm.adressForm.dataGridView1.Refresh();


        }

        private void BtnFind_Click(object sender, EventArgs e)
        {

        }
    }
}
