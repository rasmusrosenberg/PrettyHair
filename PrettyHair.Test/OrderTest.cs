using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrettyHair.Core.Repositories;
using PrettyHair.Core.Interfaces;
using PrettyHair.Core.Entities;

namespace PrettyHair.Test
{
    [TestClass]
    public class OrderTest
    {
        public OrderRepository OR = new OrderRepository();

        public IOrder order1 = new Order( new DateTime(2017, 12, 05), DateTime.Today, 1 );
        public IOrder order2 = new Order( new DateTime(2017, 02, 04), DateTime.Today, 1);
        public IOrder order3 = new Order( new DateTime(2017, 03, 03), DateTime.Today, 1);
        public IOrder order4 = new Order( new DateTime(2017, 04, 02), DateTime.Today, 1);
        public IOrder order5 = new Order( new DateTime(2017, 05, 01), DateTime.Today, 1);

        [TestMethod]
        public void MustBeEmptyByDefault()
        {
            Assert.AreEqual(0, OR.GetAllOrders().Count);
        }

        [TestMethod]
        public void CanAddToRepository()
        {
            OR.CreateOrder(order1);
            OR.CreateOrder(order2);
            OR.CreateOrder(order3);
            OR.CreateOrder(order4);
            OR.CreateOrder(order5);

            Assert.AreEqual(5, OR.GetAllOrders().Count);
        }

        [TestMethod]
        public void CanRemove()
        {
            CanAddToRepository();

            OR.RemoveByID(3);

            Assert.AreEqual(4, OR.GetAllOrders().Count);
        }

        [TestMethod]
        public void CanClear()
        {
            CanAddToRepository();

            OR.Clear();

            Assert.AreEqual(0, OR.GetAllOrders().Count);
        }

        [TestMethod]
        public void CanGet()
        {
            CanAddToRepository();

            Assert.AreSame(order1, OR.GetOrderByID(1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Delivery()
        {
            new Order(new DateTime(2016, 12, 05), new DateTime(2016, 12, 06), 1);
        }
    }
}
