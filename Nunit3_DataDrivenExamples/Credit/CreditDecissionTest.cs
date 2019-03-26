using Moq;
using NUnit.Framework;
using ShipIt.Credit;
using ShipIt.Credit.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nunit3_DataDrivenExamples.Credit
{
    [TestFixture]
    public class CreditDecissionTest
    {
        Mock<ICreditDecisionService> mockCreditDecisionService;
        CreditDecission systemUnderTest;

        [OneTimeSetUp]
        public void Setup()
        {
            mockCreditDecisionService = new Mock<ICreditDecisionService>(MockBehavior.Strict);
            systemUnderTest = new CreditDecission(mockCreditDecisionService.Object);
        }
        [Test]
        public void MakeCreditDecision_Always_ReturnsExpectedResult()
        {
            int creditScore = 200;
            string expectedResult = "Yes";
            mockCreditDecisionService.Setup(p => p.GetDecision(creditScore)).Returns(expectedResult);
            var result = systemUnderTest.MakeCreditDecision(creditScore);

            Assert.That(result, Is.EqualTo(expectedResult));

            mockCreditDecisionService.VerifyAll();
        }
        [Test]
        public void MakeCreditDecision2_Always_ReturnsExpectedResult()
        {
            int creditScore = 200;
            string expectedResult = "Yes";
            mockCreditDecisionService.Setup(_ => _.UpdateMinScore(It.IsAny<int>())).Verifiable();
            mockCreditDecisionService.Setup(p => p.GetDecision(It.IsAny<int>())).Returns(expectedResult);
            var result = systemUnderTest.MakeCreditDecision(100, creditScore);

            Assert.That(result, Is.EqualTo(expectedResult));
            mockCreditDecisionService.Verify(x=>x.UpdateMinScore(100));
        }
        [Test]
        public void UpdateMinScore_Always_ReturnsExpectedResult()
        {
            int minScore = 200;
            mockCreditDecisionService.Setup(_ => _.UpdateMinScore(It.IsAny<int>()));
            systemUnderTest.UpdateMinScore(minScore);
            mockCreditDecisionService.Verify(x => x.UpdateMinScore(200));
        }
        [Test]
        public void UpdateMinScore_Always_ThrowsExceptiont()
        {
            int minScore = -200;
            mockCreditDecisionService.Setup(_ => _.UpdateMinScore(It.IsAny<int>())).Throws(new ArgumentException());
            Assert.Throws<ArgumentException>(delegate { systemUnderTest.UpdateMinScore(minScore); });
            mockCreditDecisionService.VerifyAll();
        }
    }
}
