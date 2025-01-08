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
    public partial class FrmKitap : Form
    {
        public FrmKitap()
        {
            InitializeComponent();
        }

        kutuphaneotomasyonEntities db = new kutuphaneotomasyonEntities();

        private void FrmKitap_Load(object sender, EventArgs e)
        {
            var kitap = db.Tbl_Kitaplar.ToList();
            gridControl1.DataSource = kitap.ToList();
        }
        public void Listele() //listelekitaplar() metodu
        {
            var kitaplar = db.Tbl_Kitaplar.ToList();
            gridControl1.DataSource = kitaplar.ToList();
        }

        private void simpleButton1_Click(object sender, EventArgs e) //btnkitapekle_click() metodu
        {
            Tbl_Kitaplar kayit = new Tbl_Kitaplar();
            kayit.kaynak_ad = txtAd.Text;
            kayit.kaynak_yazar = txtYazar.Text;
            kayit.kaynak_isbn = txtisbn.Text;
            kayit.kaynak_tur = cmbtur.Text;
            kayit.kaynak_dil = txtDil.Text;

            db.Tbl_Kitaplar.Add(kayit);
            db.SaveChanges();

            gridControl1.DataSource = db.Tbl_Kitaplar.ToList();
            MessageBox.Show("Kayıt başarılı!");
            Listele();

        }

        private void simpleButton2_Click(object sender, EventArgs e)//btnkitapsil_click() metodu
        {
            var gridView = gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            int secilenId = Convert.ToInt32(gridView.GetFocusedRowCellValue("kaynak_id"));
            var kullanici = db.Tbl_Kitaplar.Where(x => x.kaynak_id == secilenId).FirstOrDefault();
            db.Tbl_Kitaplar.Remove(kullanici);
            db.SaveChanges();
            gridControl1.DataSource = db.Tbl_Kitaplar.ToList();
            Listele();
        }
    }
}
