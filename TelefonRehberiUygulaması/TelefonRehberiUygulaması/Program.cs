using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;

namespace TelefonRehberiUygulaması
{
    class Kisi
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string phone { get; set; }

    }

   
    class Program
    {
        static List<Kisi> rehber = new List<Kisi>
        {
        new Kisi {name="Ahmet", surname="Yılmaz", phone="05331234567"},
        new Kisi { name = "Mehmet", surname = "Demir", phone = "05421234567" },
        new Kisi { name = "Ayşe", surname = "Kara", phone = "05551234567" },
        new Kisi { name = "Fatma", surname = "Aydın", phone = "05321234567" },
        new Kisi { name = "Ali", surname = "Çelik", phone = "05051234567" },
        new Kisi {name="Ahmet", surname="Sever", phone="0538454567"},
        };

        static void Main ()
        {
            while(true)
            {
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
                Console.WriteLine("*****************************************************");
                Console.WriteLine("(1) Yeni Numara Kaydetmek");
                Console.WriteLine("(2) Varolan Numarayı Silmek");
                Console.WriteLine("(3) Varolan Numarayı Güncelleme");
                Console.WriteLine("(4) Rehberi Listelemek");
                Console.WriteLine("(5) Rehberde Arama Yapmak");
                Console.WriteLine("(6) Çıkış");

                Console.WriteLine("Seçiminiz : ");
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        YeniNumaraKaydet();
                        break;
                    case "2":
                        NumaraSil();
                        break;

                    case "3":
                        NumaraGüncelle();
                        break;

                    case "4":
                        RehberiListele();
                        break;

                    case "5":
                        AramaYap();
                        break;

                    case "6":
                        return;

                    default:
                        Console.WriteLine("Geçersiz seçim ! ");
                        break;

                }
            }


        }

        static void YeniNumaraKaydet()
        {

            Console.WriteLine("Lütfen isim giriniz: ");
            string isim = Console.ReadLine();

            Console.WriteLine("Lütfen soyisim giriniz: ");
            string soyisimisim = Console.ReadLine();

            Console.WriteLine("Lütfen telefon giriniz: ");
            string telefon = Console.ReadLine();

            rehber.Add(new Kisi
            {
                name = isim,
                surname = soyisimisim,
                phone = telefon,

             });

            Console.WriteLine("Yeni Numara rehberinize eklendi. ");

        }

        static void NumaraSil()
        {
            while (true)
            {
                Console.WriteLine("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz:");
                string arama = Console.ReadLine();

                var kisi = rehber.FirstOrDefault(k =>
                k.name.Equals(arama, StringComparison.OrdinalIgnoreCase) ||
                k.surname.Equals(arama, StringComparison.OrdinalIgnoreCase));

                if (kisi == null)
                {
                    Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                    Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
                    Console.WriteLine("* Yeniden denemek için      : (2)");
                    string secim = Console.ReadLine();

                    if (secim == "1")
                        break;

                    else
                        continue;
                }

                Console.WriteLine($"\n {kisi.name} {kisi.surname} isimli kişi rehberden silinmek üzere, onaylıyor musunuz ?(y/n)");
                string onay = Console.ReadLine();

                if (onay.ToLower() == "y")
                {
                    rehber.Remove(kisi);
                    Console.WriteLine("Rehberden silindi.");
                }
                else
                {
                    Console.WriteLine("Silme işlemi iptal edildi !");
                }

                break;


            }

        }

        static void NumaraGüncelle()
        {
            while (true)
            {
                Console.WriteLine("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz:");
                string arama = Console.ReadLine();

                var kisi = rehber.FirstOrDefault(k =>
                k.name.Equals(arama, StringComparison.OrdinalIgnoreCase) ||
                k.surname.Equals(arama, StringComparison.OrdinalIgnoreCase));

                if (kisi == null)
                {
                    Console.WriteLine(" Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.\r\n");
                    Console.WriteLine(" * Güncellemeyi sonlandırmak için    : (1)");
                    Console.WriteLine(" * Yeniden denemek için              : (2)");
                    string secim = Console.ReadLine();

                    if (secim == "1") 
                        break;
                    else 
                        continue;
                }

                    Console.WriteLine($"\n {kisi.name} {kisi.surname} isimli kişinin telefon numarası : {kisi.phone}");
                    Console.WriteLine("Yeni telefon numarasını giriniz :");
                    string yeniNumara=Console.ReadLine();

                    kisi.phone = yeniNumara;
                    Console.WriteLine("Numara başarıyla güncellenmiştir.");
                    break;

                }

        }

       
        static void RehberiListele()
        {
            Console.WriteLine(" Telefon Rehberi");
            Console.WriteLine("******************************");

            foreach( var kisi in rehber)
            {
                Console.WriteLine($"İsim: {kisi.name} \nSoyisim: {kisi.surname} \nTelefon Numarası: {kisi.phone}");
            }
        }

        static void AramaYap()
        {
            Console.WriteLine(" Arama yapmak istediğiniz tipi seçiniz.\r\n");
            Console.WriteLine("(1) Telefon numarasına göre arama yapmak için:");
            Console.WriteLine("(2) İsim veya soyisime göre arama yapmak için:");
            Console.WriteLine("Seçiminiz: ");
            string secim = Console.ReadLine();

            List<Kisi> bulunanlar = new List<Kisi>();
            if(secim == "1")
            {
                Console.WriteLine("Telefon numarasını giriniz: ");
                string arama=Console.ReadLine();

                bulunanlar = rehber.Where(k=> k.phone.Contains(arama)).ToList();
            }
            else if (secim == "2")
            {
                Console.WriteLine("İsim veya soyisim giriniz: ");
                string arama = Console.ReadLine();

                bulunanlar= rehber.Where(k => k.name.Contains(arama) ||
                k.surname.Contains(arama) )
                .ToList() ;


            }
            else
            {
                Console.WriteLine("Geçersiz seçim !!");
                return;
            }

            if (bulunanlar.Count == 0)
            {
                Console.WriteLine("Hiçbir Kayıt bulunamadı !");
            }

            else
            {
                Console.WriteLine("Arama Sonuçları : ");
                Console.WriteLine("*************************");

                foreach (var kisi in bulunanlar)
                {
                    Console.WriteLine($"İsim: {kisi.name} \nSoyisim: {kisi.surname} \nTelefon Numarası: {kisi.phone}");
                }
            }

        }
    }

}