using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrettyHair.Core.Repositories;
using PrettyHair.Core.Interfaces;
using PrettyHair.Core.Entities;

namespace PrettyHair.Test
{
    [TestClass]
    public class OrderlineTest
    {
        public OrderlineRepository OLR = new OrderlineRepository();

        public IOrderline orderline1 = new Orderline();
        public IOrderline orderline2 = new Orderline();
        public IOrderline orderline3 = new Orderline();
        public IOrderline orderline4 = new Orderline();
        public IOrderline orderline5 = new Orderline();

        [TestMethod]
        public void MustBeEmptyByDefault()
        {
            Assert.AreEqual(0, OLR.GetAllOrderlines().Count);
        }

        [TestMethod]
        public void CanAddToRepository()
        {
            OLR.CreateOrderline(orderline1);
            OLR.CreateOrderline(orderline2);
            OLR.CreateOrderline(orderline3);
            OLR.CreateOrderline(orderline4);
            OLR.CreateOrderline(orderline5);

            Assert.AreEqual(5, OLR.GetAllOrderlines().Count);
        }

        [TestMethod]
        public void CanRemove()
        {
            CanAddToRepository();

            OLR.RemoveByID(3);

            Assert.AreEqual(4, OLR.GetAllOrderlines().Count);
        }

        [TestMethod]
        public void CanClear()
        {
            CanAddToRepository();

            OLR.Clear();

            Assert.AreEqual(0, OLR.GetAllOrderlines().Count);
        }

        [TestMethod]
        public void CanGet()
        {
            CanAddToRepository();

            Assert.AreSame(orderline1, OLR.GetOrderlineByID(1));
        }


    }
}
