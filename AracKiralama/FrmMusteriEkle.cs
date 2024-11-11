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
    public partial class FrmMusteriEkle : Form
    {
        VeriTabaniİslemleri veriTabaniİslemleri = new VeriTabaniİslemleri();
        FrmYardımcıMetotlar fym= new FrmYardımcıMetotlar();
        FrmAnaEkran frmAnaEkran;
        string ekleResmiPath = Application.StartupPath + "\\pngler\\tasarim\\ekle_2.png";
        string ekleResmiPath2 = Application.StartupPath + "\\pngler\\tasarim\\ekle_1.png";
        string resimKaydetPath = Application.StartupPath + "\\pngler\\musteri";
        EmailAddressAttribute email = new EmailAddressAttribute();
        private TextBox[] musteriEkleTextBox;
        private int mouseX;
        private int mouseY;

        public FrmMusteriEkle(Musteri musteri, FrmAnaEkran parent)
        {
            InitializeComponent();
            frmAnaEkran = parent;
            musteriEkleTextBox = new TextBox[]{ textBoxMusteriEkleTc ,textBoxMusteriEkleAd,textBoxMusteriEkleSoyad,textBoxMusteriEkleTel,textBoxMusteriEkleDogumTarih,textBoxMusteriEkleMail,textBoxMusteriEkleEhliyetNum,textBoxMusteriEkleEhliyetSure,textBoxMusteriEkleAdres,textBoxMusteriEkleResmi};

        }

        private void pictureBoxMusteriEkleKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBoxMusteriEkleKucult_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dateTimePickerMusteriEkleDogumTarih_ValueChanged(object sender, EventArgs e)
        {
            textBoxMusteriEkleDogumTarih.Text = dateTimePickerMusteriEkleDogumTarih.Value.ToShortDateString();
        }

        private void dateTimePickerMusteriEkleEhliyetSure_ValueChanged(object sender, EventArgs e)
        {
            textBoxMusteriEkleEhliyetSure.Text = dateTimePickerMusteriEkleEhliyetSure.Value.ToShortDateString();
        }
        //Textbox ve gerekli kosulları kontrol ediyoruz
        private bool KontrolMusteriEkleTextbox()
        {
            Musteri musteri = VeriTabaniİslemleri.musteriler.Find(x => x.telefonNumarasi == textBoxMusteriEkleTel.Text.Trim());
            Musteri mus = VeriTabaniİslemleri.musteriler.Find(x => x.mail == textBoxMusteriEkleMail.Text.Trim());
            Musteri m = VeriTabaniİslemleri.musteriler.Find(x => x.ehliyetNumarasi == textBoxMusteriEkleEhliyetNum.Text.Trim());

            if (fym.VeriKontrol(3,musteriEkleTextBox))
            {
                return true;
            }
            else if (textBoxMusteriEkleTc.Text.Trim().Length < 11)
            {
                MessageBox.Show("Tc 11 haneden küçük olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (textBoxMusteriEkleTel.Text.Trim().Length < 10)
            {
                MessageBox.Show("Telefon numarası 10 haneden küçük olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (email.IsValid(textBoxMusteriEkleMail.Text.Trim()) == false)
            {
                MessageBox.Show("Geçerli bir mail adresi giriniz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (textBoxMusteriEkleEhliyetNum.Text.Trim().Length < 6)
            {
                MessageBox.Show("Ehliyet numarası 6 haneden küçük olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (musteri != null)
            {
                MessageBox.Show("Bu telefon numarası mevcut!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if(mus!= null)
            {
                MessageBox.Show("Bu mail adresi mevcut!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (m != null)
            {
                MessageBox.Show("Bu ehliyet numarası mevcut!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;

            }
            return false;
        }

        //Musteri nesnesine gerekli şeyleri veriyoruz
        private Musteri GetEkleMusteri()
        {
            Musteri m = VeriTabaniİslemleri.musteriler.Find(x => x.tc == textBoxMusteriEkleTc.Text.Trim());
            if (m == null)
            {
                m = new Musteri();
                m.tc = textBoxMusteriEkleTc.Text.Trim();
                m.ad = textBoxMusteriEkleAd.Text.Trim();
                m.soyad = textBoxMusteriEkleSoyad.Text.Trim();
                m.dogumTarihi = DateTime.Parse(textBoxMusteriEkleDogumTarih.Text.Trim());
                m.telefonNumarasi = textBoxMusteriEkleTel.Text.Trim();
                m.mail = textBoxMusteriEkleMail.Text.Trim();
                m.adres = textBoxMusteriEkleAdres.Text.Trim();
                m.ehliyetNumarasi = textBoxMusteriEkleEhliyetNum.Text.Trim();
                m.ehliyetGecerlilikSuresi = DateTime.Parse(textBoxMusteriEkleEhliyetSure.Text.Trim());
                m.musteriResmi = textBoxMusteriEkleResmi.Text.Trim();
            }
            return m;
        }
        //Müşteri ekleme işlemini yapıyoruz
        private void pictureBoxMusteriEkle_Click(object sender, EventArgs e)
        {

            if (KontrolMusteriEkleTextbox())
            {
                return;
            }
            var ekle = MessageBox.Show("Yeni müşteri eklemek istediğine emin misin?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (ekle == DialogResult.Yes)
            {
                Musteri updated = GetEkleMusteri();
                if (updated.musteriId > 0)
                {
                    MessageBox.Show("Bu [Tc]zaten kayıtlı durumda!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (veriTabaniİslemleri.MusteriEkle(updated))
                    {
                        var kapat = MessageBox.Show("Müşteri başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (kapat == DialogResult.OK)
                        {
                            veriTabaniİslemleri.MusteriCek();
                            this.Close();
                            frmAnaEkran.MusteriSayfaYukle();
                        }
                    }
                }
            }
        }

        private void pictureBoxMusteriEkle_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxMusteriEkle.ImageLocation = ekleResmiPath;
        }

        private void pictureBoxMusteriEkle_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxMusteriEkle.ImageLocation = ekleResmiPath2;

        }
        //Resim seçip dosyaya kaydediyoruz
        private void pictureBoxEkleMusteriResimSec_Click(object sender, EventArgs e)
        {
            openFileDialogEkleMusteri.Title = "Resim Seçiniz";
            openFileDialogEkleMusteri.Filter = "Png Dosyaları(*.png)|*.png";
            openFileDialogEkleMusteri.FileName = "";
            if (openFileDialogEkleMusteri.ShowDialog() == DialogResult.OK)
            {
                textBoxMusteriEkleResmi.Text = Path.GetFileName(openFileDialogEkleMusteri.FileName);
                pictureBoxMusteriEkleResim.ImageLocation = openFileDialogEkleMusteri.FileName;
                if (File.Exists(pictureBoxMusteriEkleResim.ImageLocation))
                {
                    string FileName = Path.Combine(resimKaydetPath, textBoxMusteriEkleResmi.Text.Trim());
                    if (!File.Exists(FileName))
                    {
                        File.Copy(pictureBoxMusteriEkleResim.ImageLocation, FileName);
                    }
                }
            }
        }

        private void textBoxMusteriEkleTc_KeyPress(object sender, KeyPressEventArgs e)
        {
            fym.SadeceSayi(e);
        }

        private void textBoxMusteriEkleAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            fym.SadeceHarf(e);
        }

        private void textBoxMusteriEkleSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            fym.SadeceHarf(e);
        }

        private void textBoxMusteriEkleTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            fym.SadeceSayi(e);
        }

        private void textBoxMusteriEkleEhliyetNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            fym.SadeceSayi(e);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            timerHaraket.Enabled = false;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
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
