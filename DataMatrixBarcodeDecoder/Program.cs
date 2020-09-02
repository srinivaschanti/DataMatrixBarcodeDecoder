using DataMatrixBarcodeDecoder.Model;
using System;

namespace DataMatrixBarcodeDecoder
{
    class Program
    {
        static void Main(string[] args)
        {
            Decoder decodeBarcode = new Decoder();
            DataMatrix data = new DataMatrix();
            Console.WriteLine("Enter Barcode");
            string barcode = Console.ReadLine();
            var arr = decodeBarcode.ParseBarcode(barcode);

            data.GTIN = arr[0][1];
            data.PurchaseOrderNumber = arr[1][1];
            data.SeasonYear = arr[2][1];
            data.SerialNumber = arr[3][1];
            data.CountryOfOrigin = arr[4][1];

            //for(int i = 0; i<arr.Length; i++)
            //{
            //    var result = arr[i];
            //    Console.WriteLine($"({result[0]}){result[1]}");
            //}

            Console.WriteLine(data.GTIN);
            Console.WriteLine(data.PurchaseOrderNumber);
            Console.WriteLine(data.SeasonYear);
            Console.WriteLine(data.SerialNumber);
            Console.WriteLine(data.CountryOfOrigin);
            Console.ReadKey();
        }
    }
}
