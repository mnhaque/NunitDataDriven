using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipIt.Util
{
    public interface IUtility
    {
        string Name { get; set; }
        int Value { get; set; }
        bool TryParse(string value, out string outputValue);
    }
}
