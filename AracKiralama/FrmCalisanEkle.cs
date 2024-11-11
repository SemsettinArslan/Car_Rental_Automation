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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace AracKiralama
{
    public partial class FrmCalisanEkle : Form
    {
        VeriTabaniİslemleri veriTabaniİslemleri = new VeriTabaniİslemleri();
        FrmYardımcıMetotlar fym = new FrmYardımcıMetotlar();
        FrmAnaEkran frmAnaEkran;
        string ekleResmiPath = Application.StartupPath + "\\pngler\\tasarim\\ekle_2.png";
        string ekleResmiPath2 = Application.StartupPath + "\\pngler\\tasarim\\ekle_1.png";
        string resimKaydetPath = Application.StartupPath + "\\pngler\\calisan";
        EmailAddressAttribute email = new EmailAddressAttribute();
        private TextBox[] calisanEkleTextBox;
        private int mouseX;
        private int mouseY;

        public FrmCalisanEkle(Calisan calisan, FrmAnaEkran parent)
        {
            InitializeComponent();
            frmAnaEkran = parent;
            calisanEkleTextBox = new TextBox[] { textBoxEkleCalisanKullaniciAdi, textBoxEkleCalisanSifre, textBoxEkleCalisanYetki, textBoxEkleCalisanTc, textBoxEkleCalisanAd, textBoxEkleCalisanSoyad, textBoxEkleCalisanTelefon, textBoxEkleCalisanMail, textBoxEkleCalisanAdres, textBoxEkleCalisanDogumTarihi, textBoxEkleCalisanMaas, textBoxEkleCalisanResim };

        }

        private void pictureBoxEkleKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dateTimePickerEkleCalisanDogum_ValueChanged(object sender, EventArgs e)
        {
            textBoxEkleCalisanDogumTarihi.Text = dateTimePickerEkleCalisanDogum.Value.ToShortDateString();
        }
        //Textbox ve koşul kontrollerini yapıyoruz
        private bool kontrolEkleCalisanTextBox()
        {
            Calisan calisanlar = VeriTabaniİslemleri.calisanlar.Find(x => x.tc == textBoxEkleCalisanTc.Text.Trim());
            Calisan calisan = VeriTabaniİslemleri.calisanlar.Find(x => x.kullaniciAdi == textBoxEkleCalisanKullaniciAdi.Text.Trim());
            Calisan cal = VeriTabaniİslemleri.calisanlar.Find(x => x.telefonNumarasi == textBoxEkleCalisanTelefon.Text.Trim());
            Calisan c = VeriTabaniİslemleri.calisanlar.Find(x => x.mail == textBoxEkleCalisanMail.Text.Trim());
            if (fym.VeriKontrol(1, calisanEkleTextBox))
            {
                return true;
            }
            else if (textBoxEkleCalisanKullaniciAdi.Text.Trim().Length < 6)
            {
                MessageBox.Show("[Kullanıcı Adı] 6 haneden küçük olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (textBoxEkleCalisanSifre.Text.Trim().Length < 6)
            {
                MessageBox.Show("[Şifre] 6 haneden küçük olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (Convert.ToInt32(textBoxEkleCalisanYetki.Text) < 0)
            {
                MessageBox.Show("[Yetki Dercesi] 0'dan küçük olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (Convert.ToInt32(textBoxEkleCalisanYetki.Text) > 2)
            {
                MessageBox.Show("[Yetki Dercesi] 2'den büyük olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (textBoxEkleCalisanTelefon.Text.Trim().Length < 10)
            {
                MessageBox.Show("[Telefon Numarası] 10 haneden küçük olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (email.IsValid(textBoxEkleCalisanMail.Text.Trim()) == false)
            {
                MessageBox.Show("Geçerli bir [Mail] adresi giriniz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (textBoxEkleCalisanMaas.Text.Trim().Length > 6)
            {
                MessageBox.Show("[Maaş] 6 haneden büyük olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (calisanlar != null)
            {
                MessageBox.Show("Girilen [Tc] kayıtlı", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (calisan != null)
            {
                MessageBox.Show("Girilen [Kullanıcı Adı] kayıtlı", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (cal != null)
            {
                MessageBox.Show("Girilen [Telefon Numarası] kayıtlı", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (c != null)
            {
                MessageBox.Show("Girilen [Mail] kayıtlı", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            return false;
        }
        //Calisan bilgilerini tcnin olup olmadığını kontrol ederek calisan nesnesine ayarlayıp ekleme metoduna veriyoruz
        private Calisan GetEkleCalisan()
        {
            Calisan c = VeriTabaniİslemleri.calisanlar.Find(x => x.tc == textBoxEkleCalisanTc.Text.Trim());
            if (c == null)
            {
                c=new Calisan();
                c.kullaniciAdi = textBoxEkleCalisanKullaniciAdi.Text.Trim();
                c.sifre = textBoxEkleCalisanSifre.Text.Trim();
                c.yetkiDerecesi = Convert.ToInt32(textBoxEkleCalisanYetki.Text.Trim());
                c.tc = textBoxEkleCalisanTc.Text;
                c.ad = textBoxEkleCalisanAd.Text.Trim();
                c.soyad = textBoxEkleCalisanSoyad.Text.Trim();
                c.telefonNumarasi = textBoxEkleCalisanTelefon.Text.Trim();
                c.mail = textBoxEkleCalisanMail.Text.Trim();
                c.adres = textBoxEkleCalisanAdres.Text.Trim();
                c.dogumTarihi = DateTime.Parse(textBoxEkleCalisanDogumTarihi.Text.Trim());
                c.maas = Convert.ToInt32(textBoxEkleCalisanMaas.Text.Trim());
                c.calisanResmi = textBoxEkleCalisanResim.Text.Trim();
            }
            return c;
        }
        //Çalışan ekleme metodunu burdan yapıyoruz.
        private void pictureBoxEkleCalisan_Click(object sender, EventArgs e)
        {
            if (kontrolEkleCalisanTextBox())
            {
                return;
            }
            var ekle = MessageBox.Show("Yeni çalışan eklemek istediğine emin misin?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (ekle == DialogResult.Yes)
            {
                Calisan ekleme = GetEkleCalisan();
                if (ekleme.id > 0)
                {
                    MessageBox.Show("Bu [Tc]zaten kayıtlı durumda!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (veriTabaniİslemleri.CalisanEkle(ekleme))
                    {
                        var kapat = MessageBox.Show("Çalışan başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (kapat == DialogResult.OK)
                        {
                            veriTabaniİslemleri.CalisanCek();
                            this.Close();
                            frmAnaEkran.CalisanSayfaYukle();
                        }
                    }
                }
            }

        }
        //Çalışan resmi seçip dosyaya kaydediyoruz
        private void pictureBoxEkleCalisanResimSec_Click(object sender, EventArgs e)
        {
            openFileDialogEkleCalisan.Title = "Resim Seçiniz";
            openFileDialogEkleCalisan.Filter = "Png Dosyaları(*.png)|*.png";
            openFileDialogEkleCalisan.FileName = "";
            if (openFileDialogEkleCalisan.ShowDialog() == DialogResult.OK)
            {
                textBoxEkleCalisanResim.Text = Path.GetFileName(openFileDialogEkleCalisan.FileName);
                pictureBoxEkleCalisanResim.ImageLocation = openFileDialogEkleCalisan.FileName;
                if (File.Exists(pictureBoxEkleCalisanResim.ImageLocation))
                {
                    string FileName = Path.Combine(resimKaydetPath, textBoxEkleCalisanResim.Text.Trim());
                    if (!File.Exists(FileName))
                    {
                        File.Copy(pictureBoxEkleCalisanResim.ImageLocation, FileName);
                    }
                }
            }
        }

        private void textBoxEkleCalisanYetki_KeyPress(object sender, KeyPressEventArgs e)
        {
            fym.SadeceSayi(e);
        }

        private void textBoxEkleCalisanTc_KeyPress(object sender, KeyPressEventArgs e)
        {
            fym.SadeceSayi(e);
        }

        private void textBoxEkleCalisanAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            fym.SadeceHarf(e);
        }

        private void textBoxEkleCalisanSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            fym.SadeceHarf(e);
        }

        private void textBoxEkleCalisanTelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            fym.SadeceSayi(e);
        }

        private void textBoxEkleCalisanMaas_KeyPress(object sender, KeyPressEventArgs e)
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

        private void pictureBoxEkleCalisan_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxEkleCalisan.ImageLocation = ekleResmiPath;
        }

        private void pictureBoxEkleCalisan_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxEkleCalisan.ImageLocation = ekleResmiPath2;
        }
    }
}
