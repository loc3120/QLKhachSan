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
    public partial class ThemDichVu : Form
    {
        private string maDV;

        public ThemDichVu(string maDV)
        {
            this.maDV = maDV;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string sql;
            string tenDV = tbTenDichVu.Text;
            string gia = nudGia.Value.ToString();

            List<CustomParameter> lstPara = new List<CustomParameter>();

            if (string.IsNullOrEmpty(maDV))
            {
                sql = "InsertDV";
            }
            else
            {
                sql = "UpdateDV";
                lstPara.Add(new CustomParameter()
                {
                    key = "@maDV",
                    value = maDV
                });
            }

            lstPara.Add(new CustomParameter()
            {
                key = "@tenDV",
                value = tenDV
            });

            lstPara.Add(new CustomParameter()
            {
                key = "@gia",
                value = gia
            });


            var rs = new Database().ExeCute(sql, lstPara);
            if (rs > 0)
            {
                if (string.IsNullOrEmpty(maDV))
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

        private void ThemDichVu_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maDV))
            {
                this.Text = "Thêm dịch vụ";
            }
            else
            {
                var r = new Database().Select(string.Format("SELECT MaDV, TenDV, GiaSuDung FROM DICHVU WHERE MaDV = '" + maDV + "'"));

                string tenDV = r["TenDV"].ToString();
                tbTenDichVu.Text = tenDV;
                string gia = r["GiaSuDung"].ToString();
                nudGia.Value = int.Parse(gia);

                this.Text = "Cập nhật dịch vụ";
            }
        }
    }
}
