using System;
namespace KarakteriTerstenYazma
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Lütfen birden fazla kelime giriniz:");
            string input=Console.ReadLine();

            string[] kelimeler = input.Split(' ');

            for(int i = 0; i < kelimeler.Length; i++)
            {
                string kelime= kelimeler[i];

                if(kelime.Length > 1)
                {
                    string yeniKelime = kelime.Substring(1) + kelime[0];
                    kelimeler[i] = yeniKelime;
                }
                else
                {
                    kelimeler[i] = kelime;
                }
            }

            string sonuc = string.Join(" ", kelimeler);
            Console.WriteLine("Sonuç: " + sonuc);

        }
    }
}