using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrettyHair.Core.Interfaces;
using PrettyHair.Core.Entities;
using PrettyHair.Core.Repositories;
using PrettyHair.Core.Helpers;

namespace PrettyHair
{
    class Program
    {
        private ItemRepository IR       = new ItemRepository();
        private CustomerRepository CR   = new CustomerRepository();
        private OrderlineRepository OLR = new OrderlineRepository();
        private OrderRepository OR      = new OrderRepository();

        public Program() { }

        static void Main(string[] args)
        {
            Program p = new Program();
            p.IR.RefreshItems();
            
            p.MainMenu();
        }


        public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Press 1: Stock");
            Console.WriteLine("Press 2: Orders");
            Console.WriteLine("Press 3: Customers");

            switch (AskForInteger())
            {
                case 1:
                    Stock();
                    break;
                case 2:
                    Stock();
                    break;
                case 3:
                    Stock();
                    break;
            }
        }

        public void Stock()
        {
            Console.Clear();

            PrintStock();

            StockOptions();
        }

        public void PrintStock()
        {
            foreach (KeyValuePair<int, IItem> item in IR.GetItems())
                Console.WriteLine($"{"ID: "          + item.Key,                0}" +
                                  $"{"Name: "        + item.Value.Name,        20}" +
                                  $"{"Description: " + item.Value.Description, 35}" +
                                  $"{"Amount: "      + item.Value.Amount,      20}" +
                                  $"{"Price: "       + item.Value.Price,       20}");

        }

        public void StockOptions()
        {
            ConsoleBreak();

            Console.WriteLine("1. Add New Item");
            Console.WriteLine("2. Remove Item");
            Console.WriteLine("0. Back to main menu");

            switch (AskForInteger())
            {
                case 1:
                    AddItem();
                    break;
                case 2:
                    RemoveItem();
                    break;
                case 3:
                    AdjustItem();
                    break;
                case 0:
                default:
                    MainMenu();
                    break;
            }
        }
        
        public void AddItem()
        {
            Console.Clear();

            IItem item = new Item();
            item.Name        = AskForString("Write item name");
            item.Description = AskForString("Write item description");
            item.Amount      = AskForInteger("Write item amount");
            item.Price       = AskForDouble("Write item price");

            IR.CreateItem(item);

            Stock();
        }

        public void RemoveItem()
        {
            ConsoleBreak();

            IR.RemoveItemByID( AskForInteger("Enter ID of item") );

            Stock();
        }

        public void ConsoleBreak()
        {
            Console.WriteLine("======================================================");
        }

        public void AdjustItem() { }

        /*************************************************
                          Get user inputs

                   Parameter 'message' is optional
         *************************************************/

        public string AskForString(string message = "")
        {
            if (message != "")
                Console.WriteLine(message);

            string s;
            while (!Validation.StringTryParse(Console.ReadLine(), out s))
                Console.WriteLine("You must write something.");

            return s;
        }

        public double AskForDouble(string message = "")
        {
            if (message != "")
                Console.WriteLine(message);

            double i;
            while (!double.TryParse(Console.ReadLine().Replace(".", ","), out i))
                Console.WriteLine("You must write an number.");

            return i;
        }

        public int AskForInteger(string message = "")
        {
            if (message != "")
                Console.WriteLine(message);

            int i;
            while (!Int32.TryParse(Console.ReadLine(), out i ))
                Console.WriteLine("You must write an number.");

            return i;
        }
    }
}