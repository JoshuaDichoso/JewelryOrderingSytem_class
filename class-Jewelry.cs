using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryOrderingSystem
{
    class Jewelry
    {
        public decimal GetJewelryPrice(string jewelry, Menu menu)
        {
            return menu.JewelryPrices[jewelry];
        }
    }
}
