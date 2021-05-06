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
    public partial class RentingForm : Form
    {
        public RentingForm()
        {
            InitializeComponent();
        }

        private void RentingForm_Load(object sender, EventArgs e)
        {
            rentingDgv.DataSource = new Database().SelectData("select * from THUE");
        }

        private void Reload()
        {
            rentingDgv.DataSource = new Database().SelectData("select * from THUE");
        }

        private void btnRent_Click(object sender, EventArgs e)
        {
            new RentRoom(null).ShowDialog();
            Reload();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            ReturnRoom returnRoom = new ReturnRoom();
            returnRoom.Show();
            Reload();
        }

        private void rentingDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maThue = rentingDgv.Rows[e.RowIndex].Cells["MaDK"].Value.ToString();
                new RentRoom(maThue).ShowDialog();
                Reload();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbSearch.Text))
            {
                MessageBox.Show("Bạn chưa nhập thông tin tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (cbSearch.SelectedIndex != -1)
                {
                    string valueSearch = txbSearch.Text;
                    var db = new Database();
                    string sqlSearch = "";
                    if (cbSearch.SelectedIndex == 0)
                    {
                        sqlSearch = "exec searchMaPHONGforRent '" + valueSearch + "'";
                        if (db.SelectData(sqlSearch).Rows.Count != 0)
                        {
                            new SearchGuest(sqlSearch).Show();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    else if (cbSearch.SelectedIndex == 1)
                    {
                        sqlSearch = "exec searchMaKHforRent '" + valueSearch + "'";
                        if (db.SelectData(sqlSearch).Rows.Count != 0)
                        {
                            new SearchGuest(sqlSearch).Show();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }
    }
}
