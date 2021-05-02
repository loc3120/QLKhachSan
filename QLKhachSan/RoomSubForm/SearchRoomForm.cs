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
    public partial class SearchRoomForm : Form
    {
        string sqlSearch;
        public SearchRoomForm(string sql)
        {
            InitializeComponent();
            sqlSearch = sql;
        }
        private void LoadInformation()
        {
            roomSearchDgv.DataSource = new Database().SelectData(sqlSearch);
        }

        private void SearchRoomForm_Load(object sender, EventArgs e)
        {
            LoadInformation();
        }
    }
}
