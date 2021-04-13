using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public struct Result
    {
        public Result(int buyDay, decimal buyPrice, int sellDay, decimal sellPrice)
        {
            BuyDay = buyDay;
            BuyPrice = buyPrice;
            SellDay = sellDay;
            SellPrice = sellPrice;
        }
        public int BuyDay { get; set; }
        public decimal BuyPrice { get; set; }
        public int SellDay { get; set; }
        public decimal SellPrice { get; set; }
    }
}
