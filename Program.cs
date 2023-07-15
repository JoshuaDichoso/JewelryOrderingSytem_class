using System;
using System.Collections.Generic;

namespace JewelryOrderingSystem
{
    class Program
    {
        public static Menu menu;

        static void Main()
        {
            Console.WriteLine("Welcome to the MJ's Necklace Jewelry Ordering System!");

            menu = new Menu();
            CreateDummyData();

            DisplayMenu();
        }

        public static void DisplayMenu()
        {
            Console.WriteLine("\nAvailable Necklaces:");
            for (int i = 0; i < menu.Necklaces.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {menu.Necklaces[i]}");
            }

            Console.Write("Enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (choice < 1 || choice > menu.Necklaces.Count)
                {
                    Console.WriteLine("Invalid choice!");
                    return;
                }

                string selectedNecklace = menu.Necklaces[choice - 1];
                List<string> customizationOptions = menu.GetCustomizationOptions(selectedNecklace);

                Console.WriteLine("You have selected: " + selectedNecklace);
                Console.WriteLine("Please select the customization option:");

                int customizationChoice = DisplayCustomizationOptions(customizationOptions);

                if (customizationChoice < 1 || customizationChoice > customizationOptions.Count)
                {
                    Console.WriteLine("Invalid customization choice!");
                    return;
                }

                string selectedCustomization = customizationOptions[customizationChoice - 1];
                string necklaceType = $"{selectedNecklace} ({selectedCustomization})";

                Jewelry jewelry = new Jewelry();
                decimal necklacePrice = jewelry.GetJewelryPrice(selectedNecklace, menu);

                Console.WriteLine($"Total Price: ${necklacePrice}");

                string customerName = GetCustomerName();

                decimal paymentAmount = GetPaymentAmount(necklacePrice);

                if (paymentAmount < necklacePrice)
                {
                    Console.WriteLine("Insufficient payment!");
                    return;
                }

                decimal change = paymentAmount - necklacePrice;

                GenerateReceipt(customerName, necklaceType, necklacePrice, paymentAmount, change);
            }
            else
            {
                Console.WriteLine("Invalid choice!");
            }
        }

        public static int DisplayCustomizationOptions(List<string> options)
        {
            Console.WriteLine("\nCustomization Options:");
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }

            Console.Write("Enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                return choice;
            }

            return -1;
        }

        public static string GetCustomerName()
        {
            Console.Write("Enter customer name: ");
            return Console.ReadLine();
        }

        public static decimal GetPaymentAmount(decimal totalPrice)
        {
            Console.Write("Enter payment amount: $");
            if (decimal.TryParse(Console.ReadLine(), out decimal paymentAmount))
            {
                return paymentAmount;
            }

            return -1;
        }

        public static void GenerateReceipt(string customerName, string necklaceType, decimal necklacePrice, decimal paymentAmount, decimal change)
        {
            Console.WriteLine("\n--- Receipt ---");
            Console.WriteLine($"Customer Name: {customerName}");
            Console.WriteLine($"Necklace Type: {necklaceType}");
            Console.WriteLine($"Necklace Price: ${necklacePrice}");
            Console.WriteLine($"Payment Amount: ${paymentAmount}");
            Console.WriteLine($"Change: ${change}");
            Console.WriteLine("Thank you for your order!");
        }

        public static void CreateDummyData()
        {
            menu.AddJewelry("Gold Chain Necklace", 1000m);
            menu.GetCustomizationOptions("Gold Chain Necklace").Add("Locket");
            menu.GetCustomizationOptions("Gold Chain Necklace").Add("Princess Necklace");
            menu.GetCustomizationOptions("Gold Chain Necklace").Add("Choker");
            menu.GetCustomizationOptions("Gold Chain Necklace").Add("Multi Chain");
            menu.GetCustomizationOptions("Gold Chain Necklace").Add("Negligee");

            menu.AddJewelry("Pearl Necklace", 400m);
            menu.GetCustomizationOptions("Pearl Necklace").Add("Locket");
            menu.GetCustomizationOptions("Pearl Necklace").Add("Princess Necklace");
            menu.GetCustomizationOptions("Pearl Necklace").Add("Choker");
            menu.GetCustomizationOptions("Pearl Necklace").Add("Multi Chain");
            menu.GetCustomizationOptions("Pearl Necklace").Add("Negligee");

            menu.AddJewelry("Silver Necklace", 600m);
            menu.GetCustomizationOptions("Silver Necklace").Add("Locket");
            menu.GetCustomizationOptions("Silver Necklace").Add("Princess Necklace");
            menu.GetCustomizationOptions("Silver Necklace").Add("Choker");
            menu.GetCustomizationOptions("Silver Necklace").Add("Multi Chain");
            menu.GetCustomizationOptions("Silver Necklace").Add("Negligee");

            menu.AddJewelry("Iron Chain", 100m);
            menu.GetCustomizationOptions("Iron Chain").Add("Locket");
            menu.GetCustomizationOptions("Iron Chain").Add("Princess Necklace");
            menu.GetCustomizationOptions("Iron Chain").Add("Choker");
            menu.GetCustomizationOptions("Iron Chain").Add("Multi Chain");
            menu.GetCustomizationOptions("Iron Chain").Add("Negligee");

            menu.AddJewelry("Diamond Necklace", 5000m);
            menu.GetCustomizationOptions("Diamond Necklace").Add("Locket");
            menu.GetCustomizationOptions("Diamond Necklace").Add("Princess Necklace");
            menu.GetCustomizationOptions("Diamond Necklace").Add("Choker");
            menu.GetCustomizationOptions("Diamond Necklace").Add("Multi Chain");
            menu.GetCustomizationOptions("Diamond Necklace").Add("Negligee");

            menu.AddJewelry("Yellow Gold Necklace", 9000m);
            menu.GetCustomizationOptions("Yellow Gold Necklace").Add("Locket");
            menu.GetCustomizationOptions("Yellow Gold Necklace").Add("Princess Necklace");
            menu.GetCustomizationOptions("Yellow Gold Necklace").Add("Choker");
            menu.GetCustomizationOptions("Yellow Gold Necklace").Add("Multi Chain");
            menu.GetCustomizationOptions("Yellow Gold Necklace").Add("Negligee");

            menu.AddJewelry("Quartz Necklace", 50m);
            menu.GetCustomizationOptions("Quartz Necklace").Add("Locket");
            menu.GetCustomizationOptions("Quartz Necklace").Add("Princess Necklace");
            menu.GetCustomizationOptions("Quartz Necklace").Add("Choker");
            menu.GetCustomizationOptions("Quartz Necklace").Add("Multi Chain");
            menu.GetCustomizationOptions("Quartz Necklace").Add("Negligee");
        }
    }
}
