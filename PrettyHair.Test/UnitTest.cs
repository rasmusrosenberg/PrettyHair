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

        IItem shampoo = new Item("Shampoo",  "500ml shampoo", 49.99);
        IItem scissor = new Item("Saks",     "En sort saks",  30.00);
        IItem wax     = new Item("Voks",     "80ml hårvoks",  29.00);
        IItem dye     = new Item("Hårfarve", "Rød hårfarve",  109.95);

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
        }


    }
}