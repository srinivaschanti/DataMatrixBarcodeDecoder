using DataMatrixBarcodeDecoder.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DataMatrixBarcodeDecoder
{
    public class Decoder
    {
        string[][] arrKnownAIs = new string[5][] { //AI, description, min length, max length, type, decimal point indicator? 
                                new string[] { "01", "GTIN", "14", "14", "numeric", "false"},
                                new string[] { "10", "Purchanse Order number","6", "6", "numeric", "false"},
                                new string[] { "240", "Season Year", "1", "1", "numeric", "false"},
                                new string[] { "21", "Searial Number", "12", "12", "numeric", "false"},
                                new string[] { "241", "Country of Origin", "2", "2", "alphanumeric", "false"}                                
                              };
        public DataMatrix ParseBarcode(string barcode)
        {
            DataMatrix decodeResult = new DataMatrix();
            int arrayIndex = 0;
            string[][] arrAIs = new string[arrKnownAIs.Length][];

            while (arrayIndex < arrKnownAIs.Length)
            {
                string[] arrAI = arrKnownAIs[arrayIndex];
                var strAI = arrAI[0];
                int intMin = int.Parse(arrAI[2]);
                int intMax = int.Parse(arrAI[3]);
                var strType = arrAI[4];

                var strRegExMatch = "";
                if (strType == "alphanumeric")
                {
                    strRegExMatch = Regex.Match(barcode, strAI + @"\w{" + intMin + "," + intMax + "}").ToString();
                }
                else
                {
                    strRegExMatch = Regex.Match(barcode, strAI + @"\d{" + intMin + "," + intMax + "}").ToString();
                }

                if (strRegExMatch.Length > 0)
                {
                    barcode = Regex.Replace(barcode, strRegExMatch, ""); //remove the AI and its value so that its value can't be confused as another AI
                    strRegExMatch = Regex.Replace(strRegExMatch, strAI, ""); //remove the AI from the match
                    arrAIs[arrayIndex] = new string[] { strAI, strRegExMatch };
                    switch (strAI)
                    {
                        case "01":
                            decodeResult.GTIN = strRegExMatch;
                            break;
                        case "10":
                            decodeResult.PurchaseOrder = strRegExMatch;
                            break;
                        case "240":
                            decodeResult.Season = strRegExMatch;
                            break;
                        case "21":
                            decodeResult.SerialNumber = strRegExMatch;
                            break;
                        case "241":
                            decodeResult.CountryOfOrigin = strRegExMatch;
                            break;
                    }
                }
                arrayIndex++;
            }

            return decodeResult;
        }
    }
}
