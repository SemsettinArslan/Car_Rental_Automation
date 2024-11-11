using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AracKiralama
{
    public partial class FrmAracDuzenle : Form
    {
        VeriTabaniİslemleri veriTabaniİslemleri = new VeriTabaniİslemleri();
        FrmYardımcıMetotlar fym = new FrmYardımcıMetotlar();
        FrmAnaEkran frmAnaEkran;
        string guncelleResmiPath = Application.StartupPath + "\\pngler\\tasarim\\guncelle_2.png";
        string guncelleResmiPath2 = Application.StartupPath + "\\pngler\\tasarim\\guncelle_1.png";
        string silResmiPath = Application.StartupPath + "\\pngler\\tasarim\\sil_2.png";
        string silResmiPath2 = Application.StartupPath + "\\pngler\\tasarim\\sil_1.png";
        string resimKaydetPath = Application.StartupPath + "\\pngler\\arac";
        private TextBox[] aracTextBox;
        private TextBox textBoxYakit;
        private TextBox textBoxVites;
        private TextBox textBoxAkitf;
        private TextBox textBoxKirada;
        private string plakaKontrol;
        int mouseX;
        int mouseY;
        //Yapıcı metot oluştururken textboxlara o paneldeki aracın bilgilerini yazdırıyoruz
        public FrmAracDuzenle(Arac araba, FrmAnaEkran parent)
        {
            InitializeComponent();
            frmAnaEkran = parent;
            textBoxYakit = new TextBox();
            textBoxVites = new TextBox();
            textBoxAkitf = new TextBox();
            textBoxKirada = new TextBox();
            aracTextBox = new TextBox[] { textBoxDuzenlePlaka, textBoxDuzenleMarka, textBoxDuzenleModel, textBoxDuzenleYıl, textBoxDuzenleKisiSayisi, textBoxDuzenleKilometre, textBoxYakit, textBoxVites, textBoxDuzenleUcret, textBoxAkitf, textBoxKirada, textBoxDuzenleHasar, textBoxDuzenleMuayene, textBoxDuzenleKiraBaslaTarih, textBoxDuzenleKiraBitisTarih, textBoxDuzenleKiralaMusteriId, textBoxDuzenleAracResim };
            this.labelDuzenleAracId.Text = araba.aracId.ToString();
            this.textBoxDuzenlePlaka.Text = araba.plaka;
            this.textBoxDuzenleMarka.Text = araba.marka;
            this.textBoxDuzenleModel.Text = araba.model;
            this.textBoxDuzenleYıl.Text = araba.yıl;
            this.textBoxDuzenleKilometre.Text = araba.sonKm.ToString();
            this.textBoxDuzenleKisiSayisi.Text = araba.kisiSayisi.ToString();
            if (araba.yakitTuru == "Benzin")
            {
                this.comboBoxDuzenleYakit.SelectedIndex = 0;
            }
            else if (araba.yakitTuru == "Dizel")
            {
                this.comboBoxDuzenleYakit.SelectedIndex = 1;
            }
            else if (araba.yakitTuru == "Elektrik")
            {
                this.comboBoxDuzenleYakit.SelectedIndex = 2;
            }
            this.comboBoxDuzenleYakit.Text = comboBoxDuzenleYakit.SelectedIndex.ToString();

            if (araba.vitesTuru == "Manuel")
            {
                this.comboBoxDuzenleVites.SelectedIndex = 0;
            }
            else if (araba.vitesTuru == "Otomatik")
            {
                this.comboBoxDuzenleVites.SelectedIndex = 1;
            }
            comboBoxDuzenleVites.Text = comboBoxDuzenleVites.SelectedIndex.ToString();
            this.textBoxDuzenleUcret.Text = araba.gunlukUcret.ToString();

            if (araba.aktifMi)
            {
                this.comboBoxDuzenleAktif.SelectedIndex = 0;
            }
            else
            {
                this.comboBoxDuzenleAktif.SelectedIndex = 1;
            }
            this.comboBoxDuzenleAktif.Text = comboBoxDuzenleAktif.SelectedIndex.ToString();

            if (araba.kiradaMi)
            {
                this.comboBoxDuzenleKirada.SelectedIndex = 0;
            }
            else
            {
                this.comboBoxDuzenleKirada.SelectedIndex = 1;
            }

            this.comboBoxDuzenleKirada.Text = comboBoxDuzenleKirada.SelectedIndex.ToString();
            this.textBoxDuzenleHasar.Text = araba.hasarKaydi.ToString();
            this.textBoxDuzenleMuayene.Text = araba.muayeneTarihi.ToShortDateString();
            this.textBoxDuzenleKiraBaslaTarih.Text = araba.kiraBaslangic.ToShortDateString();
            this.textBoxDuzenleKiraBitisTarih.Text = araba.kiraBitis.ToShortDateString();
            this.textBoxDuzenleKiralaMusteriId.Text = araba.kiraMusteriId.ToString();
            this.textBoxDuzenleAracResim.Text = araba.aracResmi.ToString();
            pictureBoxDuzenleAracResmi.ImageLocation = Path.Combine(resimKaydetPath, araba.aracResmi);
            plakaKontrol = textBoxDuzenlePlaka.Text.Trim();
        }
        //Bu metotta araç düzenleme yaparken kontrol edilecek tüm koşulları ayarlıyoruz
        private bool KontrolAracTextBox()
        {
            Arac arac = VeriTabaniİslemleri.araclar.Find(x => x.plaka == textBoxDuzenlePlaka.Text.Trim());
            string plaka = textBoxDuzenlePlaka.Text.Trim();
            string plakaDeseni = @"^[1-9]\d{1,2}[A-ZÇĞİÖŞÜ]{1,3}\d{1,4}$";
            textBoxYakit.Text = comboBoxDuzenleYakit.Text.Trim();
            textBoxVites.Text = comboBoxDuzenleVites.Text.Trim();
            textBoxAkitf.Text = comboBoxDuzenleAktif.Text.Trim();
            textBoxKirada.Text = comboBoxDuzenleKirada.Text.Trim();
            if (fym.VeriKontrol(4, aracTextBox))
            {
                return true;
            }
            else if (!Regex.IsMatch(plaka.ToUpper(), plakaDeseni))
            {
                MessageBox.Show("[Plaka] girişi hatalı!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (textBoxDuzenlePlaka.Text.Trim().Length < 6)
            {
                MessageBox.Show("[Plaka] 6 haneden küçük olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (textBoxDuzenleYıl.Text.Trim().Length < 4)
            {
                MessageBox.Show("[Yıl] 4 haneden küçük olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (Convert.ToInt32(textBoxDuzenleYıl.Text.Trim()) > 2024)
            {
                MessageBox.Show("[Yıl] 2024'den büyük olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (Convert.ToInt32(textBoxDuzenleYıl.Text.Trim()) < 1900)
            {
                MessageBox.Show("[Yıl] 1900'den küçük olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (Convert.ToInt32(textBoxDuzenleKisiSayisi.Text.Trim()) < 0)
            {
                MessageBox.Show("[Kişi Sayısı] 0'dan küçük olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (Convert.ToInt32(textBoxDuzenleKilometre.Text.Trim()) < 0)
            {
                MessageBox.Show("[Kilometre] 0'dan küçük olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (Convert.ToInt32(textBoxDuzenleUcret.Text.Trim()) < 0)
            {
                MessageBox.Show("[Günlük Ücret] 0'dan küçük olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (Convert.ToInt32(textBoxDuzenleHasar.Text.Trim()) < 0)
            {
                MessageBox.Show("[Hasar Kaydı] 0'dan küçük olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (DateTime.Parse(textBoxDuzenleMuayene.Text.Trim()) < DateTime.Now)
            {
                MessageBox.Show("[Muayene Tarihi] geçerli bir tarih giriniz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (Convert.ToInt32(textBoxDuzenleKiralaMusteriId.Text.Trim()) < 0)
            {
                MessageBox.Show("[Kira Müşteri Id] 0'dan küçük olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (DateTime.Parse(textBoxDuzenleKiraBaslaTarih.Text.Trim()) > DateTime.Parse(textBoxDuzenleKiraBitisTarih.Text.Trim()))
            {
                MessageBox.Show("[Kira Başlangıç Tarihi] [Kira Bitiş Tarihi]'nden büyük olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (plakaKontrol != textBoxDuzenlePlaka.Text.Trim())
            {
                if (arac != null)
                {
                    MessageBox.Show("Girilen [Plaka] kayıtlı!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return false;
        }
        //Bu metotta araç idsine göre arac nesnesine gerekli bilgileri verip güncelleme metoduna veriyoruz
        private Arac GetArac()
        {
            bool aktif = true;
            bool kira = true;
            if (comboBoxDuzenleAktif.SelectedIndex == 1)
            {
                aktif = false;
            }
            if (comboBoxDuzenleKirada.SelectedIndex == 1)
            {
                kira = false;
            }
            Arac a = VeriTabaniİslemleri.araclar.Find(x => x.aracId == Convert.ToInt32(labelDuzenleAracId.Text.Trim()));
            if (a != null)
            {
                a.plaka = textBoxDuzenlePlaka.Text.Trim();
                a.marka = textBoxDuzenleMarka.Text.Trim();
                a.model = textBoxDuzenleModel.Text.Trim();
                a.yıl = textBoxDuzenleYıl.Text.Trim();
                a.kisiSayisi = Convert.ToInt32(textBoxDuzenleKisiSayisi.Text.Trim());
                a.sonKm = Convert.ToInt32(textBoxDuzenleKilometre.Text.Trim());
                a.yakitTuru = comboBoxDuzenleYakit.Text.Trim();
                a.vitesTuru = comboBoxDuzenleVites.Text.Trim();
                a.gunlukUcret = Convert.ToInt32(textBoxDuzenleUcret.Text.Trim());
                a.aktifMi = aktif;
                a.kiradaMi = kira;
                a.hasarKaydi = Convert.ToInt32(textBoxDuzenleHasar.Text.Trim());
                a.muayeneTarihi = DateTime.Parse(textBoxDuzenleMuayene.Text.Trim());
                a.kiraBaslangic = DateTime.Parse(textBoxDuzenleKiraBaslaTarih.Text.Trim());
                a.kiraBitis = DateTime.Parse(textBoxDuzenleKiraBitisTarih.Text.Trim());
                a.kiraMusteriId = Convert.ToInt32(textBoxDuzenleKiralaMusteriId.Text.Trim());
                a.aracResmi = textBoxDuzenleAracResim.Text.Trim();
            }
            return a;

        }
        //Burada kontrol ettikten sonra aracı güncelliyoruz
        private void pictureBoxDuzenleGuncelle_Click(object sender, EventArgs e)
        {
            if (KontrolAracTextBox())
            {
                return;
            }
            var guncelle = MessageBox.Show("Bu aracı güncellemek istediğine emin misin?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (guncelle == DialogResult.Yes)
            {
                Arac guncelleArac = GetArac();
                if (guncelleArac == null)
                {
                    MessageBox.Show("Güncellemek istediğin araç bulunamadı!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (veriTabaniİslemleri.AracGuncelle(guncelleArac))
                    {
                        MessageBox.Show("Araç başarıyla Güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        veriTabaniİslemleri.AracCek();
                        this.Close();
                        frmAnaEkran.AracSayfaYukle();
                    }
                }
            }
        }

        private void pictureBoxDuzenleGuncelle_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBoxDuzenleGuncelle.ImageLocation = guncelleResmiPath;
        }

        private void pictureBoxDuzenleGuncelle_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBoxDuzenleGuncelle.ImageLocation = guncelleResmiPath2;
        }

        private void pictureBoxDuzenleSil_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBoxDuzenleSil.ImageLocation = silResmiPath;

        }

        private void pictureBoxDuzenleSil_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBoxDuzenleSil.ImageLocation = silResmiPath2;

        }
        private void dateTimePickerDuzenleMuayene_ValueChanged(object sender, EventArgs e)
        {
            this.textBoxDuzenleMuayene.Text = dateTimePickerDuzenleMuayene.Value.ToShortDateString();
        }
        //araç silme işlemini burada yapıyoruz.
        private void pictureBoxDuzenleSil_Click(object sender, EventArgs e)
        {
            if (veriTabaniİslemleri.AracSil(Convert.ToInt32(labelDuzenleAracId.Text.Trim())))
            {
                var kapat = MessageBox.Show("Araç başarıyla silindi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (kapat == DialogResult.OK)
                {
                    veriTabaniİslemleri.AracCek();
                    frmAnaEkran.AracSayfaYukle();
                    this.Close();
                }
            }
        }
        private void pictureBoxDuzenleKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dateTimePickerDuzenleKiraBaslaTarih_ValueChanged(object sender, EventArgs e)
        {
            textBoxDuzenleKiraBaslaTarih.Text = dateTimePickerDuzenleKiraBaslaTarih.Value.ToShortDateString();
        }
        private void dateTimePickerDuzenleKiraBitTarih_ValueChanged(object sender, EventArgs e)
        {
            textBoxDuzenleKiraBitisTarih.Text = dateTimePickerDuzenleKiraBitTarih.Value.ToShortDateString();
        }
        //Bu metotta araç resmi seçerek o resmin ismini alıp bir dosyaya kaydedilmesini sağlıyoruz
        private void pictureBoxDuzenleSecResim_Click(object sender, EventArgs e)
        {
            openFileDialogAracDuzenle.Title = "Resim Seçiniz";
            openFileDialogAracDuzenle.Filter = "Png Dosyaları(*.png)|*.png";
            openFileDialogAracDuzenle.FileName = "";
            if (openFileDialogAracDuzenle.ShowDialog() == DialogResult.OK)
            {
                textBoxDuzenleAracResim.Text = Path.GetFileName(openFileDialogAracDuzenle.FileName);
                pictureBoxDuzenleAracResmi.ImageLocation = openFileDialogAracDuzenle.FileName;
                if (File.Exists(pictureBoxDuzenleAracResmi.ImageLocation))
                {
                    string FileName = Path.Combine(resimKaydetPath, textBoxDuzenleAracResim.Text.Trim());
                    if (!File.Exists(FileName))
                    {
                        File.Copy(pictureBoxDuzenleAracResmi.ImageLocation, FileName);

                    }
                }
            }
        }

        private void textBoxDuzenleYıl_KeyPress(object sender, KeyPressEventArgs e)
        {
            fym.SadeceSayi(e);
        }
        private void textBoxDuzenleKisiSayisi_KeyPress(object sender, KeyPressEventArgs e)
        {
            fym.SadeceSayi(e);
        }
        private void textBoxDuzenleKilometre_KeyPress(object sender, KeyPressEventArgs e)
        {
            fym.SadeceSayi(e);
        }
        private void textBoxDuzenleUcret_KeyPress(object sender, KeyPressEventArgs e)
        {
            fym.SadeceSayi(e);
        }
        private void textBoxDuzenleHasar_KeyPress(object sender, KeyPressEventArgs e)
        {
            fym.SadeceSayi(e);
        }
        private void textBoxDuzenleKiralaMusteriId_KeyPress(object sender, KeyPressEventArgs e)
        {
            fym.SadeceSayi(e);
        }
        private void timerHaraket_Tick(object sender, EventArgs e)
        {
            this.Left = MousePosition.X - mouseX;
            this.Top = MousePosition.Y - mouseY;
        }
        private void panelHaraket_MouseUp(object sender, MouseEventArgs e)
        {
            timerHaraket.Enabled = false;
        }

        private void panelHaraket_MouseDown(object sender, MouseEventArgs e)
        {
            mouseX = MousePosition.X - this.Left;
            mouseY = MousePosition.Y - this.Top;

            timerHaraket.Enabled = true;
        }
    }
}
