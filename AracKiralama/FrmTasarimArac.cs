using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AracKiralama
{
    public class FrmTasarimArac
    {

        Color aracBaslikRenk = Color.Turquoise;
        Color aracBilgiRenk = Color.White;
        Font fontAracBaslik = new Font("Barlow", 15, FontStyle.Bold);
        Font fontAracBilgi = new Font("Barlow Medium", 11);
        VeriTabaniİslemleri veriTabaniİslemleri = new VeriTabaniİslemleri();
        public string panelArkaPlanPath = Application.StartupPath + "\\pngler\\tasarim\\araba_bg2.png";
        public string artiResmiPath = Application.StartupPath + "\\pngler\\tasarim\\plus_icon.png";
        public string duzenleResmiPath = Application.StartupPath + "\\pngler\\tasarim\\duzenle.png";
        public string teslimAlPath = Application.StartupPath + "\\pngler\\tasarim\\teslimal.png";
        public string kiralaResmiPath = Application.StartupPath + "\\pngler\\tasarim\\kirala.png";
        string resimKaydetPath = Application.StartupPath + "\\pngler\\arac";
        private Arac seciliArac;
        private Panel panelAracİslem;
        private Panel panelAracKirala;
        private Panel panelKiraRapor;
        FrmAnaEkran frmAnaEkran;
        //Bu metotta araç sekmesinde göstereceğimiz araçların panel tasarımını yapıyoruz.

        public Panel AracİslemPanel(Arac araba)
        {
            seciliArac = araba;
            Image arkaPlan = Image.FromFile(panelArkaPlanPath);
            
            panelAracİslem = new Panel();
            panelAracİslem.BackgroundImage = arkaPlan;
            panelAracİslem.Size = new Size(300, 190);
            panelAracİslem.Location = new Point(0, 0);

            PictureBox pictureBoxArac = new PictureBox();
            pictureBoxArac.BackColor = Color.Transparent;
            pictureBoxArac.Size = new Size(163, 103);
            pictureBoxArac.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxArac.Location = new Point(10, 67);
            pictureBoxArac.ImageLocation =Path.Combine(resimKaydetPath,araba.aracResmi);
            panelAracİslem.Controls.Add(pictureBoxArac);

            PictureBox pictureBoxDuzenle = new PictureBox();
            pictureBoxDuzenle.BackColor = Color.Transparent;
            pictureBoxDuzenle.Size = new Size(70, 70);
            pictureBoxDuzenle.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxDuzenle.Location = new Point(208, 111);
            pictureBoxDuzenle.ImageLocation = duzenleResmiPath;
            pictureBoxDuzenle.Cursor = Cursors.Hand;
            pictureBoxDuzenle.Click += pictureBoxDuzenle_Click;
            panelAracİslem.Controls.Add(pictureBoxDuzenle);

            int x = 194;
            int y = 35;

            for (int i = 0; i < 4; i++)
            {
                PictureBox pictureBoxArtiResmi = new PictureBox();
                pictureBoxArtiResmi.BackColor = Color.Transparent;
                pictureBoxArtiResmi.Size = new Size(10, 10);
                pictureBoxArtiResmi.SizeMode = PictureBoxSizeMode.AutoSize;
                pictureBoxArtiResmi.ImageLocation = artiResmiPath;
                pictureBoxArtiResmi.Location = new Point(x, y);
                panelAracİslem.Controls.Add(pictureBoxArtiResmi);
                y = y + 19;
            }

            Label aracBaslik = new Label();
            aracBaslik.BackColor = Color.Transparent;
            aracBaslik.Width = 165;
            aracBaslik.Height = aracBaslik.Height * 2;
            aracBaslik.Font = fontAracBaslik;
            aracBaslik.ForeColor = aracBaslikRenk;
            aracBaslik.Text = araba.marka + "\n" + araba.model;
            aracBaslik.Location = new Point(16, 17);
            panelAracİslem.Controls.Add(aracBaslik);

            Label aracFiyat = new Label();
            aracFiyat.BackColor = Color.Transparent;
            aracFiyat.Width = 100;
            aracFiyat.Font = fontAracBilgi;
            aracFiyat.ForeColor = aracBilgiRenk;
            aracFiyat.Text = araba.gunlukUcret.ToString() + "TL";
            aracFiyat.Location = new Point(207, 31);
            panelAracİslem.Controls.Add(aracFiyat);

            Label aracVites = new Label();
            aracVites.BackColor = Color.Transparent;
            aracVites.Width = 100;
            aracVites.Font = fontAracBilgi;
            aracVites.ForeColor = aracBilgiRenk;
            aracVites.Text = araba.vitesTuru;
            aracVites.Location = new Point(207, 50);
            panelAracİslem.Controls.Add(aracVites);

            Label aracYakit = new Label();
            aracYakit.BackColor = Color.Transparent;
            aracYakit.Width = 100;
            aracYakit.Font = fontAracBilgi;
            aracYakit.ForeColor = aracBilgiRenk;
            aracYakit.Text = araba.yakitTuru;
            aracYakit.Location = new Point(207, 69);
            panelAracİslem.Controls.Add(aracYakit);

            Label aracKisi = new Label();
            aracKisi.BackColor = Color.Transparent;
            aracKisi.Width = 100;
            aracKisi.Font = fontAracBilgi;
            aracKisi.ForeColor = aracBilgiRenk;
            aracKisi.Text = araba.kisiSayisi.ToString() + "Kişilik";
            aracKisi.Location = new Point(207, 88);
            panelAracİslem.Controls.Add(aracKisi);
            return panelAracİslem;
        }
        private void pictureBoxDuzenle_Click(object sender, EventArgs e)
        {
            if (seciliArac != null)
            {
                FrmAracDuzenle frmAracDuzenle = new FrmAracDuzenle(seciliArac,this.panelAracİslem.Parent as FrmAnaEkran);
                frmAracDuzenle.ShowDialog();
            }
            else
            {
                MessageBox.Show("Düzenlemek istediğiniz araç bulunamadı.");
            }
        }

        //Bu metotda arac kiralama panelinin tasarımını yapıyoruz.

        public Panel AracKiralaPanel(Arac araba)
        {
            seciliArac = araba;
            Image arkaPlan = Image.FromFile(panelArkaPlanPath);

            panelAracKirala = new Panel();
            panelAracKirala.BackgroundImage = arkaPlan;
            panelAracKirala.Size = new Size(300, 190);
            panelAracKirala.Location = new Point(500, 0);

            PictureBox pictureBoxAracKiralik = new PictureBox();
            pictureBoxAracKiralik.BackColor = Color.Transparent;
            pictureBoxAracKiralik.Size = new Size(163, 103);
            pictureBoxAracKiralik.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxAracKiralik.Location = new Point(10, 67);
            pictureBoxAracKiralik.ImageLocation = Path.Combine(resimKaydetPath,araba.aracResmi);
            panelAracKirala.Controls.Add(pictureBoxAracKiralik);

            PictureBox pictureBoxKirala = new PictureBox();
            pictureBoxKirala.BackColor = Color.Transparent;
            pictureBoxKirala.Cursor = Cursors.Hand;
            pictureBoxKirala.Size = new Size(70, 70);
            pictureBoxKirala.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxKirala.Location = new Point(208, 111);
            pictureBoxKirala.ImageLocation = kiralaResmiPath;
            pictureBoxKirala.Click += pictureBoxKirala_Click;
            panelAracKirala.Controls.Add(pictureBoxKirala);

            int x = 194;
            int y = 35;

            for (int i = 0; i < 4; i++)
            {
                PictureBox pictureBoxArtiResmiKiralama = new PictureBox();
                pictureBoxArtiResmiKiralama.BackColor = Color.Transparent;
                pictureBoxArtiResmiKiralama.Size = new Size(10, 10);
                pictureBoxArtiResmiKiralama.SizeMode = PictureBoxSizeMode.AutoSize;
                pictureBoxArtiResmiKiralama.ImageLocation = artiResmiPath;
                pictureBoxArtiResmiKiralama.Location = new Point(x, y);
                panelAracKirala.Controls.Add(pictureBoxArtiResmiKiralama);
                y = y + 19;
            }

            Label aracBaslikKiralik = new Label();
            aracBaslikKiralik.BackColor = Color.Transparent;
            aracBaslikKiralik.Width = 165;
            aracBaslikKiralik.Height = aracBaslikKiralik.Height * 2;
            aracBaslikKiralik.Font = fontAracBaslik;
            aracBaslikKiralik.ForeColor = aracBaslikRenk;
            aracBaslikKiralik.Text = araba.marka+"\n"+araba.model;
            aracBaslikKiralik.Location = new Point(16, 17);
            panelAracKirala.Controls.Add(aracBaslikKiralik);

            Label aracFiyatKiralik = new Label();
            aracFiyatKiralik.BackColor = Color.Transparent;
            aracFiyatKiralik.Width = 100;
            aracFiyatKiralik.Font = fontAracBilgi;
            aracFiyatKiralik.ForeColor = aracBilgiRenk;
            aracFiyatKiralik.Text = araba.gunlukUcret.ToString();
            aracFiyatKiralik.Location = new Point(207, 31);
            panelAracKirala.Controls.Add(aracFiyatKiralik);

            Label aracVitesKiralik = new Label();
            aracVitesKiralik.BackColor = Color.Transparent;
            aracVitesKiralik.Width = 100;
            aracVitesKiralik.Font = fontAracBilgi;
            aracVitesKiralik.ForeColor = aracBilgiRenk;
            aracVitesKiralik.Text = araba.vitesTuru;
            aracVitesKiralik.Location = new Point(207, 50);
            panelAracKirala.Controls.Add(aracVitesKiralik);

            Label aracYakitKiralik = new Label();
            aracYakitKiralik.BackColor = Color.Transparent;
            aracYakitKiralik.Width = 100;
            aracYakitKiralik.Font = fontAracBilgi;
            aracYakitKiralik.ForeColor = aracBilgiRenk;
            aracYakitKiralik.Text = araba.yakitTuru;
            aracYakitKiralik.Location = new Point(207, 69);
            panelAracKirala.Controls.Add(aracYakitKiralik);

            Label aracKisiKiralik = new Label();
            aracKisiKiralik.BackColor = Color.Transparent;
            aracKisiKiralik.Width = 100;
            aracKisiKiralik.Font = fontAracBilgi;
            aracKisiKiralik.ForeColor = aracBilgiRenk;
            aracKisiKiralik.Text = araba.kisiSayisi.ToString()+"Kişilik";
            aracKisiKiralik.Location = new Point(207, 88);
            panelAracKirala.Controls.Add(aracKisiKiralik);

            return panelAracKirala;
        }
        private void pictureBoxKirala_Click(object sender, EventArgs e)
        {
            if (seciliArac != null)
            {
                FrmAracKirala frmAracKirala = new FrmAracKirala(seciliArac, this.panelAracKirala.Parent as FrmAnaEkran);
                frmAracKirala.ShowDialog();
            }
            else
            {
                MessageBox.Show("Düzenlemek istediğiniz araç bulunamadı.");
            }
        }
        //Bu metotta arac teslim alma panellerinin tasarımını yapıyoruz
        public Panel AracTeslimPanel(Arac araba,FrmAnaEkran parent)
        {
            frmAnaEkran = parent;
            seciliArac = araba;
            Image arkaPlan = Image.FromFile(panelArkaPlanPath);


            panelKiraRapor = new Panel();
            panelKiraRapor.BackgroundImage = arkaPlan;
            panelKiraRapor.Size = new Size(300, 190);
            panelKiraRapor.Location = new Point(0, 0);

            PictureBox pictureBoxArac = new PictureBox();
            pictureBoxArac.BackColor = Color.Transparent;
            pictureBoxArac.Size = new Size(163, 103);
            pictureBoxArac.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxArac.Location = new Point(10, 67);
            pictureBoxArac.ImageLocation = Path.Combine(resimKaydetPath, araba.aracResmi);
            panelKiraRapor.Controls.Add(pictureBoxArac);

            PictureBox pictureBoxTeslimAl = new PictureBox();
            pictureBoxTeslimAl.BackColor = Color.Transparent;
            pictureBoxTeslimAl.Size = new Size(70, 70);
            pictureBoxTeslimAl.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxTeslimAl.Location = new Point(208, 111);
            pictureBoxTeslimAl.ImageLocation = teslimAlPath;
            pictureBoxTeslimAl.Cursor = Cursors.Hand;
            pictureBoxTeslimAl.Click += pictureBoxTeslimAl_Click;
            panelKiraRapor.Controls.Add(pictureBoxTeslimAl);

            int x = 190;
            int y = 35;

            for (int i = 0; i < 3; i++)
            {
                PictureBox pictureBoxArtiResmi = new PictureBox();
                pictureBoxArtiResmi.BackColor = Color.Transparent;
                pictureBoxArtiResmi.Size = new Size(10, 10);
                pictureBoxArtiResmi.SizeMode = PictureBoxSizeMode.AutoSize;
                pictureBoxArtiResmi.ImageLocation = artiResmiPath;
                pictureBoxArtiResmi.Location = new Point(x, y);
                panelKiraRapor.Controls.Add(pictureBoxArtiResmi);
                y = y + 19;
            }

            Label aracBaslik = new Label();
            aracBaslik.BackColor = Color.Transparent;
            aracBaslik.Width = 165;
            aracBaslik.Height = aracBaslik.Height * 2;
            aracBaslik.Font = fontAracBaslik;
            aracBaslik.ForeColor = aracBaslikRenk;
            aracBaslik.Text = araba.marka + "\n" + araba.model;
            aracBaslik.Location = new Point(16, 17);
            panelKiraRapor.Controls.Add(aracBaslik);

            Label aracKiralayanMusteriId = new Label();
            aracKiralayanMusteriId.BackColor = Color.Transparent;
            aracKiralayanMusteriId.Width = 100;
            aracKiralayanMusteriId.Font = fontAracBilgi;
            aracKiralayanMusteriId.ForeColor = aracBilgiRenk;
            aracKiralayanMusteriId.Text = "Musteri Id:"+araba.kiraMusteriId.ToString();
            aracKiralayanMusteriId.Location = new Point(200, 31);
            panelKiraRapor.Controls.Add(aracKiralayanMusteriId);

            Label aracKiraTarih = new Label();
            aracKiraTarih.BackColor = Color.Transparent;
            aracKiraTarih.Width = 100;
            aracKiraTarih.Font = fontAracBilgi;
            aracKiraTarih.ForeColor = aracBilgiRenk;
            aracKiraTarih.Text = araba.kiraBaslangic.ToString("dd.MM.yyyy");
            aracKiraTarih.Location = new Point(200, 50);
            panelKiraRapor.Controls.Add(aracKiraTarih);

            Label aracKiraBit = new Label();
            aracKiraBit.BackColor = Color.Transparent;
            aracKiraBit.Width = 100;
            aracKiraBit.Font = fontAracBilgi;
            aracKiraBit.ForeColor = aracBilgiRenk;
            aracKiraBit.Text = araba.kiraBitis.ToString("dd.MM.yyyy");
            aracKiraBit.Location = new Point(200, 69);
            panelKiraRapor.Controls.Add(aracKiraBit);
            return panelKiraRapor;
        }
        private void pictureBoxTeslimAl_Click(object sender, EventArgs e)
        {
            if (seciliArac != null)
            {
                var teslim = MessageBox.Show("Bu aracı teslim almak istediğine emin misin?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (teslim == DialogResult.Yes)
                {
                    veriTabaniİslemleri.AracTeslimAl(seciliArac.aracId);
                    veriTabaniİslemleri.AracCek();
                    if(frmAnaEkran != null)
                    {
                        frmAnaEkran.Guncelle();
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Düzenlemek istediğiniz araç bulunamadı.");
            }
        }
    }
}
