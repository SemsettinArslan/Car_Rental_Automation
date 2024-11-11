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
namespace AracKiralama
{
    public partial class FrmMusteriDuzenle : Form
    {
        FrmAnaEkran frmAnaEkran;
        VeriTabaniİslemleri veriTabaniİslemleri = new VeriTabaniİslemleri();
        string guncelleResmiPath = Application.StartupPath + "\\pngler\\tasarim\\guncelle_2.png";
        string guncelleResmiPath2 = Application.StartupPath + "\\pngler\\tasarim\\guncelle_1.png";
        string silResmiPath = Application.StartupPath + "\\pngler\\tasarim\\sil_2.png";
        string silResmiPath2 = Application.StartupPath + "\\pngler\\tasarim\\sil_1.png";
        string resimKaydetPath = Application.StartupPath + "\\pngler\\musteri";
        FrmYardımcıMetotlar fym = new FrmYardımcıMetotlar();
        EmailAddressAttribute email = new EmailAddressAttribute();
        private TextBox[] musteriTextBox;
        private string tcKontrol;
        private string telKontrol;
        private string mailKontrol;
        private string ehliyetNoKontrol;
        private int mouseX;
        private int mouseY;
        //Paneldeki bilgileri textboxlara geçirme işlemini yapıyoruz
        public FrmMusteriDuzenle(Musteri musteri, FrmAnaEkran parent)
        {
            InitializeComponent();
            musteriTextBox = new TextBox[] { textBoxDuzenleMusteriTc, textBoxDuzenleMusteriAd, textBoxDuzenleMusteriSoyad, textBoxDuzenleMusteriTel, textBoxDuzenleMusteriMail, textBoxDuzenleMusteriDogumTarih, textBoxDuzenleMusteriAdres, textBoxDuzenleMusteriEhliyetNum, textBoxDuzenleMusteriEhliyetSure, textBoxDuzenleMusteriKiraSayi, textBoxDuzenleMusteriResmi };
            frmAnaEkran = parent;
            this.labelMusteriId.Text = musteri.musteriId.ToString();
            this.textBoxDuzenleMusteriTc.Text = musteri.tc;
            this.textBoxDuzenleMusteriAd.Text = musteri.ad;
            this.textBoxDuzenleMusteriSoyad.Text = musteri.soyad;
            this.textBoxDuzenleMusteriTel.Text = musteri.telefonNumarasi;
            this.textBoxDuzenleMusteriMail.Text = musteri.mail;
            this.textBoxDuzenleMusteriDogumTarih.Text = musteri.dogumTarihi.ToShortDateString();
            this.textBoxDuzenleMusteriAdres.Text = musteri.adres;
            this.textBoxDuzenleMusteriEhliyetNum.Text = musteri.ehliyetNumarasi;
            this.textBoxDuzenleMusteriEhliyetSure.Text = musteri.ehliyetGecerlilikSuresi.ToShortDateString();
            this.textBoxDuzenleMusteriKiraSayi.Text = musteri.kiraladigiAracSayisi.ToString();
            this.textBoxDuzenleMusteriResmi.Text = musteri.musteriResmi;
            this.pictureBoxDuzenleMusteriRsim.ImageLocation=Path.Combine(resimKaydetPath,musteri.musteriResmi);
            tcKontrol = textBoxDuzenleMusteriTc.Text;
            telKontrol = textBoxDuzenleMusteriTel.Text;
            mailKontrol = textBoxDuzenleMusteriMail.Text;
            ehliyetNoKontrol = textBoxDuzenleMusteriEhliyetNum.Text;

        }

        private void dateTimePickerDuzenleMusteriDogumTarih_ValueChanged(object sender, EventArgs e)
        {
            textBoxDuzenleMusteriDogumTarih.Text = dateTimePickerDuzenleMusteriDogumTarih.Value.ToShortDateString();
        }
        private void dateTimePickerDuzenleMusteriEhliyetSure_ValueChanged(object sender, EventArgs e)
        {
            textBoxDuzenleMusteriEhliyetSure.Text = dateTimePickerDuzenleMusteriEhliyetSure.Value.ToShortDateString();
        }
        //Textbox ve gerekli koşulları kontrol ediyoruz
        private bool KontrolMusteriTextbox()
        {
            Musteri musteriler = VeriTabaniİslemleri.musteriler.Find(x => x.tc == textBoxDuzenleMusteriTc.Text.Trim());
            Musteri musteri = VeriTabaniİslemleri.musteriler.Find(x => x.telefonNumarasi == textBoxDuzenleMusteriTel.Text.Trim());
            Musteri mus = VeriTabaniİslemleri.musteriler.Find(x => x.mail == textBoxDuzenleMusteriMail.Text.Trim());
            Musteri m = VeriTabaniİslemleri.musteriler.Find(x => x.ehliyetNumarasi == textBoxDuzenleMusteriEhliyetNum.Text.Trim());
            if (fym.VeriKontrol(2, musteriTextBox))
            {
                return true;
            }
            else if (textBoxDuzenleMusteriTc.Text.Trim().Length < 11)
            {
                MessageBox.Show("[Tc] 11 haneden küçük olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;

            }
            else if (textBoxDuzenleMusteriTel.Text.Trim().Length < 10)
            {
                MessageBox.Show("[Telefon Numarası] 10 haneden küçük olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;

            }
            else if (email.IsValid(textBoxDuzenleMusteriMail.Text.Trim()) == false)
            {
                MessageBox.Show("Geçerli bir [Mail] adresi giriniz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (textBoxDuzenleMusteriEhliyetNum.Text.Trim().Length < 6)
            {
                MessageBox.Show("[Ehliyet Numarası] 6 haneden küçük olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (tcKontrol != textBoxDuzenleMusteriTc.Text.Trim())
            {
                if (musteriler != null)
                {
                    MessageBox.Show("Girilen [Tc] kayıtlı", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }
            else if (telKontrol != textBoxDuzenleMusteriTel.Text.Trim())
            {
                if (musteri != null)
                {
                    MessageBox.Show("Girilen [Telefon Numarası] kayıtlı!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }

            }
            else if (mailKontrol != textBoxDuzenleMusteriMail.Text.Trim())
            {
                if (mus != null)
                {
                    MessageBox.Show("Girilen [Mail] kayıtlı!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }

            }
            else if (ehliyetNoKontrol != textBoxDuzenleMusteriEhliyetNum.Text.Trim())
            {
                if (m != null)
                {
                    MessageBox.Show("Girilen [Ehliyet Numarası] kayıtlı!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;

                }
            }
            return false;
        }

        //Guncelleme metodu için musteri nesnesine gerekli bilgileri veriyoruz
        private Musteri GetMusteri()
        {
            Musteri m = VeriTabaniİslemleri.musteriler.Find(x => x.musteriId == Convert.ToInt32(labelMusteriId.Text.Trim()));
            if (m != null)
            {
                m.tc = textBoxDuzenleMusteriTc.Text.Trim();
                m.ad = textBoxDuzenleMusteriAd.Text.Trim();
                m.soyad = textBoxDuzenleMusteriSoyad.Text.Trim();
                m.dogumTarihi = DateTime.Parse(textBoxDuzenleMusteriDogumTarih.Text.Trim());
                m.telefonNumarasi = textBoxDuzenleMusteriTel.Text.Trim();
                m.mail = textBoxDuzenleMusteriMail.Text.Trim();
                m.adres = textBoxDuzenleMusteriAdres.Text.Trim();
                m.ehliyetNumarasi = textBoxDuzenleMusteriEhliyetNum.Text.Trim();
                m.ehliyetGecerlilikSuresi = DateTime.Parse(textBoxDuzenleMusteriEhliyetSure.Text.Trim());
                m.kiraladigiAracSayisi = Convert.ToInt32(textBoxDuzenleMusteriKiraSayi.Text.Trim());
                m.musteriResmi = textBoxDuzenleMusteriResmi.Text.Trim();
            }
            return m;

        }
        //Güncelleme işlemini burada yapıyoruz
        private void pictureBoxDuzenleMusteriGuncelle_Click(object sender, EventArgs e)
        {
            if (KontrolMusteriTextbox())
            {
                return;
            }
            var guncelle = MessageBox.Show("Bu müşteriyi güncellemek istediğine emin misin?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (guncelle == DialogResult.Yes)
            {
                Musteri guncelleMusteri = GetMusteri();
                if (guncelleMusteri == null)
                {
                    MessageBox.Show("Güncellemek istediğin müşteri bulunamadı!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (veriTabaniİslemleri.MusteriGuncelle(guncelleMusteri))
                    {
                        MessageBox.Show("Müşteri başarıyla Güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        veriTabaniİslemleri.MusteriCek();
                        this.Close();
                        frmAnaEkran.MusteriSayfaYukle();
                    }
                }
            }
        }

        private void pictureBoxDuzenleMusteriKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBoxDuzenleMusteriKucult_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //Silme işlemini burada yapıyoruz
        private void pictureBoxDuzenleMusteriSil_Click(object sender, EventArgs e)
        {
            var sil = MessageBox.Show("Bu müşteriyi silmek istediğine emin misin?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (sil == DialogResult.Yes)
            {
                if (veriTabaniİslemleri.MusteriSil(Convert.ToInt32(labelMusteriId.Text.Trim())))
                {
                    var kapat = MessageBox.Show("Müşteri başarıyla silindi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (kapat == DialogResult.OK)
                    {
                        veriTabaniİslemleri.MusteriCek();
                        frmAnaEkran.MusteriSayfaYukle();
                        this.Close();
                    }
                }
            }
        }

        private void pictureBoxDuzenleMusteriGuncelle_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxDuzenleMusteriGuncelle.ImageLocation = guncelleResmiPath;
        }

        private void pictureBoxDuzenleMusteriGuncelle_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxDuzenleMusteriGuncelle.ImageLocation = guncelleResmiPath2;

        }

        private void pictureBoxDuzenleMusteriSil_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxDuzenleMusteriSil.ImageLocation = silResmiPath;
        }

        private void pictureBoxDuzenleMusteriSil_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxDuzenleMusteriSil.ImageLocation = silResmiPath2;
        }
        //müşteri resmi seçip dosyaya kaydediyoruz
        private void pictureBoxMusteriResimSec_Click(object sender, EventArgs e)
        {
            openFileDialogMusteriDuzenle.Title = "Resim Seçiniz";
            openFileDialogMusteriDuzenle.Filter = "Png Dosyaları(*.png)|*.png";
            openFileDialogMusteriDuzenle.FileName = "";
            if (openFileDialogMusteriDuzenle.ShowDialog() == DialogResult.OK)
            {
                textBoxDuzenleMusteriResmi.Text = Path.GetFileName(openFileDialogMusteriDuzenle.FileName);
                pictureBoxDuzenleMusteriRsim.ImageLocation = openFileDialogMusteriDuzenle.FileName;
                if (File.Exists(pictureBoxDuzenleMusteriRsim.ImageLocation))
                {
                    string FileName = Path.Combine(resimKaydetPath, textBoxDuzenleMusteriResmi.Text.Trim());
                    if (!File.Exists(FileName))
                    {
                        File.Copy(pictureBoxDuzenleMusteriRsim.ImageLocation, FileName);
                    }
                }
            }
        }

        private void textBoxDuzenleMusteriTc_KeyPress(object sender, KeyPressEventArgs e)
        {
            fym.SadeceSayi(e);
        }

        private void textBoxDuzenleMusteriAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            fym.SadeceHarf(e);
        }

        private void textBoxDuzenleMusteriSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            fym.SadeceHarf(e);
        }

        private void textBoxDuzenleMusteriTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            fym.SadeceSayi(e);
        }

        private void textBoxDuzenleMusteriEhliyetNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            fym.SadeceSayi(e);
        }

        private void textBoxDuzenleMusteriKiraSayi_KeyPress(object sender, KeyPressEventArgs e)
        {
            fym.SadeceSayi(e);
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
        private void timerHaraket_Tick(object sender, EventArgs e)
        {
            this.Left = MousePosition.X - mouseX;
            this.Top = MousePosition.Y - mouseY;
        }
    }
}
