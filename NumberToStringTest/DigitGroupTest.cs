using NumberToString;
using NUnit.Framework;

namespace Tests
{
    class DigitGroupTestCriteria
    {
        public string Number { get; set; }
        public int NumberIndex { get; set; }
        public string ExpectedString { get; set; }
        public DigitGroupTestCriteria(string number, int index, string expectedString)
        {
            this.Number = number;
            this.NumberIndex = index;
            this.ExpectedString = expectedString;
        }
    }

    public class DigitGroupTests
    {
        private static DigitGroupTestCriteria[] expectations = {
          new DigitGroupTestCriteria("0", 0, "zero"),
          new DigitGroupTestCriteria("1", 0, "one"),
          new DigitGroupTestCriteria("13", 0, "thirteen"),
          new DigitGroupTestCriteria("21", 0, "twenty one"),
          new DigitGroupTestCriteria("100", 0, "hundred"),
          new DigitGroupTestCriteria("112", 0, "one hundred and twelve")
        };

        [Test]
        public void DigitGroupTestsRunner()
        {
            foreach (var expectation in DigitGroupTests.expectations)
            {
                var group = new DigitGroup(expectation.Number, expectation.NumberIndex);
                Assert.AreEqual(group.ToString(), expectation.ExpectedString);
            }
        }
    }
}