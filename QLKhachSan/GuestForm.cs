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
    public partial class GuestForm : Form
    {
        public GuestForm()
        {
            InitializeComponent();
            //cbSearch.SelectedIndex = 0;
        }

        private void GuestForm_Load(object sender, EventArgs e)
        {
            guestDgv.DataSource = new Database().SelectData("Select * from KHACHHANG");
        }

        private void Reload()
        {
            guestDgv.DataSource = new Database().SelectData("Select * from KHACHHANG");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new AddGuest(null).ShowDialog();
            Reload();
        }

        private void guestDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maKH = guestDgv.Rows[e.RowIndex].Cells["MaKH"].Value.ToString();
                new AddGuest(maKH).ShowDialog();
                Reload();
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
                if (cbSearch.SelectedIndex != -1)
                {
                    string valueSearch = txbSearch.Text;
                    var db = new Database();
                    string sqlSearch = "";
                    if (cbSearch.SelectedIndex == 0)
                    {
                        sqlSearch = "exec searchMaKH '" + valueSearch + "'";
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
                        sqlSearch = "exec searchTenKH '" + valueSearch + "'";
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
