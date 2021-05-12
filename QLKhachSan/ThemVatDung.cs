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
    public partial class ThemVatDung : Form
    {
        private string maVatDung;
        private DataGridView dgv;
        public ThemVatDung()
        {
            InitializeComponent();
        }
        public ThemVatDung(string maVatDung, DataGridView dgv)
        {
            this.maVatDung = maVatDung;
            this.dgv = dgv;
            InitializeComponent();
        }

        private void ThemVatDung_Load(object sender, EventArgs e)
        {
            var csdl = new Database();
            string getAllMaPhong = "SELECT MaPhong FROM PHONG";
            DataTable maPhongTable = csdl.SelectData(getAllMaPhong);
            cbbMaPhong.DataSource = maPhongTable.Copy();
            cbbMaPhong.DisplayMember = "MaPhong";
            cbbMaPhong.ValueMember = "MaPhong";
            if (string.IsNullOrEmpty(maVatDung))
            {
                this.Text = "Thêm vật dụng";
            }
            else
            {
                var r = new Database().Select(string.Format("searchMaVatDung '" + maVatDung + "'"));
                txtTenVatDung.Text = r["TenVatDung"].ToString();
                txtGiaTien.Text = r["GiaTienSuDung"].ToString();
                string maPhong = r["MaPhong"].ToString();
                cbbMaPhong.SelectedValue = maPhong;
                this.Text = "Chỉnh sửa vật dụng";
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            string tenVatDung = txtTenVatDung.Text;
            string giaTien = txtGiaTien.Text;
            string maPhong = cbbMaPhong.Text;

            List<CustomParameter> lstPara = new List<CustomParameter>();

            if (string.IsNullOrEmpty(maVatDung))
            {
                sql = "InsertVatDung";
            }
            else
            {
                sql = "UpdateVatDung";
                lstPara.Add(new CustomParameter()
                {
                    key = "@maVatDung",
                    value = maVatDung
                });
            }

            lstPara.Add(new CustomParameter()
            {
                key = "@tenVatDung",
                value = tenVatDung
            });

            lstPara.Add(new CustomParameter()
            {
                key = "@giaTien",
                value = giaTien
            });

            lstPara.Add(new CustomParameter()
            {
                key = "@maPhong",
                value = maPhong
            });


            var rs = new Database().ExeCute(sql, lstPara);
            if (rs == 1)
            {
                if (string.IsNullOrEmpty(maVatDung))
                {                   
                    MessageBox.Show("Thêm mới thành công");
                }
                else
                {
                    MessageBox.Show("Cập nhật thành công");
                }
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Thao tác không thành công");
            }
        }

        private void txtGiaTien_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cbbMaPhong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
