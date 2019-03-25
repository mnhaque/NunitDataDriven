using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShipIt
{
    public class PriceEstimator
    {
        private Func<int, int, decimal,decimal> _zip2zipStrategy;

        public void setZip2ZipStrategy(Func<int,int,decimal,decimal> strategy)
        {
            _zip2zipStrategy = strategy;
        }
        public decimal getShippingRateByZipCode(string srcZip, string destZip, decimal packageWeight)
        {
            int src = 1;
            int dest = 1;

            int.TryParse(srcZip.Split('-')[0],out src);
            int.TryParse(destZip.Split('-')[0],out dest);

            return _zip2zipStrategy(src, dest, packageWeight);
        }

        public double getFlatRateByWeight(decimal packageWeight)
        {
            if(packageWeight<=5)
            {
                return 10.99D;
            }
            else if (packageWeight>5 && packageWeight<=25 ) 
            {
                return 29.99D;
            }
            else if (packageWeight > 25 && packageWeight <= 100)
            {
                return 75.55D;
            }
            else
            {
                return 999.99D;
            }
        }

        public double getBulkRate(IEnumerable<iContainer> items)
        {
                     

            return items.Select(x => x.getPriceToShip()).ToList().Sum(); 
        }

    }
}
