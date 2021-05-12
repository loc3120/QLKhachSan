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
    public partial class ServicesForm : Form
    {
        public ServicesForm()
        {
            InitializeComponent();
        }

        private void getAllService(ObjectCommonSearch search)
        {
            string sql = "SELECT ";
            sql += "MaDV as [Mã dịch vụ], ";
            sql += "TenDV as [Tên dịch vụ], ";
            sql += "GiaSuDung as [Gía sử dụng] ";
            sql += "FROM DICHVU ";
            sql += "WHERE 1 = 1 ";
            if (!string.IsNullOrEmpty(search.String1))
            {
                sql += "AND LOWER(TenDV) LIKE LOWER(N'%" + search.String1 + "%') ";
            }
            if (search.Int1 > 0 && search.Int2 > 0)
            {
                sql += "AND GiaSuDung between " + search.Int1 + " and " + search.Int2;
            }
            servicesDgv.DataSource = new Database().SelectData(sql);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            (new ThemDichVu(null)).ShowDialog();
            ObjectCommonSearch search = new ObjectCommonSearch();
            getAllService(search);
        }

        private void ServicesForm_Load(object sender, EventArgs e)
        {
            ObjectCommonSearch search = new ObjectCommonSearch();
            getAllService(search);
        }

        private void servicesDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maDV = servicesDgv.Rows[e.RowIndex].Cells["Mã dịch vụ"].Value.ToString();
                new ThemDichVu(maDV).ShowDialog();
                ObjectCommonSearch search = new ObjectCommonSearch();
                getAllService(search);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ObjectCommonSearch search = new ObjectCommonSearch();
            search.String1 = txbSearch.Text;
            search.Int1 = (int)nudGiaMin.Value;
            search.Int2 = (int)nudGiaMax.Value;
            getAllService(search);
        }
    }
}
