using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace AracKiralama
{
    public partial class FrmCalisanDuzenle : Form
    {
        FrmAnaEkran frmAnaEkran;
        FrmYardımcıMetotlar fym = new FrmYardımcıMetotlar();
        VeriTabaniİslemleri veriTabaniİslemleri = new VeriTabaniİslemleri();
        string guncelleResmiPath = Application.StartupPath + "\\pngler\\tasarim\\guncelle_2.png";
        string guncelleResmiPath2 = Application.StartupPath + "\\pngler\\tasarim\\guncelle_1.png";
        string silResmiPath = Application.StartupPath + "\\pngler\\tasarim\\sil_2.png";
        string silResmiPath2 = Application.StartupPath + "\\pngler\\tasarim\\sil_1.png";
        string resimKaydetPath = Application.StartupPath + "\\pngler\\calisan";
        EmailAddressAttribute email = new EmailAddressAttribute();
        private TextBox[] calisanTextBox;
        private string tcKontrol;
        private string kAdiKontrol;
        private string telKontrol;
        private string mailKontrol;
        private int mouseX;
        private int mouseY;
        
        //Burada paneldeki bilgileri textboxlara geçirme işlemini yapıyoruz
        public FrmCalisanDuzenle(Calisan calisan, FrmAnaEkran parent)
        {
            InitializeComponent();
            calisanTextBox = new TextBox[]{ textBoxDuzenleCalisanKullaniciAdi, textBoxDuzenleCalisanSifre, textBoxDuzenleCalisanYetki, textBoxDuzenleCalisanTc, textBoxDuzenleCalisanAd, textBoxDuzenleCalisanSoyad, textBoxDuzenleCalisanTelefon, textBoxDuzenleCalisanMail, textBoxDuzenleCalisanAdres, textBoxDuzenleCalisanDogumTarihi, textBoxDuzenleCalisanMaas, textBoxDuzenleCalisanResim};

            frmAnaEkran = parent;
            this.labelCalisanId.Text = calisan.id.ToString();
            this.textBoxDuzenleCalisanKullaniciAdi.Text = calisan.kullaniciAdi;
            this.textBoxDuzenleCalisanSifre.Text = calisan.sifre;
            this.textBoxDuzenleCalisanYetki.Text = calisan.yetkiDerecesi.ToString();
            this.textBoxDuzenleCalisanTc.Text = calisan.tc;
            this.textBoxDuzenleCalisanAd.Text = calisan.ad;
            this.textBoxDuzenleCalisanSoyad.Text = calisan.soyad;
            this.textBoxDuzenleCalisanTelefon.Text = calisan.telefonNumarasi;
            this.textBoxDuzenleCalisanMail.Text = calisan.mail;
            this.textBoxDuzenleCalisanAdres.Text = calisan.adres;
            this.textBoxDuzenleCalisanDogumTarihi.Text = calisan.dogumTarihi.ToShortDateString(); 
            this.textBoxDuzenleCalisanMaas.Text = calisan.maas.ToString();
            this.textBoxDuzenleCalisanResim.Text = calisan.calisanResmi;
            this.pictureBoxDuzenleCalisamResim.ImageLocation = Path.Combine(resimKaydetPath, calisan.calisanResmi);
            tcKontrol = textBoxDuzenleCalisanTc.Text;
            kAdiKontrol = textBoxDuzenleCalisanKullaniciAdi.Text;
            telKontrol = textBoxDuzenleCalisanTelefon.Text;
            mailKontrol = textBoxDuzenleCalisanMail.Text;

        }
        //Textboxları ve gerekli koşulları kontrol ediyoruz
        private bool KontroMusteriTextBox()
        {
            Calisan calisanlar = VeriTabaniİslemleri.calisanlar.Find(x => x.tc == textBoxDuzenleCalisanTc.Text.Trim());
            Calisan calisan = VeriTabaniİslemleri.calisanlar.Find(x => x.kullaniciAdi == textBoxDuzenleCalisanKullaniciAdi.Text.Trim());
            Calisan cal = VeriTabaniİslemleri.calisanlar.Find(x => x.telefonNumarasi == textBoxDuzenleCalisanTelefon.Text.Trim());
            Calisan c = VeriTabaniİslemleri.calisanlar.Find(x => x.mail == textBoxDuzenleCalisanMail.Text.Trim());
            if (fym.VeriKontrol(1, calisanTextBox))
            {
                return true;
            }
            else if (textBoxDuzenleCalisanKullaniciAdi.Text.Trim().Length<6)
            {
                MessageBox.Show("[Kullanıcı Adı] 6 haneden küçük olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (textBoxDuzenleCalisanSifre.Text.Trim().Length < 6)
            {
                MessageBox.Show("[Şifre] 6 haneden küçük olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (Convert.ToInt32(textBoxDuzenleCalisanYetki.Text)<0)
            {
                MessageBox.Show("[Yetki Dercesi] 0'dan küçük olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (Convert.ToInt32(textBoxDuzenleCalisanYetki.Text) > 2)
            {
                MessageBox.Show("[Yetki Dercesi] 2'den büyük olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (textBoxDuzenleCalisanTelefon.Text.Trim().Length < 10)
            {
                MessageBox.Show("[Telefon Numarası] 10 haneden küçük olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (email.IsValid(textBoxDuzenleCalisanMail.Text.Trim()) == false)
            {
                MessageBox.Show("Geçerli bir [Mail] adresi giriniz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if(textBoxDuzenleCalisanMaas.Text.Trim().Length>6)
            {
                MessageBox.Show("[Maaş] 6 haneden büyük olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (tcKontrol != textBoxDuzenleCalisanTc.Text.Trim())
            {
                if(calisanlar != null)
                {
                    MessageBox.Show("Girilen [Tc] kayıtlı", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }
            else if (kAdiKontrol != textBoxDuzenleCalisanKullaniciAdi.Text.Trim())
            {
                if(calisan!=null)
                {
                    MessageBox.Show("Girilen [Kullanıcı Adı] kayıtlı", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }
            else if (telKontrol != textBoxDuzenleCalisanTelefon.Text.Trim())
            {
                if (cal != null)
                {
                    MessageBox.Show("Girilen [Telefon Numarası] kayıtlı", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }
            else if (mailKontrol != textBoxDuzenleCalisanMail.Text.Trim())
            {
                if (c != null)
                {
                    MessageBox.Show("Girilen [Mail] kayıtlı", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }
            return false;
        }
        //Calisan bilgilerini alıyoruz ve güncelleme metoduna veriyoruz
        private Calisan GetCalisan()
        {
            Calisan c = VeriTabaniİslemleri.calisanlar.Find(x => x.id == Convert.ToInt32(labelCalisanId.Text.Trim()));
            if(c != null)
            {
                c.kullaniciAdi = textBoxDuzenleCalisanKullaniciAdi.Text.Trim();
                c.sifre = textBoxDuzenleCalisanSifre.Text.Trim();
                c.yetkiDerecesi =Convert.ToInt32(textBoxDuzenleCalisanYetki.Text.Trim());
                c.tc = textBoxDuzenleCalisanTc.Text.Trim();
                c.ad = textBoxDuzenleCalisanAd.Text.Trim();
                c.soyad = textBoxDuzenleCalisanSoyad.Text.Trim();
                c.telefonNumarasi = textBoxDuzenleCalisanTelefon.Text.Trim();
                c.mail = textBoxDuzenleCalisanMail.Text.Trim();
                c.adres = textBoxDuzenleCalisanAdres.Text.Trim();
                c.dogumTarihi = DateTime.Parse(textBoxDuzenleCalisanDogumTarihi.Text.Trim());
                c.maas = Convert.ToInt32(textBoxDuzenleCalisanMaas.Text.Trim());
                c.calisanResmi = textBoxDuzenleCalisanResim.Text.Trim();
            }
            return c;
        }
        //Çalışan güncelleme işlemlerini burada yapıyoruz
        private void pictureBoxDuzenleCalisanGuncelle_Click(object sender, EventArgs e)
        {

            if (KontroMusteriTextBox())
            {
                return;
            }
            var guncelle = MessageBox.Show("Bu çalışanı güncellemek istediğine emin misin?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (guncelle == DialogResult.Yes)
            {
                Calisan guncelleCalisan = GetCalisan();
                if (guncelleCalisan == null)
                {
                    MessageBox.Show("Güncellemek istediğin müşteri bulunamadı!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (veriTabaniİslemleri.CalisanGuncelle(guncelleCalisan))
                    {
                        MessageBox.Show("Çalışan başarıyla Güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        veriTabaniİslemleri.CalisanCek();
                        this.Close();
                        frmAnaEkran.CalisanSayfaYukle();
                    }
                }
            }

        }

        private void dateTimePickerDuzenleCalisanDogum_ValueChanged(object sender, EventArgs e)
        {
            textBoxDuzenleCalisanDogumTarihi.Text = dateTimePickerDuzenleCalisanDogum.Value.ToShortDateString();
        }
        //Çalışan silme işlemini burada yapıyoruz.
        private void pictureBoxDuzenleCalisanSil_Click(object sender, EventArgs e)
        {
            var sil = MessageBox.Show("Bu çalışanı silmek istediğine emin misin?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (sil == DialogResult.Yes)
            {
                if (veriTabaniİslemleri.CalisanSil(Convert.ToInt32(labelCalisanId.Text.Trim())))
                {
                    var kapat = MessageBox.Show("Çalışan başarıyla silindi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (kapat == DialogResult.OK)
                    {
                        veriTabaniİslemleri.CalisanCek();
                        this.Close();
                        frmAnaEkran.CalisanSayfaYukle();
                    }
                }
            }
        }

        private void pictureBoxCalisanDuzenleKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBoxCalisanDuzenleKucult_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBoxDuzenleCalisanGuncelle_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxDuzenleCalisanGuncelle.ImageLocation = guncelleResmiPath;
        }

        private void pictureBoxDuzenleCalisanGuncelle_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxDuzenleCalisanGuncelle.ImageLocation = guncelleResmiPath2;
        }

        private void pictureBoxDuzenleCalisanSil_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxDuzenleCalisanSil.ImageLocation = silResmiPath;
        }

        private void pictureBoxDuzenleCalisanSil_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxDuzenleCalisanSil.ImageLocation = silResmiPath2;
        }
        //Seçtiğimiz resmi dosyaya kaydedip adını textboxa veriyoruz ve dosya adını veritabanında tutuyoruz.
        private void pictureBoxDuzenleCalisanResimSec_Click(object sender, EventArgs e)
        {
            openFileDialogCalisanDuzenle.Title = "Resim Seçiniz";
            openFileDialogCalisanDuzenle.Filter = "Png Dosyaları(*.png)|*.png";
            openFileDialogCalisanDuzenle.FileName = "";
            if (openFileDialogCalisanDuzenle.ShowDialog() == DialogResult.OK)
            {
                textBoxDuzenleCalisanResim.Text = Path.GetFileName(openFileDialogCalisanDuzenle.FileName);
                pictureBoxDuzenleCalisamResim.ImageLocation = openFileDialogCalisanDuzenle.FileName;
                if (File.Exists(pictureBoxDuzenleCalisamResim.ImageLocation))
                {
                    string FileName = Path.Combine(resimKaydetPath, textBoxDuzenleCalisanResim.Text.Trim());
                    if (!File.Exists(FileName))
                    {
                        File.Copy(pictureBoxDuzenleCalisamResim.ImageLocation, FileName);
                    }
                }
            }
        }

        private void textBoxDuzenleCalisanYetki_KeyPress(object sender, KeyPressEventArgs e)
        {
            fym.SadeceSayi(e);
        }

        private void textBoxDuzenleCalisanTc_KeyPress(object sender, KeyPressEventArgs e)
        {
            fym.SadeceSayi(e);
        }

        private void textBoxDuzenleCalisanAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            fym.SadeceHarf(e);
        }

        private void textBoxDuzenleCalisanSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            fym.SadeceHarf(e);
        }

        private void textBoxDuzenleCalisanTelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            fym.SadeceSayi(e);
        }

        private void textBoxDuzenleCalisanMaas_KeyPress(object sender, KeyPressEventArgs e)
        {
            fym.SadeceSayi(e);
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

        private void timerHaraket_Tick(object sender, EventArgs e)
        {
            this.Left = MousePosition.X - mouseX;
            this.Top = MousePosition.Y - mouseY;
        }
    }
}
