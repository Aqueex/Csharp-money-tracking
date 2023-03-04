using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coin_Takip_Programı
{
    public partial class kayıtlıveriler : Form
    {
        public kayıtlıveriler()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string adı = "", alıs = "", satıs = "", tarih = "";
            MySqlConnection baglanti = new MySqlConnection(connetstring.ConnetSt);
            baglanti.Open();
            MySqlCommand cmd = new MySqlCommand("Select * from money where fidFK=@deger ", baglanti);
            cmd.Parameters.AddWithValue("@deger", label1.Text);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                adı = dr["fgKoduFK"].ToString();
                alıs = dr["fgalıs"].ToString();
                satıs = dr["fgsatıs"].ToString();
                tarih = dr["fgSaveDate"].ToString();
            }
            label2.Text = adı;
            label3.Text = alıs;
            label4.Text = satıs;
            label5.Text = tarih;
            dr.Close();
            cmd.Dispose();
            baglanti.Close();
        }
      
        private void kayıtlıveriler_Load(object sender, EventArgs e)
        {

            timer1.Start();
            timer2.Start();
            timer3.Start();

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection(connetstring.ConnetSt);
            //string km = "select * from money";
            //MySqlCommand mycom = new MySqlCommand(km,baglanti);
            //MySqlDataAdapter adap = new MySqlDataAdapter(km,baglanti);
            //DataTable dt = new DataTable();
            //adap.Fill(dt);
            //bunifuCustomDataGrid1.DataSource = dt;
            //baglanti.Open();
            //MySqlDataReader mydr = mycom.ExecuteReader();
            //baglanti.Close();

            string kayit = "SELECT * from money where fidFK=@id";
            MySqlCommand komut = new MySqlCommand(kayit, baglanti);
            komut.Parameters.AddWithValue("@id", label1.Text);
            MySqlDataAdapter da = new MySqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            guna2DataGridView1.DataSource = dt;
            this.guna2DataGridView1.Columns["moneyId"].Visible = false;
            this.guna2DataGridView1.Columns["fidFK"].Visible = false;
            guna2DataGridView1.Columns["fgalıs"].HeaderText = "Alış";
            guna2DataGridView1.Columns["fgsatıs"].HeaderText = "Satış";
            guna2DataGridView1.Columns["fgsavedate"].HeaderText = "Kayıt Tarihi";
            guna2DataGridView1.Columns["fgkoduFK"].HeaderText = "Para Kodu";

            baglanti.Close();


        }

        private void data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult cikis = new DialogResult();
            cikis = MessageBox.Show("Silme işlemine devam etmek istiyor musunuz ?", "Frigos ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); //Uyarı penceresi göster.
            if (cikis == DialogResult.Yes)
            {
                try
                {
                    

                    MySqlConnection baglanti = new MySqlConnection(connetstring.ConnetSt);
                    baglanti.Open();

                    MySqlCommand kmt = new MySqlCommand("DELETE FROM money WHERE moneyId = '" + guna2DataGridView1.CurrentRow.Cells["moneyId"].Value.ToString() + "'", baglanti);

                    kmt.ExecuteNonQuery();
                    baglanti.Close();
                    timer2.Start();


                }
                catch//Hata oluşursa
                {
                    MessageBox.Show("Silme gerçekleşmedi!\n"); //Hata mesajı
                }
            }
        }
    }
}
