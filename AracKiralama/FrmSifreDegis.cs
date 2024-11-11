using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AracKiralama
{
    public partial class FrmSifreDegis : Form
    {
        VeriTabaniİslemleri veriTabaniİslemleri = new VeriTabaniİslemleri();
        FrmYardımcıMetotlar fym= new FrmYardımcıMetotlar();
        string sifreDegis = Application.StartupPath + "\\pngler\\tasarim\\sifredegis_2.png";
        string sifreDegis2 = Application.StartupPath + "\\pngler\\tasarim\\sifredegis_1.png";
        private FrmGiris giris;
        int mouseX;
        int mouseY;
        public FrmSifreDegis()
        {
            InitializeComponent();
        }
        private void pictureBoxSifreDegisKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSifreDegis_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.textBoxYeniSifre.Text = "Yeni Şifreyi Giriniz";
            this.textBoxYeniSifreTekrar.Text = "Yeni Şifreyi Giriniz";
            this.Hide();
            giris = new FrmGiris();
            giris.Show();
        }

        private void pictureBoxSifreDegisKucult_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void textBoxYeniSifre_GotFocus(object sender, EventArgs e)
        {
            if (textBoxYeniSifre.Text == "Yeni Şifreyi Giriniz")
            {
                textBoxYeniSifre.Clear();
            }
        }
        private void textBoxYeniSifre_LostFocus(object sender, EventArgs e)
        {
            if (textBoxYeniSifre.Text.Trim() == "")
            {
                textBoxYeniSifre.Text = "Yeni Şifreyi Giriniz";
            }
        }
        private void textBoxYeniSifreTekrar_GotFocus(object sender, EventArgs e)
        {
            if (textBoxYeniSifreTekrar.Text == "Yeni Şifreyi Giriniz")
            {
                textBoxYeniSifreTekrar.Clear();
            }
        }
        private void textBoxYeniSifreTekrar_LostFocus(object sender, EventArgs e)
        {
            if (textBoxYeniSifreTekrar.Text.Trim() == "")
            {
                textBoxYeniSifreTekrar.Text = "Yeni Şifreyi Giriniz";
            }
        }

        private void textBoxYeniSifre_TextChanged(object sender, EventArgs e)
        {
            fym.YazıRengi("Yeni Şifreyi Giriniz", textBoxYeniSifre);
        }

        private void textBoxYeniSifreTekrar_TextChanged(object sender, EventArgs e)
        {
            fym.YazıRengi("Yeni Şifreyi Giriniz", textBoxYeniSifreTekrar);
        }
        //Şifre güncelleme işlemini burada yapıyoruz
        private void pictureBoxSifreDegis_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = FrmSifreUnut.kullaniciAdi.ToString();
            if (textBoxYeniSifre.Text.Trim() == textBoxYeniSifreTekrar.Text.Trim() && textBoxYeniSifre.Text != "Yeni Şifreyi Giriniz" && textBoxYeniSifreTekrar.Text != "Yeni Şifreyi Giriniz" && textBoxYeniSifre.Text.Length > 0 && textBoxYeniSifre.Text.Length == textBoxYeniSifreTekrar.Text.Length)
            {
                veriTabaniİslemleri.SifreDegis(textBoxYeniSifre.Text, kullaniciAdi);
                MessageBox.Show("Şifre Değiştirme Başarılı!", "Şifre Değiştirildi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                giris.Show();
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurun ve şifrelerin aynı olduğuna emin olun!", "Uyarı!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void pictureBoxSifreDegis_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxSifreDegis.ImageLocation = sifreDegis;
        }

        private void pictureBoxSifreDegis_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxSifreDegis.ImageLocation = sifreDegis2;
        }

        private void timerHaraket_Tick(object sender, EventArgs e)
        {
            this.Left = MousePosition.X - mouseX;
            this.Top = MousePosition.Y - mouseY;
        }

        private void panelSifreDegisHaraket_MouseDown(object sender, MouseEventArgs e)
        {
            mouseX = MousePosition.X - this.Left;
            mouseY = MousePosition.Y - this.Top;

            timerHaraket.Enabled = true;
        }

        private void panelSifreDegisHaraket_MouseUp(object sender, MouseEventArgs e)
        {
            timerHaraket.Enabled = false;
        }
    }
}
