using System;
using System.Collections.Generic;

namespace VotingUygulamasi
{
    public class Program
    {
        //Kategoriler ve seçenekler
        static Dictionary<string, List<string>> kategoriler = new Dictionary<string, List<string>>()
        {
            { "Film", new List<string> { "Inception", "Interstellar", "Titanic" } },
            { "Tech Stack", new List<string> { "C#", "Python", "JavaScript" } },
            { "Spor", new List<string> { "Futbol", "Basketbol", "Tenis" } }
        };

        static HashSet<string> kullanicilar = new HashSet<string>();

        static Dictionary<string, Dictionary<string, int>> oylar = new Dictionary<string, Dictionary<string, int>>();

        static void Main()
        {
            Console.WriteLine("Lütfen kullanıcı adınızı giriniz:");
            string username=Console.ReadLine();
            if(kullanicilar.Contains(username))
            {
                Console.WriteLine($"Hoşgeldin, {username}");
            }
            else
            {
                Console.WriteLine("Kullanıcı kaydı bulunamadı. Kayıt oluşturuluyor...");
                kullanicilar.Add(username);
                Console.WriteLine("Kayıt başarılı! Oylamaya geçiliyor.");
            }

            Console.WriteLine("Oylama Başlıyor !!");

            //Oyları sıfır olarak başlatıyoruz
            foreach(var kategori in kategoriler)
            {
                if (!oylar.ContainsKey(kategori.Key))
                    oylar[kategori.Key] = new Dictionary<string, int>();

                foreach (var secenek in kategori.Value)
                {
                    if (!oylar[kategori.Key].ContainsKey(secenek))
                        oylar[kategori.Key][secenek] = 0;
                }
            }

            //Oy verme süreci
            foreach (var kategori in kategoriler)
            {
                Console.WriteLine($"\nKategori: {kategori.Key}");
                var secenekler = kategori.Value;

                for (int i = 0; i < secenekler.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {secenekler[i]}");
                }

                int secim;
                do
                {
                    Console.Write("Lütfen bir seçenek numarası girin: ");
                }
                while (!int.TryParse(Console.ReadLine(), out secim) || secim < 1 || secim > secenekler.Count);

                string secilen = secenekler[secim - 1];
                oylar[kategori.Key][secilen]++;
                Console.WriteLine($"'{secilen}' seçeneğine oy verdiniz.");
            }



                Console.WriteLine("Oylamaya Açık Kategoriler:");
            foreach (var kategori in kategoriler)
            {
                Console.WriteLine($"\nKategori: {kategori.Key}");
                int index = 1;
                foreach (var secenek in kategori.Value)
                {
                    Console.WriteLine($"  {index++}. {secenek}");
                }
            }



            Console.WriteLine("\n--- OYLAMA SONUÇLARI ---");

            foreach (var kategori in oylar)
            {
                string kategoriAdi = kategori.Key;
                var secenekOylar = kategori.Value;

                int toplamOy = 0;
                foreach (var oy in secenekOylar.Values)
                {
                    toplamOy += oy;
                }

                Console.WriteLine($"\nKategori: {kategoriAdi} (Toplam Oy: {toplamOy})");

                foreach (var secenek in secenekOylar)
                {
                    string ad = secenek.Key;
                    int oySayisi = secenek.Value;

                    double oran = toplamOy > 0 ? (double)oySayisi / toplamOy * 100 : 0;

                    Console.WriteLine($"- {ad}: {oySayisi} oy (%{oran:F2})");
                }
            }
        }
    }
}