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
    public partial class SearchGuest : Form
    {
        string sqlSearch;
        public SearchGuest(string sql)
        {
            InitializeComponent();
            sqlSearch = sql;
        }

        private void LoadInformation()
        {
            dataGridView1.DataSource = new Database().SelectData(sqlSearch);
        }

        private void SearchGuest_Load(object sender, EventArgs e)
        {
            LoadInformation();
        }
    }
}
