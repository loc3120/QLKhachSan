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
    public partial class SuppliesForm : Form
    {
        public SuppliesForm()
        {
            InitializeComponent();
        }

        private void SuppliesForm_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void reload()
        {
            suppliesDgv.DataSource = new Database().SelectData("select * from VATDUNG");
            updateHoaDonVatDung();
        }

        private void updateHoaDonVatDung()
        {
            Database db = new Database();
            string sql = "";
            DataTable listVatDung = db.SelectData("select * from VATDUNG");
            for (int i = 0; i < listVatDung.Rows.Count; i++)
            {
                List<CustomParameter> lstPara = new List<CustomParameter>();
                sql = "UpdateHoaDonVatDung";
                lstPara.Add(new CustomParameter()
                {
                    key = "@maVatDung",
                    value = listVatDung.Rows[i][0].ToString()
                });
                lstPara.Add(new CustomParameter()
                {
                    key = "@giaTien",
                    value = listVatDung.Rows[i][2].ToString()
                });

                var rs = new Database().ExeCute(sql, lstPara);
                //if (rs != 1)
                //{
                //    MessageBox.Show("Something went wrong");
                //}

            }
        }

        private void resetValue()
        {
            txbSearch.Text = "";
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
                    String valueSearch = txbSearch.Text;
                    var db = new Database();
                    String sqlSearch = "";
                    if (cbSearch.SelectedIndex == 0)
                    {
                        sqlSearch = "exec searchMaVatDung '" + valueSearch + "'";
                        if (db.SelectData(sqlSearch).Rows.Count != 0)
                        {
                            new FormSuppliesSearch(sqlSearch).Show();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (cbSearch.SelectedIndex == 1)
                    {
                        sqlSearch = "exec searchTenVatDung N'" + valueSearch + "'";
                        if (db.SelectData(sqlSearch).Rows.Count != 0)
                        {
                            new FormSuppliesSearch(sqlSearch).Show();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (cbSearch.SelectedIndex == 2)
                    {
                        sqlSearch = "exec searchMaPhong '" + valueSearch + "'";
                        if (db.SelectData(sqlSearch).Rows.Count != 0)
                        {
                            new FormSuppliesSearch(sqlSearch).Show();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (cbSearch.SelectedIndex == 3)
                    {
                        sqlSearch = "exec searchTenTacGia N'" + valueSearch + "'";
                        if (db.SelectData(sqlSearch).Rows.Count != 0)
                        {
                            new FormSuppliesSearch(sqlSearch).Show();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                resetValue();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            (new ThemVatDung(null, suppliesDgv)).ShowDialog();
            reload();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var db = new Database();
            if (MessageBox.Show("Bạn muốn xóa sách " + suppliesDgv.CurrentRow.Cells["TenVatDung"].Value.ToString() + " ?", "Warning!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.del_Supplies(suppliesDgv.CurrentRow.Cells["MaVatDung"].Value.ToString());
            }

            reload();
        }

        private void suppliesDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maVatDung = suppliesDgv.Rows[e.RowIndex].Cells["MaVatDung"].Value.ToString();
                new ThemVatDung(maVatDung, suppliesDgv).ShowDialog();
                reload();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
