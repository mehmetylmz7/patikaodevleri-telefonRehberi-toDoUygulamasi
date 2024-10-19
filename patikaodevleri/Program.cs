using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    class Kisi
    {
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public string TelefonNumarasi { get; set; }

    }
    static List<Kisi> telefonRehberi = new List<Kisi>();

    static void Main(string[] args)
    {

        int secim;

        do
        {

            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :) ");
            Console.WriteLine("*******************************************");
            Console.WriteLine("(1) Yeni Numara Kaydetmek");
            Console.WriteLine("(2) Varolan Numarayı Silmek");
            Console.WriteLine("(3) Varolan Numarayı Güncelleme");
            Console.WriteLine("(4) Rehberi Listelemek");
            Console.WriteLine("(5) Rehberde Arama Yapmak");
            Console.WriteLine("(0) Çıkış");

            secim = int.Parse(Console.ReadLine());

            switch (secim)
            {
                    case 1:
                    YeniNumaraKaydet();
                    break;

                    case 2:
                    VarOlanNumaraSil();
                    break;

                    case 3:
                    VarolanNumaraGuncelle();
                    break;

                    case 4:
                    RehberiListele();
                    break;

                    case 5:
                    RehberdeAramaYap();
                    break;

                case 0:
                    Console.WriteLine("cikis yapiliyorrr.. ");
                    break;

                    default:
                    Console.WriteLine("lutfen gecerli bir secim yapiniz");
                    break ;



            }





        } while (secim != 0);







    }

    static void YeniNumaraKaydet()
    {
        Kisi yeniKisi = new Kisi();

        Console.WriteLine("lutfen isim giriniz: ");
        yeniKisi.Isim = Console.ReadLine();

        Console.WriteLine("lutfen soyisim giriniz: ");
        yeniKisi.Soyisim = Console.ReadLine();

        Console.WriteLine("lutfen numara giriniz:  ");
        yeniKisi.TelefonNumarasi = Console.ReadLine();

        telefonRehberi.Add(yeniKisi);
        Console.WriteLine("yeni kisi eklendi");

    }


    static void VarOlanNumaraSil()
    {

        Console.Write("Lütfen silmek istediğiniz kişinin ismini ya da soyismini giriniz: ");
        
        string isimOrSoyisim =Console.ReadLine();
 
        Kisi kisi =telefonRehberi.FirstOrDefault(k => k.Isim == isimOrSoyisim);
        Kisi kisi1 =telefonRehberi.FirstOrDefault(k => k.Soyisim == isimOrSoyisim);

        if (kisi1 != null)
        {
            telefonRehberi.Remove(kisi1);
        }

        else if (kisi != null)
        {
            telefonRehberi.Remove(kisi);
        }

        else
        {
            Console.WriteLine("kayit bulunamadi");
        }



    }
    static void VarolanNumaraGuncelle()
    {
        Console.Write("Lütfen güncellemek istediğiniz kişinin ismini giriniz: ");
        string isim = Console.ReadLine();

        Kisi kisi = telefonRehberi.FirstOrDefault(k => k.Isim == isim);
        if (kisi != null)
        {
            Console.Write("Yeni telefon numarasını giriniz: ");
            kisi.TelefonNumarasi = Console.ReadLine();
            Console.WriteLine("Numara başarıyla güncellendi.\n");
        }
        else
        {
            Console.WriteLine("Kayıt bulunamadı.\n");
        }
    }
    static void RehberiListele()
    {
        if (telefonRehberi.Count == 0)
        {
            Console.WriteLine("Rehber boş.\n");
        }
        else
        {
            Console.WriteLine("Telefon Rehberi:");
            foreach (var kisi in telefonRehberi)
            {
                Console.WriteLine($"İsim: {kisi.Isim}, Soyisim: {kisi.Soyisim}, Telefon Numarası: {kisi.TelefonNumarasi}");
            }
            Console.WriteLine();
        }
    }

    static void RehberdeAramaYap()
    {
        Console.Write("Lütfen aramak istediğiniz ismi giriniz: ");
        string isim = Console.ReadLine();

        Kisi kisi = telefonRehberi.FirstOrDefault(k => k.Isim == isim);
        if (kisi != null)
        {
            Console.WriteLine($"İsim: {kisi.Isim}, Soyisim: {kisi.Soyisim}, Telefon Numarası: {kisi.TelefonNumarasi}\n");
        }
        else
        {
            Console.WriteLine("Kayıt bulunamadı.\n");
        }
    }



}
