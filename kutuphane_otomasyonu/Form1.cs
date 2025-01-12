using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kutuphane_otomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
            // Veritabanı bağlamı oluşturma
         kutuphaneotomasyonEntities dbo = new kutuphaneotomasyonEntities();

      

        private void girisbtn_Click(object sender, EventArgs e)
        {
          
            string gelenad = personel_ad.Text;
            string gelensifre = personel_sifre.Text;

            // LINQ sorgusu kullanılarak kullanıcı bilgilerini kontrol etme
            var personel = (from p in dbo.Tbl_Personeller
                            where p.person_ad == gelenad && p.person_sifre == gelensifre
                            select p).FirstOrDefault();

            if (personel == null)
            {
                MessageBox.Show("KULLANICI ADI VEYA ŞİFRE HATALI");
            }
            else
            {
                MessageBox.Show("GİRİŞ BAŞARILI");
                anasayfa anasayfa = new anasayfa();
                anasayfa.Show();

                // Mevcut formu gizle
                this.Hide();

                // Eğer tamamen kapatmak istersen:
                 //this.Close();

            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
