using System;

namespace VirgulleAyrilanİfadeler
{
    class Program
    {
        static void Main()
        {
            Console.Write("Lütfen bir string ve bir sayı giriniz (virgülle ayırın): ");
            string input = Console.ReadLine(); 

            // Virgüle göre ayırıyoruz
            string[] parcalar = input.Split(',');

            if (parcalar.Length == 2)
            {
                string kelime = parcalar[0];
                int index;

                // Sayıya çevrilebiliyorsa ve indeks geçerli ise
                if (int.TryParse(parcalar[1], out index))
                {
                    if (index >= 0 && index < kelime.Length)
                    {
                        // İndeksteki karakteri çıkar 
                        string sonuc = kelime.Remove(index, 1);
                        Console.WriteLine("Sonuç: " + sonuc);
                    }
                    else
                    {
                       
                        Console.WriteLine("Index geçerli değil. Kelimenin uzunluğu: " + kelime.Length);
                        Console.WriteLine("Sonuç: " + kelime);
                    }
                }
                else
                {
                    Console.WriteLine("Geçerli bir sayı girilmedi.");
                }
            }
            else
            {
                Console.WriteLine("Girdi formatı hatalı. Örnek: Algoritma,3");
            }
        }
    }
}
