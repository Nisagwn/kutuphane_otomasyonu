using DevExpress.XtraGrid;
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
    public partial class FrmArama : Form
    {
        public FrmArama()
        {
            InitializeComponent();
        }
        kutuphaneotomasyonEntities db = new kutuphaneotomasyonEntities();


        private void simpleButton1_Click(object sender, EventArgs e) //arama_click() metodu
        {

            
            
            string kaynakAd = txtKaynakAd.Text.Trim();
            string yazarAd = txtYazarAd.Text.Trim();
            string uyeAd = txtUyeAd.Text.Trim();
            string uyeTc = txtUyeTc.Text.Trim();
            string personelTc = txtPersonelTc.Text.Trim();

            // Arama işlemi
            if (!string.IsNullOrEmpty(kaynakAd))
            {
                // Kaynak adına göre arama
                var kayit = db.Tbl_Kitaplar
                              .Where(x => x.kaynak_ad.Contains(kaynakAd))
                              .ToList();
                gridControl2.DataSource = kayit;
            }
            else if (!string.IsNullOrEmpty(yazarAd))
            {
                // Yazar adına göre arama
                var kayit = db.Tbl_Kitaplar
                              .Where(x => x.kaynak_yazar.Contains(yazarAd))
                              .ToList();
                gridControl2.DataSource = kayit;
            }
            else if (!string.IsNullOrEmpty(uyeAd))
            {
                // Üye adına göre arama
                var uye = db.Tbl_Uyeler
                            .Where(x => x.uye_ad.Contains(uyeAd))
                            .ToList();
                gridControl3.DataSource = uye;
            }
            else if (!string.IsNullOrEmpty(uyeTc))
            {
                // Üye TC'ye göre arama
                var uye = db.Tbl_Uyeler
                            .Where(x => x.uye_tc.Contains(uyeTc))
                            .ToList();
                gridControl3.DataSource = uye;
            }
            else if (!string.IsNullOrEmpty(personelTc))
            {
                // Personel TC'ye göre arama
                var personel = db.Tbl_Personeller
                                 .Where(x => x.person_tc.Contains(personelTc))
                                 .ToList();
                gridControl4.DataSource = personel;
            }
            else
            {
                MessageBox.Show("Lütfen bir arama kriteri giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }
            
        }

        private void FrmArama_Load(object sender, EventArgs e)
        {

        }
    }
}
