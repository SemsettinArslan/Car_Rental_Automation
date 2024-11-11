using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AracKiralama
{
    public class FrmTasarimMusteri
    {
        Color musteriBaslikRenk = Color.Turquoise;
        Color musteriBilgiRenk = Color.White;
        Font fontMusteriBaslik = new Font("Barlow", 15, FontStyle.Bold);
        Font fontMusteriBilgi = new Font("Barlow Medium", 11);
        public string panelArkaPlanPath = Application.StartupPath + "\\pngler\\tasarim\\araba_bg2.png";
        public string artiResmiPath = Application.StartupPath + "\\pngler\\tasarim\\plus_icon.png";
        public string duzenleResmiPath = Application.StartupPath + "\\pngler\\tasarim\\duzenle.png";
        string resimKaydetPath = Application.StartupPath + "\\pngler\\musteri";
        private Musteri seciliMusteri;
        private Panel panelMusteriİslem;
        //Bu metotta müşteri sekmesinde göstereceğimiz müşterilerin panel tasarımını yapıyoruz.

        public Panel MusteriİslemPanel(Musteri musteri)
        {
            seciliMusteri = musteri;
            Image arkaPlan = Image.FromFile(panelArkaPlanPath);

            panelMusteriİslem = new Panel();
            panelMusteriİslem.BackgroundImage = arkaPlan;
            panelMusteriİslem.Size = new Size(300, 190);
            panelMusteriİslem.Location = new Point(0, 0);

            PictureBox pictureBoxMusteri = new PictureBox();
            pictureBoxMusteri.BackColor = Color.Transparent;
            pictureBoxMusteri.Size = new Size(163, 103);
            pictureBoxMusteri.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxMusteri.Location = new Point(10, 67);
            pictureBoxMusteri.ImageLocation = Path.Combine(resimKaydetPath,musteri.musteriResmi);
            panelMusteriİslem.Controls.Add(pictureBoxMusteri);

            PictureBox pictureBoxDuzenle = new PictureBox();
            pictureBoxDuzenle.BackColor = Color.Transparent;
            pictureBoxDuzenle.Size = new Size(70, 70);
            pictureBoxDuzenle.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxDuzenle.Location = new Point(208, 111);
            pictureBoxDuzenle.ImageLocation = duzenleResmiPath;
            pictureBoxDuzenle.Cursor = Cursors.Hand;
            pictureBoxDuzenle.Click += pictureBoxDuzenle_Click;
            panelMusteriİslem.Controls.Add(pictureBoxDuzenle);

            int x = 185;
            int y = 35;

            for (int i = 0; i < 4; i++)
            {
                PictureBox pictureBoxArtiResmi = new PictureBox();
                pictureBoxArtiResmi.BackColor = Color.Transparent;
                pictureBoxArtiResmi.Size = new Size(10, 10);
                pictureBoxArtiResmi.SizeMode = PictureBoxSizeMode.AutoSize;
                pictureBoxArtiResmi.ImageLocation = artiResmiPath;
                pictureBoxArtiResmi.Location = new Point(x, y);
                panelMusteriİslem.Controls.Add(pictureBoxArtiResmi);
                y = y + 19;
            }

            Label musteriTc = new Label();
            musteriTc.BackColor = Color.Transparent;
            musteriTc.Width = 165;
            musteriTc.Height = musteriTc.Height * 2;
            musteriTc.Font = fontMusteriBaslik;
            musteriTc.ForeColor = musteriBaslikRenk;
            musteriTc.Text = musteri.tc;
            musteriTc.Location = new Point(16, 17);
            panelMusteriİslem.Controls.Add(musteriTc);

            Label musteriAd = new Label();
            musteriAd.BackColor = Color.Transparent;
            musteriAd.Width = 100;
            musteriAd.Font = fontMusteriBilgi;
            musteriAd.ForeColor = musteriBilgiRenk;
            musteriAd.Text = musteri.ad.Length >= 12 ? musteri.ad.Substring(0, 10) + ".." : musteri.ad;
            musteriAd.Location = new Point(195, 31);
            if (musteri.ad.Length >= 12)
            {
                ToolTip musteriAdTip = new ToolTip();
                musteriAdTip.IsBalloon = true;
                musteriAdTip.ShowAlways = true;

                musteriAdTip.SetToolTip(musteriAd, musteri.ad);
            }
            panelMusteriİslem.Controls.Add(musteriAd);

            Label musteriSoyad = new Label();
            musteriSoyad.BackColor = Color.Transparent;
            musteriSoyad.Width = 100;
            musteriSoyad.Font = fontMusteriBilgi;
            musteriSoyad.ForeColor = musteriBilgiRenk;
            musteriSoyad.Text = musteri.soyad;
            musteriSoyad.Location = new Point(195, 50);
            panelMusteriİslem.Controls.Add(musteriSoyad);

            Label musteriTel = new Label();
            musteriTel.BackColor = Color.Transparent;
            musteriTel.Width = 100;
            musteriTel.Font = fontMusteriBilgi;
            musteriTel.ForeColor = musteriBilgiRenk;
            musteriTel.Text = musteri.telefonNumarasi;
            musteriTel.Location = new Point(195, 69);
            panelMusteriİslem.Controls.Add(musteriTel);

            Label musteriKiraSayi = new Label();
            musteriKiraSayi.BackColor = Color.Transparent;
            musteriKiraSayi.Width = 100;
            musteriKiraSayi.Font = fontMusteriBilgi;
            musteriKiraSayi.ForeColor = musteriBilgiRenk;
            musteriKiraSayi.Text = "Kiralama: "+musteri.kiraladigiAracSayisi.ToString();
            musteriKiraSayi.Location = new Point(195, 88);
            panelMusteriİslem.Controls.Add(musteriKiraSayi);

            return panelMusteriİslem;
        }
        private void pictureBoxDuzenle_Click(object sender, EventArgs e)
        {
            if (seciliMusteri != null)
            {
                FrmMusteriDuzenle frmMusteri = new FrmMusteriDuzenle(seciliMusteri, this.panelMusteriİslem.Parent as FrmAnaEkran);
                frmMusteri.ShowDialog();
            }
            else
            {
                MessageBox.Show("Düzenlemek istediğiniz müşteri bulunamadı.");
            }
        }
    }
}
