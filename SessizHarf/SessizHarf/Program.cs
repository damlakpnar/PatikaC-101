using System;
namespace SessizHarf
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Bir metin giriniz:");
            string input=Console.ReadLine().ToLower();
            string sessizHarfler = "b, c, ç, d, f, g, ğ, h, j, k, l, m, n, p, r, s, ş, t, v, y, z";

            bool bulundu = false;

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (sessizHarfler.Contains(input[i]) && sessizHarfler.Contains(input[i + 1])){
                    bulundu = true;
                    break;
                }
            }

            Console.WriteLine(bulundu);

        }
    }
}