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
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new RoomForm().Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new SuppliesForm().Visible = true;
        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            new GuestForm().Visible = true;

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            new RentingForm().Visible = true;

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            new ServicesForm().Visible = true;

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            new CheckOutForm().Visible = true;

        }
    }
}
