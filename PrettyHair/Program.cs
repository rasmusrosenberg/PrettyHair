using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrettyHair.Core.Interfaces;
using PrettyHair.Core.Entities;
using PrettyHair.Core.Repositories;

namespace PrettyHair
{
    class Program
    {
        private ItemRepository IR = new ItemRepository();

        static void Main(string[] args)
        {
            Program p = new Program();
            p.PopulateItemRepository();
            p.MainMenu();
        }

        public void MainMenu()
        {
            Console.WriteLine("Press 1: Stock");
            Console.WriteLine("Press 2: Orders");
            Console.WriteLine("Press 3: Customers");

            switch (Console.ReadLine())
            {
                case "1":
                    Stock();
                    break;
                case "2":
                    Stock();
                    break;
                case "3":
                    Stock();
                    break;
            }
        }

        public void Stock()
        {
            Console.Clear();

            foreach (KeyValuePair<int, IItem> item in IR.GetItems())
                Console.WriteLine("ID: " + item.Key +" "+item.ToString());

            StockOptions();

        }

        public void StockOptions()
        {
            Console.WriteLine("=======================");
            Console.WriteLine("1. Add New Item");
            Console.WriteLine("2. Remove Item");
            Console.WriteLine("0. Return");

            switch(Console.ReadLine()){
                case "1":
                    AddItem();
                    break;
                case "2":
                    RemoveItem();
                    break;
                case "3":
                    AdjustItem();
                    break;
                
                case "0":
                default:
                    MainMenu();
                    break;
            }
        }

        public void PopulateItemRepository()
        {
            IR.CreateItem(new Item("Shampoo", "500ml shampoo", 49.99, 2));
            IR.CreateItem(new Item("Saks", "En sort saks", 30.00, 1));
            IR.CreateItem(new Item("Voks", "80ml hårvoks", 29.00, 8));
            IR.CreateItem(new Item("Hårfarve", "Rød hårfarve", 109.95, 19));
        }

        public int GetID()
        {
            Console.WriteLine("Select ID");
            return Convert.ToInt32( Console.ReadLine() );
        }

        public void AddItem() { }
        public void RemoveItem() { }
        public void AdjustItem() { }
    }
}
