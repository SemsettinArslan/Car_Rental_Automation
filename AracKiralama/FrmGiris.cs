using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AracKiralama
{
    public partial class FrmGiris : Form
    {
        public static int yetkiSeviyesi = -1;
        private FrmSifreUnut sifreUnut;
        FrmYardımcıMetotlar fym = new FrmYardımcıMetotlar();
        VeriTabaniİslemleri veriTabaniİslem = new VeriTabaniİslemleri();
        private FrmAnaEkran anaEkran;
        string girisResmiPath = Application.StartupPath + "\\pngler\\tasarim\\giris_1.png";
        string girisResmiPath2 = Application.StartupPath + "\\pngler\\tasarim\\giris_2.png";
        int mouseX;
        int mouseY;
        public FrmGiris()
        {
            InitializeComponent();
            sifreGor();
            VeriTabaniİslemleri.connectionBagla();
        }
        //Mouse textboxların üstüne gelince bilgi yazısını silme ve getirme işlemleri
        private void TextBoxSifre_GotFocus(object sender, EventArgs e)
        {
            if (textBoxSifre.Text == "Şifre Giriniz")
            {
                textBoxSifre.Clear();
            }
        }

        private void TextBoxSifre_LostFocus(object sender, EventArgs e)
        {
            if (textBoxSifre.Text.Trim() == "")
            {
                textBoxSifre.Text = "Şifre Giriniz";
            }
        }


        private void textBoxKullaniciAdi_GotFocus(object sender, EventArgs e)
        {
            if (textBoxKullaniciAdi.Text == "Kullanıcı Adı Giriniz")
            {
                textBoxKullaniciAdi.Clear();
            }
        }

        private void textBoxKullaniciAdi_LostFocus(object sender, EventArgs e)
        {
            if (textBoxKullaniciAdi.Text.Trim() == "")
            {
                textBoxKullaniciAdi.Text = "Kullanıcı Adı Giriniz";
            }
        }

        private void linkLabelSifreUnuttum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            sifreUnut = new FrmSifreUnut();
            sifreUnut.Show();
            sifreUnut.FormClosing += FrmGiris_FormClosing;
        }

        private void textBoxKullaniciAdi_TextChanged(object sender, EventArgs e)
        {
            fym.YazıRengi("Kullanıcı Adı Giriniz", textBoxKullaniciAdi);
        }

        private void textBoxSifre_TextChanged(object sender, EventArgs e)
        {
            fym.YazıRengi("Şifre Giriniz", textBoxSifre);
            sifreGor();

        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            sifreGor();
        }
        //Sifre görme ve gizleme işlemini burada yapıyoruz
        private void sifreGor()
        {
            if (textBoxSifre.Text == "Şifre Giriniz")
            {
                this.textBoxSifre.PasswordChar = default(char);
            }
            else
            {
                this.textBoxSifre.PasswordChar = !checkBoxGoster.Checked ? '*' : default(char);
            }

        }

        private void pictureBoxGirisKapat_Click(object sender, EventArgs e)
        {
            var kontrol = MessageBox.Show("Çıkış yapmak istiyor musunuz ?", "Çıkış Yapılıyor...", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (kontrol == DialogResult.OK)
            {
                Application.Exit();
            }
        }
        private void linkLabelSifreUnuttum_MouseEnter(object sender, EventArgs e)
        {
            linkLabelSifreUnuttum.LinkColor = Color.Turquoise;
        }

        private void linkLabelSifreUnuttum_MouseLeave(object sender, EventArgs e)
        {
            linkLabelSifreUnuttum.LinkColor = Color.White;
        }

        private void FrmGiris_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.textBoxKullaniciAdi.Text = "Kullanıcı Adı Giriniz";
            this.textBoxSifre.Text = "Şifre Giriniz";
            this.Show();
        }

        private void pictureBoxGirisKucult_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBoxGiris_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxGiris.ImageLocation = girisResmiPath2;
        }

        private void pictureBoxGiris_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxGiris.ImageLocation = girisResmiPath;

        }
        //Giriş işlemini burada yapıyoruz
        private void pictureBoxGiris_Click(object sender, EventArgs e)
        {
            if (veriTabaniİslem.Giris(textBoxKullaniciAdi.Text, textBoxSifre.Text, ref yetkiSeviyesi))
            {
                this.Hide();
                anaEkran = new FrmAnaEkran();
                anaEkran.Show();
                anaEkran.FormClosing += FrmGiris_FormClosing;
            }
        }

        private void textBoxSifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pictureBoxGiris_Click(null, null);
            }
        }

        private void panelGirisHareket_MouseDown(object sender, MouseEventArgs e)
        {
            mouseX = MousePosition.X - this.Left;
            mouseY = MousePosition.Y - this.Top;
            timerGirisHaraket.Enabled = true;
        }

        private void timerGirisHaraket_Tick(object sender, EventArgs e)
        {
            this.Left = MousePosition.X - mouseX;
            this.Top = MousePosition.Y - mouseY;
        }

        private void panelGirisHareket_MouseUp(object sender, MouseEventArgs e)
        {
            timerGirisHaraket.Enabled = false;
        }
    }
}
