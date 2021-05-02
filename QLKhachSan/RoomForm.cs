using QLKhachSan.RoomSubForm;
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
    public partial class RoomForm : Form
    {
        public RoomForm()
        {
            InitializeComponent();
            cbSearch.SelectedIndex = 0;
        }

        private void RoomForm_Load(object sender, EventArgs e)
        {
            roomDgv.DataSource = new Database().SelectData("select * from phong");
        }
        private void Reload()
        {
            roomDgv.DataSource = new Database().SelectData("select * from phong");

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new AddRoomForm(null).ShowDialog();
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
                if(cbSearch.SelectedIndex != -1)
                {
                    string valueSearch = txbSearch.Text;
                    var db = new Database();
                    string sqlSearch = "";
                    if (cbSearch.SelectedIndex == 0)
                    {
                        sqlSearch = "exec SelectPhongByID '" + valueSearch + "'";
                        if (db.SelectData(sqlSearch).Rows.Count != 0)
                        {
                            new SearchRoomForm(sqlSearch).Show();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    else if (cbSearch.SelectedIndex == 1)
                    {
                        sqlSearch = "exec SelectPhongByName '" + valueSearch + "'";
                        if (db.SelectData(sqlSearch).Rows.Count != 0)
                        {
                            new SearchRoomForm(sqlSearch).Show();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (cbSearch.SelectedIndex == 2)
                    {
                        sqlSearch = "exec SelectPhongByCategory '" + valueSearch + "'";
                        if (db.SelectData(sqlSearch).Rows.Count != 0)
                        {
                            new SearchRoomForm(sqlSearch).Show();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (cbSearch.SelectedIndex == 3)
                    {
                        sqlSearch = "exec SelectPhongByPrice '" + valueSearch + "'";
                        if (db.SelectData(sqlSearch).Rows.Count != 0)
                        {
                            new SearchRoomForm(sqlSearch).Show();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void roomDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maPhong = roomDgv.Rows[e.RowIndex].Cells["MaPhong"].Value.ToString();
                new AddRoomForm(maPhong).ShowDialog();
                Reload();
            }
        }
    }
}
