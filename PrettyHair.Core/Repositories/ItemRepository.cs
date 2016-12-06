using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrettyHair.Core.Interfaces;
using PrettyHair.Core.Entities;

namespace PrettyHair.Core.Repositories
{
    public class ItemRepository
    {
        private Dictionary<int, IItem> Items = new Dictionary<int, IItem>();
        private int ID;

        public Dictionary<int, IItem> GetItems()
        {
            return Items;
        }

        public void CreateItem(IItem item)
        {
            // DB

            AddItem(item, NextID());
        }
        private void AddItem(IItem item, int ID)
        {
            Items.Add(ID, item);
        }

        public void RemoveItemByID(int ID)
        {
            Items.Remove(ID);
        }

        public IItem GetItemByID(int ID)
        {
            return Items[ID];
        }

        public void Clear()
        {
            Items.Clear();
        }

        public int NextID()
        {
            return ++ID;
        }
    }
}
