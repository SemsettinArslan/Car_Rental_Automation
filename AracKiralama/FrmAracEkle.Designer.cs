namespace AracKiralama
{
    partial class FrmAracEkle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAracEkle));
            this.comboBoxEkleVites = new System.Windows.Forms.ComboBox();
            this.labelEkleMuayene = new System.Windows.Forms.Label();
            this.labelEkleAracResmi = new System.Windows.Forms.Label();
            this.labelEkleHasar = new System.Windows.Forms.Label();
            this.labelEkleAktif = new System.Windows.Forms.Label();
            this.labelEkleUcret = new System.Windows.Forms.Label();
            this.labelEkleVites = new System.Windows.Forms.Label();
            this.labelEkleYakit = new System.Windows.Forms.Label();
            this.labelEkleKilometre = new System.Windows.Forms.Label();
            this.labelEkleKisiSayisi = new System.Windows.Forms.Label();
            this.labelEkleYıl = new System.Windows.Forms.Label();
            this.labelEkleModel = new System.Windows.Forms.Label();
            this.labelEkleMarka = new System.Windows.Forms.Label();
            this.labelEklePlaka = new System.Windows.Forms.Label();
            this.textBoxEkleHasar = new System.Windows.Forms.TextBox();
            this.textBoxEkleMuayene = new System.Windows.Forms.TextBox();
            this.textBoxEkleAracResim = new System.Windows.Forms.TextBox();
            this.textBoxEkleUcret = new System.Windows.Forms.TextBox();
            this.textBoxEkleKilometre = new System.Windows.Forms.TextBox();
            this.textBoxEkleKisiSayisi = new System.Windows.Forms.TextBox();
            this.textBoxEkleYıl = new System.Windows.Forms.TextBox();
            this.textBoxEkleModel = new System.Windows.Forms.TextBox();
            this.textBoxEkleMarka = new System.Windows.Forms.TextBox();
            this.textBoxEklePlaka = new System.Windows.Forms.TextBox();
            this.pictureBoxEkleAracResmi = new System.Windows.Forms.PictureBox();
            this.comboBoxEkleYakit = new System.Windows.Forms.ComboBox();
            this.comboBoxEkleAktif = new System.Windows.Forms.ComboBox();
            this.pictureBoxEkle = new System.Windows.Forms.PictureBox();
            this.pictureBoxEkleKapat = new System.Windows.Forms.PictureBox();
            this.pictureBoxEkleKucult = new System.Windows.Forms.PictureBox();
            this.dateTimePickerEkleMuayene = new System.Windows.Forms.DateTimePicker();
            this.pictureBoxAracSecResim = new System.Windows.Forms.PictureBox();
            this.openFileDialogEkleArac = new System.Windows.Forms.OpenFileDialog();
            this.panelHaraket = new System.Windows.Forms.Panel();
            this.timerHaraket = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEkleAracResmi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEkle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEkleKapat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEkleKucult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAracSecResim)).BeginInit();
            this.panelHaraket.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxEkleVites
            // 
            this.comboBoxEkleVites.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEkleVites.Font = new System.Drawing.Font("Barlow Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBoxEkleVites.FormattingEnabled = true;
            this.comboBoxEkleVites.Items.AddRange(new object[] {
            "Manuel",
            "Otomatik"});
            this.comboBoxEkleVites.Location = new System.Drawing.Point(33, 273);
            this.comboBoxEkleVites.Name = "comboBoxEkleVites";
            this.comboBoxEkleVites.Size = new System.Drawing.Size(303, 27);
            this.comboBoxEkleVites.TabIndex = 70;
            // 
            // labelEkleMuayene
            // 
            this.labelEkleMuayene.AutoSize = true;
            this.labelEkleMuayene.BackColor = System.Drawing.Color.Transparent;
            this.labelEkleMuayene.Font = new System.Drawing.Font("Barlow Medium", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelEkleMuayene.ForeColor = System.Drawing.SystemColors.Control;
            this.labelEkleMuayene.Location = new System.Drawing.Point(367, 302);
            this.labelEkleMuayene.Name = "labelEkleMuayene";
            this.labelEkleMuayene.Size = new System.Drawing.Size(107, 17);
            this.labelEkleMuayene.TabIndex = 96;
            this.labelEkleMuayene.Text = "Muayene Tarihi";
            // 
            // labelEkleAracResmi
            // 
            this.labelEkleAracResmi.AutoSize = true;
            this.labelEkleAracResmi.BackColor = System.Drawing.Color.Transparent;
            this.labelEkleAracResmi.Font = new System.Drawing.Font("Barlow Medium", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelEkleAracResmi.ForeColor = System.Drawing.SystemColors.Control;
            this.labelEkleAracResmi.Location = new System.Drawing.Point(367, 259);
            this.labelEkleAracResmi.Name = "labelEkleAracResmi";
            this.labelEkleAracResmi.Size = new System.Drawing.Size(83, 17);
            this.labelEkleAracResmi.TabIndex = 95;
            this.labelEkleAracResmi.Text = "Araç Resmi";
            // 
            // labelEkleHasar
            // 
            this.labelEkleHasar.AutoSize = true;
            this.labelEkleHasar.BackColor = System.Drawing.Color.Transparent;
            this.labelEkleHasar.Font = new System.Drawing.Font("Barlow Medium", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelEkleHasar.ForeColor = System.Drawing.SystemColors.Control;
            this.labelEkleHasar.Location = new System.Drawing.Point(367, 344);
            this.labelEkleHasar.Name = "labelEkleHasar";
            this.labelEkleHasar.Size = new System.Drawing.Size(86, 17);
            this.labelEkleHasar.TabIndex = 94;
            this.labelEkleHasar.Text = "Hasar Kaydı";
            // 
            // labelEkleAktif
            // 
            this.labelEkleAktif.AutoSize = true;
            this.labelEkleAktif.BackColor = System.Drawing.Color.Transparent;
            this.labelEkleAktif.Font = new System.Drawing.Font("Barlow Medium", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelEkleAktif.ForeColor = System.Drawing.SystemColors.Control;
            this.labelEkleAktif.Location = new System.Drawing.Point(30, 343);
            this.labelEkleAktif.Name = "labelEkleAktif";
            this.labelEkleAktif.Size = new System.Drawing.Size(41, 17);
            this.labelEkleAktif.TabIndex = 92;
            this.labelEkleAktif.Text = "Aktif";
            // 
            // labelEkleUcret
            // 
            this.labelEkleUcret.AutoSize = true;
            this.labelEkleUcret.BackColor = System.Drawing.Color.Transparent;
            this.labelEkleUcret.Font = new System.Drawing.Font("Barlow Medium", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelEkleUcret.ForeColor = System.Drawing.SystemColors.Control;
            this.labelEkleUcret.Location = new System.Drawing.Point(30, 300);
            this.labelEkleUcret.Name = "labelEkleUcret";
            this.labelEkleUcret.Size = new System.Drawing.Size(94, 17);
            this.labelEkleUcret.TabIndex = 91;
            this.labelEkleUcret.Text = "Günlük Ücret";
            // 
            // labelEkleVites
            // 
            this.labelEkleVites.AutoSize = true;
            this.labelEkleVites.BackColor = System.Drawing.Color.Transparent;
            this.labelEkleVites.Font = new System.Drawing.Font("Barlow Medium", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelEkleVites.ForeColor = System.Drawing.SystemColors.Control;
            this.labelEkleVites.Location = new System.Drawing.Point(30, 257);
            this.labelEkleVites.Name = "labelEkleVites";
            this.labelEkleVites.Size = new System.Drawing.Size(75, 17);
            this.labelEkleVites.TabIndex = 90;
            this.labelEkleVites.Text = "Vites Türü";
            // 
            // labelEkleYakit
            // 
            this.labelEkleYakit.AutoSize = true;
            this.labelEkleYakit.BackColor = System.Drawing.Color.Transparent;
            this.labelEkleYakit.Font = new System.Drawing.Font("Barlow Medium", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelEkleYakit.ForeColor = System.Drawing.SystemColors.Control;
            this.labelEkleYakit.Location = new System.Drawing.Point(30, 214);
            this.labelEkleYakit.Name = "labelEkleYakit";
            this.labelEkleYakit.Size = new System.Drawing.Size(75, 17);
            this.labelEkleYakit.TabIndex = 89;
            this.labelEkleYakit.Text = "Yakit Türü";
            // 
            // labelEkleKilometre
            // 
            this.labelEkleKilometre.AutoSize = true;
            this.labelEkleKilometre.BackColor = System.Drawing.Color.Transparent;
            this.labelEkleKilometre.Font = new System.Drawing.Font("Barlow Medium", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelEkleKilometre.ForeColor = System.Drawing.SystemColors.Control;
            this.labelEkleKilometre.Location = new System.Drawing.Point(201, 170);
            this.labelEkleKilometre.Name = "labelEkleKilometre";
            this.labelEkleKilometre.Size = new System.Drawing.Size(73, 17);
            this.labelEkleKilometre.TabIndex = 88;
            this.labelEkleKilometre.Text = "Kilometre";
            // 
            // labelEkleKisiSayisi
            // 
            this.labelEkleKisiSayisi.AutoSize = true;
            this.labelEkleKisiSayisi.BackColor = System.Drawing.Color.Transparent;
            this.labelEkleKisiSayisi.Font = new System.Drawing.Font("Barlow Medium", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelEkleKisiSayisi.ForeColor = System.Drawing.SystemColors.Control;
            this.labelEkleKisiSayisi.Location = new System.Drawing.Point(30, 170);
            this.labelEkleKisiSayisi.Name = "labelEkleKisiSayisi";
            this.labelEkleKisiSayisi.Size = new System.Drawing.Size(75, 17);
            this.labelEkleKisiSayisi.TabIndex = 87;
            this.labelEkleKisiSayisi.Text = "Kişi Sayısı";
            // 
            // labelEkleYıl
            // 
            this.labelEkleYıl.AutoSize = true;
            this.labelEkleYıl.BackColor = System.Drawing.Color.Transparent;
            this.labelEkleYıl.Font = new System.Drawing.Font("Barlow Medium", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelEkleYıl.ForeColor = System.Drawing.SystemColors.Control;
            this.labelEkleYıl.Location = new System.Drawing.Point(201, 128);
            this.labelEkleYıl.Name = "labelEkleYıl";
            this.labelEkleYıl.Size = new System.Drawing.Size(25, 17);
            this.labelEkleYıl.TabIndex = 86;
            this.labelEkleYıl.Text = "Yıl";
            // 
            // labelEkleModel
            // 
            this.labelEkleModel.AutoSize = true;
            this.labelEkleModel.BackColor = System.Drawing.Color.Transparent;
            this.labelEkleModel.Font = new System.Drawing.Font("Barlow Medium", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelEkleModel.ForeColor = System.Drawing.SystemColors.Control;
            this.labelEkleModel.Location = new System.Drawing.Point(30, 128);
            this.labelEkleModel.Name = "labelEkleModel";
            this.labelEkleModel.Size = new System.Drawing.Size(46, 17);
            this.labelEkleModel.TabIndex = 85;
            this.labelEkleModel.Text = "Model";
            // 
            // labelEkleMarka
            // 
            this.labelEkleMarka.AutoSize = true;
            this.labelEkleMarka.BackColor = System.Drawing.Color.Transparent;
            this.labelEkleMarka.Font = new System.Drawing.Font("Barlow Medium", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelEkleMarka.ForeColor = System.Drawing.SystemColors.Control;
            this.labelEkleMarka.Location = new System.Drawing.Point(201, 85);
            this.labelEkleMarka.Name = "labelEkleMarka";
            this.labelEkleMarka.Size = new System.Drawing.Size(48, 17);
            this.labelEkleMarka.TabIndex = 84;
            this.labelEkleMarka.Text = "Marka";
            // 
            // labelEklePlaka
            // 
            this.labelEklePlaka.AutoSize = true;
            this.labelEklePlaka.BackColor = System.Drawing.Color.Transparent;
            this.labelEklePlaka.Font = new System.Drawing.Font("Barlow Medium", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelEklePlaka.ForeColor = System.Drawing.SystemColors.Control;
            this.labelEklePlaka.Location = new System.Drawing.Point(30, 85);
            this.labelEklePlaka.Name = "labelEklePlaka";
            this.labelEklePlaka.Size = new System.Drawing.Size(45, 17);
            this.labelEklePlaka.TabIndex = 83;
            this.labelEklePlaka.Text = "Plaka";
            // 
            // textBoxEkleHasar
            // 
            this.textBoxEkleHasar.Font = new System.Drawing.Font("Barlow Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxEkleHasar.Location = new System.Drawing.Point(370, 362);
            this.textBoxEkleHasar.Name = "textBoxEkleHasar";
            this.textBoxEkleHasar.Size = new System.Drawing.Size(278, 25);
            this.textBoxEkleHasar.TabIndex = 74;
            this.textBoxEkleHasar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxEkleHasar_KeyPress);
            // 
            // textBoxEkleMuayene
            // 
            this.textBoxEkleMuayene.Font = new System.Drawing.Font("Barlow Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxEkleMuayene.Location = new System.Drawing.Point(370, 319);
            this.textBoxEkleMuayene.Name = "textBoxEkleMuayene";
            this.textBoxEkleMuayene.ReadOnly = true;
            this.textBoxEkleMuayene.Size = new System.Drawing.Size(278, 25);
            this.textBoxEkleMuayene.TabIndex = 76;
            // 
            // textBoxEkleAracResim
            // 
            this.textBoxEkleAracResim.Font = new System.Drawing.Font("Barlow Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxEkleAracResim.Location = new System.Drawing.Point(370, 276);
            this.textBoxEkleAracResim.Name = "textBoxEkleAracResim";
            this.textBoxEkleAracResim.ReadOnly = true;
            this.textBoxEkleAracResim.Size = new System.Drawing.Size(278, 25);
            this.textBoxEkleAracResim.TabIndex = 75;
            // 
            // textBoxEkleUcret
            // 
            this.textBoxEkleUcret.Font = new System.Drawing.Font("Barlow Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxEkleUcret.Location = new System.Drawing.Point(33, 317);
            this.textBoxEkleUcret.Name = "textBoxEkleUcret";
            this.textBoxEkleUcret.Size = new System.Drawing.Size(303, 25);
            this.textBoxEkleUcret.TabIndex = 71;
            this.textBoxEkleUcret.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxEkleUcret_KeyPress);
            // 
            // textBoxEkleKilometre
            // 
            this.textBoxEkleKilometre.Font = new System.Drawing.Font("Barlow Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxEkleKilometre.Location = new System.Drawing.Point(204, 188);
            this.textBoxEkleKilometre.MaxLength = 8;
            this.textBoxEkleKilometre.Name = "textBoxEkleKilometre";
            this.textBoxEkleKilometre.Size = new System.Drawing.Size(132, 25);
            this.textBoxEkleKilometre.TabIndex = 68;
            this.textBoxEkleKilometre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxEkleKilometre_KeyPress);
            // 
            // textBoxEkleKisiSayisi
            // 
            this.textBoxEkleKisiSayisi.Font = new System.Drawing.Font("Barlow Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxEkleKisiSayisi.Location = new System.Drawing.Point(33, 188);
            this.textBoxEkleKisiSayisi.MaxLength = 2;
            this.textBoxEkleKisiSayisi.Name = "textBoxEkleKisiSayisi";
            this.textBoxEkleKisiSayisi.Size = new System.Drawing.Size(132, 25);
            this.textBoxEkleKisiSayisi.TabIndex = 67;
            this.textBoxEkleKisiSayisi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxEkleKisiSayisi_KeyPress);
            // 
            // textBoxEkleYıl
            // 
            this.textBoxEkleYıl.Font = new System.Drawing.Font("Barlow Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxEkleYıl.Location = new System.Drawing.Point(204, 145);
            this.textBoxEkleYıl.MaxLength = 4;
            this.textBoxEkleYıl.Name = "textBoxEkleYıl";
            this.textBoxEkleYıl.Size = new System.Drawing.Size(132, 25);
            this.textBoxEkleYıl.TabIndex = 66;
            this.textBoxEkleYıl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxEkleYıl_KeyPress);
            // 
            // textBoxEkleModel
            // 
            this.textBoxEkleModel.Font = new System.Drawing.Font("Barlow Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxEkleModel.Location = new System.Drawing.Point(33, 145);
            this.textBoxEkleModel.MaxLength = 20;
            this.textBoxEkleModel.Name = "textBoxEkleModel";
            this.textBoxEkleModel.Size = new System.Drawing.Size(132, 25);
            this.textBoxEkleModel.TabIndex = 65;
            // 
            // textBoxEkleMarka
            // 
            this.textBoxEkleMarka.Font = new System.Drawing.Font("Barlow Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxEkleMarka.Location = new System.Drawing.Point(204, 102);
            this.textBoxEkleMarka.MaxLength = 20;
            this.textBoxEkleMarka.Name = "textBoxEkleMarka";
            this.textBoxEkleMarka.Size = new System.Drawing.Size(132, 25);
            this.textBoxEkleMarka.TabIndex = 64;
            // 
            // textBoxEklePlaka
            // 
            this.textBoxEklePlaka.Font = new System.Drawing.Font("Barlow Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxEklePlaka.Location = new System.Drawing.Point(33, 102);
            this.textBoxEklePlaka.MaxLength = 8;
            this.textBoxEklePlaka.Name = "textBoxEklePlaka";
            this.textBoxEklePlaka.Size = new System.Drawing.Size(132, 25);
            this.textBoxEklePlaka.TabIndex = 63;
            // 
            // pictureBoxEkleAracResmi
            // 
            this.pictureBoxEkleAracResmi.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxEkleAracResmi.Location = new System.Drawing.Point(370, 70);
            this.pictureBoxEkleAracResmi.Name = "pictureBoxEkleAracResmi";
            this.pictureBoxEkleAracResmi.Size = new System.Drawing.Size(278, 186);
            this.pictureBoxEkleAracResmi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxEkleAracResmi.TabIndex = 80;
            this.pictureBoxEkleAracResmi.TabStop = false;
            // 
            // comboBoxEkleYakit
            // 
            this.comboBoxEkleYakit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEkleYakit.Font = new System.Drawing.Font("Barlow Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBoxEkleYakit.FormattingEnabled = true;
            this.comboBoxEkleYakit.Items.AddRange(new object[] {
            "Benzin",
            "Dizel",
            "Elektrik"});
            this.comboBoxEkleYakit.Location = new System.Drawing.Point(33, 231);
            this.comboBoxEkleYakit.Name = "comboBoxEkleYakit";
            this.comboBoxEkleYakit.Size = new System.Drawing.Size(303, 27);
            this.comboBoxEkleYakit.TabIndex = 69;
            // 
            // comboBoxEkleAktif
            // 
            this.comboBoxEkleAktif.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEkleAktif.Font = new System.Drawing.Font("Barlow Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBoxEkleAktif.FormattingEnabled = true;
            this.comboBoxEkleAktif.Items.AddRange(new object[] {
            "Evet",
            "Hayır"});
            this.comboBoxEkleAktif.Location = new System.Drawing.Point(33, 360);
            this.comboBoxEkleAktif.Name = "comboBoxEkleAktif";
            this.comboBoxEkleAktif.Size = new System.Drawing.Size(303, 27);
            this.comboBoxEkleAktif.TabIndex = 72;
            // 
            // pictureBoxEkle
            // 
            this.pictureBoxEkle.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxEkle.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxEkle.Image")));
            this.pictureBoxEkle.Location = new System.Drawing.Point(195, 412);
            this.pictureBoxEkle.Name = "pictureBoxEkle";
            this.pictureBoxEkle.Size = new System.Drawing.Size(279, 48);
            this.pictureBoxEkle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxEkle.TabIndex = 97;
            this.pictureBoxEkle.TabStop = false;
            this.pictureBoxEkle.Click += new System.EventHandler(this.pictureBoxEkle_Click);
            this.pictureBoxEkle.MouseEnter += new System.EventHandler(this.pictureBoxEkle_MouseEnter);
            this.pictureBoxEkle.MouseLeave += new System.EventHandler(this.pictureBoxEkle_MouseLeave);
            // 
            // pictureBoxEkleKapat
            // 
            this.pictureBoxEkleKapat.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxEkleKapat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxEkleKapat.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxEkleKapat.Image")));
            this.pictureBoxEkleKapat.Location = new System.Drawing.Point(646, 12);
            this.pictureBoxEkleKapat.Name = "pictureBoxEkleKapat";
            this.pictureBoxEkleKapat.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxEkleKapat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxEkleKapat.TabIndex = 98;
            this.pictureBoxEkleKapat.TabStop = false;
            this.pictureBoxEkleKapat.Click += new System.EventHandler(this.pictureBoxEkleKapat_Click);
            // 
            // pictureBoxEkleKucult
            // 
            this.pictureBoxEkleKucult.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxEkleKucult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxEkleKucult.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxEkleKucult.Image")));
            this.pictureBoxEkleKucult.Location = new System.Drawing.Point(630, 18);
            this.pictureBoxEkleKucult.Name = "pictureBoxEkleKucult";
            this.pictureBoxEkleKucult.Size = new System.Drawing.Size(10, 3);
            this.pictureBoxEkleKucult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxEkleKucult.TabIndex = 99;
            this.pictureBoxEkleKucult.TabStop = false;
            this.pictureBoxEkleKucult.Click += new System.EventHandler(this.pictureBoxEkleKucult_Click);
            // 
            // dateTimePickerEkleMuayene
            // 
            this.dateTimePickerEkleMuayene.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateTimePickerEkleMuayene.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dateTimePickerEkleMuayene.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimePickerEkleMuayene.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerEkleMuayene.Location = new System.Drawing.Point(631, 318);
            this.dateTimePickerEkleMuayene.Name = "dateTimePickerEkleMuayene";
            this.dateTimePickerEkleMuayene.Size = new System.Drawing.Size(17, 26);
            this.dateTimePickerEkleMuayene.TabIndex = 100;
            this.dateTimePickerEkleMuayene.ValueChanged += new System.EventHandler(this.dateTimePickerEkleMuayene_ValueChanged);
            // 
            // pictureBoxAracSecResim
            // 
            this.pictureBoxAracSecResim.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBoxAracSecResim.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxAracSecResim.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxAracSecResim.Image")));
            this.pictureBoxAracSecResim.Location = new System.Drawing.Point(624, 276);
            this.pictureBoxAracSecResim.Name = "pictureBoxAracSecResim";
            this.pictureBoxAracSecResim.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxAracSecResim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxAracSecResim.TabIndex = 101;
            this.pictureBoxAracSecResim.TabStop = false;
            this.pictureBoxAracSecResim.Click += new System.EventHandler(this.pictureBoxAracSecResim_Click);
            // 
            // openFileDialogEkleArac
            // 
            this.openFileDialogEkleArac.FileName = "openFileDialog1";
            // 
            // panelHaraket
            // 
            this.panelHaraket.BackColor = System.Drawing.Color.Transparent;
            this.panelHaraket.Controls.Add(this.pictureBoxEkleKapat);
            this.panelHaraket.Controls.Add(this.pictureBoxEkleKucult);
            this.panelHaraket.Location = new System.Drawing.Point(3, 0);
            this.panelHaraket.Name = "panelHaraket";
            this.panelHaraket.Size = new System.Drawing.Size(677, 39);
            this.panelHaraket.TabIndex = 102;
            this.panelHaraket.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelHaraket_MouseDown);
            this.panelHaraket.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelHaraket_MouseUp);
            // 
            // timerHaraket
            // 
            this.timerHaraket.Tick += new System.EventHandler(this.timerHaraket_Tick);
            // 
            // FrmAracEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(677, 482);
            this.Controls.Add(this.panelHaraket);
            this.Controls.Add(this.pictureBoxAracSecResim);
            this.Controls.Add(this.dateTimePickerEkleMuayene);
            this.Controls.Add(this.pictureBoxEkle);
            this.Controls.Add(this.comboBoxEkleVites);
            this.Controls.Add(this.labelEkleMuayene);
            this.Controls.Add(this.labelEkleAracResmi);
            this.Controls.Add(this.labelEkleHasar);
            this.Controls.Add(this.labelEkleAktif);
            this.Controls.Add(this.labelEkleUcret);
            this.Controls.Add(this.labelEkleVites);
            this.Controls.Add(this.labelEkleYakit);
            this.Controls.Add(this.labelEkleKilometre);
            this.Controls.Add(this.labelEkleKisiSayisi);
            this.Controls.Add(this.labelEkleYıl);
            this.Controls.Add(this.labelEkleModel);
            this.Controls.Add(this.labelEkleMarka);
            this.Controls.Add(this.labelEklePlaka);
            this.Controls.Add(this.textBoxEkleHasar);
            this.Controls.Add(this.textBoxEkleMuayene);
            this.Controls.Add(this.textBoxEkleAracResim);
            this.Controls.Add(this.textBoxEkleUcret);
            this.Controls.Add(this.textBoxEkleKilometre);
            this.Controls.Add(this.textBoxEkleKisiSayisi);
            this.Controls.Add(this.textBoxEkleYıl);
            this.Controls.Add(this.textBoxEkleModel);
            this.Controls.Add(this.textBoxEkleMarka);
            this.Controls.Add(this.textBoxEklePlaka);
            this.Controls.Add(this.pictureBoxEkleAracResmi);
            this.Controls.Add(this.comboBoxEkleYakit);
            this.Controls.Add(this.comboBoxEkleAktif);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAracEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AracKiralamaOtomasyonu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEkleAracResmi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEkle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEkleKapat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEkleKucult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAracSecResim)).EndInit();
            this.panelHaraket.ResumeLayout(false);
            this.panelHaraket.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxEkleVites;
        private System.Windows.Forms.Label labelEkleMuayene;
        private System.Windows.Forms.Label labelEkleAracResmi;
        private System.Windows.Forms.Label labelEkleHasar;
        private System.Windows.Forms.Label labelEkleAktif;
        private System.Windows.Forms.Label labelEkleUcret;
        private System.Windows.Forms.Label labelEkleVites;
        private System.Windows.Forms.Label labelEkleYakit;
        private System.Windows.Forms.Label labelEkleKilometre;
        private System.Windows.Forms.Label labelEkleKisiSayisi;
        private System.Windows.Forms.Label labelEkleYıl;
        private System.Windows.Forms.Label labelEkleModel;
        private System.Windows.Forms.Label labelEkleMarka;
        private System.Windows.Forms.Label labelEklePlaka;
        private System.Windows.Forms.TextBox textBoxEkleHasar;
        private System.Windows.Forms.TextBox textBoxEkleMuayene;
        private System.Windows.Forms.TextBox textBoxEkleAracResim;
        private System.Windows.Forms.TextBox textBoxEkleUcret;
        private System.Windows.Forms.TextBox textBoxEkleKilometre;
        private System.Windows.Forms.TextBox textBoxEkleKisiSayisi;
        private System.Windows.Forms.TextBox textBoxEkleYıl;
        private System.Windows.Forms.TextBox textBoxEkleModel;
        private System.Windows.Forms.TextBox textBoxEkleMarka;
        private System.Windows.Forms.TextBox textBoxEklePlaka;
        private System.Windows.Forms.PictureBox pictureBoxEkleAracResmi;
        private System.Windows.Forms.ComboBox comboBoxEkleYakit;
        private System.Windows.Forms.ComboBox comboBoxEkleAktif;
        private System.Windows.Forms.PictureBox pictureBoxEkle;
        private System.Windows.Forms.PictureBox pictureBoxEkleKapat;
        private System.Windows.Forms.PictureBox pictureBoxEkleKucult;
        private System.Windows.Forms.DateTimePicker dateTimePickerEkleMuayene;
        private System.Windows.Forms.PictureBox pictureBoxAracSecResim;
        private System.Windows.Forms.OpenFileDialog openFileDialogEkleArac;
        private System.Windows.Forms.Panel panelHaraket;
        private System.Windows.Forms.Timer timerHaraket;
    }
}