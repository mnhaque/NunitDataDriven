using ShipIt.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipIt
{
    public class StringOperations
    {
        IUtility utility;
        public StringOperations(IUtility utility)
        {
            this.utility = utility;
        }
        public string GetParsedString(string input)
        {
            string output;
            if (utility.TryParse(input, out output))
            {
                return output + " Success";
            }
            else
            {
                return string.Empty;
            }
        }
        public string GetName()
        {
            return utility.Name;
        }
    }
}
