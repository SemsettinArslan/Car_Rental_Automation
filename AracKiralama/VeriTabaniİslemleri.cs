using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Microsoft.Win32;
using System.IO;
using System.Globalization;

namespace AracKiralama
{
    public class VeriTabaniİslemleri
    {
        public static List<Arac> araclar = new List<Arac>();
        public static List<Musteri> musteriler = new List<Musteri>();
        public static List<Calisan> calisanlar = new List<Calisan>();

        private static SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;


        public static void connectionBagla()
        {
            con = new SqlConnection(ConfigurationManager.AppSettings.Get("connstr"));
        }

        //Baglan metodunda eğer veritabanı bağlantımız kapalı ise veritabanı bağlantımızı açıyoruz.
        public void Baglan()
        {
            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
            }
            catch
            {

                var kontrol = MessageBox.Show("Veri Tabanına bağlanılamadı, program kapatılıyor.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (kontrol == DialogResult.OK)
                {
                    Environment.Exit(0);
                }
            }
        }
        //Kapat metodunda eğer veritabanı bağlantımız açık ise veritabanı bağlantımızı kapatıyoruz.
        public void Kapat()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }



        //Giris metodunda kullanıcı adı ve şifre karşılaştırması yaparak kullanıcının ana ekrana giriş yapmasını sağlıyoruz.
        //Yetki parametresini ana ekranda sadece yetki seviyesi yeten kişilerin görebileceği özellikleri göstermek için alıyoruz.
        public bool Giris(string kAd, string sifre, ref int yetki)
        {
            var result = false;
            Baglan();
            string sorgu = "Select * From Giris Where KullaniciAdi=@kAd AND Sifre=@Sifre";
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@kAd", kAd);
            cmd.Parameters.AddWithValue("Sifre", sifre);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                yetki = (int)dr["YetkiDerecesi"];
                result = true;
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre girdiniz!", "Uyarı!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            Kapat();
            return result;
        }
        //Şifremi unuttum için MailYolla metodunu yapıyoruz burada kullanıcı adına göre mail adresini çekerek o mail adresine doğrulama kodunu yolluyoruz.
        public void MailYolla(string kAdi)
        {
            string kod = DogrulamaKod();

            Baglan();
            string sorgu2 = "Select Mail From Giris Where KullaniciAdi=@kAd";
            cmd = new SqlCommand(sorgu2, con);
            cmd.Parameters.AddWithValue("@kAd", kAdi);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                //Mail yollama işlemlerini burada yapıyoruz ve mail adresine doğrulama kodunu yolluyoruz.credentials ve from kısımlarına kendi mail adres bilgilerinizi giriniz.
                string mailadres = dr["Mail"].ToString();
                SmtpClient smtp = new SmtpClient();
                smtp.Credentials = new System.Net.NetworkCredential("", "");
                smtp.Port = 587;
                smtp.Host = "smtp-mail.outlook.com";
                smtp.EnableSsl = true;
                MailMessage mail = new MailMessage();
                mail.To.Add(mailadres);
                mail.From = new MailAddress("");
                mail.Subject = "Araç kiralama otomasyonu şifre hatırlatma maili";
                mail.Body = "Aşağıdaki doğrulama kodunu girerek şifrenizi sıfırlayabilirsiniz \n" + "Doğrulama Kodu : " + kod;
                smtp.Send(mail);
                MessageBox.Show("Mail adresinize kod gönderildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dr.Close();
                string sorgu4 = "Select * From Dogrulama Where kullaniciAdi=@kAd";
                SqlCommand cmd3;
                SqlDataReader dr3;
                cmd3 = new SqlCommand(sorgu4, con);
                cmd3.Parameters.AddWithValue("@kAd", kAdi);
                dr3 = cmd3.ExecuteReader();
                if (dr3.Read())
                {
                    dr3.Close();
                    string sorgu5 = "Update Dogrulama Set dKod=@dKod Where kullaniciAdi=@kAd";
                    SqlCommand cmd4;
                    SqlDataReader dr4;
                    cmd4 = new SqlCommand(sorgu5, con);
                    cmd4.Parameters.AddWithValue("@dKod", kod);
                    cmd4.Parameters.AddWithValue("@kAd", kAdi);
                    dr4 = cmd4.ExecuteReader();
                    dr4.Close();
                }
                else
                {

                    dr3.Close();
                    string sorgu3 = "Insert Into Dogrulama (kullaniciAdi,dKod) values (@kAd,@dKod)";
                    SqlCommand cmd;
                    SqlDataReader dr;
                    cmd = new SqlCommand(sorgu3, con);
                    cmd.Parameters.AddWithValue("@kAd", kAdi);
                    cmd.Parameters.AddWithValue("@dKod", kod);
                    dr = cmd.ExecuteReader();
                    dr.Close();
                }
            }
            else
            {
                MessageBox.Show("Geçersiz kullanıcı adı girdiniz", "Uyarı!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            Kapat();

        }
        // Bu metotda rastgele bir doğrulama kodu oluşturuyoruz.
        public string DogrulamaKod()
        {
            string kod = "";
            string[] bHarf = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "V", "Y", "Z" };
            string[] kHarf = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "r", "s", "t", "u", "v", "y", "z" };

            Random rastgele = new Random();

            for (int i = 0; i < 12; i++)
            {
                int sayi = rastgele.Next(1, 4);
                if (sayi == 1)
                {
                    int bul = rastgele.Next(0, 23);
                    kod = kod + bHarf[bul];
                }
                else if (sayi == 2)
                {
                    int bul = rastgele.Next(0, 23);
                    kod = kod + kHarf[bul];
                }
                else
                {
                    int bul = rastgele.Next(0, 10);
                    kod = kod + bul;
                }
            }
            return kod;
        }
        //Buradaki Dogrula metodunda maile gelen doğrulama koduna göre şifre değiştirme ekranına yollama işlemlerini yapıyoruz.
        public bool Dogrula(string kAd, string dogrulamaKodu)
        {
            var result = false;
            Baglan();
            string sorgu4 = "Select * From Dogrulama Where kullaniciAdi =@kAd AND dKod=@dKod";
            cmd = new SqlCommand(sorgu4, con);
            cmd.Parameters.AddWithValue("kAd", kAd);
            cmd.Parameters.AddWithValue("@dKod", dogrulamaKodu);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                dr.Close();
                string sorgu6 = "Delete from Dogrulama Where dKod=@dKod";
                SqlCommand cmd;
                cmd = new SqlCommand(sorgu6, con);
                cmd.Parameters.AddWithValue("@dKod", dogrulamaKodu);
                cmd.ExecuteNonQuery();
                result = true;
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya doğrulama kodunda hata var.", "Uyarı!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            Kapat();
            return result;
        }
        //Şifre değiştirme işlemlerinin olduğu metot
        public void SifreDegis(string sifre, string kAd)
        {
            Baglan();
            string sorgu7 = "Update Giris Set Sifre=@sifre Where KullaniciAdi=@kAd ";
            cmd = new SqlCommand(sorgu7, con);
            cmd.Parameters.AddWithValue("@sifre", sifre);
            cmd.Parameters.AddWithValue("@kAd", kAd);
            dr = cmd.ExecuteReader();
            Kapat();
        }


       
        //Bu metotta veritabanındaki araçları çekip listeye ekletiyoruz
        public bool AracCek()
        {
            var kontrol = false;
            Baglan();
            string sorgu8 = "Select * From Arac";
            cmd = new SqlCommand(sorgu8, con);
            dr = cmd.ExecuteReader();
            araclar.Clear();
            while (dr.Read())
            {
                Arac arac = new Arac();
                arac.aracId = (int)dr["aracId"];
                arac.plaka = (string)dr["Plaka"];
                arac.marka = (string)dr["Marka"];
                arac.model = (string)dr["Model"];
                arac.yıl = (string)dr["Yıl"];
                arac.kisiSayisi = (int)dr["KisiSayisi"];
                arac.sonKm = (int)dr["SonKM"];
                arac.yakitTuru = (string)dr["YakitTuru"];
                arac.vitesTuru = (string)dr["VitesTuru"];
                arac.gunlukUcret = (int)dr["GunlukUcret"];
                arac.aktifMi = (bool)dr["AktifMi"];
                arac.kiradaMi = (bool)dr["KiradaMi"];
                arac.hasarKaydi = (int)dr["HasarKaydi"];
                arac.muayeneTarihi = (DateTime)dr["MuayeneTarihi"];
                arac.kiraBaslangic = (DateTime)dr["KiraBaslangic"];
                arac.kiraBitis = (DateTime)dr["KiraBitis"];
                arac.kiraMusteriId = (int)dr["KiraMusteriId"];
                arac.aracResmi = (string)dr["AracResmi"];
                araclar.Add(arac);
            }
            Kapat();
            return kontrol;
        }
        //Bu metotta veritabanındaki müşterileri çekip listeye ekletiyoruz

        public bool MusteriCek()
        {
            var kontrol = false;
            Baglan();
            string sorgu9 = "Select * From Musteri";
            cmd = new SqlCommand(sorgu9, con);
            dr = cmd.ExecuteReader();
            musteriler.Clear();
            while (dr.Read())
            {
                Musteri musteri = new Musteri();
                musteri.musteriId = (int)dr["musteriId"];
                musteri.tc = (string)dr["Tc"];
                musteri.ad = (string)dr["Ad"];
                musteri.soyad = (string)dr["Soyad"];
                musteri.telefonNumarasi = (string)dr["TelefonNumarasi"];
                musteri.mail = (string)dr["Mail"];
                musteri.dogumTarihi = (DateTime)dr["DogumTarihi"];
                musteri.adres = (string)dr["Adres"];
                musteri.ehliyetNumarasi = (string)dr["EhliyetNumarasi"];
                musteri.ehliyetGecerlilikSuresi = (DateTime)dr["EhliyetGecerlilikSuresi"];
                musteri.kiraladigiAracSayisi = (int)dr["KiraladigiAracSayisi"];
                musteri.musteriResmi = dr["MusteriResmi"] == DBNull.Value ? "" : (string)dr["MusteriResmi"];
                musteriler.Add(musteri);
            }
            Kapat();
            return kontrol;
        }
        //Bu metotta veritabanındaki çalışanları çekip listeye ekletiyoruz
        public bool CalisanCek()
        {
            var kontrol = false;
            Baglan();
            string sorgu10 = "Select * From Giris";
            cmd = new SqlCommand(sorgu10, con);
            dr = cmd.ExecuteReader();
            calisanlar.Clear();
            while (dr.Read())
            {
                Calisan calisan = new Calisan();
                calisan.id = (int)dr["calisanid"];
                calisan.kullaniciAdi = (string)dr["KullaniciAdi"];
                calisan.sifre = (string)dr["Sifre"];
                calisan.yetkiDerecesi = (int)dr["YetkiDerecesi"];
                calisan.tc = (string)dr["Tc"];
                calisan.ad = (string)dr["Ad"];
                calisan.soyad = (string)dr["Soyad"];
                calisan.telefonNumarasi = (string)dr["TelefonNumarasi"];
                calisan.mail = (string)dr["Mail"];
                calisan.adres = (string)dr["Adres"];
                calisan.maas = (int)dr["Maas"];
                calisan.dogumTarihi = (DateTime)dr["DogumTarihi"];
                calisan.calisanResmi = dr["CalisanResmi"] == DBNull.Value ? "" : (string)dr["CalisanResmi"];
                calisanlar.Add(calisan);
            }
            Kapat();
            return kontrol;
        }
        //Buradaki metotta araçları güncelleme işlemi sorgusunu yapıyoruz
        public bool AracGuncelle(Arac a)
        {
            bool kontrol = false;
            int etkilenenSayisi;
            Baglan();
            string sorgu11 = "UPDATE Arac SET Plaka=@Plaka,Marka=@Marka,Model=@Model,Yıl=@Yıl,KisiSayisi=@KisiSayisi,SonKM=@SonKM,YakitTuru=@YakitTuru,VitesTuru=@VitesTuru,GunlukUcret=@GunlukUcret,AktifMi=@AktifMi,KiradaMi=@KiradaMi,HasarKaydi=@HasarKaydi,MuayeneTarihi=@MuayeneTarihi,KiraBaslangic=@KiraBaslangic,KiraBitis=@KiraBitis,KiraMusteriId=@KiraMusteriId,AracResmi=@AracResmi WHERE aracId=@aracId";
            cmd = new SqlCommand(sorgu11, con);
            cmd.Parameters.AddWithValue("@aracId", a.aracId);
            cmd.Parameters.AddWithValue("@Plaka", a.plaka);
            cmd.Parameters.AddWithValue("@Marka", a.marka);
            cmd.Parameters.AddWithValue("@Model", a.model);
            cmd.Parameters.AddWithValue("@Yıl", a.yıl);
            cmd.Parameters.AddWithValue("@KisiSayisi", a.kisiSayisi);
            cmd.Parameters.AddWithValue("@SonKM", a.sonKm);
            cmd.Parameters.AddWithValue("@YakitTuru", a.yakitTuru);
            cmd.Parameters.AddWithValue("@VitesTuru", a.vitesTuru);
            cmd.Parameters.AddWithValue("@GunlukUcret", a.gunlukUcret);
            cmd.Parameters.AddWithValue("@AktifMi", a.aktifMi);
            cmd.Parameters.AddWithValue("@KiradaMi", a.kiradaMi);
            cmd.Parameters.AddWithValue("@HasarKaydi", a.hasarKaydi);
            cmd.Parameters.AddWithValue("@MuayeneTarihi", a.muayeneTarihi);
            cmd.Parameters.AddWithValue("@KiraBaslangic", a.kiraBaslangic);
            cmd.Parameters.AddWithValue("@KiraBitis", a.kiraBitis);
            cmd.Parameters.AddWithValue("@KiraMusteriId", a.kiraMusteriId);
            cmd.Parameters.AddWithValue("@AracResmi", a.aracResmi);
            etkilenenSayisi = cmd.ExecuteNonQuery();
            if (etkilenenSayisi > 0)
            {
                kontrol = true;
            }
            else
            {
                MessageBox.Show("Araç güncellerken bir sorun oluştu Aracın mevcut olup olmadığını  kontrol ediniz veya yetkili ile iletişime geçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Kapat();
            return kontrol;
        }
        //Buradaki metotta araçları silme işlemi sorgusunu yapıyoruz
        public bool AracSil(int aracId)
        {
            bool kontrol = false;
            int etkilenenSayısı;
            Baglan();
            string sorgu12 = "Delete  From Arac Where aracId=@aracId";
            cmd = new SqlCommand(sorgu12, con);
            cmd.Parameters.AddWithValue("@aracId", aracId);
            etkilenenSayısı = cmd.ExecuteNonQuery();
            if (etkilenenSayısı > 0)
            {
                kontrol = true;
            }
            else
            {
                MessageBox.Show("Araç silerken bir sorun oluştu Aracın mevcut olup olmadığını  kontrol ediniz veya yetkili ile iletişime geçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Kapat();
            return kontrol;
        }
        //Buradaki metotta araçları ekleme işlemi sorgusunu yapıyoruz
        public bool AracEkle(Arac a)
        {
            bool kontrol = false;
            Baglan();
            string sorgu13 = "Insert Into Arac(Plaka,Marka,Model,Yıl,KisiSayisi,SonKM,YakitTuru,VitesTuru,GunlukUcret,AktifMi,MuayeneTarihi,HasarKaydi,AracResmi) Values(@Plaka,@Marka,@Model,@Yıl,@KisiSayisi,@SonKM,@YakitTuru,@VitesTuru,@GunlukUcret,@AktifMi,@MuayeneTarihi,@HasarKaydi,@AracResmi)";
            cmd = new SqlCommand(sorgu13, con);
            cmd.Parameters.AddWithValue("@Plaka", a.plaka);
            cmd.Parameters.AddWithValue("@Marka", a.marka);
            cmd.Parameters.AddWithValue("@Model", a.model);
            cmd.Parameters.AddWithValue("@Yıl", a.yıl);
            cmd.Parameters.AddWithValue("@KisiSayisi", a.kisiSayisi);
            cmd.Parameters.AddWithValue("@SonKM", a.sonKm);
            cmd.Parameters.AddWithValue("@YakitTuru", a.yakitTuru);
            cmd.Parameters.AddWithValue("@VitesTuru", a.vitesTuru);
            cmd.Parameters.AddWithValue("@GunlukUcret", a.gunlukUcret);
            cmd.Parameters.AddWithValue("@AktifMi", a.aktifMi);
            cmd.Parameters.AddWithValue("@MuayeneTarihi", a.muayeneTarihi);
            cmd.Parameters.AddWithValue("@HasarKaydi", a.hasarKaydi);
            cmd.Parameters.AddWithValue("@AracResmi", a.aracResmi);
            if (cmd.ExecuteNonQuery() > 0)
            {
                kontrol = true;
            }
            else
            {
                MessageBox.Show("Araç eklerken bir sorun oluştu  Aracın mevcut olup olmadığını kontrol ediniz veya yetkili ile iletişime geçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Kapat();
            return kontrol;
        }
        //Bu metotta arac kiralama sorgusunu yapıyoruz
        public bool AracKirala(Arac a, int id)
        {
            bool kontrol = false;
            int etkilenenSayisi;
            int etkilenenSayisi2;
            Baglan();
            string sorgu14 = "Update Arac Set KiradaMi=@KiradaMi,KiraMusteriId=@KiraMusteriId,KiraBaslangic=@KiraBasla,KiraBitis=@Kirabitis Where aracId=@aracId";
            cmd = new SqlCommand(sorgu14, con);
            cmd.Parameters.AddWithValue("@KiradaMi", a.kiradaMi);
            cmd.Parameters.AddWithValue("@KiraMusteriId", a.kiraMusteriId);
            cmd.Parameters.AddWithValue("@KiraBasla", a.kiraBaslangic);
            cmd.Parameters.AddWithValue("@Kirabitis", a.kiraBitis);
            cmd.Parameters.AddWithValue("@aracId", a.aracId);
            etkilenenSayisi = cmd.ExecuteNonQuery();
            string sorgu144 = "Update Musteri Set KiraladigiAracSayisi=KiraladigiAracSayisi +" + 1 + " Where musteriId=@musteriId";
            SqlCommand cmd2 = new SqlCommand(sorgu144, con);
            cmd2.Parameters.AddWithValue("@musteriId", id);
            etkilenenSayisi2 = cmd2.ExecuteNonQuery();
            if (etkilenenSayisi > 0 && etkilenenSayisi2 > 0)
            {
                kontrol = true;
            }
            else
            {
                MessageBox.Show("Araç kiralarken bir sorun oluştu Araç Id'nin mevcut olup olmadığını  kontrol ediniz veya yetkili ile iletişime geçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Kapat();
            return kontrol;

        }
        //Bu metotta arac teslim alma sorgusunu yapıyoruz
        public bool AracTeslimAl(int aracId)
        {
            bool kontrol = false;
            int etkilenenSayisi;
            Baglan();
            string sorgu15 = "Update Arac Set KiradaMi=@KiradaMi,KiraMusteriId=@KiraMusteriId Where aracId=@aracId";
            cmd = new SqlCommand(sorgu15, con);
            cmd.Parameters.AddWithValue("@KiradaMi", false);
            cmd.Parameters.AddWithValue("@KiraMusteriId", 0);
            cmd.Parameters.AddWithValue("@aracId", aracId);
            etkilenenSayisi = cmd.ExecuteNonQuery();
            if (etkilenenSayisi > 0)
            {
                kontrol = true;
                MessageBox.Show("Araç başarıyla Teslim Alındı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Araç teslim alırken bir sorun oluştu Araç Id'nin mevcut olup olmadığını  kontrol ediniz veya yetkili ile iletişime geçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Kapat();
            return kontrol;
        }
        //bu metotta müşteri güncelleme sorgusu ayarlıyoruz
        public bool MusteriGuncelle(Musteri m)
        {
            var kontrol = false;
            int etkilenenSayısı;
            Baglan();
            string sorgu16 = "Update Musteri  Set Tc=@Tc,Ad=@Ad,Soyad=@Soyad,DogumTarihi=@DogumTarihi,TelefonNumarasi=@TelefonNumarasi,Mail=@Mail,Adres=@Adres,EhliyetNumarasi=@EhliyetNumarasi,EhliyetGecerlilikSuresi=@EhliyetGecerlilikSuresi,KiraladigiAracSayisi=@KiraladigiAracSayisi,MusteriResmi=@MusteriResmi Where musteriId=@musteriId";
            cmd = new SqlCommand(sorgu16, con);
            cmd.Parameters.AddWithValue("@Tc", m.tc);
            cmd.Parameters.AddWithValue("@Ad", m.ad);
            cmd.Parameters.AddWithValue("@Soyad", m.soyad);
            cmd.Parameters.AddWithValue("@DogumTarihi", m.dogumTarihi);
            cmd.Parameters.AddWithValue("@TelefonNumarasi", m.telefonNumarasi);
            cmd.Parameters.AddWithValue("@Mail", m.mail);
            cmd.Parameters.AddWithValue("@Adres", m.adres);
            cmd.Parameters.AddWithValue("@EhliyetNumarasi", m.ehliyetNumarasi);
            cmd.Parameters.AddWithValue("@EhliyetGecerlilikSuresi", m.ehliyetGecerlilikSuresi);
            cmd.Parameters.AddWithValue("@KiraladigiAracSayisi", m.kiraladigiAracSayisi);
            cmd.Parameters.AddWithValue("@MusteriResmi", m.musteriResmi);
            cmd.Parameters.AddWithValue("@musteriId", m.musteriId);
            etkilenenSayısı = cmd.ExecuteNonQuery();
            if (etkilenenSayısı > 0)
            {
                kontrol = true;
            }
            else
            {
                MessageBox.Show("Müşteri güncellerken bir sorun oluştu müşterinin mevcut olup olmadığını  kontrol ediniz veya yetkili ile iletişime geçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Kapat();
            return kontrol;
        }
        //Bu metotta müşteri silme sorgusunu yapıyoruz
        public bool MusteriSil(int musteriId)
        {
            var kontrol = false;
            int etkilenenSayısı;
            Baglan();
            string sorgu17 = "Delete From Musteri Where musteriId=@musteriId";
            cmd = new SqlCommand(sorgu17, con);
            cmd.Parameters.AddWithValue("@musteriId", musteriId);
            etkilenenSayısı = cmd.ExecuteNonQuery();
            if (etkilenenSayısı > 0)
            {
                kontrol = true;
            }
            else
            {
                MessageBox.Show("Müşteri silerken bir sorun oluştu müşterinin mevcut olup olmadığını  kontrol ediniz veya yetkili ile iletişime geçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Kapat();
            return kontrol;
        }
        //Bu metotta müşteri ekleme sorgusunu yapıyoruz
        public bool MusteriEkle(Musteri m)
        {
            var kontrol = false;
            Baglan();
            string sorgu18 = "Insert Into Musteri(Tc,Ad,Soyad,DogumTarihi,TelefonNumarasi,Mail,Adres,EhliyetNumarasi,EhliyetGecerlilikSuresi,MusteriResmi) Values (@Tc,@Ad,@Soyad,@DogumTarihi,@TelefonNumarasi,@Mail,@Adres,@EhliyetNumarasi,@EhliyetGecerlilikSuresi,@MusteriResmi)";
            cmd = new SqlCommand(sorgu18, con);
            cmd.Parameters.AddWithValue("@Tc", m.tc);
            cmd.Parameters.AddWithValue("@Ad", m.ad);
            cmd.Parameters.AddWithValue("@Soyad", m.soyad);
            cmd.Parameters.AddWithValue("@DogumTarihi", m.dogumTarihi);
            cmd.Parameters.AddWithValue("@TelefonNumarasi", m.telefonNumarasi);
            cmd.Parameters.AddWithValue("@Mail", m.mail);
            cmd.Parameters.AddWithValue("@Adres", m.adres);
            cmd.Parameters.AddWithValue("@EhliyetNumarasi", m.ehliyetNumarasi);
            cmd.Parameters.AddWithValue("@EhliyetGecerlilikSuresi", m.ehliyetGecerlilikSuresi);
            cmd.Parameters.AddWithValue("@MusteriResmi", m.musteriResmi);
            if (cmd.ExecuteNonQuery() > 0)
            {
                kontrol = true;
            }
            else
            {
                MessageBox.Show("Müşteri eklerken bir sorun oluştu müşterinin mevcut olup olmadığını  kontrol ediniz veya yetkili ile iletişime geçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Kapat();
            return kontrol;
        }
        //Bu metotta çalışan güncelleme sorgusunu yapıyoruz
        public bool CalisanGuncelle(Calisan c)
        {
            var kontrol = false;
            int etkilenenSayısı;
            Baglan();
            string sorgu19 = "Update Giris Set KullaniciAdi=@KullaniciAdi,Sifre=@Sifre,YetkiDerecesi=@YetkiDerecesi,Tc=@Tc,Ad=@Ad,Soyad=@Soyad,DogumTarihi=@DogumTarihi,TelefonNumarasi=@TelefonNumarasi,Mail=@Mail,Adres=@Adres,CalisanResmi=@CalisanResmi,Maas=@Maas Where calisanid=@calisanid";
            cmd = new SqlCommand(sorgu19, con);
            cmd.Parameters.AddWithValue("@KullaniciAdi", c.kullaniciAdi);
            cmd.Parameters.AddWithValue("@Sifre", c.sifre);
            cmd.Parameters.AddWithValue("@YetkiDerecesi", c.yetkiDerecesi);
            cmd.Parameters.AddWithValue("@Tc", c.tc);
            cmd.Parameters.AddWithValue("@Ad", c.ad);
            cmd.Parameters.AddWithValue("@Soyad", c.soyad);
            cmd.Parameters.AddWithValue("@DogumTarihi", c.dogumTarihi);
            cmd.Parameters.AddWithValue("@TelefonNumarasi", c.telefonNumarasi);
            cmd.Parameters.AddWithValue("@Mail", c.mail);
            cmd.Parameters.AddWithValue("@Adres", c.adres);
            cmd.Parameters.AddWithValue("@CalisanResmi", c.calisanResmi);
            cmd.Parameters.AddWithValue("@Maas", c.maas);
            cmd.Parameters.AddWithValue("@calisanid", c.id);
            etkilenenSayısı = cmd.ExecuteNonQuery();
            if (etkilenenSayısı > 0)
            {
                kontrol = true;
            }
            else
            {
                MessageBox.Show("Çalışan güncellerken bir sorun oluştu Çalışanın mevcut olup olmadığını  kontrol ediniz veya yetkili ile iletişime geçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Kapat();
            return kontrol;
        }
        //Bu metotta calisan silme sorgusunu yapıyoruz
        public bool CalisanSil(int calisanId)
        {
            var kontrol = false;
            int etkilenenSayısı;
            Baglan();
            string sorgu20 = "Delete From Giris Where calisanid=@calisanid";
            cmd = new SqlCommand(sorgu20, con);
            cmd.Parameters.AddWithValue("@calisanid", calisanId);
            etkilenenSayısı = cmd.ExecuteNonQuery();
            if (etkilenenSayısı > 0)
            {
                kontrol = true;
            }
            else
            {
                MessageBox.Show("Çalışan silerken bir sorun oluştu çalışanın mevcut olup olmadığını  kontrol ediniz veya yetkili ile iletişime geçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Kapat();
            return kontrol;
        }
        //Bu metotta calisan ekleme sorgusunu yapıyoruz
        public bool CalisanEkle(Calisan c)
        {
            var kontrol = false;
            int etkilenenSayısı;
            Baglan();
            string sorgu21 = "Insert Into Giris(KullaniciAdi,Sifre,YetkiDerecesi,Tc,Ad,Soyad,DogumTarihi,TelefonNumarasi,Mail,Adres,CalisanResmi,Maas) Values (@KullaniciAdi,@Sifre,@YetkiDerecesi,@Tc,@Ad,@Soyad,@DogumTarihi,@TelefonNumarasi,@Mail,@Adres,@CalisanResmi,@Maas)";
            cmd = new SqlCommand(sorgu21, con);
            cmd.Parameters.AddWithValue("@KullaniciAdi", c.kullaniciAdi);
            cmd.Parameters.AddWithValue("@Sifre", c.sifre);
            cmd.Parameters.AddWithValue("@YetkiDerecesi", c.yetkiDerecesi);
            cmd.Parameters.AddWithValue("@Tc", c.tc);
            cmd.Parameters.AddWithValue("@Ad", c.ad);
            cmd.Parameters.AddWithValue("@Soyad", c.soyad);
            cmd.Parameters.AddWithValue("@DogumTarihi", c.dogumTarihi);
            cmd.Parameters.AddWithValue("@TelefonNumarasi", c.telefonNumarasi);
            cmd.Parameters.AddWithValue("@Mail", c.mail);
            cmd.Parameters.AddWithValue("@Adres", c.adres);
            cmd.Parameters.AddWithValue("@CalisanResmi", c.calisanResmi);
            cmd.Parameters.AddWithValue("@Maas", c.maas);
            etkilenenSayısı = cmd.ExecuteNonQuery();
            if (etkilenenSayısı > 0)
            {
                kontrol = true;
            }
            else
            {
                MessageBox.Show("Çalışan eklerken bir sorun oluştu Çalışanın mevcut olup olmadığını  kontrol ediniz veya yetkili ile iletişime geçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Kapat();
            return kontrol;
        }
        //Zam yapma sorgusu
        public bool ZamYap(int zam)
        {
            bool kontrol = false;
            Baglan();
            string sorgu22 = "Update Arac Set GunlukUcret=GunlukUcret + GunlukUcret*" + zam + "/100";
            cmd = new SqlCommand(sorgu22, con);
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Tüm araçların fiyatına %" + zam + " zam uygulandı.");
                kontrol = true;
            }
            else
            {
                MessageBox.Show("Araç fiyatlarına zam yapılırken bir sorun oluştu yetkili ile iletişime geçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return kontrol;
        }
        //indirim yapma sorgusu
        public bool IndirimYap(int indirim)
        {
            bool kontrol = false;
            Baglan();
            string sorgu23 = "Update Arac Set GunlukUcret=GunlukUcret - GunlukUcret*" + indirim + "/100";
            cmd = new SqlCommand(sorgu23, con);
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Tüm araçların fiyatına %" + indirim + " indirim uygulandı.");
                kontrol = true;
            }
            else
            {
                MessageBox.Show("Araç fiyatlarına indirim yapılırken bir sorun oluştu yetkili ile iletişime geçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return kontrol;
        }
    }
}
