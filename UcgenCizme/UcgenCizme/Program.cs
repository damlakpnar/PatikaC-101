using System;

namespace UcgenCizme
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Üçgen boyutunu giriniz: ");
            string input = Console.ReadLine();
            int boyut= Convert.ToInt32(input);

            for(int i=1; i<=boyut; i++)
            {
                //Boşluklar
                for (int j = 1; j <= boyut - i; j++)
                {
                    Console.Write(" ");
                }

                //Yıldızlar
                for (int k = 1; k <= (2 * i - 1); k++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }
    }
}