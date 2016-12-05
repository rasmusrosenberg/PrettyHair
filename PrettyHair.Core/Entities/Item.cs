using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrettyHair.Core.Interfaces;

namespace PrettyHair.Core.Entities
{
    public class Item : IItem
    {
        public string Name        { get; set; }
        public string Description { get; set; }
        public double Price       { get; set; }
        public int Amount         { get; set; }

        public Item(string name, string description, double price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public void AdjustPriceByID(int id, double price)
        {
            throw new NotImplementedException();
        }

        public void AdjustAmountByID(int id, int offset)
        {
            throw new NotImplementedException();
        }
    }
}
