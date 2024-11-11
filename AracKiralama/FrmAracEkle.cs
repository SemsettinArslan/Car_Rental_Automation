using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AracKiralama
{
    public partial class FrmAracEkle : Form
    {
        VeriTabaniİslemleri veriTabaniİslemleri = new VeriTabaniİslemleri();
        FrmAnaEkran frmAnaEkran;
        FrmYardımcıMetotlar fym = new FrmYardımcıMetotlar();
        string ekleResmiPath = Application.StartupPath + "\\pngler\\tasarim\\ekle_2.png";
        string ekleResmiPath2 = Application.StartupPath + "\\pngler\\tasarim\\ekle_1.png";
        string resimKaydetPath = Application.StartupPath + "\\pngler\\arac";
        private TextBox[] aracEkleTextBox2;
        private TextBox textBoxEkleYakit;
        private TextBox textBoxEkleVites;
        private TextBox textBoxEkleAktif;
        int mouseX;
        int mouseY;
        public FrmAracEkle(Arac araba, FrmAnaEkran parent)
        {
            InitializeComponent();
            frmAnaEkran = parent;
            textBoxEkleAktif = new TextBox();
            textBoxEkleYakit = new TextBox();
            textBoxEkleVites = new TextBox();
            aracEkleTextBox2 = new TextBox[] { textBoxEklePlaka, textBoxEkleMarka, textBoxEkleModel, textBoxEkleYıl, textBoxEkleKisiSayisi, textBoxEkleKilometre, textBoxEkleYakit, textBoxEkleVites, textBoxEkleUcret, textBoxEkleAktif, textBoxEkleHasar, textBoxEkleMuayene, textBoxEkleAracResim };
        }
        //Bu metotta araç eklerken kontrol edilecek şeyleri yapıyoruz
        private bool KontrolAracEkleTextBox()
        {
            textBoxEkleYakit.Text = comboBoxEkleYakit.Text.Trim();
            textBoxEkleVites.Text = comboBoxEkleVites.Text.Trim();
            textBoxEkleAktif.Text = comboBoxEkleAktif.Text.Trim();
            string plaka = textBoxEklePlaka.Text.Trim();
            string plakaDeseni = @"^[1-9]\d{1,2}[A-ZÇĞİÖŞÜ]{1,3}\d{1,4}$";
            if (fym.VeriKontrol(6, aracEkleTextBox2))
            {
                return true;
            }
            else if (!Regex.IsMatch(plaka.ToUpper(), plakaDeseni))
            {
                MessageBox.Show("[Plaka] girişi hatalı!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (textBoxEklePlaka.Text.Trim().Length < 6)
            {
                MessageBox.Show("[Plaka] 6 haneden küçük olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (textBoxEkleYıl.Text.Trim().Length < 4)
            {
                MessageBox.Show("[Yıl] 4 haneden küçük olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (Convert.ToInt32(textBoxEkleYıl.Text.Trim()) > 2024)
            {
                MessageBox.Show("[Yıl] 2024'den büyük olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (Convert.ToInt32(textBoxEkleYıl.Text.Trim()) < 1900)
            {
                MessageBox.Show("[Yıl] 1900'den küçük olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (Convert.ToInt32(textBoxEkleKisiSayisi.Text.Trim()) < 0)
            {
                MessageBox.Show("[Kişi Sayısı] 0'dan küçük olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (Convert.ToInt32(textBoxEkleKilometre.Text.Trim()) < 0)
            {
                MessageBox.Show("[Kilometre] 0'dan küçük olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (Convert.ToInt32(textBoxEkleUcret.Text.Trim()) < 0)
            {
                MessageBox.Show("[Günlük Ücret] 0'dan küçük olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (Convert.ToInt32(textBoxEkleHasar.Text.Trim()) < 0)
            {
                MessageBox.Show("[Hasar Kaydı] 0'dan küçük olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (DateTime.Parse(textBoxEkleMuayene.Text.Trim()) < new DateTime(2023, 12, 31))
            {
                MessageBox.Show("[Muayene Tarihi] geçerli bir tarih giriniz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }
        //Ekleme metodu için eğer mevcut plaka ekli değilse arac nesnesine bilgileri verip ekleme metoduna  veriyoruz.
        private Arac GetEkleArac()
        {
            bool aktif = true;
            if (comboBoxEkleAktif.SelectedIndex == 1)
            {
                aktif = false;
            }
            Arac a = VeriTabaniİslemleri.araclar.Find(x => x.plaka == textBoxEklePlaka.Text.Trim());
            if (a == null)
            {
                a = new Arac();
                a.plaka = textBoxEklePlaka.Text.Trim();
                a.marka = textBoxEkleMarka.Text.Trim();
                a.model = textBoxEkleModel.Text.Trim();
                a.yıl = textBoxEkleYıl.Text.Trim();
                a.kisiSayisi = Convert.ToInt32(textBoxEkleKisiSayisi.Text.Trim());
                a.sonKm = Convert.ToInt32(textBoxEkleKilometre.Text.Trim());
                a.yakitTuru = comboBoxEkleYakit.Text.Trim();
                a.vitesTuru = comboBoxEkleVites.Text.Trim();
                a.gunlukUcret = Convert.ToInt32(textBoxEkleUcret.Text.Trim());
                a.aktifMi = aktif;
                a.hasarKaydi = Convert.ToInt32(textBoxEkleHasar.Text.Trim());
                a.muayeneTarihi = DateTime.Parse(textBoxEkleMuayene.Text.Trim());
                a.aracResmi = textBoxEkleAracResim.Text.Trim();
            }
            return a;
        }
        //Burada araç ekleme işlemlerini yapıyoruz.
        private void pictureBoxEkle_Click(object sender, EventArgs e)
        {
            if (KontrolAracEkleTextBox())
            {
                return;
            }
            var ekle = MessageBox.Show("Yeni araç eklemek istediğine emin misin?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (ekle == DialogResult.Yes)
            {
                Arac aracId = GetEkleArac();
                if (aracId.aracId > 0)
                {
                    MessageBox.Show("Bu [Plaka]zaten kayıtlı durumda!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (veriTabaniİslemleri.AracEkle(aracId))
                    {
                        var kapat = MessageBox.Show("Araç başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (kapat == DialogResult.OK)
                        {
                            veriTabaniİslemleri.AracCek();
                            this.Close();
                            frmAnaEkran.AracSayfaYukle();
                        }
                    }
                }
            }
        }

        private void dateTimePickerEkleMuayene_ValueChanged(object sender, EventArgs e)
        {
            textBoxEkleMuayene.Text = dateTimePickerEkleMuayene.Value.ToShortDateString();
        }

        private void pictureBoxEkle_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxEkle.ImageLocation = ekleResmiPath;
        }

        private void pictureBoxEkle_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxEkle.ImageLocation = ekleResmiPath2;

        }

        private void pictureBoxEkleKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBoxEkleKucult_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //Araç resmi seçip dosyaya kaydetme işlemlerini yapıyoruz.
        private void pictureBoxAracSecResim_Click(object sender, EventArgs e)
        {
            openFileDialogEkleArac.Title = "Resim Seçiniz";
            openFileDialogEkleArac.Filter = "Png Dosyaları(*.png)|*.png";
            openFileDialogEkleArac.FileName = "";
            if (openFileDialogEkleArac.ShowDialog() == DialogResult.OK)
            {
                textBoxEkleAracResim.Text = Path.GetFileName(openFileDialogEkleArac.FileName);
                pictureBoxEkleAracResmi.ImageLocation = openFileDialogEkleArac.FileName;
                if (File.Exists(pictureBoxEkleAracResmi.ImageLocation))
                {
                    string FileName = Path.Combine(resimKaydetPath, textBoxEkleAracResim.Text.Trim());
                    if (!File.Exists(FileName))
                    {
                        File.Copy(pictureBoxEkleAracResmi.ImageLocation, FileName);
                    }
                }
            }
        }

        private void textBoxEkleYıl_KeyPress(object sender, KeyPressEventArgs e)
        {
            fym.SadeceSayi(e);
        }

        private void textBoxEkleKisiSayisi_KeyPress(object sender, KeyPressEventArgs e)
        {
            fym.SadeceSayi(e);
        }

        private void textBoxEkleKilometre_KeyPress(object sender, KeyPressEventArgs e)
        {
            fym.SadeceSayi(e);
        }

        private void textBoxEkleUcret_KeyPress(object sender, KeyPressEventArgs e)
        {
            fym.SadeceSayi(e);
        }

        private void textBoxEkleHasar_KeyPress(object sender, KeyPressEventArgs e)
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
