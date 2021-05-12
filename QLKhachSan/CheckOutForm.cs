using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKhachSan
{
    public partial class CheckOutForm : Form
    {
        public CheckOutForm()
        {
            InitializeComponent();
        }


        private void checkOutDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maHD = checkOutDgv.Rows[e.RowIndex].Cells["MaHD"].Value.ToString();
                new ThemHD(maHD, checkOutDgv).ShowDialog();
                reload();
            }
        }

        private void CheckOutForm_Load(object sender, EventArgs e)
        {
            checkOutDgv.DataSource = new Database().SelectData("Select * from HOADON");
        }
        private void reload()
        {
            checkOutDgv.DataSource = new Database().SelectData("select * from HOADON");

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new ThemHD().ShowDialog();
            reload();
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbSearch.Text))
            {
                MessageBox.Show("Bạn chưa nhập thông tin tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string sqlSearch = "";
                sqlSearch = "exec searchHD '" + txbSearch.Text + "'";
                new SearchHD(sqlSearch).Show();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
