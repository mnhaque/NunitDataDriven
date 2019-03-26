using Moq;
using NUnit.Framework;
using ShipIt;
using ShipIt.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nunit3_DataDrivenExamples.StringOperation
{
    [TestFixture]
    public class StringoperationsTest
    {
        Mock<IUtility> mockUtility;
        StringOperations stringOperations;

        [OneTimeSetUp]
        public void Setup()
        {
            mockUtility = new Mock<IUtility>(MockBehavior.Strict);
            stringOperations = new StringOperations(mockUtility.Object);
        }
        [Test]
        public void TryParse_Always_ReturnExpected()
        {
            string outdata = "Test parsed";
            mockUtility.Setup(_ => _.TryParse(It.IsAny<string>(), out outdata)).Returns(true);
            Assert.That(stringOperations.GetParsedString("Test"), Is.EqualTo("Test parsed Success"));
        }
        [Test]
        public void GetName_Always_ReturnExpected()
        {
            string outdata = "Nunit";
            mockUtility.Setup(_ => _.Name).Returns(outdata);
            Assert.That(stringOperations.GetName(), Is.EqualTo("Nunit"));
        }
    }
}
