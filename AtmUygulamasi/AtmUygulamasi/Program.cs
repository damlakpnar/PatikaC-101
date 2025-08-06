using System;
using System.Collections.Generic;
using System.IO;
namespace AtmUygulamasi
{
    public class Program
    {
        static Dictionary<string, string> kullanıcı = new Dictionary<string, string>()
            {
                {"ahmet","123"},
                {"ayşe","456" }
            };

        static List<string> transactionLog = new List<string>();
        static List<string> fraudLog = new List<string>();

        static void Main()
        {
            string aktifKullanici = "";
            Console.WriteLine("ATM GİRİŞ EKRANI");
            for(int deneme=1; deneme <= 3; deneme++)
            {
                Console.WriteLine("Kullanıcı Adı:");
                string username=Console.ReadLine();
                Console.WriteLine("Şifre:");
                string parola=Console.ReadLine();

                if(kullanıcı.ContainsKey(username) && kullanıcı[username]==parola)
                {
                    aktifKullanici = username;
                    Console.WriteLine($"Hoşgeldiniz {aktifKullanici}");
                    break;
                }
                else 
                {
                    string log = $"{DateTime.Now}- Hatalı giriş denemesi. Kullanıcı adı= '{username}'";
                    fraudLog.Add(log);
                    Console.WriteLine("Hatalı kullanıcı adı veya şifre !");
                }
            }

            if (aktifKullanici == "")
            {
                Console.WriteLine("3 başarısız deneme. Sistemden çıkılıyor...");
                return;
            }


            //Menü ekranı
            bool devam = true;
            while (devam)
            {
                Console.WriteLine("ANA MENÜ");
                Console.WriteLine("1-Para Çekme");
                Console.WriteLine("2-Para Yatırma");
                Console.WriteLine("3-Ödeme Yapma");
                Console.WriteLine("4-Çıkış");
                Console.WriteLine("Seçiminiz:");
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        Console.WriteLine("Para çekme işlemi...");
                        transactionLog.Add($"{DateTime.Now:dd.MM.yyyy HH:mm:ss} - {aktifKullanici} para çekti.");
                        break;

                    case "2":
                        Console.WriteLine("Para yatırma işlemi...");
                        transactionLog.Add($"{DateTime.Now:dd.MM.yyyy HH:mm:ss} - {aktifKullanici} para yatırdı.");
                        break;

                    case "3":
                        Console.WriteLine("Ödeme yapma işlemi...");
                        transactionLog.Add($"{DateTime.Now:dd.MM.yyyy HH:mm:ss} - {aktifKullanici} ödeme yaptı.");
                        break;

                    case "4":
                        devam = false;
                        Console.WriteLine("Çıkış yapılıyor...");
                        break;

                    default:
                        Console.WriteLine("Geçersiz işlem seçtiniz!");
                        break;
                }


            }

            Console.WriteLine();

        }
    }
}