using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // Kart büyüklükleri Enum
    enum Buyukluk { XS = 1, S, M, L, XL }

    // Kart sınıfı
    class Kart
    {
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public string AtananKisi { get; set; }
        public Buyukluk Buyukluk { get; set; }
    }

    // Board Line'larını tutan Dictionary yapısı
    static Dictionary<string, List<Kart>> board = new Dictionary<string, List<Kart>>()
    {
        { "TODO", new List<Kart>() },
        { "IN PROGRESS", new List<Kart>() },
        { "DONE", new List<Kart>() }
    };

    // Takım üyeleri ID - İsim ilişkisi
    static Dictionary<int, string> takimUyeleri = new Dictionary<int, string>()
    {
        { 1, "Ali" },
        { 2, "Ayşe" },
        { 3, "Veli" },
        { 4, "Fatma" }
    };

    static void Main(string[] args)
    {
        // Varsayılan kartlar
        board["TODO"].Add(new Kart { Baslik = "Proje Başlat", Icerik = "Araştırma yapılacak", AtananKisi = takimUyeleri[1], Buyukluk = Buyukluk.M });
        board["IN PROGRESS"].Add(new Kart { Baslik = "UI Tasarımı", Icerik = "UI tamamlanacak", AtananKisi = takimUyeleri[2], Buyukluk = Buyukluk.L });
        board["DONE"].Add(new Kart { Baslik = "Araştırma", Icerik = "Proje araştırması bitti", AtananKisi = takimUyeleri[3], Buyukluk = Buyukluk.S });

        int secim;

        do
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :) ");
            Console.WriteLine("*******************************************");
            Console.WriteLine("(1) Board Listelemek");
            Console.WriteLine("(2) Board'a Kart Eklemek");
            Console.WriteLine("(3) Board'dan Kart Silmek");
            Console.WriteLine("(4) Kart Taşımak");
            Console.WriteLine("(0) Çıkış");

            secim = int.Parse(Console.ReadLine());

            switch (secim)
            {
                case 1:
                    BoardListele();
                    break;
                case 2:
                    KartEkle();
                    break;
                case 3:
                    KartSil();
                    break;
                case 4:
                    KartTasi();
                    break;
                case 0:
                    Console.WriteLine("Çıkış yapılıyor...");
                    break;
                default:
                    Console.WriteLine("Geçersiz bir işlem!");
                    break;
            }

        } while (secim != 0);
    }

    // Board'u Listeleme
    static void BoardListele()
    {
        foreach (var kolon in board)
        {
            Console.WriteLine($"{kolon.Key} Line");
            Console.WriteLine("************************");

            if (kolon.Value.Count == 0)
            {
                Console.WriteLine("~ BOŞ ~");
            }
            else
            {
                foreach (var kart in kolon.Value)
                {
                    Console.WriteLine($"Başlık      : {kart.Baslik}");
                    Console.WriteLine($"İçerik      : {kart.Icerik}");
                    Console.WriteLine($"Atanan Kişi : {kart.AtananKisi}");
                    Console.WriteLine($"Büyüklük    : {kart.Buyukluk}");
                    Console.WriteLine("-");
                }
            }

            Console.WriteLine();
        }
    }

    // Kart Ekleme
    static void KartEkle()
    {
        Kart yeniKart = new Kart();

        Console.Write("Başlık Giriniz                                  : ");
        yeniKart.Baslik = Console.ReadLine();

        Console.Write("İçerik Giriniz                                  : ");
        yeniKart.Icerik = Console.ReadLine();

        Console.Write("Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5)  : ");
        yeniKart.Buyukluk = (Buyukluk)int.Parse(Console.ReadLine());

        Console.Write("Kişi Seçiniz                                    : ");
        foreach (var uye in takimUyeleri)
        {
            Console.WriteLine($"{uye.Key} - {uye.Value}");
        }

        int kisiID = int.Parse(Console.ReadLine());

        if (takimUyeleri.ContainsKey(kisiID))
        {
            yeniKart.AtananKisi = takimUyeleri[kisiID];
            board["TODO"].Add(yeniKart);
            Console.WriteLine("Kart başarıyla eklendi!\n");
        }
        else
        {
            Console.WriteLine("Hatalı girişler yaptınız!\n");
        }
    }

    // Kart Silme
    static void KartSil()
    {
        Console.Write("Lütfen silmek istediğiniz kartın başlığını yazınız: ");
        string baslik = Console.ReadLine();

        foreach (var kolon in board)
        {
            var kart = kolon.Value.FirstOrDefault(k => k.Baslik == baslik);
            if (kart != null)
            {
                kolon.Value.Remove(kart);
                Console.WriteLine("Kart başarıyla silindi!\n");
                return;
            }
        }

        Console.WriteLine("Aradığınız kriterlere uygun kart board'da bulunamadı.\n");
    }

    // Kart Taşıma
    static void KartTasi()
    {
        Console.Write("Lütfen taşımak istediğiniz kartın başlığını yazınız: ");
        string baslik = Console.ReadLine();

        foreach (var kolon in board)
        {
            var kart = kolon.Value.FirstOrDefault(k => k.Baslik == baslik);
            if (kart != null)
            {
                Console.WriteLine($"Bulunan Kart Bilgileri:\nBaşlık: {kart.Baslik}\nİçerik: {kart.Icerik}\nAtanan Kişi: {kart.AtananKisi}\nBüyüklük: {kart.Buyukluk}");
                Console.WriteLine("Lütfen taşımak istediğiniz Line'ı seçiniz: (1) TODO (2) IN PROGRESS (3) DONE");

                int lineSecimi = int.Parse(Console.ReadLine());

                string yeniLine = lineSecimi switch
                {
                    1 => "TODO",
                    2 => "IN PROGRESS",
                    3 => "DONE",
                    _ => null
                };

                if (yeniLine != null)
                {
                    kolon.Value.Remove(kart);
                    board[yeniLine].Add(kart);
                    Console.WriteLine("Kart başarıyla taşındı!\n");
                    return;
                }
                else
                {
                    Console.WriteLine("Hatalı bir seçim yaptınız!\n");
                    return;
                }
            }
        }

        Console.WriteLine("Aradığınız kriterlere uygun kart board'da bulunamadı.\n");
    }
}
