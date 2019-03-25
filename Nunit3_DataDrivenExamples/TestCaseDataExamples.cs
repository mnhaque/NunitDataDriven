using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using ShipIt;

namespace Nunit3_DataDrivenExamples
{
    public class TestCaseDataExamples
    {
        private PriceEstimator _shipper;
        [OneTimeSetUp]
        public void Setup()
        {
            _shipper = new PriceEstimator();
            _shipper.setZip2ZipStrategy((src, dest, weight) => Math.Round(Math.Abs(src - dest) * (weight / 500), 2));
        }

        //nunit 3 requires the sources to be static
        static decimal[] under5PackageWeights = new decimal[] { 0.01m, 2m, 4.99m };

        [TestCaseSource(nameof(under5PackageWeights))]
        public void test_GivenPackageWeightLessThan5_ThenFlatRate_10_99(decimal packageWeight)
        {
            double actualRate = _shipper.getFlatRateByWeight(packageWeight);

            Assert.That(actualRate, Is.EqualTo(10.99));
        }

        public static IEnumerable<TestCaseData> bulkSource()
        {
            yield return new TestCaseData(new List<iContainer> { new Box(3, 1, 2) }).SetName("Bulk-Box Only");
            yield return new TestCaseData(new List<iContainer> { new Box(10, 2, 5), new Bag(10) }).SetName("Bulk-Box and Bag");

        }

        [TestCaseSource("bulkSource")]
        public void testBulkRate(IEnumerable<iContainer> items)
        {
            double expectedPrice = 0;
            foreach (iContainer item in items)
            {
                expectedPrice += item.getPriceToShip();
            }

            var actualPrice = _shipper.getBulkRate(items);

            Assert.That(expectedPrice, Is.EqualTo(actualPrice));

        }
    }
}
