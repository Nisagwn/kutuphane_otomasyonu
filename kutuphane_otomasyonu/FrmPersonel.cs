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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }
        
        kutuphaneotomasyonEntities db = new kutuphaneotomasyonEntities();
        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            var kayit = db.Tbl_Personeller.ToList();
            gridControl1.DataSource = kayit;

        }
        public void Listele()
        {
            var personel = db.Tbl_Personeller.ToList();
            gridControl1.DataSource = personel.ToList();
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            Tbl_Personeller person = new Tbl_Personeller();
            person.person_ad = txtAd.Text;
            person.person_soyad = txtSoyad.Text;
            person.person_tc = txtTC.Text;
            person.person_mail = txtMail.Text;
            person.person_tel = txtTel.Text;
            person.person_sifre = txtSifre.Text;

            db.Tbl_Personeller.Add(person);
            db.SaveChanges();
           
            gridControl1.DataSource = db.Tbl_Personeller.ToList();
            MessageBox.Show("Kayıt başarılı!");
            Listele();
           
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            var gridView = gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            int secilenId = Convert.ToInt32(gridView.GetFocusedRowCellValue("person_id"));
            var kullanici = db.Tbl_Personeller.Where(x => x.person_id == secilenId).FirstOrDefault();
            db.Tbl_Personeller.Remove(kullanici);
            db.SaveChanges();
            gridControl1.DataSource = db.Tbl_Personeller.ToList();
            Listele();
        }

        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {

            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtId.Text = dr["person_id"].ToString();
                txtAd.Text = dr["person_ad"].ToString();
                txtSoyad.Text = dr["person_soyad"].ToString();
                txtTel.Text = dr["person_tel"].ToString();
                txtMail.Text = dr["person_mail"].ToString();
                txtTC.Text = dr["person_tc"].ToString();
                txtSifre.Text = dr["person_sifre"].ToString();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            var gridView = gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            int secilenId = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "person_id"));
            var kullanici = db.Tbl_Personeller.Where(x => x.person_id == secilenId).FirstOrDefault();
            kullanici.person_ad = txtAd.Text;
            kullanici.person_soyad = txtSoyad.Text;
            kullanici.person_tc = txtTC.Text;
            kullanici.person_mail = txtMail.Text;
            kullanici.person_tel = txtTel.Text;
            kullanici.person_sifre = txtSifre.Text;
            db.SaveChanges();
            Listele();


        }

       
    }
}
