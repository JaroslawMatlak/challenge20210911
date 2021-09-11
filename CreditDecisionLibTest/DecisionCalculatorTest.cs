using CreditDecisionLib;
using NUnit.Framework;

namespace CreditDecisionLibTest
{
    //TODO: use mocks 
    [TestFixture]
    public class DecisionCalculatorTest
    {
        private IDecisionCalculator _calculator;

        public DecisionCalculatorTest()
        {
            _calculator = new DecisionCalculator();
        }

        [Test]
        public void GivenParametrsAreNull_ThenCalculatorReturnsDefaultDecision()
        {
            DecisionParameters parameters = null;
            var expected = new CreditDecision();

            var result = _calculator.CalculateDecision(parameters);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenRequestedAmountIsLessThan2000_ThenCalculatorRejectsApplication()
        {
            DecisionParameters parameters = new DecisionParameters() { RequestedCredit = 1999 };

            var result = _calculator.CalculateDecision(parameters);

            Assert.IsFalse(result.Decision);
        }

        [Test]
        public void GivenRequestedAmountIsMoreThan69000_ThenCalculatorRejectsApplication()
        {
            DecisionParameters parameters = new DecisionParameters() { RequestedCredit = 69001 };

            var result = _calculator.CalculateDecision(parameters);

            Assert.IsFalse(result.Decision);
        }

        [Test]
        [TestCase(2000)]
        [TestCase(2001)]
        [TestCase(69000)]
        [TestCase(68999)]
        public void GivenRequestedAmountIsWithinAcceptanceRange_ThenCalculatorApprovesApplication(int requested)
        {
            DecisionParameters parameters = new DecisionParameters() { RequestedCredit = requested };

            var result = _calculator.CalculateDecision(parameters);

            Assert.IsTrue(result.Decision);
        }

        [Test]
        [TestCase(0, 0, 3)]
        [TestCase(10000, 0, 3)]
        [TestCase(10000, 10000, 4)]
        [TestCase(10000, 20000, 4)]
        [TestCase(10000, 30000, 5)]
        [TestCase(10000, 40000, 5)]
        [TestCase(10000, 50000, 6)]
        [TestCase(10000, 60000, 6)]
        [TestCase(10000, 70000, 6)]
        public void GivenTotalDebtSatisfiesSpecificRange_TotalRateOfInterestsIsCalculatedAccordingToTheRequirements(
            int requested, int existing, int expectedRateOfInterest)
        {
            DecisionParameters parameters = new DecisionParameters() { RequestedCredit = requested, ExistingDebt = existing };

            var result = _calculator.CalculateDecision(parameters);

            Assert.AreEqual(result.InterestRatePercent, expectedRateOfInterest);
        }
    }
}
