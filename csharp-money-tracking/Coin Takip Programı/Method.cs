using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace Coin_Takip_Programı
{
    class Method
    {
        

        public int KullanıcıKontrol(string kAd, string kSf)
        {
            MySqlConnection baglanti = new MySqlConnection(connetstring.ConnetSt);

            int sonuc = 0;
            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM frigoslogin where fusername='{kAd}' AND fpassword='{kSf}'", baglanti);

            try
            {
                cmd.Connection.Open();
                MySqlDataReader dtr = cmd.ExecuteReader();
                if (dtr.Read())
                {
                    string d_k = dtr["fusername"].ToString();
                    string d_s = dtr["fpassword"].ToString();
                    if (d_k == kAd && d_s == kSf)
                    {
                        sonuc = 1;
                    }
                    else
                    {
                        sonuc = 0;
                    }
                }


            }
            catch (Exception hata)
            {
                System.Windows.Forms.MessageBox.Show(hata.Message);
                sonuc = 0;
            }
            return sonuc;
        }
    }
}
