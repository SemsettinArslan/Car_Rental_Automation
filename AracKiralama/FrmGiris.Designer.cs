namespace AracKiralama
{
    partial class FrmGiris
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGiris));
            this.buttonGiris = new System.Windows.Forms.Button();
            this.textBoxSifre = new System.Windows.Forms.TextBox();
            this.textBoxKullaniciAdi = new System.Windows.Forms.TextBox();
            this.linkLabelSifreUnuttum = new System.Windows.Forms.LinkLabel();
            this.checkBoxGoster = new System.Windows.Forms.CheckBox();
            this.pictureBoxGirisKapat = new System.Windows.Forms.PictureBox();
            this.pictureBoxGirisKucult = new System.Windows.Forms.PictureBox();
            this.panelGirisHareket = new System.Windows.Forms.Panel();
            this.pictureBoxGiris = new System.Windows.Forms.PictureBox();
            this.labelİslemSeciniz = new System.Windows.Forms.Label();
            this.timerGirisHaraket = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGirisKapat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGirisKucult)).BeginInit();
            this.panelGirisHareket.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGiris)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGiris
            // 
            this.buttonGiris.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonGiris.BackgroundImage")));
            this.buttonGiris.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGiris.Font = new System.Drawing.Font("Barlow Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonGiris.Location = new System.Drawing.Point(632, 441);
            this.buttonGiris.Name = "buttonGiris";
            this.buttonGiris.Size = new System.Drawing.Size(342, 38);
            this.buttonGiris.TabIndex = 6;
            this.buttonGiris.Text = "Giriş Yap";
            this.buttonGiris.UseVisualStyleBackColor = true;
            // 
            // textBoxSifre
            // 
            this.textBoxSifre.Font = new System.Drawing.Font("Barlow Medium", 14.25F, System.Drawing.FontStyle.Bold);
            this.textBoxSifre.ForeColor = System.Drawing.Color.Silver;
            this.textBoxSifre.Location = new System.Drawing.Point(632, 387);
            this.textBoxSifre.MaxLength = 16;
            this.textBoxSifre.Name = "textBoxSifre";
            this.textBoxSifre.Size = new System.Drawing.Size(342, 30);
            this.textBoxSifre.TabIndex = 3;
            this.textBoxSifre.Text = "Şifre Giriniz";
            this.textBoxSifre.TextChanged += new System.EventHandler(this.textBoxSifre_TextChanged);
            this.textBoxSifre.GotFocus += new System.EventHandler(this.TextBoxSifre_GotFocus);
            this.textBoxSifre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSifre_KeyDown);
            this.textBoxSifre.LostFocus += new System.EventHandler(this.TextBoxSifre_LostFocus);
            // 
            // textBoxKullaniciAdi
            // 
            this.textBoxKullaniciAdi.Font = new System.Drawing.Font("Barlow Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxKullaniciAdi.ForeColor = System.Drawing.Color.Silver;
            this.textBoxKullaniciAdi.Location = new System.Drawing.Point(632, 334);
            this.textBoxKullaniciAdi.MaxLength = 16;
            this.textBoxKullaniciAdi.Name = "textBoxKullaniciAdi";
            this.textBoxKullaniciAdi.Size = new System.Drawing.Size(342, 30);
            this.textBoxKullaniciAdi.TabIndex = 2;
            this.textBoxKullaniciAdi.Text = "Kullanıcı Adı Giriniz";
            this.textBoxKullaniciAdi.TextChanged += new System.EventHandler(this.textBoxKullaniciAdi_TextChanged);
            this.textBoxKullaniciAdi.GotFocus += new System.EventHandler(this.textBoxKullaniciAdi_GotFocus);
            this.textBoxKullaniciAdi.LostFocus += new System.EventHandler(this.textBoxKullaniciAdi_LostFocus);
            // 
            // linkLabelSifreUnuttum
            // 
            this.linkLabelSifreUnuttum.ActiveLinkColor = System.Drawing.Color.Turquoise;
            this.linkLabelSifreUnuttum.AutoSize = true;
            this.linkLabelSifreUnuttum.BackColor = System.Drawing.Color.Transparent;
            this.linkLabelSifreUnuttum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabelSifreUnuttum.Font = new System.Drawing.Font("Barlow", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.linkLabelSifreUnuttum.LinkColor = System.Drawing.Color.White;
            this.linkLabelSifreUnuttum.Location = new System.Drawing.Point(629, 508);
            this.linkLabelSifreUnuttum.Name = "linkLabelSifreUnuttum";
            this.linkLabelSifreUnuttum.Size = new System.Drawing.Size(103, 17);
            this.linkLabelSifreUnuttum.TabIndex = 5;
            this.linkLabelSifreUnuttum.TabStop = true;
            this.linkLabelSifreUnuttum.Text = "Şifremi Unuttum";
            this.linkLabelSifreUnuttum.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSifreUnuttum_LinkClicked);
            this.linkLabelSifreUnuttum.MouseEnter += new System.EventHandler(this.linkLabelSifreUnuttum_MouseEnter);
            this.linkLabelSifreUnuttum.MouseLeave += new System.EventHandler(this.linkLabelSifreUnuttum_MouseLeave);
            // 
            // checkBoxGoster
            // 
            this.checkBoxGoster.AutoSize = true;
            this.checkBoxGoster.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxGoster.Font = new System.Drawing.Font("Barlow Medium", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkBoxGoster.ForeColor = System.Drawing.Color.Turquoise;
            this.checkBoxGoster.Location = new System.Drawing.Point(980, 392);
            this.checkBoxGoster.Name = "checkBoxGoster";
            this.checkBoxGoster.Size = new System.Drawing.Size(71, 21);
            this.checkBoxGoster.TabIndex = 7;
            this.checkBoxGoster.Text = "Göster";
            this.checkBoxGoster.UseVisualStyleBackColor = false;
            this.checkBoxGoster.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // pictureBoxGirisKapat
            // 
            this.pictureBoxGirisKapat.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxGirisKapat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxGirisKapat.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxGirisKapat.Image")));
            this.pictureBoxGirisKapat.Location = new System.Drawing.Point(1018, 11);
            this.pictureBoxGirisKapat.Name = "pictureBoxGirisKapat";
            this.pictureBoxGirisKapat.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxGirisKapat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxGirisKapat.TabIndex = 8;
            this.pictureBoxGirisKapat.TabStop = false;
            this.pictureBoxGirisKapat.Click += new System.EventHandler(this.pictureBoxGirisKapat_Click);
            // 
            // pictureBoxGirisKucult
            // 
            this.pictureBoxGirisKucult.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxGirisKucult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxGirisKucult.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxGirisKucult.Image")));
            this.pictureBoxGirisKucult.Location = new System.Drawing.Point(975, 22);
            this.pictureBoxGirisKucult.Name = "pictureBoxGirisKucult";
            this.pictureBoxGirisKucult.Size = new System.Drawing.Size(25, 10);
            this.pictureBoxGirisKucult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxGirisKucult.TabIndex = 9;
            this.pictureBoxGirisKucult.TabStop = false;
            this.pictureBoxGirisKucult.Click += new System.EventHandler(this.pictureBoxGirisKucult_Click);
            // 
            // panelGirisHareket
            // 
            this.panelGirisHareket.BackColor = System.Drawing.Color.Transparent;
            this.panelGirisHareket.Controls.Add(this.pictureBoxGirisKapat);
            this.panelGirisHareket.Controls.Add(this.pictureBoxGirisKucult);
            this.panelGirisHareket.Location = new System.Drawing.Point(3, -1);
            this.panelGirisHareket.Name = "panelGirisHareket";
            this.panelGirisHareket.Size = new System.Drawing.Size(1068, 61);
            this.panelGirisHareket.TabIndex = 10;
            this.panelGirisHareket.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelGirisHareket_MouseDown);
            this.panelGirisHareket.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelGirisHareket_MouseUp);
            // 
            // pictureBoxGiris
            // 
            this.pictureBoxGiris.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxGiris.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxGiris.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxGiris.Image")));
            this.pictureBoxGiris.Location = new System.Drawing.Point(632, 441);
            this.pictureBoxGiris.Name = "pictureBoxGiris";
            this.pictureBoxGiris.Size = new System.Drawing.Size(342, 38);
            this.pictureBoxGiris.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxGiris.TabIndex = 11;
            this.pictureBoxGiris.TabStop = false;
            this.pictureBoxGiris.Click += new System.EventHandler(this.pictureBoxGiris_Click);
            this.pictureBoxGiris.MouseEnter += new System.EventHandler(this.pictureBoxGiris_MouseEnter);
            this.pictureBoxGiris.MouseLeave += new System.EventHandler(this.pictureBoxGiris_MouseLeave);
            // 
            // labelİslemSeciniz
            // 
            this.labelİslemSeciniz.AutoSize = true;
            this.labelİslemSeciniz.BackColor = System.Drawing.Color.Transparent;
            this.labelİslemSeciniz.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labelİslemSeciniz.Font = new System.Drawing.Font("Barlow", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelİslemSeciniz.ForeColor = System.Drawing.Color.Turquoise;
            this.labelİslemSeciniz.Location = new System.Drawing.Point(579, 193);
            this.labelİslemSeciniz.Name = "labelİslemSeciniz";
            this.labelİslemSeciniz.Size = new System.Drawing.Size(453, 138);
            this.labelİslemSeciniz.TabIndex = 27;
            this.labelİslemSeciniz.Text = "Araç Kiralama Otomasyonu\r\nGiriş Sayfası\r\n\r\n";
            this.labelİslemSeciniz.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerGirisHaraket
            // 
            this.timerGirisHaraket.Tick += new System.EventHandler(this.timerGirisHaraket_Tick);
            // 
            // FrmGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1072, 648);
            this.Controls.Add(this.labelİslemSeciniz);
            this.Controls.Add(this.pictureBoxGiris);
            this.Controls.Add(this.panelGirisHareket);
            this.Controls.Add(this.checkBoxGoster);
            this.Controls.Add(this.linkLabelSifreUnuttum);
            this.Controls.Add(this.textBoxKullaniciAdi);
            this.Controls.Add(this.textBoxSifre);
            this.Controls.Add(this.buttonGiris);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmGiris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AracKiralamaOtomasyonu";
            this.TransparencyKey = System.Drawing.Color.IndianRed;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmGiris_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGirisKapat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGirisKucult)).EndInit();
            this.panelGirisHareket.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGiris)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonGiris;
        private System.Windows.Forms.TextBox textBoxSifre;
        private System.Windows.Forms.TextBox textBoxKullaniciAdi;
        private System.Windows.Forms.LinkLabel linkLabelSifreUnuttum;
        private System.Windows.Forms.CheckBox checkBoxGoster;
        private System.Windows.Forms.PictureBox pictureBoxGirisKapat;
        private System.Windows.Forms.PictureBox pictureBoxGirisKucult;
        private System.Windows.Forms.Panel panelGirisHareket;
        private System.Windows.Forms.PictureBox pictureBoxGiris;
        private System.Windows.Forms.Label labelİslemSeciniz;
        private System.Windows.Forms.Timer timerGirisHaraket;
    }
}

