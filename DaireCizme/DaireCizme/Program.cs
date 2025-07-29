using System;

namespace DaireCizme
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dairenin yarıçapını giriniz:");
            string input = Console.ReadLine();
            int radius = Convert.ToInt32(input);

            double kalinlik = 0.4; // Kenar yumuşaklığı için tolerans
            double merkezX = radius;
            double merkezY = radius;

            for (int y = 0; y <= 2 * radius; y++)
            {
                for (int x = 0; x <= 2 * radius; x++)
                {
                    double mesafe = Math.Sqrt(Math.Pow(x - merkezX, 2) + Math.Pow(y - merkezY, 2));

                    if (mesafe >= radius - kalinlik && mesafe <= radius + kalinlik)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}