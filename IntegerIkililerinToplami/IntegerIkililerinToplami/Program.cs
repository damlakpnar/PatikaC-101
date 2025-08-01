using System;
namespace IntegerIkililerinToplami
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sayıları boşluklarla giriniz : ");
            string input = Console.ReadLine();

            string[] parts = input.Split(' ');
            int uzunluk = parts.Length;

            if(uzunluk % 2 != 0)
            {
                Console.WriteLine("Uyarı");
                uzunluk -= 1;

            }
            for (int i=0; i<uzunluk; i=i+2)
            {
                int sayi1  = int.Parse(parts[i]);
                int sayi2 = int.Parse((parts[i+1]));
                int toplam = sayi1 + sayi2;

                if(sayi1 == sayi2)
                {
                    Console.WriteLine($"{toplam*toplam}");
                }
                else
                {
                    Console.WriteLine($"{toplam}");
                }
            }

        }
    }
}