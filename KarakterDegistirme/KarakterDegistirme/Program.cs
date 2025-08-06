using System;
namespace KarakterDegistirme
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Bir cümle girin:");
            string input = Console.ReadLine();
            string[] kelimeler = input.Split(' ');

            for(int i = 0; i < kelimeler.Length; i++)
            {
                string kelime = kelimeler[i];
                if(kelime.Length > 1) 
                {
                    char ilk = kelime[0];
                    char son = kelime[kelime.Length - 1];
                    string orta = kelime.Substring(1, kelime.Length - 2);
                    kelimeler[i]=son+orta+ilk;
                }

            }

            string sonuc = string.Join(" ", kelimeler);
            Console.WriteLine("Çıktı :" + sonuc);
        }
    }
}