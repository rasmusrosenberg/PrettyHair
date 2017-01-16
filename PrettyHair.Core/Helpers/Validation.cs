using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHair.Core.Helpers
{
    public class Validation
    {
        public static bool StringTryParse(string s, out string output)
        {
            output = s.Trim();

            if (s.Trim() == "")
                return false;

            return true;
        }
    }
}
