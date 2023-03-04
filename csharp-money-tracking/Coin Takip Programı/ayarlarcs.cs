using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coin_Takip_Programı
{
    public partial class ayarlarcs : Form
    {
        public ayarlarcs()
        {
            InitializeComponent();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                    }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (label6.Text == TxtNameOnay.Text)
                {
                    paralistesi pr = new paralistesi();
                    Form1 fm = new Form1();
                    MySqlConnection baglanti = new MySqlConnection(connetstring.ConnetSt);
                    baglanti.Open();
                    MySqlCommand kmt = new MySqlCommand("Update frigoslogin Set fusername=@user Where fid='" + label1.Text + "'", baglanti);

                    kmt.Parameters.AddWithValue("@user", TxtKytAd.Text);
                    kmt.ExecuteNonQuery();
                    baglanti.Close();
                    string asd = TxtKytAd.Text;
                    MessageBox.Show($"Kullanıcı İsmi Başarılıyla {asd} Olarak Degiştirildi, Lütfen Tekrar Giriş Yapınız", "Frigos");
                    fm.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lütfen Şifreyi Eksiksiz Giriniz");
                }
            }
            catch (Exception a)
            {

                MessageBox.Show("Error" + a.Message);
            }
          
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (sf.Text == sf1.Text)
                {
                    if (sf.Text != " " && sf1.Text != " ")
                    {
                        Form1 fm = new Form1();

                        MySqlConnection baglanti = new MySqlConnection(connetstring.ConnetSt);
                        baglanti.Open();
                        MySqlCommand kmt = new MySqlCommand("Update frigoslogin Set fpassword=@sifre Where fid='" + label1.Text + "'", baglanti);

                        kmt.Parameters.AddWithValue("@sifre", sf.Text);
                        kmt.ExecuteNonQuery();

                        baglanti.Close();
                        MessageBox.Show($"Şifre İsmi Başarılıyla Degiştirildi, Lütfen Tekrar Giriş Yapınız", "Frigos");

                        fm.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Lütfen Boş Alan Bırakmayınız");
                    }
                }
                else
                {
                    MessageBox.Show("Şifreler Eşleşmiyor");
                }
            }
            catch (Exception a)
            {

                MessageBox.Show(a.Message);
            }
            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ayarlarcs_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            sf.PasswordChar = '*';
            sf1.PasswordChar = '*';
            TxtNameOnay.PasswordChar = '*';
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                string ad = "";
                MySqlConnection baglanti = new MySqlConnection(connetstring.ConnetSt);
                baglanti.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from frigoslogin where fid=@deger ", baglanti);
                cmd.Parameters.AddWithValue("@deger", label1.Text);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ad = dr["fpassword"].ToString();
                }
                label6.Text = ad;
                dr.Close();
                cmd.Dispose();
                baglanti.Close();
            }
            catch (Exception aa)
            {
                MessageBox.Show("Error");
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            paralistesi pr = new paralistesi();
            pr.Show();
            this.Close();
            pr.label23.Text = label1.Text;
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                string ad = "", mail = "", date = "";
                MySqlConnection baglanti = new MySqlConnection(connetstring.ConnetSt);
                baglanti.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from frigoslogin where fid=@deger ", baglanti);
                cmd.Parameters.AddWithValue("@deger", label1.Text);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ad = dr["fusername"].ToString();
                    mail = dr["femail"].ToString();
                    date = dr["ftarih"].ToString();
                }
                label11.Text = ad;
                label12.Text = mail;
                label13.Text = date;
                dr.Close();
                cmd.Dispose();
                baglanti.Close();
            }
            catch (Exception aa)
            {
                MessageBox.Show("Error");
            }
        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (NewPassSw.Checked == true)
            {
                sf.PasswordChar = '\0';
                sf1.PasswordChar = '\0';
            }
            else
            {
                sf.PasswordChar = '*';
                sf1.PasswordChar = '*';
            }
        }

        private void NameOnay_CheckedChanged(object sender, EventArgs e)
        {
            if (NameOnay.Checked == true)
            {
                TxtNameOnay.PasswordChar = '\0';
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            paralistesi pl = new paralistesi();
            frm1.Show();
            this.Hide();
            pl.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            DialogResult cikis = new DialogResult();
            cikis = MessageBox.Show("Silme işlemine devam etmek istiyor musunuz ?", "Frigos ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); //Uyarı penceresi göster.
            if (cikis == DialogResult.Yes)
            {
                try
                {
                    Form1 frm1 = new Form1();

                    MySqlConnection baglanti = new MySqlConnection(connetstring.ConnetSt);
                    baglanti.Open();

                    MySqlCommand kmt = new MySqlCommand("DELETE FROM frigoslogin WHERE fid = '" + label1.Text + "'", baglanti);

                    kmt.ExecuteNonQuery();
                    baglanti.Close();
                    frm1.Show();

                    this.Close();
                    this.Close();
                    frm1.Show();


                }
                catch//Hata oluşursa
                {
                    MessageBox.Show("Silme gerçekleşmedi!\n"); //Hata mesajı
                }
            }
        }
    }
}
