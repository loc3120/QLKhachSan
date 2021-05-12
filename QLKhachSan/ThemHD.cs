using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKhachSan
{
    public partial class ThemHD : Form
    {
        private string maHoaDon;
        private DataGridView dgv;
        public ThemHD()
        {
            InitializeComponent();
        }

        public ThemHD(string maHoaDon, DataGridView dgv)
        {
            this.maHoaDon = maHoaDon;
            this.dgv = dgv;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ThemHD_Load(object sender, EventArgs e)
        {
            var csdl = new Database();

            string getAllKH = "SELECT MaKH FROM KhachHang";
            DataTable maKHTable = csdl.SelectData(getAllKH);
            cbbMaKH.DataSource = maKHTable.Copy();
            cbbMaKH.DisplayMember = "MaKH";
            cbbMaKH.ValueMember = "MaKH";


            cbbMaKH_SelectedIndexChanged(sender, e);


            string getAllDV = "SELECT Tendv FROM dichvu";
            DataTable tendvTable = csdl.SelectData(getAllDV);
            cbbDichVu.DataSource = tendvTable.Copy();
            cbbDichVu.DisplayMember = "TenDV";
            cbbDichVu.ValueMember = "TenDV";

            string getAllVD = "SELECT TenVatDung FROM VATDUNG";
            DataTable tenVDTable = csdl.SelectData(getAllVD);
            cbbVatDung.DataSource = tenVDTable.Copy();
            cbbVatDung.DisplayMember = "Tenvatdung";
            cbbVatDung.ValueMember = "Tenvatdung";

            if (string.IsNullOrEmpty(maHoaDon))
            {
                this.Text = "Thêm hóa đơn";
            }
            else
            {
                this.Text = "Sửa hóa đơn";
                string getAllKH1 = "SELECT kh.MaKH FROM KhachHang kh, HOADON hd where hd.makh=kh.makh and hd.mahd='" + maHoaDon + "'";
                DataTable maKHTable1 = csdl.SelectData(getAllKH1);
                cbbMaKH.DataSource = maKHTable1.Copy();
                cbbMaKH.DisplayMember = "MaKH";
                cbbMaKH.ValueMember = "MaKH";


                cbbMaKH_SelectedIndexChanged(sender, e);


                cbbDichVu_SelectedIndexChanged(sender, e);

                cbbVatDung_SelectedIndexChanged(sender, e);



            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            var db = new Database();

            string txtMaPhong = cbbMaPhong.Text;
            string txtMaKH = cbbMaKH.Text;
            string txtTenDV = cbbDichVu.Text;
            string txtTenVD = cbbVatDung.Text;

            int sldv = Int32.Parse(nudSL1.Value.ToString());
            int slvd = Int32.Parse(nudSL2.Value.ToString());

            var tmp = db.SelectData("select dbo.tien ('" + txtMaKH + "','" + txtMaPhong + "','" + maHoaDon + "')");
            textBox1.Text= tmp.Rows[0].ItemArray[0].ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            var db = new Database();
            string txtMaPhong = cbbMaPhong.Text;
            string txtMaKH = cbbMaKH.Text;
            string txtTenDV = cbbDichVu.Text;
            string txtTenVD = cbbVatDung.Text;

            int sldv = Int32.Parse(nudSL1.Value.ToString());
            int slvd = Int32.Parse(nudSL2.Value.ToString());

            string sqladd = "exec test '" + txtMaKH + "','" + txtMaPhong + "',N'" + txtTenDV + "',N'" + txtTenVD + "'," + slvd.ToString() + "," + sldv.ToString() + "";

            if (string.IsNullOrEmpty(maHoaDon))
            {
                db.SelectData(sqladd);
                MessageBox.Show("Thêm mới thành công");
            }
            else
            {
                string sqledit = "exec testedit '" + maHoaDon + "','" + txtMaKH + "','" + txtMaPhong + "',N'" + txtTenDV + "',N'" + txtTenVD + "'," + slvd.ToString() + "," + sldv.ToString() + "";
                textBox1.Text = sqledit;
                db.SelectData(sqledit);
                MessageBox.Show("Cập nhật thành công");
            }


        }

        private void cbbMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            var csdl = new Database();
            string getAllMaPhong = "SELECT p.MaPhong FROM PHONG p , thue t, KHACHHANG k where p.MaPhong=t.MaPhong and t.MaKH=k.MaKH and k.MaKH='" + cbbMaKH.Text + "'";
            DataTable maPhongTable = csdl.SelectData(getAllMaPhong);
            cbbMaPhong.DataSource = maPhongTable.Copy();
            cbbMaPhong.DisplayMember = "MaPhong";
            cbbMaPhong.ValueMember = "MaPhong";
        }

        private void nudSL1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void nudSL2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbbDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbbVatDung_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
