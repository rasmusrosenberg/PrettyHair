using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHair.Core.Interfaces
{
    public interface IItem
    {
        void AdjustPriceByID(int ID, double price);
        void AdjustAmountByID(int ID, int offset);
    }
}
