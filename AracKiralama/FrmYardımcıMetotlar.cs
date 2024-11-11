using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace AracKiralama
{
    internal class FrmYardımcıMetotlar
    {
        Color yaziRengi = Color.Silver;
        //Buradaki metotta textboxlara yazdığımız bilgi yazılarının "Şifre Giriniz"gibi yazıların yazı yazmadan önce renklerinin silver eğer yazı yazarsak içerisine default renge dönmesini sağlıyoruz.
        public void YazıRengi(string mesaj, TextBox txtBox)
        {
            if (txtBox.Text == mesaj)
            {
                txtBox.ForeColor = yaziRengi;
            }
            else
            {
                txtBox.ForeColor = default;
            }
        }
        string[] calisanDeger = { "Kullanıcı Adı", "Şifre", "Yetki", "Tc", "Ad", "Soyad", "Telefon Numarası", "Mail", "Adres", "Doğum Tarihi", "Maaş", "Çalışan resmi" };
        string[] musteriDeger = { "Tc", "Ad", "Soyad", "Telefon Numarası", "Mail", "Doğum Tarihi", "Adres", "Ehliyet Numarası", "Ehliyet Geçerlilik Süresi", "Kiraladığı araç sayısı", "Müşteri Resmi" };
        string[] musteriEkleDeger = { "Tc", "Ad", "Soyad", "Telefon Numarası", "Mail", "Doğum Tarihi", "Adres", "Ehliyet Numarası", "Ehliyet Geçerlilik Süresi", "Müşteri Resmi" };
        string[] aracDeger = { "Plaka", "Marka", "Model", "Yıl", "Kişi Sayısı", "Kilometre", "Yakit Turu", "Vites Turu", "Günlük Ücret", "Aktiflik Durumu", "Kiralık Durumu", "Hasar Kaydı", "Muayene Tarihi", "Kira Başlangıç Tarihi", "Kira Bitiş Tarihi", "Kiralayan Müşteri Id'si", "Araç Resmi" };
        string[] aracEkleDeger = { "Plaka", "Marka", "Model", "Yıl", "Kişi Sayısı", "Kilometre", "Yakit Turu", "Vites Turu", "Günlük Ücret", "Aktiflik Durumu", "Hasar Kaydı", "Muayene Tarihi", "Araç Resmi" };
        string[] aracKirala = { "Kira Başlangıç", "Kira Bitiş", "Müşteri Tc" };
      
        // Buradaki metotta hata kontrol ederken textboxların içinin boş olup olmadığını kontrol edeceğimiz metot.
        public bool VeriKontrol(int secim, params TextBox[] textbox) 
        {
            bool kontrol = false;
            string result = "";
            if (secim == 1)
            {
                for (int i = 0; i < textbox.Length; i++)
                {
                    if (string.IsNullOrEmpty(textbox[i].Text))
                    {
                        result += "[" + calisanDeger[i] + "] hatalı veya boş bir değer olamaz!\n";
                        kontrol = true;
                    }
                }
            }
            else if (secim == 2)
            {
                for (int i = 0; i < textbox.Length; i++)
                {
                    if (string.IsNullOrEmpty(textbox[i].Text))
                    {
                        result += "[" + musteriDeger[i] + "] hatalı veya boş bir değer olamaz!\n";
                        kontrol = true;
                    }
                }
            }
            else if (secim == 3)
            {
                for (int i = 0; i < textbox.Length; i++)
                {
                    if (string.IsNullOrEmpty(textbox[i].Text))
                    {
                        result += "[" + musteriEkleDeger[i] + "] hatalı veya boş bir değer olamaz!\n";
                        kontrol = true;
                    }
                }
            }
            else if (secim == 4)
            {
                for (int i = 0; i < textbox.Length; i++)
                {
                    if (string.IsNullOrEmpty(textbox[i].Text))
                    {
                        result += "[" + aracDeger[i] + "] hatalı veya boş bir değer olamaz!\n";
                        kontrol = true;
                    }
                }
            }
            else if (secim == 5)
            {
                for (int i = 0; i < textbox.Length; i++)
                {
                    if (string.IsNullOrEmpty(textbox[i].Text))
                    {
                        result += "[" + aracKirala[i] + "] hatalı veya boş bir değer olamaz!\n";
                        kontrol = true;
                    }
                }
            }
            else if (secim == 6)
            {
                for (int i = 0; i < textbox.Length; i++)
                {
                    if (string.IsNullOrEmpty(textbox[i].Text))
                    {
                        result += "[" + aracEkleDeger[i] + "] hatalı veya boş bir değer olamaz!\n";
                        kontrol = true;
                    }
                }
            }
            if (result != "")
            {
                result = result.Substring(0, result.Length - 1);
                MessageBox.Show(result, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return kontrol;
        }
        //pdf fontunu ayaralama metodu
        public iTextSharp.text.Font GetArialUtf8Font(int fontSize = 9)
        {
            string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");

            BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            return new iTextSharp.text.Font(bf, fontSize, iTextSharp.text.Font.NORMAL);
        }
        //Bu metotta araç kiralama işlemi yaparken sözleşme pdfi oluşturmasını sağlıyoruz.
        public bool PdfOlustur(string plaka, string marka, string model, DateTime kirabasla, DateTime kirabit, string ad, string soyad, string tc, string telNo, string adres, int ucret, DateTime dogumtarihi)
        {
            bool kontrol = false;
            string title = "ARAÇ KİRALAMA SÖZLEŞMESİ";
            string sozlesmeMetni = @"

Bu sözleşme {0} tarihinde Araç Kiralama Otomoasyonu ile {6} {7} arasında aşağıdaki şartlar üzerine yapılmıştır:

1. KONU
Bu sözleşmenin konusu {1} Plaka {2} Marka {3} Model aracın {4} ile {5} tarihleri arasında Adı Soyadı {6} {7}, Tc kimlik numarası {8}, Doğum Tarihi {12}, Telefon Numarası {9}, ve adresi {10} olan şahsın, {1} plakalı aracı günlük {11} Türk Lirası karşılığında kiralamasıdır.


2. TARAFLAR
Bu sözleşmeyi aşağıdaki taraflar imzalamıştır:
    Kiraya Veren: Araç Kiralama Satış Personeli
    Kiracı: {6} {7}

3. KİRALAMA ŞARTLARI
	Aracı kiralayan kiracı tarihi geçmeden önce aracı Araç Kiralama Satış Personeline teslim etmesi gereklidir.
	Araç kiralandıktan sonra oluşacak hasarlardan kiracı sorumludur.
	Kiracı araç kiralama ücretinin %50'si kadar Türk lirasını kiralamadan önce peşin olarak vermesi geri kalan ücreti teslim ederken vermesi gereklidir.
	

İmza:                                                                       İmza:
Kiraya Veren                                                           Kiracı";

            sozlesmeMetni = string.Format(sozlesmeMetni, DateTime.Now.ToShortDateString(), plaka, marka, model, kirabasla.ToShortDateString(), kirabit.ToShortDateString(), ad, soyad, tc, telNo, adres, ucret, dogumtarihi.ToShortDateString());
            iTextSharp.text.Font normalFont = GetArialUtf8Font(14);
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "PDF DOSYALARI (*.pdf)|(*.pdf";
            file.Title = "Sözleşme";
            if (file.ShowDialog() == DialogResult.OK)
            {
                FileStream dosya = new FileStream(file.FileName, FileMode.Create);
                Document pdf = new Document();
                PdfWriter.GetInstance(pdf, dosya);

                pdf.AddCreator("Araç Kiralama Otomasyonu");
                pdf.AddTitle("Araç Kiralama Sözleşmesi");
                pdf.AddSubject("Araç Kiralama Sözleşmesi Hakkında");
                pdf.AddCreationDate();
                Paragraph pgtitle = new Paragraph(title, normalFont);
                pgtitle.Alignment = Element.ALIGN_CENTER;
                Paragraph pg = new Paragraph(sozlesmeMetni, normalFont);
                pdf.Open();
                pdf.Add(pgtitle);
                pdf.Add(pg);
                pdf.Close();
                kontrol = true;
            }
            return kontrol;
        }
        //Bu metotta textboxlara sadece sayı girilmesi gereken yerler olduğu zaman harf girememesi için metot tanımlıyoruz
        public void SadeceSayi(KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
        }        
        //Bu metotta textboxlara sadece harf girilmesi gereken yerler olduğu zaman sayi girememesi için metot tanımlıyoruz
        public void SadeceHarf(KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);

        }
        //label visible ayarlarını ayarlamak için metot tanımılıyoruz
        public void LabeVisible(params Label[] lbl)
        {
            for (int i = 0; i < lbl.Length; i++)
            {
                lbl[i].Visible = !lbl[i].Visible;
            }
        }
    }
}
