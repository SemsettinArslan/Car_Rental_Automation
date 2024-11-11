namespace AracKiralama
{
    partial class FrmFiyatGuncelle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFiyatGuncelle));
            this.pictureBoxİndirim = new System.Windows.Forms.PictureBox();
            this.textBoxİndirim = new System.Windows.Forms.TextBox();
            this.textBoxZam = new System.Windows.Forms.TextBox();
            this.pictureBoxZam = new System.Windows.Forms.PictureBox();
            this.labelİndirim = new System.Windows.Forms.Label();
            this.labelZam = new System.Windows.Forms.Label();
            this.pictureBoxFiyatKucult = new System.Windows.Forms.PictureBox();
            this.pictureBoxFiyatKapat = new System.Windows.Forms.PictureBox();
            this.panelHaraket = new System.Windows.Forms.Panel();
            this.timerHaraket = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxİndirim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxZam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFiyatKucult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFiyatKapat)).BeginInit();
            this.panelHaraket.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxİndirim
            // 
            this.pictureBoxİndirim.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxİndirim.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxİndirim.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxİndirim.Image")));
            this.pictureBoxİndirim.Location = new System.Drawing.Point(27, 196);
            this.pictureBoxİndirim.Name = "pictureBoxİndirim";
            this.pictureBoxİndirim.Size = new System.Drawing.Size(253, 35);
            this.pictureBoxİndirim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxİndirim.TabIndex = 0;
            this.pictureBoxİndirim.TabStop = false;
            this.pictureBoxİndirim.Click += new System.EventHandler(this.pictureBoxİndirim_Click);
            this.pictureBoxİndirim.MouseEnter += new System.EventHandler(this.pictureBoxİndirim_MouseEnter);
            this.pictureBoxİndirim.MouseLeave += new System.EventHandler(this.pictureBoxİndirim_MouseLeave);
            // 
            // textBoxİndirim
            // 
            this.textBoxİndirim.Font = new System.Drawing.Font("Barlow Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxİndirim.Location = new System.Drawing.Point(27, 154);
            this.textBoxİndirim.MaxLength = 3;
            this.textBoxİndirim.Name = "textBoxİndirim";
            this.textBoxİndirim.Size = new System.Drawing.Size(253, 27);
            this.textBoxİndirim.TabIndex = 1;
            this.textBoxİndirim.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxİndirim_KeyPress);
            // 
            // textBoxZam
            // 
            this.textBoxZam.Font = new System.Drawing.Font("Barlow Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxZam.Location = new System.Drawing.Point(316, 154);
            this.textBoxZam.MaxLength = 3;
            this.textBoxZam.Name = "textBoxZam";
            this.textBoxZam.Size = new System.Drawing.Size(253, 27);
            this.textBoxZam.TabIndex = 2;
            this.textBoxZam.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxZam_KeyPress);
            // 
            // pictureBoxZam
            // 
            this.pictureBoxZam.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxZam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxZam.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxZam.Image")));
            this.pictureBoxZam.Location = new System.Drawing.Point(316, 196);
            this.pictureBoxZam.Name = "pictureBoxZam";
            this.pictureBoxZam.Size = new System.Drawing.Size(253, 35);
            this.pictureBoxZam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxZam.TabIndex = 3;
            this.pictureBoxZam.TabStop = false;
            this.pictureBoxZam.Click += new System.EventHandler(this.pictureBoxZam_Click);
            this.pictureBoxZam.MouseEnter += new System.EventHandler(this.pictureBoxZam_MouseEnter);
            this.pictureBoxZam.MouseLeave += new System.EventHandler(this.pictureBoxZam_MouseLeave);
            // 
            // labelİndirim
            // 
            this.labelİndirim.AutoSize = true;
            this.labelİndirim.BackColor = System.Drawing.Color.Transparent;
            this.labelİndirim.Font = new System.Drawing.Font("Barlow Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelİndirim.ForeColor = System.Drawing.SystemColors.Control;
            this.labelİndirim.Location = new System.Drawing.Point(23, 127);
            this.labelİndirim.Name = "labelİndirim";
            this.labelİndirim.Size = new System.Drawing.Size(150, 24);
            this.labelİndirim.TabIndex = 4;
            this.labelİndirim.Text = "İndirim Yüzdesi";
            // 
            // labelZam
            // 
            this.labelZam.AutoSize = true;
            this.labelZam.BackColor = System.Drawing.Color.Transparent;
            this.labelZam.Font = new System.Drawing.Font("Barlow Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelZam.ForeColor = System.Drawing.SystemColors.Control;
            this.labelZam.Location = new System.Drawing.Point(312, 127);
            this.labelZam.Name = "labelZam";
            this.labelZam.Size = new System.Drawing.Size(124, 24);
            this.labelZam.TabIndex = 5;
            this.labelZam.Text = "Zam Yüzdesi";
            // 
            // pictureBoxFiyatKucult
            // 
            this.pictureBoxFiyatKucult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxFiyatKucult.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxFiyatKucult.Image")));
            this.pictureBoxFiyatKucult.Location = new System.Drawing.Point(547, 20);
            this.pictureBoxFiyatKucult.Name = "pictureBoxFiyatKucult";
            this.pictureBoxFiyatKucult.Size = new System.Drawing.Size(10, 3);
            this.pictureBoxFiyatKucult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxFiyatKucult.TabIndex = 6;
            this.pictureBoxFiyatKucult.TabStop = false;
            this.pictureBoxFiyatKucult.Click += new System.EventHandler(this.pictureBoxFiyatKucult_Click);
            // 
            // pictureBoxFiyatKapat
            // 
            this.pictureBoxFiyatKapat.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxFiyatKapat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxFiyatKapat.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxFiyatKapat.Image")));
            this.pictureBoxFiyatKapat.Location = new System.Drawing.Point(572, 14);
            this.pictureBoxFiyatKapat.Name = "pictureBoxFiyatKapat";
            this.pictureBoxFiyatKapat.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxFiyatKapat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxFiyatKapat.TabIndex = 7;
            this.pictureBoxFiyatKapat.TabStop = false;
            this.pictureBoxFiyatKapat.Click += new System.EventHandler(this.pictureBoxFiyatKapat_Click);
            // 
            // panelHaraket
            // 
            this.panelHaraket.BackColor = System.Drawing.Color.Transparent;
            this.panelHaraket.Controls.Add(this.pictureBoxFiyatKapat);
            this.panelHaraket.Controls.Add(this.pictureBoxFiyatKucult);
            this.panelHaraket.Location = new System.Drawing.Point(-1, 2);
            this.panelHaraket.Name = "panelHaraket";
            this.panelHaraket.Size = new System.Drawing.Size(607, 47);
            this.panelHaraket.TabIndex = 8;
            this.panelHaraket.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelHaraket_MouseDown);
            this.panelHaraket.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelHaraket_MouseUp);
            // 
            // timerHaraket
            // 
            this.timerHaraket.Tick += new System.EventHandler(this.timerHaraket_Tick);
            // 
            // FrmFiyatGuncelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(602, 315);
            this.Controls.Add(this.panelHaraket);
            this.Controls.Add(this.labelZam);
            this.Controls.Add(this.labelİndirim);
            this.Controls.Add(this.pictureBoxZam);
            this.Controls.Add(this.textBoxZam);
            this.Controls.Add(this.textBoxİndirim);
            this.Controls.Add(this.pictureBoxİndirim);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmFiyatGuncelle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AracKiralamaOtomasyonu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxİndirim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxZam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFiyatKucult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFiyatKapat)).EndInit();
            this.panelHaraket.ResumeLayout(false);
            this.panelHaraket.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxİndirim;
        private System.Windows.Forms.TextBox textBoxİndirim;
        private System.Windows.Forms.TextBox textBoxZam;
        private System.Windows.Forms.PictureBox pictureBoxZam;
        private System.Windows.Forms.Label labelİndirim;
        private System.Windows.Forms.Label labelZam;
        private System.Windows.Forms.PictureBox pictureBoxFiyatKucult;
        private System.Windows.Forms.PictureBox pictureBoxFiyatKapat;
        private System.Windows.Forms.Panel panelHaraket;
        private System.Windows.Forms.Timer timerHaraket;
    }
}