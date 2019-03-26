using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipIt.Util
{
    public class Utility : IUtility
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public bool TryParse(string value, out string outputValue)
        {
            outputValue = value + "parsed";

            return true;
        }
    }
}
