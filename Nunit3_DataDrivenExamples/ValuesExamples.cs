using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using ShipIt;

namespace Nunit3_DataDrivenExamples
{
    public class ValuesExamples
    {
        private PriceEstimator _shipper;
        [OneTimeSetUp]
        public void Setup()
        {
            _shipper = new PriceEstimator();
            _shipper.setZip2ZipStrategy((src, dest, weight) =>src+dest+weight);
        }

        [Test]
        [Sequential]
        public void testGetFlatRateByWeight([Values(4.5D, 15D, 55D, 125D)] decimal packageWeight, [Values(10.99, 29.99, 75.55, 999.99)] double expectedRate)
        {
            double actualRate = _shipper.getFlatRateByWeight(packageWeight);

            Assert.That(actualRate, Is.EqualTo(expectedRate));
        }

        [Test]
        [Combinatorial]
        public void testGetShippingRate_Combinatorial([Values("60050", "22015", "32043")] string sourceZipCode, [Values("60050", "93108","11111")] string destinationZipcode, [Values(5D,0.5D,100.55D,993D)] decimal packageWeight)
        {
            decimal src = 0;
            decimal dest = 0;

            decimal.TryParse(sourceZipCode, out src);
            decimal.TryParse(destinationZipcode, out dest);

            decimal expectedResult = src + dest + packageWeight;

            decimal actualRate = _shipper.getShippingRateByZipCode(sourceZipCode, destinationZipcode, packageWeight);

            Assert.That(actualRate, Is.EqualTo(expectedResult));
        }

        [Test]
        [Pairwise]
        public void testGetShippingRate_Pairwise([Values("60050", "22015", "32043")] string sourceZipCode, [Values("60050", "93108", "11111")] string destinationZipcode, [Values(5D, 0.5D, 100.55D, 993D)] decimal packageWeight)
        {
            decimal src = 0;
            decimal dest = 0;

            decimal.TryParse(sourceZipCode, out src);
            decimal.TryParse(destinationZipcode, out dest);

            decimal expectedResult = src + dest + packageWeight;

            decimal actualRate = _shipper.getShippingRateByZipCode(sourceZipCode, destinationZipcode, packageWeight);

            Assert.That(actualRate, Is.EqualTo(expectedResult));
        }
    }
}
