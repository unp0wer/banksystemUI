using System;
using System.Windows.Forms;
using BLL;
using Model;
using static banksystemUI.ToolForm.AllAdressDic;

namespace banksystemUI
{
    public partial class AdressAddAndChange : Form
    {
        // 实例化BLL层，仅调用BLL，禁止直接操作DAL
        private readonly AdressBLL _adressBLL = new AdressBLL();
        private readonly bool _isEdit;

        public AdressAddAndChange(bool isEdit = false)
        {
            _isEdit = isEdit;
            InitializeComponent();
        }

        private void BtnAdressChange_Click(object sender, EventArgs e)
        {
            try
            {
                // 基础非空验证（可根据需求扩展）
                if (string.IsNullOrWhiteSpace(CbbProvince.Text) || string.IsNullOrWhiteSpace(CbbCity.Text))
                {
                    MessageBox.Show("请选择省/市！");
                    return;
                }

                if (_isEdit)
                {
                    // ============== 修改地址 ==============
                    int addressId = int.Parse(MainForm.current_mainForm.adressForm.dataGridView1.CurrentRow.Cells["Id"].Value.ToString());
                    Adress adress = new Adress
                    {
                        Province = CbbProvince.Text,
                        City = CbbCity.Text,
                        County = CbbCounty.Text,
                        Road = TxtRoad.Text,
                        Number = TxtNumber.Text
                    };

                    // 调用BLL修改方法
                    bool result = _adressBLL.UpdateAdress(addressId, adress);
                    MessageBox.Show(result ? "修改成功！" : "修改失败！");
                }
                else
                {
                    // ============== 添加地址 ==============
                    Adress adress = new Adress
                    {
                        Province = CbbProvince.Text,
                        City = CbbCity.Text,
                        County = CbbCounty.Text,
                        Road = TxtRoad.Text,
                        Number = TxtNumber.Text
                    };

                    // 调用BLL添加方法
                    bool result = _adressBLL.AddAdress(adress);
                    MessageBox.Show(result ? "添加成功！" : "添加失败！");
                }

                // 关闭窗体，父窗体AdressForm的BindData会自动刷新数据
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"操作异常：{ex.Message}");
            }
        }

        // ===================== 省市区联动逻辑（完全保留，不做修改）=====================
        private void AdressAddAndChange_Load(object sender, EventArgs e)
        {
            CbbProvince.Items.Clear();
            foreach (var province in ProvinceCityCountyDic.Keys)
            {
                CbbProvince.Items.Add(province);
            }
        }

        private void CbbProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            CbbCity.Items.Clear();
            CbbCounty.Items.Clear();
            ProvinceCityCountyDic.TryGetValue(CbbProvince.Text, out var cityCountyDic);
            if (cityCountyDic != null)
            {
                foreach (var city in cityCountyDic.Keys)
                {
                    CbbCity.Items.Add(city);
                }
            }
        }

        private void CbbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            CbbCounty.Items.Clear();
            ProvinceCityCountyDic.TryGetValue(CbbProvince.Text, out var cityCountyDic);
            if (cityCountyDic != null && cityCountyDic.TryGetValue(CbbCity.Text, out var countyList))
            {
                CbbCounty.Items.AddRange(countyList.ToArray());
            }
        }
    }
}