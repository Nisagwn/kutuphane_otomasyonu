
using System;
using System.Linq;
using System.Windows.Forms;

namespace kutuphane_otomasyonu
{
    public partial class FrmOdunc : Form
    {
        public FrmOdunc()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Formu ekranın ortasında başlatır.
        }

        kutuphaneotomasyonEntities db = new kutuphaneotomasyonEntities();

        // Ödünç listeleme metodu
        void listeleOdunc()
        {
            gridControl1.DataSource = db.Tbl_Odunc.ToList();
            gridControl1.RefreshDataSource();
        }

        // Kitap listeleme metodu
        void listeleKitap()
        {
            gridControl2.DataSource = db.Tbl_Kitaplar.ToList();
            gridControl2.RefreshDataSource();
        }

        // Form yüklenirken listeleme işlemleri
        private void FrmOdunc_Load(object sender, EventArgs e)
        {
            listeleKitap();
            listeleOdunc();
        }

        // Üye TC ile arama
        private void simpleButton1_Click(object sender, EventArgs e) // btnUyeAra_Click
        {
            string aranantc = txtUyeTc.Text;
            var bulunanKullanici = db.Tbl_Uyeler.FirstOrDefault(x => x.uye_tc == aranantc);

            if (bulunanKullanici != null)
            {
                txtUyeAd.Text = $"{bulunanKullanici.uye_ad} {bulunanKullanici.uye_soyad}";
            }
            else
            {
                MessageBox.Show("Kişi Bulunamadı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUyeAd.Clear();
            }
        }

        // Ödünç verme
        private void simpleButton2_Click(object sender, EventArgs e) // btnOduncVer_Click
        {
            string gelenTC = txtUyeTc.Text;
            var secilenKisi = db.Tbl_Uyeler.FirstOrDefault(x => x.uye_tc == gelenTC);

            if (secilenKisi == null)
            {
                MessageBox.Show("Üye bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var gridView = gridControl2.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gridView.FocusedRowHandle < 0)
            {
                MessageBox.Show("Lütfen bir kitap seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int secilenKitapId = Convert.ToInt32(gridView.GetRowCellValue(gridView.FocusedRowHandle, gridView.Columns[0]));
            var secilenKitap = db.Tbl_Kitaplar.FirstOrDefault(x => x.kaynak_id == secilenKitapId);

            if (secilenKitap == null)
            {
                MessageBox.Show("Kitap bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Tbl_Odunc yeniOdunc = new Tbl_Odunc
            {
                kitap_id = secilenKitap.kaynak_id,
                kullanici_id = secilenKisi.uye_id,
                alis_tarih = DateTime.Today,
                veris_tarih = DateTime.Today.AddDays(7),
                durum = false
            };
            db.Tbl_Odunc.Add(yeniOdunc);

            secilenKitap.kaynak_okumaSayisi += 1;
            db.SaveChanges();

            MessageBox.Show("Seçilen kitap ödünç verildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listeleOdunc();
        }

        // Ödünç iade etme
        private void simpleButton3_Click(object sender, EventArgs e) // btnOduncIadeEt_Click
        {
            if (!int.TryParse(txtOduncId.Text, out int oduncId))
            {
                MessageBox.Show("Geçerli bir ödünç ID girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // var oduncKaydi = db.Tbl_Odunc.FirstOrDefault(x => x.odunc_id == oduncId && !x.durum);
            var oduncKaydi = db.Tbl_Odunc.FirstOrDefault(x => x.odunc_id == oduncId && x.durum == false);


            if (oduncKaydi != null)
            {
                oduncKaydi.durum = true;
                db.SaveChanges();

                MessageBox.Show("Ödünç kaydı başarıyla iade edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listeleOdunc();
            }
            else
            {
                MessageBox.Show("Belirtilen ID'ye ait aktif bir ödünç kaydı bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
