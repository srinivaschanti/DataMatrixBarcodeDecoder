using DataMatrixBarcodeDecoder.Model;
using System;

namespace DataMatrixBarcodeDecoder
{
    class Program
    {
        //Example DataMatrix Barcode
        //010731392734276810780814240921151153067776241US
        static void Main(string[] args)
        {
            Decoder decodeBarcode = new Decoder();
            DataMatrix data = new DataMatrix();
            Console.WriteLine("Enter Barcode");
            string barcode = Console.ReadLine();
            data = decodeBarcode.ParseBarcode(barcode);
            
            Console.WriteLine("");
            Console.WriteLine("Decoded Barcode Values:");
            Console.WriteLine($"GTIN: {data.GTIN}");
            Console.WriteLine($"Purchase Order Number: {data.PurchaseOrder}");
            Console.WriteLine($"Season: {data.Season}");
            Console.WriteLine($"Serial Number: {data.SerialNumber}");
            Console.WriteLine($"Country of Origin: {data.CountryOfOrigin}");
            Console.ReadKey();
        }
    }
}
