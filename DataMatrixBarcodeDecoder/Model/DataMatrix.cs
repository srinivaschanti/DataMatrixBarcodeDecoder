using System;
using System.Collections.Generic;
using System.Text;

namespace DataMatrixBarcodeDecoder.Model
{
    public class DataMatrix
    {
        public string GTIN { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string SeasonYear { get; set; }
        public string SerialNumber { get; set; }
        public string CountryOfOrigin { get; set; }

    }
}
