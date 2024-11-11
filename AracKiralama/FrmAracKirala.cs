using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AracKiralama
{
    public partial class FrmAracKirala : Form
    {
        VeriTabaniİslemleri veriTabaniİslemleri = new VeriTabaniİslemleri();
        FrmAnaEkran frmAnaEkran;
        FrmYardımcıMetotlar fym = new FrmYardımcıMetotlar();
        string musteriVar = Application.StartupPath + "\\pngler\\tasarim\\ok.png";
        string musteriYok = Application.StartupPath + "\\pngler\\tasarim\\close_normal.png";
        string kirala = Application.StartupPath + "\\pngler\\tasarim\\kirala_2.png";
        string kirala2 = Application.StartupPath + "\\pngler\\tasarim\\kirala_1.png";
        string esle = Application.StartupPath + "\\pngler\\tasarim\\esle_2.png";
        string esle2 = Application.StartupPath + "\\pngler\\tasarim\\esle_1.png";
        string resimKaydetPath = Application.StartupPath + "\\pngler\\arac";
        private TextBox[] aracKiralaTextBox;
        DateTime ehliyetsure;
        private int mouseX;
        private int mouseY;

        //Burada panelldeki bilgileri textboxlara geçiyoruz
        public FrmAracKirala(Arac araba, FrmAnaEkran parent)
        {
            frmAnaEkran = parent;
            InitializeComponent();
            aracKiralaTextBox = new TextBox[] { textBoxKiralaKiraBaslaTarih, textBoxKiralaKiraBitisTarih, textBoxMusteriTcKiralama };
            this.labelaracId.Text = araba.aracId.ToString();
            this.textBoxKiralaPlaka.Text = araba.plaka.ToString();
            this.textBoxKiralaMarka.Text = araba.marka;
            this.textBoxKiralaModel.Text = araba.model;
            this.textBoxKiralaYıl.Text = araba.yıl;
            this.textBoxKiralaKisiSayisi.Text = araba.kisiSayisi.ToString();
            this.textBoxKiralaKilometre.Text = araba.sonKm.ToString();
            this.textBoxYakitKirala.Text = araba.yakitTuru;
            this.textBoxVitesKirala.Text = araba.vitesTuru;
            this.textBoxKiralaUcret.Text = araba.gunlukUcret.ToString();
            this.textBoxKiralaHasar.Text = araba.hasarKaydi.ToString();
            this.textBoxKiralaMuayene.Text = araba.muayeneTarihi.ToShortDateString();
            this.pictureBoxKiralaAracResmi.ImageLocation = Path.Combine(resimKaydetPath, araba.aracResmi.ToString());
        }
        //arac nesnesine id kontrol ederek gerekli bilgileri veriyoruz
        private Arac GetAracKirala()
        {
            Arac a = VeriTabaniİslemleri.araclar.Find(x => x.aracId == Convert.ToInt32(labelaracId.Text.Trim()));
            {
                if (a != null)
                {
                    a.kiradaMi = true;
                    a.kiraMusteriId = Convert.ToInt32(labelMusteriId.Text.Trim());
                    a.kiraBaslangic = DateTime.Parse(textBoxKiralaKiraBaslaTarih.Text.Trim());
                    a.kiraBitis = DateTime.Parse(textBoxKiralaKiraBitisTarih.Text.Trim());
                }
                return a;
            }
        }
        //musteriyi kontrol ederek gerekli bilgileri alıyoruz
        private Musteri GetMusteriKiralama()
        {
            Musteri m = VeriTabaniİslemleri.musteriler.Find(x => x.tc == textBoxMusteriTcKiralama.Text);
            if (m != null)
            {
                
                labelad.Text = m.ad;
                labelsoyad.Text = m.soyad;
                labeltc.Text = m.tc;
                labeltel.Text = m.telefonNumarasi;
                labeladres.Text = m.adres;
                labeldogumtarihi.Text = m.dogumTarihi.ToShortDateString();
                ehliyetsure = m.ehliyetGecerlilikSuresi;
            }
            return m;
        }
        //araç kiralama ve sözleşme oluşturulma işlemini yapıyoruz.
        private void pictureBoxAracKirala_Click(object sender, EventArgs e)
        {
            Musteri musteri = GetMusteriKiralama();
            if (KontrolAracTexBox())
            {
                return;
            }
            var guncelle = MessageBox.Show("Bu aracı kiralamak istediğine emin misin?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (guncelle == DialogResult.Yes)
            {
                Arac kiralaArac = GetAracKirala();
                if (kiralaArac == null)
                {
                    MessageBox.Show("Kiralamak istediğin araç bulunamadı!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (musteri == null)
                    {
                        MessageBox.Show("Müşteri bulunamadı!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (fym.PdfOlustur(textBoxKiralaPlaka.Text.Trim(), textBoxKiralaMarka.Text.Trim(), textBoxKiralaModel.Text.Trim(), DateTime.Parse(textBoxKiralaKiraBaslaTarih.Text), DateTime.Parse(textBoxKiralaKiraBitisTarih.Text), labelad.Text, labelsoyad.Text, labeltc.Text, labeltel.Text, labeladres.Text, Convert.ToInt32(textBoxKiralaUcret.Text), DateTime.Parse(labeldogumtarihi.Text)))
                        {
                            if (veriTabaniİslemleri.AracKirala(kiralaArac, Convert.ToInt32(labelMusteriId.Text.Trim())))
                            {
                                MessageBox.Show("Araç başarıyla kiralandı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                veriTabaniİslemleri.AracCek();
                                veriTabaniİslemleri.MusteriCek();
                                this.Close();
                                frmAnaEkran.AracKiraSayfaYukle();
                            }
                        }
                    }
                }
            }
        }
        //Burada kiralama işleminde textboxları ve diğer koşulları kontrol ediyoruz
        private bool KontrolAracTexBox()
        {
            if (fym.VeriKontrol(5, aracKiralaTextBox))
            {
                return true;
            }
            else if (DateTime.Parse(textBoxKiralaMuayene.Text.Trim()) <= DateTime.Parse(textBoxKiralaKiraBitisTarih.Text.Trim()) && DateTime.Parse(textBoxKiralaMuayene.Text.Trim()) >= DateTime.Parse(textBoxKiralaKiraBaslaTarih.Text.Trim()))
            {
                MessageBox.Show("[Muayene Tarihi] Kira tarihleri arasında olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (DateTime.Parse(textBoxKiralaKiraBaslaTarih.Text.Trim()) > DateTime.Parse(textBoxKiralaKiraBitisTarih.Text.Trim()))
            {
                MessageBox.Show("[Kira Başlangıç] [Kira Bitiş] Tarihinden daha ileride olamaz", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (pictureBoxKiralaOk.ImageLocation != musteriVar)
            {
                MessageBox.Show("Girdiğiniz [TC] değerinde kayıtlı bir [Müşteri) bulunamadı!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (DateTime.Compare(ehliyetsure, DateTime.Parse(textBoxKiralaKiraBaslaTarih.Text.Trim())) < 0)
            {
                MessageBox.Show("[Ehliyet Süresi] dolan kişiye araç kiralanamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }
        //Burada tc numarası bir kayıtla eşleşip eşleşmediğini kontrol ediyoruz
        private void pictureBoxAracEsle_Click(object sender, EventArgs e)
        {
            if (textBoxMusteriTcKiralama.Text.Trim().Length < 11)
            {
                MessageBox.Show("Girdiğiniz [TC] değerinde 11 haneden küçük olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Musteri m = VeriTabaniİslemleri.musteriler.Find(x => x.tc == textBoxMusteriTcKiralama.Text);
            if (m != null)
            {
                labelMusteriId.Text = m.musteriId.ToString();
                pictureBoxKiralaOk.ImageLocation = musteriVar;
            }
            else
            {
                pictureBoxKiralaOk.ImageLocation = musteriYok;
            }
        }

        private void dateTimePickerKiralaKiraBaslaTarih_ValueChanged(object sender, EventArgs e)
        {
            textBoxKiralaKiraBaslaTarih.Text = dateTimePickerKiralaKiraBaslaTarih.Value.ToShortDateString();
        }

        private void dateTimePickerKiralaKiraBitTarih_ValueChanged(object sender, EventArgs e)
        {
            textBoxKiralaKiraBitisTarih.Text = dateTimePickerKiralaKiraBitTarih.Value.ToShortDateString();

        }

        private void pictureBoxKiralaKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBoxKiralaKucult_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBoxAracKirala_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxAracKirala.ImageLocation = kirala;
        }

        private void pictureBoxAracKirala_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxAracKirala.ImageLocation = kirala2;

        }

        private void pictureBoxAracEsle_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxAracEsle.ImageLocation = esle;

        }

        private void pictureBoxAracEsle_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxAracEsle.ImageLocation = esle2;
        }

        private void textBoxMusteriTcKiralama_KeyPress(object sender, KeyPressEventArgs e)
        {
            fym.SadeceSayi(e);
        }

        private void timerHaraket_Tick(object sender, EventArgs e)
        {
            this.Left = MousePosition.X - mouseX;
            this.Top = MousePosition.Y - mouseY;
        }

        private void panelHaraket_MouseDown(object sender, MouseEventArgs e)
        {
            mouseX = MousePosition.X - this.Left;
            mouseY = MousePosition.Y - this.Top;

            timerHaraket.Enabled = true;
        }

        private void panelHaraket_MouseUp(object sender, MouseEventArgs e)
        {
            timerHaraket.Enabled = false;

        }
    }
}
