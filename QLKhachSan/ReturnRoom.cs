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
using static QLKhachSan.Database;

namespace QLKhachSan
{
    public partial class ReturnRoom : Form
    {
        public ReturnRoom()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {            
            dataGridView1.DataSource = new Database().SelectData("select * from THUE where MaPhong = '" + txtSearch.Text + "' and NgayDi is null");                       
        }

        private void ReturnRoom_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            txtSearch.Clear();
        }

        string maKH;
        string ngayDen;
        string rowid;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Visible = true;

            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                rowid = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                maKH = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                ngayDen = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            txtMaKH.Text = maKH;
            txtRentDate.Text = ngayDen;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "data source = LAPCUATUNG; database = QLKhachSan; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            conn.Open();

            cmd.CommandText = "update THUE set NgayDi = '" + dtpReturn.Value + "' where MaPhong ='" + txtSearch.Text + "' and MaDK = '" + rowid + "'";
            cmd.ExecuteNonQuery();

            conn.Close();

            MessageBox.Show("Trả Phòng Thành Công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ReturnRoom_Load(this, null);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                panel2.Visible = false;
                dataGridView1.DataSource = null;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }

        private void ReturnRoom_Load_1(object sender, EventArgs e)
        {

        }
    }       
}
