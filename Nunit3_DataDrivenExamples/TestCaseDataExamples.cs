using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using ShipIt;

namespace Nunit3_DataDrivenExamples
{
    [TestFixture]
    public class TestCaseDataExamples
    {
        private PriceEstimator _shipper;
        [OneTimeSetUp]
        public void Setup()
        {
            _shipper = new PriceEstimator();
            _shipper.setZip2ZipStrategy((src, dest, weight) => Math.Round(Math.Abs(src - dest) * (weight / 500), 2));
        }

        static decimal[] under5PackageWeights = new decimal[] { 0.01m, 2m, 4.99m };

        [TestCaseSource(nameof(under5PackageWeights))]
        public void test_GivenPackageWeightLessThan5_ThenFlatRate_10_99(decimal packageWeight)
        {
            double actualRate = _shipper.getFlatRateByWeight(packageWeight);

            Assert.That(actualRate, Is.EqualTo(10.99));
        }
    }
}
