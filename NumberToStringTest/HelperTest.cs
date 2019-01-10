using NumberToString;
using NUnit.Framework;

namespace Tests
{
    public class HelperTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Helper_should_create_two_string_groups()
        {
            var digitParts = Helper.GetDigitParts(110212);
            Assert.AreEqual(digitParts.Count, 2);
        }

        [Test]
        public void Helper_should_create_three_digit_groups() {
            var digitGroups = Helper.GetDigitGroups(6110212);
            Assert.AreEqual(digitGroups.Count, 3);
        }
    }
}