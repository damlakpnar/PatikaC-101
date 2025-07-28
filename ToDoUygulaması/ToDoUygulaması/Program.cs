using System;

namespace ToDoUygulaması
{
    class Program
    {
        static List<TeamMember> teamMembers = new List<TeamMember>
        {
            new TeamMember{ID = 1, name="Damla"},
            new TeamMember{ID = 2,name="Mehmet"},
            new TeamMember{ID = 3, name="Ayşe"}
        };
        
        static Board board = new Board();
        static void Main(string[] args)
        {
            InitializeDefaultCards();
            Console.WriteLine("Pano, varsayılan kartlar ve takım üyeleriyle oluşturuldu.");


            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz: ");
                Console.WriteLine("*********************************************");
                Console.WriteLine(" (1) Board Listelemek");
                Console.WriteLine(" (2) Board'a Kart Eklemek");
                Console.WriteLine(" (3) Board'dan Kart Silmek");
                Console.WriteLine(" (4) Kart Taşımak");
                Console.WriteLine(" (0) Çıkış");

                string secim= Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        boardListele();
                        break;

                    case "2":
                        kartEkle();
                        break;

                    case "3":
                        kartSil();
                        break;
                    case "4":
                        kartTasi();
                        break;

                    case "0":
                        Console.WriteLine("Uygulama sonlandırılıyor...");
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim! Lütfen 0-4 arasında bir sayı girin.");
                        break;
                }
            }


        }
        static void InitializeDefaultCards()
        {
            board.Lines[Line.TODO].Add(new Card
            {
                tittle = "Projeyi Başlat",
                content = "İlk konsol yapısını oluştur",
                AssignedTo = teamMembers[0],
                size = Size.M
            });

            board.Lines[Line.IN_PROGRESS].Add(new Card
            {
                tittle = "Sınıfları Tasarla",
                content = "Kart, Pano, TakımÜyesi sınıflarını tanımla",
                AssignedTo = teamMembers[1],
                size = Size.L
            });

            board.Lines[Line.DONE].Add(new Card
            {
                tittle = "Enumları Yaz",
                content = "Boyut ve Satır enum'larını ekle",
                AssignedTo = teamMembers[2],
                size = Size.S
            });
        }

        static void boardListele()
        {
            foreach (var satir in board.Lines)
            {
                Console.WriteLine($"\n {satir.Key} Satırı ");
                Console.WriteLine("************************");

                if (satir.Value.Count == 0)
                {
                    Console.WriteLine("~ BOŞ ~");
                }
                else
                {
                    foreach (var kart in satir.Value)
                    {
                        Console.WriteLine($"Başlık      : {kart.tittle}");
                        Console.WriteLine($"İçerik      : {kart.content}");
                        Console.WriteLine($"Atanan Kişi : {kart.AssignedTo.name}");
                        Console.WriteLine($"Büyüklük    : {kart.size}");
                        Console.WriteLine("-");
                    }
                }


            }

        }

        static void kartEkle()
        {
            Console.Write("Başlık giriniz             : ");
            string baslik = Console.ReadLine();

            Console.Write("İçerik giriniz             : ");
            string icerik = Console.ReadLine();

            Console.Write("Büyüklük seçiniz -> XS(1), S(2), M(3), L(4), XL(5): ");
            bool boyutOk = int.TryParse(Console.ReadLine(), out int boyutSecim);

            if (!boyutOk || !Enum.IsDefined(typeof(Size), boyutSecim))
            {
                Console.WriteLine("Geçersiz büyüklük seçimi!");
                return;
            }

            Console.WriteLine("Lütfen bir kişi seçin (ID):");
            foreach (var uye in teamMembers)
            {
                Console.WriteLine($"ID: {uye.ID} - Ad: {uye.name}");
            }

            bool idOk = int.TryParse(Console.ReadLine(), out int uyeId);
            var secilenUye = teamMembers.FirstOrDefault(u => u.ID == uyeId);

            if (secilenUye == null)
            {
                Console.WriteLine("Hatalı giriş yaptınız! Kart eklenemedi.");
                return;
            }

            Card yeniKart = new Card
            {
                tittle = baslik,
                content = icerik,
                AssignedTo = secilenUye,
                size = (Size)boyutSecim
            };

            board.Lines[Line.TODO].Add(yeniKart);
            Console.WriteLine("Kart başarıyla eklendi ve 'Yapılacak' satırına yerleştirildi.");
        }


        static void kartSil()
        {
            Console.Write("Lütfen silmek istediğiniz kartın başlığını yazınız: ");
            string girilenBaslik = Console.ReadLine();

            // Kartı bulmaya çalış
            var bulunanKart = board.Lines
                .SelectMany(satir => satir.Value)
                .FirstOrDefault(kart => kart.tittle.Equals(girilenBaslik, StringComparison.OrdinalIgnoreCase));

            if (bulunanKart == null)
            {
                Console.WriteLine("Aradığınız kriterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine(" * Silmeyi sonlandırmak için : (1)");
                Console.WriteLine(" * Yeniden denemek için       : (2)");

                string secim = Console.ReadLine();
                if (secim == "2")
                    kartSil(); // yeniden başlat
                return;
            }

            // Kartı hangi satırda olduğunu bul
            foreach (var satir in board.Lines)
            {
                if (satir.Value.Remove(bulunanKart))
                {
                    Console.WriteLine("Kart başarıyla silindi.");
                    return;
                }
            }

            Console.WriteLine("Silme işlemi başarısız oldu.");
        }


        static void kartTasi()
        {
            Console.Write("Lütfen taşımak istediğiniz kartın başlığını yazınız: ");
            string girilenBaslik = Console.ReadLine();

            Card kart = null;
            Line mevcutSatir = Line.TODO;

            // Kartı ve bulunduğu satırı bul
            foreach (var satir in board.Lines)
            {
                kart = satir.Value.FirstOrDefault(k => k.tittle.Equals(girilenBaslik, StringComparison.OrdinalIgnoreCase));
                if (kart != null)
                {
                    mevcutSatir = satir.Key;
                    break;
                }
            }

            if (kart == null)
            {
                Console.WriteLine("Aradığınız kriterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine(" * İşlemi sonlandırmak için : (1)");
                Console.WriteLine(" * Yeniden denemek için     : (2)");

                string secim = Console.ReadLine();
                if (secim == "2")
                    kartTasi(); // yeniden başlat
                return;
            }

            // Kart bilgilerini göster
            Console.WriteLine("\nBulunan Kart Bilgileri:");
            Console.WriteLine("**************************************");
            Console.WriteLine($"Başlık      : {kart.tittle}");
            Console.WriteLine($"İçerik      : {kart.content}");
            Console.WriteLine($"Atanan Kişi : {kart.AssignedTo.name}");
            Console.WriteLine($"Büyüklük    : {kart.size}");
            Console.WriteLine($"Satır       : {mevcutSatir}");

            Console.WriteLine("Lütfen taşımak istediğiniz satırı seçiniz:");
            Console.WriteLine("(1) Yapılacak");
            Console.WriteLine("(2) Yapılıyor");
            Console.WriteLine("(3) Tamamlandı");

            bool secimOk = int.TryParse(Console.ReadLine(), out int yeniSatirSecimi);
            if (!secimOk || !Enum.IsDefined(typeof(Line), yeniSatirSecimi))
            {
                Console.WriteLine("Hatalı bir seçim yaptınız!");
                return;
            }

            Line yeniSatir = (Line)yeniSatirSecimi;

            // Eski yerinden sil, yenisine ekle
            board.Lines[mevcutSatir].Remove(kart);
            board.Lines[yeniSatir].Add(kart);

            Console.WriteLine("Kart başarıyla taşındı. Güncel pano:");
            boardListele();
        }

    }

}