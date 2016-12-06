using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHair.Core.Interfaces
{
    public interface IOrderline
    {
        IItem item { get; set; }
        int Quantity { get; set; }
        int OrderID { get; set; }
    }
}
