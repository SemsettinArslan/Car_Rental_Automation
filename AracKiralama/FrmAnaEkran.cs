using iTextSharp.text;
using Org.BouncyCastle.Bcpg.OpenPgp;
using Org.BouncyCastle.Crypto.Prng;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace AracKiralama
{
    public partial class FrmAnaEkran : Form
    {
        VeriTabaniİslemleri veriTabaniİslem = new VeriTabaniİslemleri();
        FrmYardımcıMetotlar fym = new FrmYardımcıMetotlar();
        Arac araba = new Arac();
        Musteri musteri = new Musteri();
        Calisan calisan = new Calisan();
        private int seciliSayfa = 1;

        private int m_maxSayfa;
        private int maxSayfa
        {
            get
            {
                return this.m_maxSayfa;
            }
            set
            {
                this.m_maxSayfa = value;
                if (this.m_maxSayfa < 1) { this.m_maxSayfa = 1; }

            }
        }
        private int maxPanel;
        private List<Control> sayfaİtem;
        private int pagestate;
        private Label[] lblArac;
        private Label[] lblMusteri;
        private Label[] lblCalisan;
        private Label[] lblMenu;
        private List<Label[]> all;
        int mouseX;
        int mouseY;
        public FrmAnaEkran()
        {
            InitializeComponent();
            veriTabaniİslem.AracCek();
            veriTabaniİslem.MusteriCek();
            veriTabaniİslem.CalisanCek();
            maxPanel = 6;
            sayfaİtem = new List<Control>();
            PageItemVisible(false);
            lblArac = new Label[] { labelAracEkle, labelAracGuncelle, labelAracKirala, labelAracRapor };
            lblMusteri = new Label[] { labelMusteriEkle, labelMusteriGuncelle };
            lblCalisan = new Label[] { labelCalisanEkle, labelCalisanGuncelle };
            lblMenu = new Label[] { labelFiyatGuncelle, labelCıkıs };
            all = new List<Label[]>();
            all.Add(lblArac);
            all.Add(lblMusteri);
            all.Add(lblCalisan);
            all.Add(lblMenu);

        }
        // Bu metotta ileri geri ve sayfa bilgilerinin visible ayarlarını güncelliyoruz
        private void PageItemVisible(bool state)
        {
            if (this.pictureBoxSayfaSag.Visible) { return; }
            this.pictureBoxSayfaSag.Visible = this.pictureBoxSayfaSol.Visible = this.labelSayfa.Visible = state;
            labelİslemSeciniz.Visible = !state;
        }
        private void FrmAnaEkran_Load(object sender, EventArgs e)
        {
            if (FrmGiris.yetkiSeviyesi > 0)
            {
                labelCalisanİslem.Enabled = true;
                labelCalisanGuncelle.Enabled = true;
                labelCalisanEkle.Enabled = true;
            }
        }
        private void labelAracGuncelle_Click(object sender, EventArgs e)
        {
            labelArama.Text = "Araç Plaka";
            labelArama.Visible = true;
            textBoxArama.Visible = true;
            comboBoxKiraKontrol.Visible = false;
            this.seciliSayfa = 1;
            this.pagestate = 1;
            Guncelle();
        }
        //Bu metotta oluşturduğumuz panellerin visible ayarlarını kontrol ediyoruz
        public void Goster()
        {
            this.labelSonuc.Visible = sayfaİtem.Count == 0 && !string.IsNullOrEmpty(this.textBoxArama.Text);
            foreach (Control item in sayfaİtem)
            {
                item.Visible = true;
            }
        }
        //Bu metotta eklediğimiz panelleri dispose ediyoruz
        public void Temizleİtem()
        {
            foreach (Control con in this.sayfaİtem)
            {
                con.Parent.Controls.Remove(con);
                con.Dispose();
            }
        }
        //Bu metotta racların panellerini 3üst 3 alt şekilde sıralanmasını sağlıyoruz
        public void AracSayfaYukle()
        {
            maxSayfa = (int)Math.Ceiling((double)((double)VeriTabaniİslemleri.araclar.Count / (double)maxPanel));
            pagestate = 1;
            this.labelSayfa.Text = seciliSayfa + "/" + maxSayfa;
            int max = seciliSayfa * maxPanel;
            int min = max - maxPanel;
            int count = 0;
            int county = 0;
            Temizleİtem();
            sayfaİtem.Clear();
            for (int i = min; i < max; i++)
            {
                if (i < VeriTabaniİslemleri.araclar.Count && VeriTabaniİslemleri.araclar[i] != null)
                {
                    FrmTasarimArac frmTasarimArac = new FrmTasarimArac();
                    Panel aracPanel = frmTasarimArac.AracİslemPanel(VeriTabaniİslemleri.araclar[i]);
                    aracPanel.Visible = false;
                    aracPanel.Name = "aracsayfa" + i;
                    sayfaİtem.Add(aracPanel);
                    aracPanel.Location = new Point(135 + (count * 300), county * 190 + 220);
                    this.Controls.Add(aracPanel);
                    count++;
                    if (count == 3)
                    {
                        count = 0;
                        county++;
                    }
                }
            }
            Goster();

        }
        //Burada sayfanın ileri ve geri gitmesini sağlıyoruz
        private void pictureBoxSayfaSol_Click(object sender, EventArgs e)
        {
            this.seciliSayfa--;
            if (this.seciliSayfa < 1)
            {
                this.seciliSayfa = maxSayfa;
            }
            Guncelle();
        }
        private void pictureBoxSayfaSag_Click(object sender, EventArgs e)
        {
            this.seciliSayfa++;
            if (this.seciliSayfa > maxSayfa)
            {
                this.seciliSayfa = 1;
            }
            Guncelle();
        }
        //Bu metotta tıkladığımız label a göre gerekli panelleri güncelletiyoruz
        public void Guncelle()
        {
            PageItemVisible(true);
            if (!string.IsNullOrEmpty(this.textBoxArama.Text))
            {
                Arama();
                return;
            }
            if (pagestate == 1)
            {
                AracSayfaYukle();
            }
            else if (pagestate == 2)
            {
                AracKiraSayfaYukle();
            }
            else if (pagestate == 3)
            {
                MusteriSayfaYukle();
            }
            else if (pagestate == 4)
            {
                CalisanSayfaYukle();
            }
            else if (pagestate == 5)
            {
                AracRaporSayfaYukle();
            }
            else if (pagestate == 6)
            {
                AracRaporGecmisSayfaYukle();
            }
        }
        //Bu metotta kiralanabilecek durumda olan araçların panel olarak ekrana sıralanmasını sağlıyoruz
        public void AracKiraSayfaYukle()
        {
            List<Arac> kiradaOlmayanlar = VeriTabaniİslemleri.araclar.Where(x => x.aktifMi == true && x.kiradaMi == false).ToList();
            pagestate = 2;
            maxSayfa = (int)Math.Ceiling((double)((double)kiradaOlmayanlar.Count / (double)maxPanel));
            this.labelSayfa.Text = seciliSayfa + "/" + maxSayfa;
            int max = seciliSayfa * maxPanel;
            int min = max - maxPanel;
            int count = 0;
            int county = 0;
            Temizleİtem();
            sayfaİtem.Clear();
            for (int i = min; i < max; i++)
            {
                if (i < kiradaOlmayanlar.Count && kiradaOlmayanlar[i] != null)
                {
                    FrmTasarimArac frmTasarimArac = new FrmTasarimArac();
                    Panel aracKiralaPanel = frmTasarimArac.AracKiralaPanel(kiradaOlmayanlar[i]);
                    aracKiralaPanel.Visible = false;
                    aracKiralaPanel.Name = "aracsayfa" + i;
                    sayfaİtem.Add(aracKiralaPanel);

                    aracKiralaPanel.Location = new Point(135 + (count * 300), county * 190 + 220);
                    this.Controls.Add(aracKiralaPanel);
                    count++;
                    if (count == 3)
                    {
                        count = 0;
                        county++;
                    }
                }
            }
            Goster();
        }
        //Bu metotta kirada olan araçların panellerle sıralanmasını sağlıyoruz
        public void AracRaporSayfaYukle()
        {
            List<Arac> kiraTarihi = VeriTabaniİslemleri.araclar.Where(x => x.aktifMi == true && x.kiradaMi == true && x.kiraBitis > DateTime.Today).ToList();
            pagestate = 5;
            maxSayfa = (int)Math.Ceiling((double)((double)kiraTarihi.Count / (double)maxPanel));
            this.labelSayfa.Text = seciliSayfa + "/" + maxSayfa;
            int max = seciliSayfa * maxPanel;
            int min = max - maxPanel;
            int count = 0;
            int county = 0;
            Temizleİtem();
            sayfaİtem.Clear();
            for (int i = min; i < max; i++)
            {
                if (i < kiraTarihi.Count && kiraTarihi[i] != null)
                {
                    FrmTasarimArac frmTasarimArac = new FrmTasarimArac();
                    Panel AracTeslimPanel = frmTasarimArac.AracTeslimPanel(kiraTarihi[i], this);
                    AracTeslimPanel.Visible = false;
                    AracTeslimPanel.Name = "aracsayfa" + i;
                    sayfaİtem.Add(AracTeslimPanel);

                    AracTeslimPanel.Location = new Point(135 + (count * 300), county * 190 + 220);
                    this.Controls.Add(AracTeslimPanel);
                    count++;
                    if (count == 3)
                    {
                        count = 0;
                        county++;
                    }
                }
            }
            Goster();
        }
        //Bu metotta kira süresi geçmiş araçların sıralanmasını sağlıyoruz
        public void AracRaporGecmisSayfaYukle()
        {
            List<Arac> kiraTarihiGecmis = VeriTabaniİslemleri.araclar.Where(x => x.aktifMi == true && x.kiradaMi == true && x.kiraBitis < DateTime.Today).ToList();
            pagestate = 6;
            maxSayfa = (int)Math.Ceiling((double)((double)kiraTarihiGecmis.Count / (double)maxPanel));
            this.labelSayfa.Text = seciliSayfa + "/" + maxSayfa;
            int max = seciliSayfa * maxPanel;
            int min = max - maxPanel;
            int count = 0;
            int county = 0;
            Temizleİtem();
            sayfaİtem.Clear();
            for (int i = min; i < max; i++)
            {
                if (i < kiraTarihiGecmis.Count && kiraTarihiGecmis[i] != null)
                {
                    FrmTasarimArac frmTasarimArac = new FrmTasarimArac();
                    Panel AracTeslimPanel = frmTasarimArac.AracTeslimPanel(kiraTarihiGecmis[i], this);
                    AracTeslimPanel.Visible = false;
                    AracTeslimPanel.Name = "aracsayfa" + i;
                    sayfaİtem.Add(AracTeslimPanel);

                    AracTeslimPanel.Location = new Point(135 + (count * 300), county * 190 + 220);
                    this.Controls.Add(AracTeslimPanel);
                    count++;
                    if (count == 3)
                    {
                        count = 0;
                        county++;
                    }
                }
            }
            Goster();
        }
        private void labelAracEkle_Click(object sender, EventArgs e)
        {
            labelİslemSeciniz.Visible = false;
            comboBoxKiraKontrol.Visible = false;
            FrmAracEkle frmAracEkle = new FrmAracEkle(araba, this);
            frmAracEkle.ShowDialog();
        }

        private void pictureBoxAnaKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void pictureBoxAnaKucult_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void labelAracKirala_Click(object sender, EventArgs e)
        {
            labelArama.Text = "Araç Plaka";
            labelArama.Visible = true;
            textBoxArama.Visible = true;
            comboBoxKiraKontrol.Visible = false;
            this.seciliSayfa = 1;
            this.pagestate = 2;
            this.Guncelle();
        }

        private void labelMusteriGuncelle_Click(object sender, EventArgs e)
        {
            labelArama.Text = "Müşteri TC";
            labelArama.Visible = true;
            textBoxArama.Visible = true;
            comboBoxKiraKontrol.Visible = false;
            this.seciliSayfa = 1;
            this.pagestate = 3;
            this.Guncelle();
        }
        //Bu metotta müşteri panellerinin sıralanmasını yapıyoruz
        public void MusteriSayfaYukle()
        {
            pagestate = 3;
            maxSayfa = (int)Math.Ceiling((double)((double)VeriTabaniİslemleri.musteriler.Count / (double)maxPanel));
            this.labelSayfa.Text = seciliSayfa + "/" + maxSayfa;
            int max = seciliSayfa * maxPanel;
            int min = max - maxPanel;
            int count = 0;
            int county = 0;
            Temizleİtem();
            sayfaİtem.Clear();
            for (int i = min; i < max; i++)
            {
                if (i < VeriTabaniİslemleri.musteriler.Count && VeriTabaniİslemleri.musteriler[i] != null)
                {
                    FrmTasarimMusteri frmTasarimMusteri = new FrmTasarimMusteri();
                    Panel musteriDuzenlePanel = frmTasarimMusteri.MusteriİslemPanel(VeriTabaniİslemleri.musteriler[i]);
                    musteriDuzenlePanel.Visible = false;
                    musteriDuzenlePanel.Name = "musterisayfa" + i;
                    sayfaİtem.Add(musteriDuzenlePanel);

                    musteriDuzenlePanel.Location = new Point(135 + (count * 300), county * 190 + 220);
                    this.Controls.Add(musteriDuzenlePanel);
                    count++;
                    if (count == 3)
                    {
                        count = 0;
                        county++;
                    }
                }
            }
            Goster();
        }
        //Bu metotta çalışan panellerinin sıralanmasını sağlıyoruz.
        public void CalisanSayfaYukle()
        {
            pagestate = 4;
            maxSayfa = (int)Math.Ceiling((double)((double)VeriTabaniİslemleri.calisanlar.Count / (double)maxPanel));
            this.labelSayfa.Text = seciliSayfa + "/" + maxSayfa;
            int max = seciliSayfa * maxPanel;
            int min = max - maxPanel;
            int count = 0;
            int county = 0;
            Temizleİtem();
            sayfaİtem.Clear();
            for (int i = min; i < max; i++)
            {
                if (i < VeriTabaniİslemleri.calisanlar.Count && VeriTabaniİslemleri.calisanlar[i] != null)
                {
                    FrmTasarimCalisan frmTasarimCalisan = new FrmTasarimCalisan();
                    Panel calisanDuzenlePanel = frmTasarimCalisan.CalisanİslemPanel(VeriTabaniİslemleri.calisanlar[i]);
                    calisanDuzenlePanel.Visible = false;
                    calisanDuzenlePanel.Name = "calisansayfa" + i;
                    sayfaİtem.Add(calisanDuzenlePanel);

                    calisanDuzenlePanel.Location = new Point(135 + (count * 300), county * 190 + 220);
                    this.Controls.Add(calisanDuzenlePanel);
                    count++;
                    if (count == 3)
                    {
                        count = 0;
                        county++;
                    }
                }
            }
            Goster();
        }


        //Arama işlemleri için switch case ayarlıyoruz
        public void Arama()
        {
            switch (pagestate)
            {
                case 1:
                case 2:
                case 5:
                case 6:
                    AramaAraba(string.IsNullOrEmpty(this.textBoxArama.Text) ? VeriTabaniİslemleri.araclar : VeriTabaniİslemleri.araclar.Where(x => x.plaka.ToLower().Contains(this.textBoxArama.Text.ToLower().Trim())).ToList());
                    break;
                case 3:
                    AramaMusteri(string.IsNullOrEmpty(this.textBoxArama.Text) ? VeriTabaniİslemleri.musteriler : VeriTabaniİslemleri.musteriler.Where(x => x.tc.ToLower().Contains(this.textBoxArama.Text.ToLower().Trim())).ToList());
                    break;
                case 4:
                    AramaCalisan(string.IsNullOrEmpty(this.textBoxArama.Text) ? VeriTabaniİslemleri.calisanlar : VeriTabaniİslemleri.calisanlar.Where(x => x.tc.ToLower().Contains(this.textBoxArama.Text.ToLower().Trim())).ToList());
                    break;
            }
        }
        //Arama metotları
        private void AramaAraba(List<Arac> list)
        {
            maxSayfa = (int)Math.Ceiling((double)((double)list.Count / (double)maxPanel));
            this.labelSayfa.Text = seciliSayfa + "/" + maxSayfa;
            int max = seciliSayfa * maxPanel;
            int min = max - maxPanel;
            int count = 0;
            int county = 0;
            Temizleİtem();
            sayfaİtem.Clear();
            for (int i = min; i < max; i++)
            {
                if (i < list.Count && list[i] != null)
                {
                    FrmTasarimArac frmTasarimArac = new FrmTasarimArac();
                    Panel aracPanel = null;
                    switch (pagestate)
                    {
                        case 1: 
                            aracPanel = frmTasarimArac.AracİslemPanel(list[i]);
                            break;
                        case 2:
                            aracPanel = frmTasarimArac.AracKiralaPanel(list[i]);
                            break;
                        case 5:
                        case 6:
                            aracPanel = frmTasarimArac.AracTeslimPanel(list[i], this);
                            break;
                    }

                    aracPanel.Visible = false;
                    aracPanel.Name = "aracsayfa" + i;
                    sayfaİtem.Add(aracPanel);
                    aracPanel.Location = new Point(135 + (count * 300), county * 190 + 220);
                    this.Controls.Add(aracPanel);
                    count++;
                    if (count == 3)
                    {
                        count = 0;
                        county++;
                    }
                }
            }
            Goster();
        }
        private void AramaMusteri(List<Musteri> list)
        {
            maxSayfa = (int)Math.Ceiling((double)((double)list.Count / (double)maxPanel));
            this.labelSayfa.Text = seciliSayfa + "/" + maxSayfa;
            int max = seciliSayfa * maxPanel;
            int min = max - maxPanel;
            int count = 0;
            int county = 0;
            Temizleİtem();
            sayfaİtem.Clear();
            for (int i = min; i < max; i++)
            {
                if (i < list.Count && list[i] != null)
                {
                    FrmTasarimMusteri frmTasarimMusteri = new FrmTasarimMusteri();
                    Panel musteriPanel = frmTasarimMusteri.MusteriİslemPanel(list[i]);
                    musteriPanel.Visible = false;
                    musteriPanel.Name = "aracsayfa" + i;
                    sayfaİtem.Add(musteriPanel);
                    musteriPanel.Location = new Point(135 + (count * 300), county * 190 + 220);
                    this.Controls.Add(musteriPanel);
                    count++;
                    if (count == 3)
                    {
                        count = 0;
                        county++;
                    }
                }
            }
            Goster();
        }
        private void AramaCalisan(List<Calisan> list)
        {
            maxSayfa = (int)Math.Ceiling((double)((double)list.Count / (double)maxPanel));
            this.labelSayfa.Text = seciliSayfa + "/" + maxSayfa;
            int max = seciliSayfa * maxPanel;
            int min = max - maxPanel;
            int count = 0;
            int county = 0;
            Temizleİtem();
            sayfaİtem.Clear();
            for (int i = min; i < max; i++)
            {
                if (i < list.Count && list[i] != null)
                {
                    FrmTasarimCalisan frmTasarimCalisan = new FrmTasarimCalisan();
                    Panel calisanPanel = frmTasarimCalisan.CalisanİslemPanel(list[i]);
                    calisanPanel.Visible = false;
                    calisanPanel.Name = "aracsayfa" + i;
                    sayfaİtem.Add(calisanPanel);
                    calisanPanel.Location = new Point(135 + (count * 300), county * 190 + 220);
                    this.Controls.Add(calisanPanel);
                    count++;
                    if (count == 3)
                    {
                        count = 0;
                        county++;
                    }
                }
            }
            Goster();
        }

        private void labelCalisanGuncelle_Click(object sender, EventArgs e)
        {
            labelArama.Text = "Çalışan TC";
            labelArama.Visible = true;
            textBoxArama.Visible = true;
            comboBoxKiraKontrol.Visible = false;
            this.seciliSayfa = 1;
            this.pagestate = 4;
            this.Guncelle();
        }

        private void labelMusteriEkle_Click(object sender, EventArgs e)
        {
            labelİslemSeciniz.Visible = false;
            comboBoxKiraKontrol.Visible = false;
            FrmMusteriEkle frmMusteriEkle = new FrmMusteriEkle(musteri, this);
            frmMusteriEkle.ShowDialog();
        }

        private void labelCalisanEkle_Click(object sender, EventArgs e)
        {
            labelİslemSeciniz.Visible = false;
            comboBoxKiraKontrol.Visible = false;
            FrmCalisanEkle frmCalisanEkle = new FrmCalisanEkle(calisan, this);
            frmCalisanEkle.ShowDialog();
        }

        private void labelCıkıs_Click(object sender, EventArgs e)
        {
            var kontrol = MessageBox.Show("Çıkış yapmak istiyor musunuz ?", "Çıkış Yapılıyor...", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (kontrol == DialogResult.OK)
            {
                this.Close();
                FrmGiris frmGiris = new FrmGiris();
                frmGiris.Show();
            }

        }

        private void labelAracRapor_Click(object sender, EventArgs e)
        {
            labelArama.Text = "Araç Plaka";
            labelArama.Visible = true;
            textBoxArama.Visible = true;
            comboBoxKiraKontrol.Visible = true;
            comboBoxKiraKontrol.SelectedIndex = 0;
            this.seciliSayfa = 1;
            this.pagestate = 5;
            this.Guncelle();
        }

        private void comboBoxKiraKontrol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxKiraKontrol.SelectedIndex == 0)
            {
                this.seciliSayfa = 1;
                this.pagestate = 5;
                this.Guncelle();
            }
            else
            {
                this.seciliSayfa = 1;
                this.pagestate = 6;
                this.Guncelle();
            }
        }

        private void labelFiyatGuncelle_Click(object sender, EventArgs e)
        {
            labelİslemSeciniz.Visible = false;
            comboBoxKiraKontrol.Visible = false;
            FrmFiyatGuncelle frmFiyatGuncelle = new FrmFiyatGuncelle(this);
            frmFiyatGuncelle.ShowDialog();
        }
        private void labelAracİslem_Click(object sender, EventArgs e)
        {
            comboBoxKiraKontrol.Visible = false;
            GuncelleLabel(lblArac);
        }

        private void labelMusteriİslem_Click(object sender, EventArgs e)
        {
            comboBoxKiraKontrol.Visible = false;
            GuncelleLabel(lblMusteri);
        }

        private void labelCalisanİslem_Click(object sender, EventArgs e)
        {
            comboBoxKiraKontrol.Visible = false;
            GuncelleLabel(lblCalisan);
        }

        private void pictureBoxMenu_Click(object sender, EventArgs e)
        {
            comboBoxKiraKontrol.Visible = false;
            GuncelleLabel(lblMenu);
        }
        //Bu metotta labela tıkladığımızda diğer labellerin kapanmasını sağlıyoruz
        private void GuncelleLabel(Label[] l)
        {
            foreach (Label[] labels in all)
            {
                if (labels != l)
                {
                    foreach (Label label in labels)
                    {
                        label.Visible = false;
                    }
                }
                else
                {
                    fym.LabeVisible(l);
                }
            }
        }
        //Form haraket ettirme metotları
        private void timerHaraketAnaEkran_Tick(object sender, EventArgs e)
        {
            this.Left = MousePosition.X - mouseX;
            this.Top = MousePosition.Y - mouseY;
        }

        private void panelHaraketAnaEkran_MouseDown(object sender, MouseEventArgs e)
        {
            mouseX = MousePosition.X - this.Left;
            mouseY = MousePosition.Y - this.Top;
            timerHaraketAnaEkran.Enabled = true;
        }

        private void panelHaraketAnaEkran_MouseUp(object sender, MouseEventArgs e)
        {
            timerHaraketAnaEkran.Enabled = false;
        }


        private void textBoxArama_TextChanged(object sender, EventArgs e)
        {
            this.Arama();
        }
    }
}
