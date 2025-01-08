
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
    public partial class anasayfa : Form
    {
        public anasayfa()
        {
            InitializeComponent();
          
        }

        FrmPersonel frm1;
        FrmUyeler frm2;
        FrmKitap frm3;
        FrmOdunc frm4;
        FrmArama frm5;

        private void CloseAllChildForms()
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CloseAllChildForms();
            frm1 = new FrmPersonel();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CloseAllChildForms();
            frm2 = new FrmUyeler();
            frm2.MdiParent = this;
            frm2.Show();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CloseAllChildForms();
            frm3 = new FrmKitap();
            frm3.MdiParent = this;
            frm3.Show();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CloseAllChildForms();
            frm4 = new FrmOdunc();
            frm4.MdiParent = this;
            frm4.Show();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CloseAllChildForms();
            frm5 = new FrmArama();
            frm5.MdiParent = this;
            frm5.Show();
        }

        private void anasayfa_Load(object sender, EventArgs e)
        {

        }
    }
}
