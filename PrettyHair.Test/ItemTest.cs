using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrettyHair.Core.Repositories;
using PrettyHair.Core.Interfaces;
using PrettyHair.Core.Entities;

/*
 * 
 * WARNING: Hver gang testene bliver kørt, bliver der indsat items i database.
 *          Derfor er der så mange.
 * 
 */

namespace PrettyHair.Test
{
    [TestClass]
    public class ItemTest
    {
        ItemRepository ItemRepo = new ItemRepository();

        IItem shampoo = new Item("Shampoo",  "500ml shampoo", 49.99, 2);
        IItem scissor = new Item("Saks",     "En sort saks",  30.00, 1);
        IItem wax     = new Item("Voks",     "80ml hårvoks",  29.00, 8);
        IItem dye     = new Item("Hårfarve", "Rød hårfarve",  109.95, 19);

        [TestMethod]
        public void ItemRepoIsEmpty()
        {
            Assert.AreEqual(0, ItemRepo.GetItems().Count);
        }

        [TestMethod]
        public void CanAddItem()
        {
            ItemRepo.CreateItem(shampoo);
            Assert.AreEqual(1, ItemRepo.GetItems().Count);

            ItemRepo.CreateItem(scissor);
            Assert.AreEqual(2, ItemRepo.GetItems().Count);
        }

        /*
        [TestMethod]
        public void CanRemoveItem()
        {
            ItemRepo.CreateItem(shampoo);
            Assert.AreEqual(1, ItemRepo.GetItems().Count);

            ItemRepo.RemoveItemByID(1);
            Assert.AreEqual(0, ItemRepo.GetItems().Count);
        }
        */
        /*
        [TestMethod]
        public void CanGetItem()
        {
            ItemRepo.CreateItem(shampoo);
            ItemRepo.CreateItem(scissor);

            Assert.AreEqual(shampoo, ItemRepo.GetItemByID(1));
            Assert.AreEqual(scissor, ItemRepo.GetItemByID(2));
        }
        */

        [TestMethod]
        public void CanGetAllItems()
        {
            ItemRepo.CreateItem(shampoo);
            ItemRepo.CreateItem(scissor);
            ItemRepo.CreateItem(wax);
            ItemRepo.CreateItem(dye);

            Assert.AreEqual(4, ItemRepo.GetItems().Count);
        }

        [TestMethod]
        public void CanClearRepository()
        {
            CanGetAllItems();

            ItemRepo.Clear();
            Assert.AreEqual(0, ItemRepo.GetItems().Count);
        }

        [TestMethod]
        public void CanAdjustPrice()
        {
            ItemRepo.CreateItem(shampoo);

            var item = ItemRepo.GetItemByID(15);

            Assert.AreEqual(49.99, item.Price);

            item.AdjustPrice(30.0);

            Assert.AreEqual(30.0, ItemRepo.GetItemByID(15).Price);
        }
        /*
        [TestMethod]
        public void CanAdjustAmount()
        {
            ItemRepo.CreateItem(shampoo);

            var item = ItemRepo.GetItemByID(15);

            Assert.AreEqual(2, item.Amount);

            item.AdjustAmount(3);

            Assert.AreEqual(5, item.Amount);
        }
        */

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NegativeAmountNotAllowed()
        {
            ItemRepo.CreateItem(shampoo);

            var item = ItemRepo.GetItemByID(15);

            item.AdjustAmount(-200);
        }


        [TestMethod]
        public void CanAdjustDescription()
        {
            ItemRepo.CreateItem(shampoo);

            var item = ItemRepo.GetItemByID(15);

            item.AdjustDescription("600ml shampoo");

            Assert.AreEqual("600ml shampoo", item.Description);

        }
        /*
        [TestMethod]
        public void CanGetLatestInsertedID()
        {
            Assert.AreEqual(2, ItemRepo.GetLastInsertedID());
        }
        */
    }
}