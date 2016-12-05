using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrettyHair.Core.Repositories;
using PrettyHair.Core.Interfaces;
using PrettyHair.Core.Entities;

namespace PrettyHair.Test
{
    [TestClass]
    public class UnitTests
    {
        ItemRepository ItemRepo = new ItemRepository();

        IItem shampoo = new Item("Shampoo",  "500ml shampoo", 49.99, 2);
        IItem scissor = new Item("Saks",     "En sort saks",  30.00, 1);
        IItem wax     = new Item("Voks",     "80ml hårvoks",  29.00, 8);
        IItem dye     = new Item("Hårfarve", "Rød hårfarve",  109.95, 19);

        public UnitTests()
        {

        }

        [TestMethod]
        public void ItemRepoIsEmpty()
        {
            Assert.AreEqual(0, ItemRepo.GetItems().Count);
        }

        [TestMethod]
        public void CanAddItem()
        {
            ItemRepo.AddItem(shampoo);
            Assert.AreEqual(1, ItemRepo.GetItems().Count);

            ItemRepo.AddItem(scissor);
            Assert.AreEqual(2, ItemRepo.GetItems().Count);
        }

        [TestMethod]
        public void CanRemoveItem()
        {
            ItemRepo.AddItem(shampoo);
            Assert.AreEqual(1, ItemRepo.GetItems().Count);

            ItemRepo.RemoveItemByID(1);
            Assert.AreEqual(0, ItemRepo.GetItems().Count);
        }

        [TestMethod]
        public void CanGetItem()
        {
            ItemRepo.AddItem(shampoo);
            ItemRepo.AddItem(scissor);

            Assert.AreEqual(shampoo, ItemRepo.GetItemByID(1));
            Assert.AreEqual(scissor, ItemRepo.GetItemByID(2));
        }

        [TestMethod]
        public void CanGetAllItems()
        {
            ItemRepo.AddItem(shampoo);
            ItemRepo.AddItem(scissor);
            ItemRepo.AddItem(wax);
            ItemRepo.AddItem(dye);

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
            ItemRepo.AddItem(shampoo);

            var item = ItemRepo.GetItemByID(1);

            Assert.AreEqual(49.99, item.Price);

            item.AdjustPrice(30.0);

            Assert.AreEqual(30.0, ItemRepo.GetItemByID(1).Price);
        }

        [TestMethod]
        public void CanAdjustAmount()
        {
            ItemRepo.AddItem(shampoo);

            var item = ItemRepo.GetItemByID(1);

            Assert.AreEqual(2, item.Amount);

            item.AdjustAmount(3);

            Assert.AreEqual(5, item.Amount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NegativeAmountNotAllowed()
        {
            ItemRepo.AddItem(shampoo);

            var item = ItemRepo.GetItemByID(1);

            item.AdjustAmount(-3);
        }


        [TestMethod]
        public void CanAdjustDescription()
        {
            ItemRepo.AddItem(shampoo);

            var item = ItemRepo.GetItemByID(1);

            Assert.AreEqual("500ml shampoo", item.Description);

            item.AdjustDescription("600ml shampoo");

            Assert.AreEqual("600ml shampoo", item.Description);

        }

        [TestMethod]
        public void CanWriteToString()
        {
            Assert.AreEqual("[Name: Shampoo - Description: 500ml shampoo - Price: 49,99 - Amount: 2]", shampoo.ToString());
        }

    }
}