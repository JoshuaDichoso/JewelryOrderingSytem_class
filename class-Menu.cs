using System;
using System.Collections.Generic;

namespace JewelryOrderingSystem
{
    class Menu
    {
        public List<string> Necklaces { get; set; }
        public Dictionary<string, decimal> JewelryPrices { get; set; }
        public Dictionary<string, List<string>> Customizations { get; set; }

        public Menu()
        {
            Necklaces = new List<string>();
            JewelryPrices = new Dictionary<string, decimal>();
            Customizations = new Dictionary<string, List<string>>();
        }

        public void AddJewelry(string jewelry, decimal price)
        {
            Necklaces.Add(jewelry);
            JewelryPrices.Add(jewelry, price);
            Customizations.Add(jewelry, new List<string>());
        }

        public List<string> GetCustomizationOptions(string jewelry)
        {
            return Customizations[jewelry];
        }
    }
}
