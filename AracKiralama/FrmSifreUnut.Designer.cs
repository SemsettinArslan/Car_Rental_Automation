namespace AracKiralama
{
    partial class FrmSifreUnut
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSifreUnut));
            this.textBoxSifreUnutKullaniciAdi = new System.Windows.Forms.TextBox();
            this.textBoxSifreUnutKod = new System.Windows.Forms.TextBox();
            this.pictureBoxSifreUnutKucult = new System.Windows.Forms.PictureBox();
            this.pictureBoxSifreUnutKapat = new System.Windows.Forms.PictureBox();
            this.pictureBoxDogrula = new System.Windows.Forms.PictureBox();
            this.pictureBoxKodGonder = new System.Windows.Forms.PictureBox();
            this.panelHaraket = new System.Windows.Forms.Panel();
            this.timerHaraketlen = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSifreUnutKucult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSifreUnutKapat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDogrula)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKodGonder)).BeginInit();
            this.panelHaraket.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxSifreUnutKullaniciAdi
            // 
            this.textBoxSifreUnutKullaniciAdi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSifreUnutKullaniciAdi.Font = new System.Drawing.Font("Barlow Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxSifreUnutKullaniciAdi.ForeColor = System.Drawing.Color.Silver;
            this.textBoxSifreUnutKullaniciAdi.Location = new System.Drawing.Point(65, 136);
            this.textBoxSifreUnutKullaniciAdi.Multiline = true;
            this.textBoxSifreUnutKullaniciAdi.Name = "textBoxSifreUnutKullaniciAdi";
            this.textBoxSifreUnutKullaniciAdi.Size = new System.Drawing.Size(290, 30);
            this.textBoxSifreUnutKullaniciAdi.TabIndex = 0;
            this.textBoxSifreUnutKullaniciAdi.Text = "Kullanıcı Adını Giriniz";
            this.textBoxSifreUnutKullaniciAdi.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBoxSifreUnutKullaniciAdi.GotFocus += new System.EventHandler(this.textBoxSifreUnutMail_GotFocus);
            this.textBoxSifreUnutKullaniciAdi.LostFocus += new System.EventHandler(this.textBoxSifreUnutMail_LostFocus);
            // 
            // textBoxSifreUnutKod
            // 
            this.textBoxSifreUnutKod.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSifreUnutKod.Font = new System.Drawing.Font("Barlow Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxSifreUnutKod.ForeColor = System.Drawing.Color.Silver;
            this.textBoxSifreUnutKod.Location = new System.Drawing.Point(65, 185);
            this.textBoxSifreUnutKod.Multiline = true;
            this.textBoxSifreUnutKod.Name = "textBoxSifreUnutKod";
            this.textBoxSifreUnutKod.Size = new System.Drawing.Size(290, 30);
            this.textBoxSifreUnutKod.TabIndex = 2;
            this.textBoxSifreUnutKod.Text = "Doğrulama Kodunu Giriniz";
            this.textBoxSifreUnutKod.TextChanged += new System.EventHandler(this.textBoxSifreUnutKod_TextChanged);
            this.textBoxSifreUnutKod.GotFocus += new System.EventHandler(this.textBoxSifreUnutKod_GotFocus);
            this.textBoxSifreUnutKod.LostFocus += new System.EventHandler(this.textBoxSifreUnutKod_LostFocus);
            // 
            // pictureBoxSifreUnutKucult
            // 
            this.pictureBoxSifreUnutKucult.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSifreUnutKucult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxSifreUnutKucult.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSifreUnutKucult.Image")));
            this.pictureBoxSifreUnutKucult.Location = new System.Drawing.Point(529, 25);
            this.pictureBoxSifreUnutKucult.Name = "pictureBoxSifreUnutKucult";
            this.pictureBoxSifreUnutKucult.Size = new System.Drawing.Size(12, 4);
            this.pictureBoxSifreUnutKucult.TabIndex = 5;
            this.pictureBoxSifreUnutKucult.TabStop = false;
            this.pictureBoxSifreUnutKucult.Click += new System.EventHandler(this.pictureBoxSifreUnutKucult_Click);
            // 
            // pictureBoxSifreUnutKapat
            // 
            this.pictureBoxSifreUnutKapat.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSifreUnutKapat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxSifreUnutKapat.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSifreUnutKapat.Image")));
            this.pictureBoxSifreUnutKapat.Location = new System.Drawing.Point(553, 19);
            this.pictureBoxSifreUnutKapat.Name = "pictureBoxSifreUnutKapat";
            this.pictureBoxSifreUnutKapat.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxSifreUnutKapat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxSifreUnutKapat.TabIndex = 6;
            this.pictureBoxSifreUnutKapat.TabStop = false;
            this.pictureBoxSifreUnutKapat.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBoxDogrula
            // 
            this.pictureBoxDogrula.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxDogrula.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxDogrula.Image")));
            this.pictureBoxDogrula.Location = new System.Drawing.Point(361, 178);
            this.pictureBoxDogrula.Name = "pictureBoxDogrula";
            this.pictureBoxDogrula.Size = new System.Drawing.Size(208, 50);
            this.pictureBoxDogrula.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxDogrula.TabIndex = 8;
            this.pictureBoxDogrula.TabStop = false;
            this.pictureBoxDogrula.Click += new System.EventHandler(this.pictureBoxDogrula_Click);
            this.pictureBoxDogrula.MouseEnter += new System.EventHandler(this.pictureBoxDogrula_MouseEnter);
            this.pictureBoxDogrula.MouseLeave += new System.EventHandler(this.pictureBoxDogrula_MouseLeave);
            // 
            // pictureBoxKodGonder
            // 
            this.pictureBoxKodGonder.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxKodGonder.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxKodGonder.Image")));
            this.pictureBoxKodGonder.Location = new System.Drawing.Point(361, 125);
            this.pictureBoxKodGonder.Name = "pictureBoxKodGonder";
            this.pictureBoxKodGonder.Size = new System.Drawing.Size(208, 50);
            this.pictureBoxKodGonder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxKodGonder.TabIndex = 7;
            this.pictureBoxKodGonder.TabStop = false;
            this.pictureBoxKodGonder.Click += new System.EventHandler(this.pictureBoxKodGonder_Click);
            this.pictureBoxKodGonder.MouseEnter += new System.EventHandler(this.pictureBoxKodGonder_MouseEnter);
            this.pictureBoxKodGonder.MouseLeave += new System.EventHandler(this.pictureBoxKodGonder_MouseLeave);
            // 
            // panelHaraket
            // 
            this.panelHaraket.BackColor = System.Drawing.Color.Transparent;
            this.panelHaraket.Controls.Add(this.pictureBoxSifreUnutKapat);
            this.panelHaraket.Controls.Add(this.pictureBoxSifreUnutKucult);
            this.panelHaraket.Location = new System.Drawing.Point(0, 0);
            this.panelHaraket.Name = "panelHaraket";
            this.panelHaraket.Size = new System.Drawing.Size(579, 58);
            this.panelHaraket.TabIndex = 9;
            this.panelHaraket.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelHaraket_MouseDown);
            this.panelHaraket.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelHaraket_MouseUp);
            // 
            // timerHaraketlen
            // 
            this.timerHaraketlen.Tick += new System.EventHandler(this.timerHaraketlen_Tick);
            // 
            // FrmSifreUnut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(578, 294);
            this.Controls.Add(this.panelHaraket);
            this.Controls.Add(this.pictureBoxDogrula);
            this.Controls.Add(this.pictureBoxKodGonder);
            this.Controls.Add(this.textBoxSifreUnutKod);
            this.Controls.Add(this.textBoxSifreUnutKullaniciAdi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSifreUnut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AracKiralamaOtomasyonu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSifreUnut_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSifreUnutKucult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSifreUnutKapat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDogrula)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKodGonder)).EndInit();
            this.panelHaraket.ResumeLayout(false);
            this.panelHaraket.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSifreUnutKullaniciAdi;
        private System.Windows.Forms.TextBox textBoxSifreUnutKod;
        private System.Windows.Forms.PictureBox pictureBoxSifreUnutKucult;
        private System.Windows.Forms.PictureBox pictureBoxSifreUnutKapat;
        private System.Windows.Forms.PictureBox pictureBoxDogrula;
        private System.Windows.Forms.PictureBox pictureBoxKodGonder;
        private System.Windows.Forms.Panel panelHaraket;
        private System.Windows.Forms.Timer timerHaraketlen;
    }
}