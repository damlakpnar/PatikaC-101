using System;

namespace MutlakKareAlma
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Boşluk bırakarak sayıları giriniz: ");
            string input =Console.ReadLine();
            string[] parts = input.Split(' ');
            int kucuklerToplami = 0;
            int buyuklerToplami = 0;

            foreach (string part in parts)
            {
                if(int.TryParse(part, out int sayi))
                {
                    if (sayi > 67)
                    {
                        int fark = sayi - 67;
                        buyuklerToplami += fark*fark;
                    }
                    else if( sayi < 67)
                    {
                        kucuklerToplami += (67 - sayi);
                    }
                }
            }


            Console.WriteLine($"{kucuklerToplami}, {buyuklerToplami}");

        }
    }
}