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
        ItemRepository IR = new ItemRepository();

        static void Main(string[] args)
        {
            Program p = new Program();
        }

        public void ManageStock()
        {
            Console.WriteLine("Press 1: Add item");
            Console.WriteLine("Press 2: Show items");

            switch (Console.ReadLine())
            {
                case "1":
                    AddItem();
                    break;

                case "2":
                    ShowItems();
                    break;
            }
        }

        public void AddItem()
        {

        }

        public void ShowItems()
        {

        }
    }
}
