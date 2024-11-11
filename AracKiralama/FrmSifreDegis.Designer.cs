namespace AracKiralama
{
    partial class FrmSifreDegis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSifreDegis));
            this.textBoxYeniSifre = new System.Windows.Forms.TextBox();
            this.textBoxYeniSifreTekrar = new System.Windows.Forms.TextBox();
            this.pictureBoxSifreDegisKapat = new System.Windows.Forms.PictureBox();
            this.pictureBoxSifreDegisKucult = new System.Windows.Forms.PictureBox();
            this.pictureBoxSifreDegis = new System.Windows.Forms.PictureBox();
            this.panelSifreDegisHaraket = new System.Windows.Forms.Panel();
            this.timerHaraket = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSifreDegisKapat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSifreDegisKucult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSifreDegis)).BeginInit();
            this.panelSifreDegisHaraket.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxYeniSifre
            // 
            this.textBoxYeniSifre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxYeniSifre.Font = new System.Drawing.Font("Barlow Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxYeniSifre.ForeColor = System.Drawing.Color.Silver;
            this.textBoxYeniSifre.Location = new System.Drawing.Point(165, 135);
            this.textBoxYeniSifre.Multiline = true;
            this.textBoxYeniSifre.Name = "textBoxYeniSifre";
            this.textBoxYeniSifre.Size = new System.Drawing.Size(229, 30);
            this.textBoxYeniSifre.TabIndex = 0;
            this.textBoxYeniSifre.Text = "Yeni Şifreyi Giriniz";
            this.textBoxYeniSifre.TextChanged += new System.EventHandler(this.textBoxYeniSifre_TextChanged);
            this.textBoxYeniSifre.GotFocus += new System.EventHandler(this.textBoxYeniSifre_GotFocus);
            this.textBoxYeniSifre.LostFocus += new System.EventHandler(this.textBoxYeniSifre_LostFocus);
            // 
            // textBoxYeniSifreTekrar
            // 
            this.textBoxYeniSifreTekrar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxYeniSifreTekrar.Font = new System.Drawing.Font("Barlow Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxYeniSifreTekrar.ForeColor = System.Drawing.Color.Silver;
            this.textBoxYeniSifreTekrar.Location = new System.Drawing.Point(165, 181);
            this.textBoxYeniSifreTekrar.Multiline = true;
            this.textBoxYeniSifreTekrar.Name = "textBoxYeniSifreTekrar";
            this.textBoxYeniSifreTekrar.Size = new System.Drawing.Size(229, 30);
            this.textBoxYeniSifreTekrar.TabIndex = 2;
            this.textBoxYeniSifreTekrar.Text = "Yeni Şifreyi Giriniz";
            this.textBoxYeniSifreTekrar.TextChanged += new System.EventHandler(this.textBoxYeniSifreTekrar_TextChanged);
            this.textBoxYeniSifreTekrar.GotFocus += new System.EventHandler(this.textBoxYeniSifreTekrar_GotFocus);
            this.textBoxYeniSifreTekrar.LostFocus += new System.EventHandler(this.textBoxYeniSifreTekrar_LostFocus);
            // 
            // pictureBoxSifreDegisKapat
            // 
            this.pictureBoxSifreDegisKapat.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSifreDegisKapat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxSifreDegisKapat.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSifreDegisKapat.Image")));
            this.pictureBoxSifreDegisKapat.Location = new System.Drawing.Point(512, 11);
            this.pictureBoxSifreDegisKapat.Name = "pictureBoxSifreDegisKapat";
            this.pictureBoxSifreDegisKapat.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxSifreDegisKapat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSifreDegisKapat.TabIndex = 3;
            this.pictureBoxSifreDegisKapat.TabStop = false;
            this.pictureBoxSifreDegisKapat.Click += new System.EventHandler(this.pictureBoxSifreDegisKapat_Click);
            // 
            // pictureBoxSifreDegisKucult
            // 
            this.pictureBoxSifreDegisKucult.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSifreDegisKucult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxSifreDegisKucult.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSifreDegisKucult.Image")));
            this.pictureBoxSifreDegisKucult.Location = new System.Drawing.Point(488, 16);
            this.pictureBoxSifreDegisKucult.Name = "pictureBoxSifreDegisKucult";
            this.pictureBoxSifreDegisKucult.Size = new System.Drawing.Size(12, 4);
            this.pictureBoxSifreDegisKucult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSifreDegisKucult.TabIndex = 4;
            this.pictureBoxSifreDegisKucult.TabStop = false;
            this.pictureBoxSifreDegisKucult.Click += new System.EventHandler(this.pictureBoxSifreDegisKucult_Click);
            // 
            // pictureBoxSifreDegis
            // 
            this.pictureBoxSifreDegis.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSifreDegis.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSifreDegis.Image")));
            this.pictureBoxSifreDegis.Location = new System.Drawing.Point(110, 231);
            this.pictureBoxSifreDegis.Name = "pictureBoxSifreDegis";
            this.pictureBoxSifreDegis.Size = new System.Drawing.Size(315, 38);
            this.pictureBoxSifreDegis.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxSifreDegis.TabIndex = 5;
            this.pictureBoxSifreDegis.TabStop = false;
            this.pictureBoxSifreDegis.Click += new System.EventHandler(this.pictureBoxSifreDegis_Click);
            this.pictureBoxSifreDegis.MouseEnter += new System.EventHandler(this.pictureBoxSifreDegis_MouseEnter);
            this.pictureBoxSifreDegis.MouseLeave += new System.EventHandler(this.pictureBoxSifreDegis_MouseLeave);
            // 
            // panelSifreDegisHaraket
            // 
            this.panelSifreDegisHaraket.BackColor = System.Drawing.Color.Transparent;
            this.panelSifreDegisHaraket.Controls.Add(this.pictureBoxSifreDegisKapat);
            this.panelSifreDegisHaraket.Controls.Add(this.pictureBoxSifreDegisKucult);
            this.panelSifreDegisHaraket.Location = new System.Drawing.Point(2, 1);
            this.panelSifreDegisHaraket.Name = "panelSifreDegisHaraket";
            this.panelSifreDegisHaraket.Size = new System.Drawing.Size(534, 41);
            this.panelSifreDegisHaraket.TabIndex = 6;
            this.panelSifreDegisHaraket.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelSifreDegisHaraket_MouseDown);
            this.panelSifreDegisHaraket.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelSifreDegisHaraket_MouseUp);
            // 
            // timerHaraket
            // 
            this.timerHaraket.Tick += new System.EventHandler(this.timerHaraket_Tick);
            // 
            // FrmSifreDegis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(537, 297);
            this.Controls.Add(this.panelSifreDegisHaraket);
            this.Controls.Add(this.pictureBoxSifreDegis);
            this.Controls.Add(this.textBoxYeniSifreTekrar);
            this.Controls.Add(this.textBoxYeniSifre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSifreDegis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AracKiralamaOtomasyonu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSifreDegis_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSifreDegisKapat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSifreDegisKucult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSifreDegis)).EndInit();
            this.panelSifreDegisHaraket.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxYeniSifre;
        private System.Windows.Forms.TextBox textBoxYeniSifreTekrar;
        private System.Windows.Forms.PictureBox pictureBoxSifreDegisKapat;
        private System.Windows.Forms.PictureBox pictureBoxSifreDegisKucult;
        private System.Windows.Forms.PictureBox pictureBoxSifreDegis;
        private System.Windows.Forms.Panel panelSifreDegisHaraket;
        private System.Windows.Forms.Timer timerHaraket;
    }
}