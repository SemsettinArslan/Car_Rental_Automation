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
    public partial class FrmSifreUnut : Form
    {
        FrmYardımcıMetotlar fym = new FrmYardımcıMetotlar();
        VeriTabaniİslemleri veriTabaniİslem = new VeriTabaniİslemleri();
        private FrmSifreDegis sifreDegis;
        string kod = Application.StartupPath + "\\pngler\\tasarim\\kodgonder_2.png";
        string kod2 = Application.StartupPath + "\\pngler\\tasarim\\kodgonder_1.png";
        string dogrula = Application.StartupPath + "\\pngler\\tasarim\\dogrula_2.png";
        string dogrula2 = Application.StartupPath + "\\pngler\\tasarim\\dogrula_1.png";
        public static string kullaniciAdi = "";
        int mouseX;
        int mouseY;
        public FrmSifreUnut()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            fym.YazıRengi("Kullanıcı Adını Giriniz", textBoxSifreUnutKullaniciAdi);
        }

        private void textBoxSifreUnutKod_TextChanged(object sender, EventArgs e)
        {
            fym.YazıRengi("Doğrulama Kodunu Giriniz", textBoxSifreUnutKod);
        }
        private void textBoxSifreUnutKod_GotFocus(object sender, EventArgs e)
        {
            if (textBoxSifreUnutKod.Text == "Doğrulama Kodunu Giriniz")
            {
                textBoxSifreUnutKod.Clear();
            }
        }
        private void textBoxSifreUnutKod_LostFocus(object sender, EventArgs e)
        {
            if (textBoxSifreUnutKod.Text.Trim() == "")
            {
                textBoxSifreUnutKod.Text = "Doğrulama Kodunu Giriniz";
            }
        }
        private void textBoxSifreUnutMail_GotFocus(object sender, EventArgs e)
        {
            if (textBoxSifreUnutKullaniciAdi.Text == "Kullanıcı Adını Giriniz")
            {
                textBoxSifreUnutKullaniciAdi.Clear();
            }
        }
        private void textBoxSifreUnutMail_LostFocus(object sender, EventArgs e)
        {
            if (textBoxSifreUnutKullaniciAdi.Text.Trim() == "")
            {
                textBoxSifreUnutKullaniciAdi.Text = "Kullanıcı Adını Giriniz";
            }
        }

        private void FrmSifreUnut_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.textBoxSifreUnutKullaniciAdi.Text = "Kullanıcı Adını Giriniz";
            this.textBoxSifreUnutKod.Text = "Doğrulama Kodunu Giriniz";
            this.Hide();
        }

        private void pictureBoxSifreUnutKucult_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //Mail yollama metodunu burada çağırıyoruz
        private void pictureBoxKodGonder_Click(object sender, EventArgs e)
        {
            veriTabaniİslem.MailYolla(textBoxSifreUnutKullaniciAdi.Text.Trim());
        }
        //Kod doğrulamasını burada yapıyoruz
        private void pictureBoxDogrula_Click(object sender, EventArgs e)
        {
            if (veriTabaniİslem.Dogrula(textBoxSifreUnutKullaniciAdi.Text.Trim(), textBoxSifreUnutKod.Text.Trim()))
            {
                kullaniciAdi = textBoxSifreUnutKullaniciAdi.Text.Trim();
                this.Hide();
                sifreDegis = new FrmSifreDegis();
                sifreDegis.Show();
                sifreDegis.FormClosing += FrmSifreUnut_FormClosing;
            }
        }

        private void pictureBoxKodGonder_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxKodGonder.ImageLocation = kod;
        }

        private void pictureBoxKodGonder_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxKodGonder.ImageLocation = kod2;

        }

        private void pictureBoxDogrula_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxDogrula.ImageLocation = dogrula;
        }

        private void pictureBoxDogrula_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxDogrula.ImageLocation = dogrula2;
        }

        private void panelHaraket_MouseDown(object sender, MouseEventArgs e)
        {
            mouseX = MousePosition.X - this.Left;
            mouseY = MousePosition.Y - this.Top;

            timerHaraketlen.Enabled = true;
        }

        private void timerHaraketlen_Tick(object sender, EventArgs e)
        {
            this.Left = MousePosition.X - mouseX;
            this.Top = MousePosition.Y - mouseY;
        }

        private void panelHaraket_MouseUp(object sender, MouseEventArgs e)
        {
            timerHaraketlen.Enabled = false;
        }
    }
}
