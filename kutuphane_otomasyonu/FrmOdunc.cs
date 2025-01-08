using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kutuphane_otomasyonu
{
    public partial class FrmOdunc : Form
    {
        public FrmOdunc()
        {
            InitializeComponent();
        }
        kutuphaneotomasyonEntities db = new kutuphaneotomasyonEntities();
        void listeleOdunc()
        {
            var kayit = db.Tbl_Odunc.ToList();
            gridControl1.DataSource = kayit.ToList();
        }
        void listeleKitap()
        {
            var kayit = db.Tbl_Kitaplar.ToList();
            gridControl2.DataSource = kayit.ToList();
        }
        private void FrmOdunc_Load(object sender, EventArgs e)
        {
            var kitap = db.Tbl_Kitaplar.ToList();
            gridControl2.DataSource = kitap.ToList();

            var kayit = db.Tbl_Odunc.ToList();
            gridControl1.DataSource = kayit.ToList();
        }

        private void simpleButton1_Click(object sender, EventArgs e) //btnuyeara_click
        {
            string aranantc = txtUyeTc.Text;
            var bulunanKullanici = db.Tbl_Uyeler.Where(x => x.uye_tc.Equals(aranantc)).FirstOrDefault();
            if (bulunanKullanici != null)
            {
                txtUyeAd.Text = bulunanKullanici.uye_ad + " " + bulunanKullanici.uye_soyad;
            }
            else
            {
                MessageBox.Show("Kişi Bulunamadı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUyeAd.Text = "";
            }
        }
        //Ödünç verme
        private void simpleButton2_Click(object sender, EventArgs e) //btnoduncver_click
        {
            //TC'nin alınması
            string gelenTC = txtUyeTc.Text;
            var secilenKisi = db.Tbl_Uyeler.Where(x => x.uye_tc.Equals(gelenTC)).FirstOrDefault();
            //Kitap id'sinin alınması
            var gridView = gridControl2.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            int secilenKitapId = Convert.ToInt32(gridView.GetRowCellValue(gridView.FocusedRowHandle, gridView.Columns[0]));
            var secilenKitap = db.Tbl_Kitaplar.Where(x => x.kaynak_id == secilenKitapId).FirstOrDefault();
            MessageBox.Show("Seçilen kitap ödünç verildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Ödünç tablosunda yeni kayıt 
            Tbl_Odunc yeniOdunc = new Tbl_Odunc();
            yeniOdunc.kitap_id = secilenKitap.kaynak_id;
            yeniOdunc.kullanici_id = secilenKisi.uye_id;
            yeniOdunc.alis_tarih = DateTime.Today;
            yeniOdunc.veris_tarih = DateTime.Today.AddDays(1);
            yeniOdunc.durum = false;
            db.Tbl_Odunc.Add(yeniOdunc);
            secilenKitap.kaynak_okumaSayisi += 1;
            db.SaveChanges();

            //Ödünç tablosunda yeni tablonun listelenmesi
            var odunc = db.Tbl_Odunc.ToList();
            gridControl1.DataSource = odunc;
        }

        private void simpleButton3_Click(object sender, EventArgs e) //btnodunciadeet_click
        {
            // Kullanıcının girdiği ödünç ID'yi al
            int oduncId = Convert.ToInt32(txtOduncId.Text);

            // Ödünç tablosunda ilgili kaydı bul
            var oduncKaydi = db.Tbl_Odunc.Where(x => x.odunc_id == oduncId && x.durum == false).FirstOrDefault();

            if (oduncKaydi != null)
            {
                // Durumu iade edildi olarak güncelle
                oduncKaydi.durum = true;

                // Veritabanında değişiklikleri kaydet
                db.SaveChanges();

                

                // Kullanıcıya işlem bilgisi ver
                MessageBox.Show("Ödünç kaydı başarıyla iade edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // İlgili ödünç kaydı bulunamazsa uyarı mesajı göster
                MessageBox.Show("Belirtilen ID'ye ait aktif bir ödünç kaydı bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // Güncel ödünç kayıtlarını listele
            var odunc = db.Tbl_Odunc.Where(x => x.durum == false).ToList();
            gridControl1.DataSource = odunc;
        }

        private void gridControl2_Click(object sender, EventArgs e)
        {

        }
    }
}
