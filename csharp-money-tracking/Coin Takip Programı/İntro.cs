using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coin_Takip_Programı
{
    public partial class İntro : Form
    {
        public İntro()
        {
            InitializeComponent();
        }
        bool islem;
        Form1 giris = new Form1();
        private void İntro_Load(object sender, EventArgs e)
        {
          

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!islem)
            {
                this.Opacity += 0.010;
            }
            if (this.Opacity == 1.0)
            {
                islem = true;
            }
            if (islem)
            {
                this.Opacity -= 0.010;
            }
            if (this.Opacity == 0)
            {
                this.Hide();

                giris.Show();
                timer1.Enabled = false;
            }
            
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
           
        }
    }
}
