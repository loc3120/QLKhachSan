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
    public partial class SearchHD : Form
    {
        string sqlSearch;
        public SearchHD()
        {
            InitializeComponent();
        }

        public SearchHD(string sqlSearch)
        {
            this.sqlSearch = sqlSearch;
            InitializeComponent();
        }

        private void LoadInformation()
        {
            dataGridView1.DataSource = new Database().SelectData(sqlSearch);
        }

        private void SearchHD_Load(object sender, EventArgs e)
        {
            LoadInformation();
        }
    }
}
