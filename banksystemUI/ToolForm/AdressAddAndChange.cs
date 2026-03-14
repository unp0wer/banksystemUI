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
    public partial class AdressAddAndChange : Form
    {
        private bool _isEdit;
        public AdressAddAndChange(bool isEdit = false)
        {
            _isEdit = isEdit;
            InitializeComponent();
        }

        private void BtnAdressChange_Click(object sender, EventArgs e)
        {
            if (_isEdit)
            {

                MainForm.current_mainForm.adressForm.adressDAL.Change(
                    int.Parse(MainForm.current_mainForm.adressForm.dataGridView1.CurrentRow.Cells[0].Value.ToString()),
                    new Model.Adress
                    {
                       
                        Provice = Txtprovince.Text,
                        City = TxtCity.Text,
                        County = TxtCounty.Text,
                        Road = TxtRoad.Text,
                        Number = TxtNumber.Text
                    }
                    );
                MessageBox.Show("修改成功");

            }
            else
            {
                MainForm.current_mainForm.adressForm.adressDAL.Add(
                    UserDAL.GetAllUser().Count + 1,
                    new Model.Adress
                    {

                        Provice = Txtprovince.Text,
                        City = TxtCity.Text,
                        County = TxtCounty.Text,
                        Road = TxtRoad.Text,
                        Number = TxtNumber.Text
                    }
                );
                MessageBox.Show("添加成功");
            }

            MainForm.current_mainForm.adressForm.dataGridView1.DataSource = null;//重新绑定数据源才会时时更新修改后的数据
            MainForm.current_mainForm.adressForm.dataGridView1.DataSource = AdressDAL.GetAllAdress();
            this.Close();
        }
    }

}