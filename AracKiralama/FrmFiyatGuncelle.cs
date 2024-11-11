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
    public partial class FrmFiyatGuncelle : Form
    {
        VeriTabaniİslemleri veriTabaniİslemleri = new VeriTabaniİslemleri();
        FrmYardımcıMetotlar frmYardımcıMetotlar=new FrmYardımcıMetotlar();
        string indirim = Application.StartupPath + "\\pngler\\tasarim\\indirimyap_2.png";
        string indirim2 = Application.StartupPath + "\\pngler\\tasarim\\indirimyap_1.png";
        string zam = Application.StartupPath + "\\pngler\\tasarim\\zamyap_2.png";
        string zam2 = Application.StartupPath + "\\pngler\\tasarim\\zamyap_1.png";
        private int mouseX;
        private int mouseY;
        FrmAnaEkran frmAnaEkran;

        public FrmFiyatGuncelle(FrmAnaEkran parent)
        {
            InitializeComponent();
            frmAnaEkran = parent;
        }
        //İndirim yapmayı burada yapıyoruz
        private void pictureBoxİndirim_Click(object sender, EventArgs e)
        {
            var indirim = MessageBox.Show("İndirim yapmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (indirim == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(textBoxİndirim.Text.Trim())&& Convert.ToInt32(textBoxİndirim.Text.Trim())<=100)
                {
                    veriTabaniİslemleri.IndirimYap(Convert.ToInt32(textBoxİndirim.Text.Trim()));
                    this.Close();
                    veriTabaniİslemleri.AracCek();
                    frmAnaEkran.AracSayfaYukle();
                }
                else
                {
                    MessageBox.Show("Lütfen geçerli bir indirim yüzdesi giriniz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
               
        }
        //Zam yapma işlemini burada yapıyoruz
        private void pictureBoxZam_Click(object sender, EventArgs e)
        {
            var indirim = MessageBox.Show("Zam yapmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (indirim == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(textBoxZam.Text.Trim()) && Convert.ToInt32(textBoxZam.Text.Trim()) <= 100)
                {
                    veriTabaniİslemleri.ZamYap(Convert.ToInt32(textBoxZam.Text.Trim()));
                    this.Close();
                    veriTabaniİslemleri.AracCek();
                    frmAnaEkran.AracSayfaYukle();
                }
                else
                {
                    MessageBox.Show("Lütfen geçerli bir zam yüzdesi giriniz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
               
        }

        private void textBoxİndirim_KeyPress(object sender, KeyPressEventArgs e)
        {
            frmYardımcıMetotlar.SadeceSayi(e);
        }

        private void textBoxZam_KeyPress(object sender, KeyPressEventArgs e)
        {
            frmYardımcıMetotlar.SadeceSayi(e);
        }

        private void pictureBoxFiyatKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBoxFiyatKucult_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
        }

        private void pictureBoxİndirim_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxİndirim.ImageLocation = indirim;
        }

        private void pictureBoxİndirim_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxİndirim.ImageLocation = indirim2;

        }

        private void pictureBoxZam_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxZam.ImageLocation = zam;
        }

        private void pictureBoxZam_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxZam.ImageLocation = zam2;
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
