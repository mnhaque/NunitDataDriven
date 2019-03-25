using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using ShipIt;

namespace DataDrivenExamples
{
    [TestFixture]
    public class Nunit_Examples
    {
        private PriceEstimator _shipper;
        [OneTimeSetUp]
        public void Setup()
        {
            _shipper = new PriceEstimator();
            _shipper.setZip2ZipStrategy((src, dest, weight) =>Math.Round(Math.Abs(src - dest) * (weight / 500),2));
        }
               
        [TestCase("60050", "17042", 1D, 86.02D)]
        [TestCase("22015", "30040", 50D, 802.5D)]
        [TestCase("32043-5694", "30040-6941", 0.5D,  2D)]
        public void testGetShippingRate(string sourceZipCode, string destinationZipcode, decimal packageWeight, decimal expectedResult)
        {
            decimal actualRate= _shipper.getShippingRateByZipCode(sourceZipCode, destinationZipcode, packageWeight);

            Assert.That(actualRate, Is.EqualTo(expectedResult));
        }

        [TestCase("60050", "17042", 1D, ExpectedResult = 86.02D, TestName = "Source Greater Than Destination")]
        [TestCase("22015", "30040", 50D, ExpectedResult = 802.5D, TestName = "Source Less Than Destination")]
        [TestCase("32043-5694", "30040-6941", 0.5D, ExpectedResult = 2D, TestName = "9 digit zipcodes with dashes")]
        public Decimal testGetShippingRate_withImplicitAssert(string sourceZipCode, string destinationZipcode, decimal packageWeight)
        {
            return _shipper.getShippingRateByZipCode(sourceZipCode, destinationZipcode, packageWeight);
        }   

    }
}
