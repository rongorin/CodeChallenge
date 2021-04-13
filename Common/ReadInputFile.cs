using System;
using System.Collections.Generic;
using System.IO; 
using System.Text; 

namespace Common.Utils
{
    public class ReadInputFile
    {
        public static IEnumerable<decimal> ReadPrices(string inputFile)
        {
            if (!File.Exists(inputFile)) throw new ArgumentException("File does not exist");

            var stringDecimals = File.ReadAllText(inputFile, Encoding.UTF8);
            if (string.IsNullOrWhiteSpace(stringDecimals)) throw new ArgumentException("Invalid file");

            string[] decimalsTextList = stringDecimals.Split(',');
  
            foreach (string price in decimalsTextList)
            {
                if (decimal.TryParse(price, out decimal result))
                    yield return result;
            } 

        }
    }
}
