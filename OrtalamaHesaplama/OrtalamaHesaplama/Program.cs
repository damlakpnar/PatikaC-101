using System;
using System.Collections.Generic;

namespace OrtalamaHesaplama
{
    class Program
    {
        static void Main()
        {
            Console.Write("Fibonacci serisinin derinliğini giriniz: ");
            string input = Console.ReadLine();
            int depth=Convert.ToInt32(input);

            List<int> fibonacci = new List<int>();

            if(depth >= 1)
            {
                fibonacci.Add(0);
            }
            if(depth >= 2)
            {
                fibonacci.Add(1);
            }

            for(int i=2; i<depth; i++)
            {
                int nextNumber = fibonacci[i-1] + fibonacci[i-2];
                fibonacci.Add(nextNumber);
            }

            Console.WriteLine("Fibonacci Serisi");
            foreach(int number in fibonacci)
            {
                Console.WriteLine(number + " ");
            }

            int toplam = 0;
            foreach(int sayi in fibonacci)
            {
                toplam += sayi;
            }

            double ortalama = (double)toplam/fibonacci.Count;
            Console.WriteLine($"Serideki sayıların ortalaması: {ortalama} ");

        }




    }

}