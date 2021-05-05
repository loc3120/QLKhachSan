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
    public partial class FormSuppliesSearch : Form
    {
        string sqlSearch;
        public FormSuppliesSearch()
        {
            InitializeComponent();
        }
        public FormSuppliesSearch(string sql)
        {
            sqlSearch = sql;
            InitializeComponent();
        }

        private void LoadSupplies()
        {
            dvgSearch.DataSource = null;
            dvgSearch.DataSource = new Database().SelectData(sqlSearch);
            dvgSearch.Columns["MaVatDung"].HeaderText = "Mã vật dụng";
            dvgSearch.Columns["TenVatDung"].HeaderText = "Tên vật dụng";
            dvgSearch.Columns["GiaTienSuDung"].HeaderText = "Giá tiền sử dụng";
            dvgSearch.Columns["MaPhong"].HeaderText = "Mã phòng";
        }

        private void FormSuppliesSearch_Load(object sender, EventArgs e)
        {
            LoadSupplies();
        }
    }
}
