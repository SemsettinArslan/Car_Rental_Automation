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
    public class FrmTasarimCalisan
    {
        Color musteriBaslikRenk = Color.Turquoise;
        Color musteriBilgiRenk = Color.White;
        Font fontMusteriBaslik = new Font("Barlow", 15, FontStyle.Bold);
        Font fontMusteriBilgi = new Font("Barlow Medium", 11);
        public string panelArkaPlanPath = Application.StartupPath + "\\pngler\\tasarim\\araba_bg2.png";
        public string artiResmiPath = Application.StartupPath + "\\pngler\\tasarim\\plus_icon.png";
        public string duzenleResmiPath = Application.StartupPath + "\\pngler\\tasarim\\duzenle.png";
        string resimKaydetPath = Application.StartupPath + "\\pngler\\calisan";
        private Calisan seciliCalisan;
        private Panel panelCalisanİslem;

        //Bu metotta müşteri sekmesinde göstereceğimiz müşterilerin panel tasarımını yapıyoruz.

        public Panel CalisanİslemPanel(Calisan calisan)
        {
            seciliCalisan = calisan;
            Image arkaPlan = Image.FromFile(panelArkaPlanPath);

            panelCalisanİslem = new Panel();
            panelCalisanİslem.BackgroundImage = arkaPlan;
            panelCalisanİslem.Size = new Size(300, 190);
            panelCalisanİslem.Location = new Point(0, 0);

            PictureBox pictureBoxCalisan = new PictureBox();
            pictureBoxCalisan.BackColor = Color.Transparent;
            pictureBoxCalisan.Size = new Size(163, 103);
            pictureBoxCalisan.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxCalisan.Location = new Point(10, 67);
            pictureBoxCalisan.ImageLocation = Path.Combine(resimKaydetPath,calisan.calisanResmi);
            panelCalisanİslem.Controls.Add(pictureBoxCalisan);

            PictureBox pictureBoxDuzenle = new PictureBox();
            pictureBoxDuzenle.BackColor = Color.Transparent;
            pictureBoxDuzenle.Size = new Size(70, 70);
            pictureBoxDuzenle.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxDuzenle.Location = new Point(208, 111);
            pictureBoxDuzenle.ImageLocation = duzenleResmiPath;
            pictureBoxDuzenle.Click += pictureBoxDuzenle_Click;
            pictureBoxDuzenle.Cursor = Cursors.Hand;
            panelCalisanİslem.Controls.Add(pictureBoxDuzenle);

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
                panelCalisanİslem.Controls.Add(pictureBoxArtiResmi);
                y = y + 19;
            }

            Label calisanTc = new Label();
            calisanTc.BackColor = Color.Transparent;
            calisanTc.Width = 165;
            calisanTc.Height = calisanTc.Height * 2;
            calisanTc.Font = fontMusteriBaslik;
            calisanTc.ForeColor = musteriBaslikRenk;
            calisanTc.Text = calisan.tc;
            calisanTc.Location = new Point(16, 17);
            panelCalisanİslem.Controls.Add(calisanTc);



            Label calisanAd = new Label();
            calisanAd.BackColor = Color.Transparent;
            calisanAd.Width = 100;
            calisanAd.Font = fontMusteriBilgi;
            calisanAd.ForeColor = musteriBilgiRenk;
            calisanAd.Text = calisan.ad;
            calisanAd.Location = new Point(198, 31);
            if (calisan.ad.Length >= 12)
            {
                ToolTip calisanAdTip = new ToolTip();
                calisanAdTip.IsBalloon = true;
                calisanAdTip.ShowAlways = true;

                calisanAdTip.SetToolTip(calisanAd, calisan.ad);
            }
            panelCalisanİslem.Controls.Add(calisanAd);


            Label calisanSoyad = new Label();
            calisanSoyad.BackColor = Color.Transparent;
            calisanSoyad.Width = 100;
            calisanSoyad.Font = fontMusteriBilgi;
            calisanSoyad.ForeColor = musteriBilgiRenk;
            calisanSoyad.Text = calisan.soyad;
            calisanSoyad.Location = new Point(198, 50);
            panelCalisanİslem.Controls.Add(calisanSoyad);

            Label calisanTel = new Label();
            calisanTel.BackColor = Color.Transparent;
            calisanTel.Width = 100;
            calisanTel.Font = fontMusteriBilgi;
            calisanTel.ForeColor = musteriBilgiRenk;
            calisanTel.Text = calisan.telefonNumarasi;
            calisanTel.Location = new Point(198, 69);
            panelCalisanİslem.Controls.Add(calisanTel);

            Label calisanMaas = new Label();
            calisanMaas.BackColor = Color.Transparent;
            calisanMaas.Width = 100;
            calisanMaas.Font = fontMusteriBilgi;
            calisanMaas.ForeColor = musteriBilgiRenk;
            calisanMaas.Text = calisan.maas.ToString();
            calisanMaas.Location = new Point(198, 88);
            panelCalisanİslem.Controls.Add(calisanMaas);

            return panelCalisanİslem;
        }
        private void pictureBoxDuzenle_Click(object sender, EventArgs e)
        {
            if (seciliCalisan != null)
            {
                FrmCalisanDuzenle frmCalisanDuzenle = new FrmCalisanDuzenle(seciliCalisan, this.panelCalisanİslem.Parent as FrmAnaEkran);
                frmCalisanDuzenle.ShowDialog();
            }
            else
            {
                MessageBox.Show("Düzenlemek istediğiniz çalışan bulunamadı.");
            }
        }
    }
}
