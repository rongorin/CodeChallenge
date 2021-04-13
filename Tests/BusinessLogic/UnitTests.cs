using BuySell.BusinessLogic;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class UnitTests
    {  
        [TestMethod]
        public void ProcessBuySell_ShouldNotSelectLowestBuy_WhenAfterBestSell()
            {

            decimal[] sharePrices = { 1.50m, 2m, 3m, 4m, 3m, 1m, 1.1m };  
            decimal lowestBuyPrice = sharePrices.Min();

            var result = ProcessBuySell.CalculateBestProfit(sharePrices); 
             
            Assert.AreNotEqual(result.SellPrice, lowestBuyPrice);  
        } 
        [TestMethod]
        public void ProcessBuySell_ShouldCalculateResult_WhenValuesSupplied()
        {

            decimal[] sharePrices = { 1.50m, 2m, 3m, 4m, 3m, 1m, 1.1m };
            decimal expectedBuy = 1.5m;
            decimal expectedSell = 4m;

            int expectedBuyDay = 1;
            int expectedSellDay = 4;

            var result = ProcessBuySell.CalculateBestProfit(sharePrices);

            Assert.AreEqual(result.BuyPrice, expectedBuy);
            Assert.AreEqual(result.SellPrice, expectedSell);
            Assert.AreEqual(result.BuyDay, expectedBuyDay);
            Assert.AreEqual(result.SellDay, expectedSellDay); 

        }
        [TestMethod]
        public void ProcessBuySell_ShouldShowZeroes_WhenNoProfitsCalculated()
        { 
            decimal[] sharePrices = { 5.50m, 5m, 4m, 3m, 2m, 1m };
            decimal expectedZero = 0; 
              
            var result = ProcessBuySell.CalculateBestProfit(sharePrices);

            Assert.AreEqual(result.BuyPrice, expectedZero);
            Assert.AreEqual(result.SellPrice, expectedZero);  
        }
    }
}
