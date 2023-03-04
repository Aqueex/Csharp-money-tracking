using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Coin_Takip_Programı
{
    public partial class paralistesi : Form
    {
        public paralistesi()
        {
            InitializeComponent();
        }
        public void degis(string al, string sat, string kod)
        {
            try
            {
                MySqlConnection baglanti = new MySqlConnection(connetstring.ConnetSt);
                string kaydet = "INSERT INTO money (fgalıs,fgsatıs,fgsaveDate,fgKoduFK,fidFK) VALUES (@al,@sat,@save,@kod,@id)";
                MySqlCommand kmtkaydet = new MySqlCommand(kaydet, baglanti);
                kmtkaydet.Parameters.AddWithValue("al", al);
                kmtkaydet.Parameters.AddWithValue("sat", sat);
                kmtkaydet.Parameters.AddWithValue("kod", kod);
                kmtkaydet.Parameters.AddWithValue("id", label23.Text);
                kmtkaydet.Parameters.AddWithValue("save", dateTimePicker1.Value);
                label26.Visible = true;
                label26.Text = "Bilgiler Kaydedildi " + kod;
                baglanti.Open();
                kmtkaydet.ExecuteNonQuery();
            }
            catch (Exception a)
            {

                MessageBox.Show(a.Message);
            }
            
        }
        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void paralistesi_Load(object sender, EventArgs e)
        {
            try
            {

                if (NetworkInterface.GetIsNetworkAvailable() == true)
                {
                    string today = "http://www.tcmb.gov.tr/kurlar/today.xml";

                    var xmlDoc = new XmlDocument();
                    xmlDoc.Load(today);

                    // Xml içinden tarihi alma - gerekli olabilir
                    DateTime exchangeDate = Convert.ToDateTime(xmlDoc.SelectSingleNode("//Tarih_Date").Attributes["Tarih"].Value);

                    string USDBUY = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/ForexBuying").InnerXml;
                    string USDsell = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/ForexSelling").InnerXml;

                    string EUROBUY = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/ForexBuying").InnerXml;
                    string EUROSELL = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/ForexSelling").InnerXml;

                    string POUNDBUY = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/ForexBuying").InnerXml;
                    string POUNDSELL = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/ForexSelling").InnerXml;

                    string CNYBUY = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='CNY']/ForexBuying").InnerXml;
                    string CNYSELL = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='CNY']/ForexSelling").InnerXml;

                    string AZNBUY = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='AZN']/ForexBuying").InnerXml;
                    string AZNSELL = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='AZN']/ForexSelling").InnerXml;

                    string BGNBUY = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='BGN']/ForexBuying").InnerXml;
                    string BGNSELL = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='BGN']/ForexSelling").InnerXml;

                    string IRRBUY = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='IRR']/ForexBuying").InnerXml;
                    string IRRSELL = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='IRR']/ForexSelling").InnerXml;

                    string CHFBUY = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='CHF']/ForexBuying").InnerXml;
                    string CHFSELL = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='CHF']/ForexSelling").InnerXml;

                    string KWDBUY = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='KWD']/ForexBuying").InnerXml;
                    string KWDSELL = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='KWD']/ForexSelling").InnerXml;

                    label20.Text = USDBUY;
                    label1.Text = USDsell;

                    label2.Text = EUROBUY;
                    label19.Text = EUROSELL;

                    label4.Text = POUNDBUY;
                    label18.Text = POUNDSELL;

                    label3.Text = CNYBUY;
                    label17.Text = CNYSELL;

                    label8.Text = AZNBUY;
                    label16.Text = AZNSELL;

                    label7.Text = BGNBUY;
                    label15.Text = BGNSELL;

                    label6.Text = IRRBUY;
                    label14.Text = IRRSELL;

                    label10.Text = CHFBUY;
                    label12.Text = CHFSELL;

                    label9.Text = KWDBUY;
                    label11.Text = KWDSELL;
                }
            }
            catch (Exception a)
            {

                MessageBox.Show(a.Message);
            }
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
         
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
     
            degis(label1.Text,label20.Text,usdtxt.Text);
        }
       
        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            degis(label2.Text, label19.Text, eurotxt.Text);
        }

        private void guna2PictureBox3_Click_1(object sender, EventArgs e)
        {
            degis(label4.Text, label18.Text, gbptxt.Text);
        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            degis(label3.Text, label17.Text, cyntxt.Text);

        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {
            degis(label8.Text, label16.Text, azntxt.Text);

        }

        private void guna2PictureBox6_Click(object sender, EventArgs e)
        {
            degis(label7.Text, label15.Text, bgntxt.Text);
        }

        private void guna2PictureBox7_Click(object sender, EventArgs e)
        {
            degis(label6.Text, label14.Text, ırrtxt.Text);
        }

        private void guna2PictureBox8_Click(object sender, EventArgs e)
        {
            degis(label10.Text, label12.Text, chftxt.Text);

        }

        private void guna2PictureBox9_Click(object sender, EventArgs e)
        {
            degis(label9.Text, label11.Text, kwdtxt.Text);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            kayıtlıveriler ky = new kayıtlıveriler();
            ky.Show();
            ky.label1.Text = label23.Text;

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ayarlarcs ayar = new ayarlarcs();
            ayar.Show();
            this.Close();
            ayar.label1.Text = label23.Text;
        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            kayıtlıveriler ky = new kayıtlıveriler();
            ky.Show();
            ky.label1.Text = label23.Text;
        }

        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }
    }
}
