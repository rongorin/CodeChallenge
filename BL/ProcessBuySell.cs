
using BL.Models;
using System; 
namespace BuySell.BusinessLogic
{
    public class ProcessBuySell
    {
        /// <summary>
        /// process through every price. Outer loop is for the buy price to be compared 
        /// to each price after (the inner loop) to find the maximum difference between them.
        /// </summary> buyIndex
        public static Result CalculateBestProfit(decimal[] stockPrices)
        { 
            decimal maximumProfit = 0;
            int lowestIndex = 0;
            int highestIndex = 0;
            decimal lowestPrice = 0;
            decimal highestPrice = 0; 
         
            for (int buyIndex = 0; buyIndex < stockPrices.Length; buyIndex++)
            {
                var buyPrice = stockPrices[buyIndex];

                for (int sellIndex = buyIndex + 1; sellIndex < stockPrices.Length; sellIndex++)
                {
                    var sellPrice = stockPrices[sellIndex];

                    var potentialProfit = sellPrice - buyPrice;

                    if (potentialProfit > maximumProfit)
                    {
                        if (buyIndex > sellIndex) continue; //in case sell is before buy 

                        maximumProfit = potentialProfit;
                        lowestIndex = buyIndex + 1;
                        highestIndex = sellIndex + 1;
                        lowestPrice = buyPrice;
                        highestPrice = sellPrice;
                    }
                }
            }
            return new Result(lowestIndex, lowestPrice, highestIndex, highestPrice); 
        }
    }
}
