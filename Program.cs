using System;
using System.Collections.Generic;

namespace JewelryOrderingSystem
{
    class Program
    {
        private static Menu menu;

        static void Main()
        {
            Console.WriteLine("Welcome to the MJ's Necklace Jewelry Ordering System!");

            menu = new Menu();
            CreateDummyData();

            DisplayMenu();
        }

        private static void DisplayMenu()
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

        private static int DisplayCustomizationOptions(List<string> options)
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

        private static string GetCustomerName()
        {
            Console.Write("Enter customer name: ");
            return Console.ReadLine();
        }

        private static decimal GetPaymentAmount(decimal totalPrice)
        {
            Console.Write("Enter payment amount: $");
            if (decimal.TryParse(Console.ReadLine(), out decimal paymentAmount))
            {
                return paymentAmount;
            }

            return -1;
        }

        private static void GenerateReceipt(string customerName, string necklaceType, decimal necklacePrice, decimal paymentAmount, decimal change)
        {
            Console.WriteLine("\n--- Receipt ---");
            Console.WriteLine($"Customer Name: {customerName}");
            Console.WriteLine($"Necklace Type: {necklaceType}");
            Console.WriteLine($"Necklace Price: ${necklacePrice}");
            Console.WriteLine($"Payment Amount: ${paymentAmount}");
            Console.WriteLine($"Change: ${change}");
            Console.WriteLine("Thank you for your order!");
        }

        private static void CreateDummyData()
        {
            menu.AddJewelry("Gold Chain Necklace", 1000m);
            menu.AddJewelry("Pearl Necklace", 400m);
            menu.AddJewelry("Silver Necklace", 600m);
            menu.AddJewelry("Iron Chain", 100m);
            menu.AddJewelry("Diamond Necklace", 5000m);
            menu.AddJewelry("Yellow Gold Necklace", 9000m);
            menu.AddJewelry("Quartz Necklace", 50m);
        }
    }
}
