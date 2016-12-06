using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrettyHair.Core.Interfaces;

namespace PrettyHair.Core.Entities
{
    public class Orderline : IOrderline
    {
        public IItem item { get; set; }
        public int Quantity { get; set; }
        public int OrderID { get; set; }
    }
}
