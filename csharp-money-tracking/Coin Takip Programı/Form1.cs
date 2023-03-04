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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Kayıtform kytform = new Kayıtform();
        //ConnetDB aquex = new ConnetDB();
        paralistesi pr = new paralistesi();
        //Method aquex2 = new Method();
        //MySqlCommand cmd;
        //MySqlDataReader dr;



        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
             sifre.PasswordChar = '*';



        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

       
        
        ayarlarcs ayrr = new ayarlarcs();
        kayıtlıveriler ky = new kayıtlıveriler();
        Method mt = new Method();
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (mt.KullanıcıKontrol(Kullanıcı_Adı.Text, sifre.Text) == 1)
                {
                    string  id = "";
                    MySqlConnection baglanti = new MySqlConnection(connetstring.ConnetSt);
                    baglanti.Open();
                    MySqlCommand cmd = new MySqlCommand("Select * from frigoslogin where fpassword=@deger ", baglanti);
                    cmd.Parameters.AddWithValue("@deger", sifre.Text);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                       
                        id = dr["fid"].ToString();

                    }
                    dr.Close();
                    cmd.Dispose();
                    baglanti.Close();
                    pr.label23.Text = id;
                    pr.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı veya Şifre Yanlıştır");
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }
        }

        private void guna2HtmlLabel4_Click_1(object sender, EventArgs e)
        {
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            İntro baslangıc = new İntro();
            baslangıc.Close();

            Application.Exit();



    }

        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void NameOnay_CheckedChanged(object sender, EventArgs e)
        {
            if (girisSifre.Checked == true)
            {
                sifre.PasswordChar = '\0';

            }
            else
            {
                sifre.PasswordChar = '*';

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            kytform.Show();
            this.Hide();
        }
    }
}
