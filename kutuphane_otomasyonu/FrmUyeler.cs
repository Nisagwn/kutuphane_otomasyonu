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
    public partial class FrmUyeler : Form
    {
        public FrmUyeler()
        {
            InitializeComponent();
        }
        kutuphaneotomasyonEntities db = new kutuphaneotomasyonEntities();
        private void FrmUyeler_Load(object sender, EventArgs e)
        {
            var kayit = db.Tbl_Uyeler.ToList();
            gridControl1.DataSource = kayit;
        }
        public void Listele()
        {
            var uye = db.Tbl_Uyeler.ToList();
            gridControl1.DataSource = uye.ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Tbl_Uyeler uye = new Tbl_Uyeler();
            uye.uye_ad = txtAd.Text;
            uye.uye_soyad = txtSoyad.Text;
            uye.uye_tc = txtTC.Text;
            uye.uye_mail = txtMail.Text;
            uye.uye_tel = txtTel.Text;
            

            db.Tbl_Uyeler.Add(uye);
            db.SaveChanges();

            gridControl1.DataSource = db.Tbl_Uyeler.ToList();
            MessageBox.Show("Kayıt başarılı!");
            Listele();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var gridView = gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            int secilenId = Convert.ToInt32(gridView.GetFocusedRowCellValue("uye_id"));
            var kullanici = db.Tbl_Uyeler.Where(x => x.uye_id == secilenId).FirstOrDefault();
            db.Tbl_Uyeler.Remove(kullanici);
            db.SaveChanges();
            gridControl1.DataSource = db.Tbl_Uyeler.ToList();
            Listele();
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
