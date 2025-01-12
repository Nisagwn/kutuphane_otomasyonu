namespace kutuphane_otomasyonu
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.personel_ad = new System.Windows.Forms.TextBox();
            this.personel_sifre = new System.Windows.Forms.TextBox();
            this.girisbtn = new System.Windows.Forms.Button();
            this.personeladilbl = new System.Windows.Forms.Label();
            this.personelsifrelbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // personel_ad
            // 
            this.personel_ad.Location = new System.Drawing.Point(422, 302);
            this.personel_ad.Name = "personel_ad";
            this.personel_ad.Size = new System.Drawing.Size(332, 22);
            this.personel_ad.TabIndex = 0;
            // 
            // personel_sifre
            // 
            this.personel_sifre.Location = new System.Drawing.Point(422, 387);
            this.personel_sifre.Name = "personel_sifre";
            this.personel_sifre.PasswordChar = '*';
            this.personel_sifre.Size = new System.Drawing.Size(332, 22);
            this.personel_sifre.TabIndex = 1;
            // 
            // girisbtn
            // 
            this.girisbtn.BackColor = System.Drawing.Color.MistyRose;
            this.girisbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.girisbtn.Location = new System.Drawing.Point(503, 493);
            this.girisbtn.Name = "girisbtn";
            this.girisbtn.Size = new System.Drawing.Size(182, 47);
            this.girisbtn.TabIndex = 2;
            this.girisbtn.Text = "GİRİŞ";
            this.girisbtn.UseVisualStyleBackColor = false;
            this.girisbtn.Click += new System.EventHandler(this.girisbtn_Click);
            // 
            // personeladilbl
            // 
            this.personeladilbl.AutoSize = true;
            this.personeladilbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.personeladilbl.Location = new System.Drawing.Point(233, 300);
            this.personeladilbl.Name = "personeladilbl";
            this.personeladilbl.Size = new System.Drawing.Size(154, 22);
            this.personeladilbl.TabIndex = 3;
            this.personeladilbl.Text = "PERSONEL ADI";
            // 
            // personelsifrelbl
            // 
            this.personelsifrelbl.AutoSize = true;
            this.personelsifrelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.personelsifrelbl.Location = new System.Drawing.Point(320, 387);
            this.personelsifrelbl.Name = "personelsifrelbl";
            this.personelsifrelbl.Size = new System.Drawing.Size(67, 22);
            this.personelsifrelbl.TabIndex = 4;
            this.personelsifrelbl.Text = "ŞİFRE";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(503, 79);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(182, 154);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1178, 755);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.personelsifrelbl);
            this.Controls.Add(this.personeladilbl);
            this.Controls.Add(this.girisbtn);
            this.Controls.Add(this.personel_sifre);
            this.Controls.Add(this.personel_ad);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox personel_ad;
        private System.Windows.Forms.TextBox personel_sifre;
        private System.Windows.Forms.Button girisbtn;
        private System.Windows.Forms.Label personeladilbl;
        private System.Windows.Forms.Label personelsifrelbl;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

