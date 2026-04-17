using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
namespace banksystemUI
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
            // 给按钮添加颜色（在AddActionButtons方法中）
            change.DefaultCellStyle.BackColor = Color.LightBlue;
            change.DefaultCellStyle.ForeColor = Color.White;
            delect.DefaultCellStyle.BackColor = Color.IndianRed;
            delect.DefaultCellStyle.ForeColor = Color.White;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
