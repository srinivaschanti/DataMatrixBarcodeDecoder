using System;
using System.Collections.Generic;
using System.Text;

namespace DataMatrixBarcodeDecoder.Model
{
    public class DataMatrix
    {
        public string GTIN { get; set; }
        public string PurchaseOrder { get; set; }
        public string Season { get; set; }
        public string SerialNumber { get; set; }
        public string CountryOfOrigin { get; set; }

    }
}
