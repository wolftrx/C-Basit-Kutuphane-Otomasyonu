using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Kutuphane_Otomasyon
{
    static class DatabaseConnector
    {
        static string BaglantiYolu = "Server=DESKTOP-HTMQRLQ;Database=Kutuphane;Trusted_Connection=True;";
        static SqlConnection baglanti = new SqlConnection(BaglantiYolu);
        static SqlDataReader datareader;
        public static int girisYap(string kullanici,string sifre)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    SqlCommand komut = new SqlCommand("SELECT * FROM YONETICI where Ad=@ad AND Sifre=@sifre");
                    komut.Parameters.AddWithValue("@ad", kullanici);
                    komut.Parameters.AddWithValue("@sifre", sifre);
                    baglanti.Open();
                    komut.Connection = baglanti;
                    datareader = komut.ExecuteReader();
                    if (datareader.Read())
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                    baglanti.Close();
                }
                else
                {
                    baglanti.Close();
                    SqlCommand komut = new SqlCommand("SELECT * FROM YONETICI where Ad=@ad AND Sifre=@sifre");
                    komut.Parameters.AddWithValue("@ad", kullanici);
                    komut.Parameters.AddWithValue("@sifre", sifre);
                    baglanti.Open();
                    komut.Connection = baglanti;
                    datareader = komut.ExecuteReader();
                    if (datareader.Read())
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                    baglanti.Close();
                }


            }
            catch (Exception a)
            {
                MessageBox.Show(Convert.ToString(a));
                return 0;
                
            }

        }
        public static DataTable UyeGoster()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("SELECT * FROM UYELER",baglanti);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    //SqlDataAdapter sınıfı verilerin databaseden aktarılması işlemini gerçekleştirir.
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //Bir DataTable oluşturarak DataAdapter ile getirilen verileri tablo içerisine dolduruyoruz.
                    baglanti.Close();
                    return dt;
                }
                else
                {
                    baglanti.Close();
                    SqlCommand komut = new SqlCommand("SELECT * FROM UYELER", baglanti);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    //SqlDataAdapter sınıfı verilerin databaseden aktarılması işlemini gerçekleştirir.
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //Bir DataTable oluşturarak DataAdapter ile getirilen verileri tablo içerisine dolduruyoruz.
                    baglanti.Close();
                    return dt;
                }


            }
            catch (Exception a)
            {
                MessageBox.Show(Convert.ToString(a));
                DataTable dt=new DataTable();
                return dt;

            }

        }
        public static int SonAdresiGetir()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("SELECT top 1 Id FROM ADRESLER order by Id desc", baglanti);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    //SqlDataAdapter sınıfı verilerin databaseden aktarılması işlemini gerçekleştirir.
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //Bir DataTable oluşturarak DataAdapter ile getirilen verileri tablo içerisine dolduruyoru
                    baglanti.Close();
                    return Convert.ToInt32(dt.Rows[0][0].ToString());

                }
                else
                {
                    baglanti.Close();
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("SELECT top 1 Id FROM ADRESLER order by Id desc", baglanti);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    //SqlDataAdapter sınıfı verilerin databaseden aktarılması işlemini gerçekleştirir.
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //Bir DataTable oluşturarak DataAdapter ile getirilen verileri tablo içerisine dolduruyoruz.
                    
                    baglanti.Close();
                    return Convert.ToInt32(dt.Rows[0][0].ToString());
                }


            }
            catch (Exception a)
            {
                MessageBox.Show(Convert.ToString(a));
                return 0;

            }

        }
        public static string UyeEkle(string ad,string soyad,string cinsiyet,string telefon)
        {
            string cevap = "";
            try
            {
                if(cevap== "")
                {
                    SqlCommand komut = new SqlCommand("INSERT INTO UYELER(Ad,Soyad,Adres_id,Cinsiyet,Tur_id,GSM) VALUES(@ad,@soyad,@adresid,@cinsiyet,@turid,@telefon)", baglanti);
                    komut.Parameters.AddWithValue("@ad", ad);
                    komut.Parameters.AddWithValue("@soyad", soyad);
                    komut.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                    komut.Parameters.AddWithValue("@adresid", SonAdresiGetir());//buraya adresi id gelecek
                    komut.Parameters.AddWithValue("@turid", 2);
                    komut.Parameters.AddWithValue("@telefon", telefon);
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                        komut.ExecuteNonQuery();
                        baglanti.Close();

                    }
                    else
                    {
                        baglanti.Close();
                        baglanti.Open();
                        komut.ExecuteNonQuery();
                        baglanti.Close();
                    }
                    cevap += "Üye bilgileri girildi.";
                }
                else
                {
                    cevap += "Üye bilgileri girilemedi";
                }

            }
            catch (Exception ex)
            {

                cevap+=ex.ToString();
            }
            return cevap;
            
        }
        public static string AdresEkle(int no,string cadde,int postakodu,string il,string mahalle,int daire,int kat,string sokak)
        {
            string cevap = "";
            try
            {
                SqlCommand komut = new SqlCommand("INSERT INTO ADRESLER(No,Cadde,Postakodu,Il,Mahalle,Daire,Kat,Sokak) VALUES(@no,@cadde,@postakodu,@il,@mahalle,@daire,@kat,@sokak)", baglanti);
                komut.Parameters.AddWithValue("@il", il);
                komut.Parameters.AddWithValue("@mahalle", mahalle);
                komut.Parameters.AddWithValue("@cadde", cadde);
                komut.Parameters.AddWithValue("@sokak", sokak);
                komut.Parameters.AddWithValue("@no", Convert.ToInt32(no));
                komut.Parameters.AddWithValue("@kat", Convert.ToInt32(kat));
                komut.Parameters.AddWithValue("@daire", Convert.ToInt32(daire));
                komut.Parameters.AddWithValue("@postakodu", Convert.ToInt32(postakodu));
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();

                }
                else
                {
                    baglanti.Close();
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                }
                cevap += "Adres bilgileri girildi.";

                return cevap;

            }
            catch (Exception ex)
            {
                cevap += "Adres bilgileri girilemedi.";
                return cevap;
            }
        }
        
        public static string UyeSil(int Id,bool adresdesilinsin)
        {
            try
            {
                if (adresdesilinsin == true)
                {
                    SqlCommand komut = new SqlCommand("DELETE FROM UYELER WHERE Id=@Id", baglanti);
                    komut.Parameters.AddWithValue("@Id", Id);
                    SqlCommand komut2 = new SqlCommand("DELETE FROM ADRESLER WHERE Id=@Id",baglanti);
                    komut2.Parameters.AddWithValue("@Id", UyeAdresIdGetir(Id));
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                        komut.ExecuteNonQuery();
                        komut2.ExecuteNonQuery();
                        baglanti.Close();

                    }
                    else
                    {

                        komut.ExecuteNonQuery();
                        komut2.ExecuteNonQuery();
                        baglanti.Close();
                    }
                    return "Üye adres bilgileri ile birlikte silindi.";
                }
                else
                {
                    SqlCommand komut = new SqlCommand("DELETE FROM UYELER WHERE Id=@Id", baglanti);
                    komut.Parameters.AddWithValue("@Id", Id);
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                        komut.ExecuteNonQuery();
                        baglanti.Close();

                    }
                    else
                    {

                        komut.ExecuteNonQuery();
                        baglanti.Close();
                    }
                    return "Üyenin sadece bilgileri silindi.";
                }
            }
            catch (Exception)
            {

                return "Beklenmedik bir hata ile karşılandı.";
            }


        }
        public static int UyeAdresIdGetir(int Id)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("select Adres_id from UYELER where Id=@Id", baglanti);
                    komut.Parameters.AddWithValue("@Id", Id);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    baglanti.Close();
                    return Convert.ToInt32(dt.Rows[0][0].ToString());

                }
                else
                {
                    SqlCommand komut = new SqlCommand("select Adres_id from UYELER where Id=@Id", baglanti);
                    komut.Parameters.AddWithValue("@Id", Id);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    baglanti.Close();
                    return Convert.ToInt32(dt.Rows[0][0].ToString());
                }

                
            }
            catch (Exception)
            {

                throw null;
            }


        }
        //------------------------Yazar---------------------------------------------
        public static DataTable YazarGoster()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("SELECT * FROM YAZARLAR", baglanti);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    //SqlDataAdapter sınıfı verilerin databaseden aktarılması işlemini gerçekleştirir.
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //Bir DataTable oluşturarak DataAdapter ile getirilen verileri tablo içerisine dolduruyoruz.
                    baglanti.Close();
                    return dt;
                }
                else
                {
                    baglanti.Close();
                    SqlCommand komut = new SqlCommand("SELECT * FROM YAZARLAR", baglanti);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    //SqlDataAdapter sınıfı verilerin databaseden aktarılması işlemini gerçekleştirir.
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //Bir DataTable oluşturarak DataAdapter ile getirilen verileri tablo içerisine dolduruyoruz.
                    baglanti.Close();
                    return dt;
                }


            }
            catch (Exception a)
            {
                MessageBox.Show(Convert.ToString(a));
                DataTable dt = new DataTable();
                return dt;

            }

        }
        public static string YazarEkle(string ad, string soyad, int kitapid)
        {
            string cevap = "";
            try
            {
                if (cevap == "")
                {
                    SqlCommand komut = new SqlCommand("INSERT INTO YAZARLAR(Ad,Soyad,Kitap_id) VALUES(@ad,@soyad,@Kitapid)", baglanti);
                    komut.Parameters.AddWithValue("@ad", ad);
                    komut.Parameters.AddWithValue("@soyad", soyad);
                    komut.Parameters.AddWithValue("@Kitapid", kitapid);
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                        komut.ExecuteNonQuery();
                        baglanti.Close();

                    }
                    else
                    {
                        baglanti.Close();
                        baglanti.Open();
                        komut.ExecuteNonQuery();
                        baglanti.Close();
                    }
                    cevap += "Yazar bilgileri girildi.";
                }
                else
                {
                    cevap += "Yazar bilgileri girilemedi";
                }

            }
            catch (Exception ex)
            {

                cevap += ex.ToString();
            }
            return cevap;

        }
        public static string YazarGuncelle(string ad,string soyad,int kitapid,int id)
        {
            string cevap = "";
            if (baglanti.State == ConnectionState.Closed)
            {
                try
                {
                    SqlCommand komut = new SqlCommand("UPDATE YAZARLAR SET Ad=@ad,Soyad=@soyad,Kitap_id=@Kitapid  WHERE Id=@id", baglanti);
                    komut.Parameters.AddWithValue("@ad", ad);
                    komut.Parameters.AddWithValue("@soyad", soyad);
                    komut.Parameters.AddWithValue("@Kitapid", kitapid);
                    komut.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    cevap += "Yazar Güncellendi.";

                }
                catch (Exception ex)
                {

                    cevap += ex.ToString();
                }
            }
            else
            {
                try
                {
                    SqlCommand komut = new SqlCommand("UPDATE YAZARLAR SET Ad=@ad,Soyad=@soyad,Kitap_id=@Kitapid  WHERE Id=@id", baglanti);
                    komut.Parameters.AddWithValue("@ad", ad);
                    komut.Parameters.AddWithValue("@soyad", soyad);
                    komut.Parameters.AddWithValue("@Kitapid", kitapid);
                    komut.Parameters.AddWithValue("@id", id);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    cevap += "Yazar Güncellendi.";

                }
                catch (Exception ex)
                {

                    cevap+=ex.ToString();
                }
            }
            return cevap;
        }
        public static string YazarSil(int id)
        {
            string cevap = "";
            if (baglanti.State == ConnectionState.Closed)
            {
                try
                {
                    SqlCommand komut = new SqlCommand("DELETE FROM YAZARLAR WHERE Id=@id", baglanti);
                    komut.Parameters.AddWithValue("@id", id);
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    cevap += "Yazar Silindi.";

                }
                catch (Exception ex)
                {

                    cevap += ex.ToString();
                }
            }
            else
            {
                try
                {
                    SqlCommand komut = new SqlCommand("DELETE FROM YAZARLAR WHERE Id=@id", baglanti);
                    komut.Parameters.AddWithValue("@id", id);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    cevap += "Yazar Silindi.";

                }
                catch (Exception ex)
                {

                    cevap += ex.ToString();
                }
            }
            return cevap;
        }

        //----------------------------------------------------------------------------
        //------------------------Kitap-----------------------------------------------
        public static DataTable KitapGoster()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("SELECT * FROM KITAPLAR", baglanti);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    //SqlDataAdapter sınıfı verilerin databaseden aktarılması işlemini gerçekleştirir.
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //Bir DataTable oluşturarak DataAdapter ile getirilen verileri tablo içerisine dolduruyoruz.
                    baglanti.Close();
                    return dt;
                }
                else
                {
                    baglanti.Close();
                    SqlCommand komut = new SqlCommand("SELECT * FROM YAZARLAR", baglanti);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    //SqlDataAdapter sınıfı verilerin databaseden aktarılması işlemini gerçekleştirir.
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //Bir DataTable oluşturarak DataAdapter ile getirilen verileri tablo içerisine dolduruyoruz.
                    baglanti.Close();
                    return dt;
                }


            }
            catch (Exception a)
            {
                MessageBox.Show(Convert.ToString(a));
                DataTable dt = new DataTable();
                return dt;

            }

        }
        public static DataTable KategoriGetir()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("SELECT * FROM KATEGORILER", baglanti);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    //SqlDataAdapter sınıfı verilerin databaseden aktarılması işlemini gerçekleştirir.
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //Bir DataTable oluşturarak DataAdapter ile getirilen verileri tablo içerisine dolduruyoruz.
                    baglanti.Close();
                    return dt;
                }
                else
                {
                    baglanti.Close();
                    SqlCommand komut = new SqlCommand("SELECT * FROM KATEGORILER", baglanti);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    //SqlDataAdapter sınıfı verilerin databaseden aktarılması işlemini gerçekleştirir.
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //Bir DataTable oluşturarak DataAdapter ile getirilen verileri tablo içerisine dolduruyoruz.
                    baglanti.Close();
                    return dt;
                }


            }
            catch (Exception a)
            {
                MessageBox.Show(Convert.ToString(a));
                DataTable dt = new DataTable();
                return dt;

            }
        }
        public static string KitapEkle(int Kategori_id, int RafNo, string Yayimyili, string Basim, int Stok, int SayfaSayisi, string Tur, string Adi,string ISBN)
        {
            string cevap = "";
            try
            {
                if (cevap == "")
                {
                    SqlCommand komut = new SqlCommand("INSERT INTO KITAPLAR(Kategori_id,RafNo,Yayimyili,Basim,Stok,SayfaSayisi,Tur,Adi,ISBN) VALUES(@Kategori_id,@RafNo,@Yayimyili,@Basim,@Stok,@SayfaSayisi,@Tur,@Adi,@ISBN)", baglanti);
                    komut.Parameters.AddWithValue("@Kategori_id", Kategori_id);
                    komut.Parameters.AddWithValue("@RafNo", RafNo);
                    komut.Parameters.AddWithValue("@Yayimyili", Yayimyili);
                    komut.Parameters.AddWithValue("@Basim", Basim);
                    komut.Parameters.AddWithValue("@Stok", Stok);
                    komut.Parameters.AddWithValue("@SayfaSayisi", SayfaSayisi);
                    komut.Parameters.AddWithValue("@Tur", Tur);
                    komut.Parameters.AddWithValue("@Adi", Adi);
                    komut.Parameters.AddWithValue("@ISBN", ISBN);
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                        komut.ExecuteNonQuery();
                        baglanti.Close();

                    }
                    else
                    {
                        baglanti.Close();
                        baglanti.Open();
                        komut.ExecuteNonQuery();
                        baglanti.Close();
                    }
                    cevap += "Kitap girildi.";
                }
                else
                {
                    cevap += "Kitap girilemedi";
                }

            }
            catch (Exception ex)
            {

                cevap += ex.ToString();
            }
            return cevap;

        }
        public static string KitapSil(int id)
        {
            string cevap = "";
            if (baglanti.State == ConnectionState.Closed)
            {
                try
                {
                    SqlCommand komut = new SqlCommand("DELETE FROM KITAPLAR WHERE Id=@id", baglanti);
                    komut.Parameters.AddWithValue("@id", id);
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    cevap += "Kitap Silindi.";

                }
                catch (Exception ex)
                {

                    cevap += ex.ToString();
                }
            }
            else
            {
                try
                {
                    SqlCommand komut = new SqlCommand("DELETE FROM KITAPLAR WHERE Id=@id", baglanti);
                    komut.Parameters.AddWithValue("@id", id);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    cevap += "Kitap Silindi.";

                }
                catch (Exception ex)
                {

                    cevap += ex.ToString();
                }
            }
            return cevap;
        }
        //------------------------------------------------------------------------------
        //------------------------Çevirmen---------------------------------------------
        public static DataTable CevirmenGoster()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("SELECT * FROM CEVIRMENLER", baglanti);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    //SqlDataAdapter sınıfı verilerin databaseden aktarılması işlemini gerçekleştirir.
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //Bir DataTable oluşturarak DataAdapter ile getirilen verileri tablo içerisine dolduruyoruz.
                    baglanti.Close();
                    return dt;
                }
                else
                {
                    baglanti.Close();
                    SqlCommand komut = new SqlCommand("SELECT * FROM CEVIRMENLER", baglanti);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    //SqlDataAdapter sınıfı verilerin databaseden aktarılması işlemini gerçekleştirir.
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //Bir DataTable oluşturarak DataAdapter ile getirilen verileri tablo içerisine dolduruyoruz.
                    baglanti.Close();
                    return dt;
                }


            }
            catch (Exception a)
            {
                MessageBox.Show(Convert.ToString(a));
                DataTable dt = new DataTable();
                return dt;

            }

        }
        public static string CevirmenEkle(string ad, string soyad,string cevirdigidil, int kitapid)
        {
            string cevap = "";
            try
            {
                if (cevap == "")
                {
                    SqlCommand komut = new SqlCommand("INSERT INTO CEVIRMENLER(Kitap_id,Cevirdigi_dil,CevirmenSoyad,CevirmenAd) VALUES(@Kitap_id,@Cevirdigi_dil,@CevirmenSoyad,@CevirmenAd)", baglanti);
                    komut.Parameters.AddWithValue("@CevirmenAd", ad);
                    komut.Parameters.AddWithValue("@CevirmenSoyad", soyad);
                    komut.Parameters.AddWithValue("@Cevirdigi_dil", cevirdigidil);
                    komut.Parameters.AddWithValue("@Kitap_id", kitapid);
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                        komut.ExecuteNonQuery();
                        baglanti.Close();

                    }
                    else
                    {
                        baglanti.Close();
                        baglanti.Open();
                        komut.ExecuteNonQuery();
                        baglanti.Close();
                    }
                    cevap += "Çevirmen bilgileri girildi.";
                }
                else
                {
                    cevap += "Çevirmen bilgileri girilemedi";
                }

            }
            catch (Exception ex)
            {

                cevap += ex.ToString();
            }
            return cevap;

        }
        public static string CevirmenSil(int Kitapid)
        {
            string cevap = "";
            if (baglanti.State == ConnectionState.Closed)
            {
                try
                {
                    SqlCommand komut = new SqlCommand("DELETE FROM CEVIRMENLER WHERE Kitap_id=@id", baglanti);
                    komut.Parameters.AddWithValue("@id", Kitapid);
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    cevap += "Çevirmen Silindi.";

                }
                catch (Exception ex)
                {

                    cevap += ex.ToString();
                }
            }
            else
            {
                try
                {
                    SqlCommand komut = new SqlCommand("DELETE FROM CEVIRMENLER WHERE Kitap_id=@id", baglanti);
                    komut.Parameters.AddWithValue("@id", Kitapid);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    cevap += "Çevirmen Silindi.";

                }
                catch (Exception ex)
                {

                    cevap += ex.ToString();
                }
            }
            return cevap;
        }
        //-----------------------Kategoriler---------------------------------------
        public static DataTable KategoriGoster()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("SELECT * FROM KATEGORILER", baglanti);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    //SqlDataAdapter sınıfı verilerin databaseden aktarılması işlemini gerçekleştirir.
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //Bir DataTable oluşturarak DataAdapter ile getirilen verileri tablo içerisine dolduruyoruz.
                    baglanti.Close();
                    return dt;
                }
                else
                {
                    baglanti.Close();
                    SqlCommand komut = new SqlCommand("SELECT * FROM KATEGORILER", baglanti);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    //SqlDataAdapter sınıfı verilerin databaseden aktarılması işlemini gerçekleştirir.
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //Bir DataTable oluşturarak DataAdapter ile getirilen verileri tablo içerisine dolduruyoruz.
                    baglanti.Close();
                    return dt;
                }


            }
            catch (Exception a)
            {
                MessageBox.Show(Convert.ToString(a));
                DataTable dt = new DataTable();
                return dt;

            }

        }
        public static string KategoriEkle(string ad)
        {
            string cevap = "";
            try
            {
                if (cevap == "")
                {
                    SqlCommand komut = new SqlCommand("INSERT INTO KATEGORILER(Adi) VALUES(@Adi)", baglanti);
                    komut.Parameters.AddWithValue("@Adi", ad);
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                        komut.ExecuteNonQuery();
                        baglanti.Close();

                    }
                    else
                    {
                        baglanti.Close();
                        baglanti.Open();
                        komut.ExecuteNonQuery();
                        baglanti.Close();
                    }
                    cevap += "Kategori bilgileri girildi.";
                }
                else
                {
                    cevap += "Kategori bilgileri girilemedi";
                }

            }
            catch (Exception ex)
            {

                cevap += ex.ToString();
            }
            return cevap;

        }
        public static string KategoriSil(int KategoriId)
        {
            string cevap = "";
            if (baglanti.State == ConnectionState.Closed)
            {
                try
                {
                    SqlCommand komut = new SqlCommand("DELETE FROM KATEGORILER WHERE Id=@id", baglanti);
                    komut.Parameters.AddWithValue("@id", KategoriId);
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    cevap += "Kategori Silindi.";

                }
                catch (Exception ex)
                {

                    cevap += ex.ToString();
                }
            }
            else
            {
                try
                {
                    SqlCommand komut = new SqlCommand("DELETE FROM KATEGORILER WHERE Id=@id", baglanti);
                    komut.Parameters.AddWithValue("@id", KategoriId);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    cevap += "Kategori Silindi.";

                }
                catch (Exception ex)
                {

                    cevap += ex.ToString();
                }
            }
            return cevap;
        }
        //--------------------------------------------------------------------------
        //-----------------------Yayımevleri----------------------------------------
        public static DataTable YayimEvleriGoster()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("SELECT * FROM YAYINEVLER", baglanti);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    //SqlDataAdapter sınıfı verilerin databaseden aktarılması işlemini gerçekleştirir.
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //Bir DataTable oluşturarak DataAdapter ile getirilen verileri tablo içerisine dolduruyoruz.
                    baglanti.Close();
                    return dt;
                }
                else
                {
                    baglanti.Close();
                    SqlCommand komut = new SqlCommand("SELECT * FROM YAYINEVLER", baglanti);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    //SqlDataAdapter sınıfı verilerin databaseden aktarılması işlemini gerçekleştirir.
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //Bir DataTable oluşturarak DataAdapter ile getirilen verileri tablo içerisine dolduruyoruz.
                    baglanti.Close();
                    return dt;
                }


            }
            catch (Exception a)
            {
                MessageBox.Show(Convert.ToString(a));
                DataTable dt = new DataTable();
                return dt;

            }

        }
        public static string YayimeviEkle(string ad,string KitapId,string AdresId)
        {
            string cevap = "";
            try
            {
                if (cevap == "")
                {
                    SqlCommand komut = new SqlCommand("INSERT INTO YAYINEVLER(Adi,Adres_id,Kitap_id) VALUES(@Adi,@Adres_id,@Kitap_id)", baglanti);
                    komut.Parameters.AddWithValue("@Adi", ad);
                    komut.Parameters.AddWithValue("@Adres_id", Convert.ToInt32(AdresId));
                    komut.Parameters.AddWithValue("@Kitap_id", Convert.ToInt32(KitapId));
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                        komut.ExecuteNonQuery();
                        baglanti.Close();

                    }
                    else
                    {
                        baglanti.Close();
                        baglanti.Open();
                        komut.ExecuteNonQuery();
                        baglanti.Close();
                    }
                    cevap += "Kategori bilgileri girildi.";
                }
                else
                {
                    cevap += "Kategori bilgileri girilemedi";
                }

            }
            catch (Exception ex)
            {

                cevap += ex.ToString();
            }
            return cevap;

        }
        public static string YayimeviSil(int KategoriId)
        {
            string cevap = "";
            if (baglanti.State == ConnectionState.Closed)
            {
                try
                {
                    SqlCommand komut = new SqlCommand("DELETE FROM KATEGORILER WHERE Id=@id", baglanti);
                    komut.Parameters.AddWithValue("@id", KategoriId);
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    cevap += "Kategori Silindi.";

                }
                catch (Exception ex)
                {

                    cevap += ex.ToString();
                }
            }
            else
            {
                try
                {
                    SqlCommand komut = new SqlCommand("DELETE FROM KATEGORILER WHERE Id=@id", baglanti);
                    komut.Parameters.AddWithValue("@id", KategoriId);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    cevap += "Kategori Silindi.";

                }
                catch (Exception ex)
                {

                    cevap += ex.ToString();
                }
            }
            return cevap;
        }

    }
}
