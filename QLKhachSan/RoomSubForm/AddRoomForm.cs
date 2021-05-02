using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKhachSan.RoomSubForm
{
    public partial class AddRoomForm : Form
    {
        private string maPhong;
        public AddRoomForm(string maPhong)
        {
            InitializeComponent();
            this.maPhong = maPhong;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql;
            string tenPhong = txbRoomName.Text;
            string loaiPhong = cbRoomCategory.SelectedItem.ToString();
            string giaPhong = txbRoomPrice.Text;

            List<CustomParameter> lstPara = new List<CustomParameter>();
            if (string.IsNullOrEmpty(maPhong))
            {
                sql = "InsertPhong";
            }
            else
            {
                sql = "UpdatePhong";
                lstPara.Add(new CustomParameter()
                {
                    key = "@maPhong",
                    value = maPhong
                });
            }
            lstPara.Add(new CustomParameter()
            {
                key = "@tenPhong",
                value = tenPhong
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@loaiPhong",
                value = loaiPhong
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@giaThue1Ngay",
                value = giaPhong
            });

            var rs = new Database().ExeCute(sql, lstPara);
            if (rs == 1)
            {

                if (string.IsNullOrEmpty(maPhong))
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

        private void AddRoomForm_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maPhong))
            {
                this.Text = "Thêm Phòng";
            }
            else
            {
                var r = new Database().Select(string.Format("SelectPhongByID'" + maPhong + "'"));
                txbRoomName.Text = r["TenPhong"].ToString();
                cbRoomCategory.SelectedItem = r["LoaiPhong"].ToString();
                txbRoomPrice.Text = r["GiaThue1Ngay"].ToString();
            }
        }
    }
}
