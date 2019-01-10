using System;
using NumberToString;
using NUnit.Framework;

namespace Tests
{
    class NumberToStringTestCriteria
    {
        public int Number { get; set; }
        public string ExpectedString { get; set; }
        public NumberToStringTestCriteria(int number, string expectedString)
        {
            this.Number = number;
            this.ExpectedString = expectedString;
        }
    }

    public class NumberToStringTests
    {
        private static NumberToStringTestCriteria[] expectations = {
          new NumberToStringTestCriteria(0, "zero"),
          new NumberToStringTestCriteria(100, "hundred"),
          new NumberToStringTestCriteria(56945781, "fifty six million, nine hundred and forty five thousand, seven hundred and eighty one"),
          new NumberToStringTestCriteria(1000015, "one million and fifteen"),
          new NumberToStringTestCriteria(1001000012, "one billion, one million and twelve"),
          new NumberToStringTestCriteria(-12302, "negative twelve thousand, three hundred and two"),
        };

        [Test]
        public void NumberToStringTestsRunner()
        {
            foreach (var expectation in NumberToStringTests.expectations)
            {
                var group = new NumberToString.NumberToString(expectation.Number);
                Assert.AreEqual(group.ToString(), expectation.ExpectedString);
            }
        }
    }
}