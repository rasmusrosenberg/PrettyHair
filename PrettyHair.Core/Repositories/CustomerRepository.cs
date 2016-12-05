using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrettyHair.Core.Entities;
using PrettyHair.Core.Interfaces;

namespace PrettyHair.Core.Repositories
{
    public class CustomerRepository
    {
        private Dictionary<int, ICustomer> Customers = new Dictionary<int, ICustomer>();
        private int ID;

        public Dictionary<int, ICustomer> GetAllCustomers()
        {
            return Customers;
        }

        public void AddCustomer(ICustomer customer)
        {
            Customers.Add(NextID(), customer);
        }

        public void RemoveCustomerByID(int ID)
        {
            Customers.Remove(ID);
        }

        public void Clear()
        {
            Customers.Clear();
        }

        public bool CustomerExistFromID(int ID)
        {
            return Customers.ContainsKey(ID);
        }

        public ICustomer GetCustomerByID(int ID)
        {
            return Customers[ID];
        }

        public int NextID()
        {
            return ++ID;
        }
    }
}
