using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKhachSan
{
    public partial class AddGuest : Form
    {
        private string maKH;
        public AddGuest()
        {
            InitializeComponent();
        }

        public AddGuest(string maKH)
        {
            this.maKH = maKH;
            InitializeComponent();
        }

        private void AddGuest_Load(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(maKH))
            {
                this.Text = "Thêm Khách Hàng";
            }    
            else
            {
                this.Text = "Cập nhật thông tin khách hàng";

                var r = new Database().Select(string.Format("SelectKHByID '" + maKH + "'"));

                txtName.Text = r["HoTen"].ToString();
                dateTimePicker1.Text = r["Ngaysinh"].ToString();
                if(r["GioiTinh"].ToString() == "Nam")
                {
                    rbtNam.Checked = true;
                }
                else
                {
                    rbtNu.Checked = true;
                }
            }    
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql;
            string TenKH = txtName.Text;
            DateTime NgaySinh = dateTimePicker1.Value;
            string GT = rbtNam.Checked ? "Nam" : "Nữ";

            List<CustomParameter> lstPara = new List<CustomParameter>();
            if(string.IsNullOrEmpty(maKH))
            {
                sql = "InsertKhach";
            }
            else
            {
                sql = "UpdateKHACHHANG";
                lstPara.Add(new CustomParameter()
                {
                    key = "@maKH",
                    value = maKH
                }) ;
            }

            lstPara.Add(new CustomParameter()
            {
                key = "@tenKH",
                value = TenKH
            }) ;

            lstPara.Add(new CustomParameter()
            {
                key = "@NS",
                value = NgaySinh.ToString("yyyy-MM-dd")
            });

            lstPara.Add(new CustomParameter()
            {
                key = "@GT",
                value = GT
            });

            var rs = new Database().ExeCute(sql, lstPara);
            if (rs == 1)
            {
                if (string.IsNullOrEmpty(maKH))
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
