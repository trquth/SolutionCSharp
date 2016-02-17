using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacode
{
    class Program
    {
        static void Main(string[] args)
        {
           var barcode= GenerateQR(200, 200, "Thien");
            barcode.Save(@"D:\myBarcode.png", System.Drawing.Imaging.ImageFormat.Png);
            Console.WriteLine("Success");
            Console.ReadLine();

        }
         public static Bitmap GenerateQR(int width,int height,string text)
        {
            var bw = new ZXing.BarcodeWriter();
            var encOptions = new ZXing.Common.EncodingOptions() { Width = width, Height = height, Margin = 0 };
            bw.Options = encOptions;
            bw.Format = ZXing.BarcodeFormat.CODE_128;
            var result = new Bitmap(bw.Write(text));
            return result;

        }
    }
}
