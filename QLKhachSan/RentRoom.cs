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
    public partial class RentRoom : Form
    {
        private string maThue;
        public RentRoom()
        {
            InitializeComponent();
        }

        public RentRoom(string maThue)
        {
            this.maThue = maThue;
            InitializeComponent();
        }

        private void RentRoom_Load(object sender, EventArgs e)
        {
            var csdl = new Database();

            string getMaKH = "exec selectMaKHforRent";
            DataTable maKHtbl = csdl.SelectData(getMaKH);
            cbbMaKH.DataSource = maKHtbl.Copy();
            cbbMaKH.DisplayMember = "MaKH";
            cbbMaKH.ValueMember = "MaKH";

            string getMaPH = "exec selectMaPHforRent";
            DataTable maPHtbl = csdl.SelectData(getMaPH);
            cbbMaPH.DataSource = maPHtbl.Copy();
            cbbMaPH.DisplayMember = "MaPhong";
            cbbMaPH.ValueMember = "MaPhong";

            if (string.IsNullOrEmpty(maThue))
            {
                this.Text = "Thuê Phòng";
            }
            else
            {
                var r = new Database().Select(string.Format("selectThuebyID '" + maThue + "'"));
                
                string maKH = r["MaKH"].ToString();
                cbbMaKH.SelectedValue = maKH;
                string maPH = r["MaPhong"].ToString();
                cbbMaPH.SelectedValue = maPH;
                dateTimePicker1.Text = r["NgayDen"].ToString();

                this.Text = "Cập nhật thuê phòng";
            }
        }

        private void btnRent_Click(object sender, EventArgs e)
        {
            string sql;
            string maKH = cbbMaKH.Text;
            string maPH = cbbMaPH.Text;
            DateTime NgayDen = dateTimePicker1.Value;

            List<CustomParameter> lstPara = new List<CustomParameter>();

            if (string.IsNullOrEmpty(maThue))
            {
                sql = "InsertTHUE";
            }
            else
            {
                sql = "UpdateTHUE";
                lstPara.Add(new CustomParameter()
                {
                    key = "@maThue",
                    value = maThue
                });
            }

            lstPara.Add(new CustomParameter()
            {
                key = "@MaKH",
                value = maKH
            });
          
            lstPara.Add(new CustomParameter()
            {
                key = "@MaPhong",
                value = maPH
            });

            lstPara.Add(new CustomParameter()
            {
                key = "@NgayDen",
                value = NgayDen.ToString("yyyy-MM-dd")
            });


            var rs = new Database().ExeCute(sql, lstPara);
            if (rs == 1)
            {
                if (string.IsNullOrEmpty(maThue))
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
