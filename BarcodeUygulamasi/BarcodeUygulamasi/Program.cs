using System;
using System.Drawing;
using System.Drawing.Imaging;
using ZXing;
using ZXing.Windows.Compatibility;
class Program
{
    static void Main()
    {
        Console.WriteLine("Barkod için bir metin giriniz:");
        string metin = Console.ReadLine();

        string masaustu = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string dosyaYolu = Path.Combine(masaustu, "barcode.png");

        // Barkod üret
        var barcodeWriter = new BarcodeWriter
        {
            Format = BarcodeFormat.CODE_128,
            Options = new ZXing.Common.EncodingOptions
            {
                Width = 300,
                Height = 100,
                Margin = 10
            }
        };

        using (Bitmap barcodeBitmap = barcodeWriter.Write(metin))
        {
            barcodeBitmap.Save(dosyaYolu, ImageFormat.Png);
            Console.WriteLine($"Barcode başarıyla oluşturuldu: {dosyaYolu}");
        }

        // Barkod oku
        if (File.Exists(dosyaYolu))
        {
            using (Bitmap bitmap = new Bitmap(dosyaYolu))
            {
                var barcodeReader = new BarcodeReader();
                var sonuc = barcodeReader.Decode(bitmap);

                if (sonuc != null)
                    Console.WriteLine("Barcode içeriği: " + sonuc.Text);
                else
                    Console.WriteLine("Barcode çözümlenemedi.");
            }
        }
    }
}

