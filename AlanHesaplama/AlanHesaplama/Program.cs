using System;

namespace AlanHesaplama
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("İşlem yapılmak istenen geometrik şekli yazınız (Daire, Üçgen, Kare): ");
            string sekil=Console.ReadLine().Trim().ToLower();

            Console.WriteLine("Hesaplamak istediğiniz işlemi yazınız (Alan,Çevre) : ");
            string islem=Console.ReadLine().Trim().ToLower();

            double sonuc = 0;

            switch(sekil)
            {
                case "daire":
                    Console.WriteLine("Yarıcapı giriniz: ");
                    double r=Convert.ToDouble(Console.ReadLine());

                    if(islem== "alan")
                    {
                        sonuc = Math.PI * r * r;
                    }
                    else if(islem== "çevre")
                    {
                        sonuc = 2 * Math.PI * r;
                    }
                    else
                    {
                        hataMesaji();
                    }
                    break;

                case "üçgen":
                    if(islem== "alan")
                    {
                        Console.WriteLine("Taban uzunluğunu giriniz:");
                        double taban=Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Yükseklik uzunluğunu giriniz");
                        double yukseklik=Convert.ToDouble(Console.ReadLine());

                        sonuc = (taban * yukseklik) / 2;
                    }
                    else if (islem == "çevre")
                    {
                        Console.WriteLine("1.Kenar Uzunluğu giriniz:");
                        double a=Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("2.Kenar Uzunluğu giriniz:");
                        double b = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("3.Kenar Uzunluğu giriniz:");
                        double c = Convert.ToDouble(Console.ReadLine());

                        sonuc = a + b + c;
                    }
                    else
                    {
                        hataMesaji();
                    }
                    break;

                case "kare":
                    Console.WriteLine("Kenar uzunluğunu giriniz: ");
                    double kenar = Convert.ToDouble(Console.ReadLine());

                    if(islem == "alan")
                    {
                        sonuc = kenar * kenar;
                    }
                    else if(islem == "çevre")
                    {
                        sonuc = 4 * kenar;
                    }
                    else
                    {
                        hataMesaji();
                    }

                    break;


                default:
                    Console.WriteLine("Geçersiz şekil girdiniz.");
                    break;

            }

            Console.WriteLine($"Seçilen Şekil: {sekil.ToUpper()}");
            Console.WriteLine($"İşlem: {islem.ToUpper()}");
            Console.WriteLine($"Sonuç: {Math.Round(sonuc,2)}");


        }


        static void hataMesaji()
        {
            Console.WriteLine("Hatalı islem seçtiniz. Alan veya Çevre islemleri yapılır.");
            Environment.Exit(0);
        }
    }
}