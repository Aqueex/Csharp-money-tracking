using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coin_Takip_Programı
{
    public partial class Kayıtform : Form
    {
        public Kayıtform()
        {
            InitializeComponent();
        }
       

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TextBox1_Validating(object sender, CancelEventArgs e)
        {
        }

        private void guna2TextBox3_Validating(object sender, CancelEventArgs e)
        {
        }

        private void guna2TextBox2_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Kayıtform_Load(object sender, EventArgs e)
        {
            TxtKytsifre.PasswordChar = '*';




        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");

                Form1 fm = new Form1();
                
                paralistesi pr = new paralistesi();
                Method aquex2 = new Method();
                MySqlConnection baglanti = new MySqlConnection(connetstring.ConnetSt);

                string kaydet = "INSERT INTO frigosLogin (fusername,femail,fpassword,ftarih) VALUES (@usr,@emai,@pass,@cd)";
                MySqlCommand kmtkaydet = new MySqlCommand(kaydet, baglanti);
                kmtkaydet.Parameters.AddWithValue("usr", TxtKytAd.Text);
                kmtkaydet.Parameters.AddWithValue("emai", TxtKytPosta.Text);
                kmtkaydet.Parameters.AddWithValue("pass", TxtKytsifre.Text);
                kmtkaydet.Parameters.AddWithValue("cd", guna2DateTimePicker1.Value);
                baglanti.Open();
                kmtkaydet.ExecuteNonQuery();
                MessageBox.Show("Kayıt Başarılı Login Sayfasına Yönlendiriliyorsunuz");
                fm.Show();
                this.Hide();
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void KytSifre_CheckedChanged(object sender, EventArgs e)
        {
            if (KytSifre.Checked == true)
            {
                TxtKytsifre.PasswordChar = '\0';
            }
            else
            {
                TxtKytsifre.PasswordChar = '*';       
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }
    }
}
