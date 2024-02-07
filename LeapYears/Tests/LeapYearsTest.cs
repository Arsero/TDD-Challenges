using Core;
using FluentAssertions;

namespace Tests
{
    public class LeapYearsTest
    {
        private readonly LeapYears _leapYears;

        public LeapYearsTest()
        {
            _leapYears = new LeapYears();
        }

        [Fact]
        public void LeapYear_ShouldBeFalse_WhenYearIsOne()
        {
            bool isLeapYear = _leapYears.IsLeapYear(1);
            isLeapYear.Should().BeFalse();
        }

        [Fact]
        public void LeapYear_ShouldBeTrue_WhenYearIsFour()
        {
            bool isLeapYear = _leapYears.IsLeapYear(4);
            isLeapYear.Should().BeTrue();
        }

        [Fact]
        public void LeapYear_ShouldBeTrue_WhenYearIsEight()
        {
            bool isLeapYear = _leapYears.IsLeapYear(8);
            isLeapYear.Should().BeTrue();
        }

        [Fact]
        public void LeapYear_ShouldBeTrue_WhenYearIsFourHundred()
        {
            bool isLeapYear = _leapYears.IsLeapYear(400);
            isLeapYear.Should().BeTrue();
        }

        [Fact]
        public void LeapYear_ShouldBeFalse_WhenYearMultipleOfHundredOnly()
        {
            bool isLeapYear = _leapYears.IsLeapYear(500);
            isLeapYear.Should().BeFalse();
        }

        [Theory]
        [InlineData(2017, false)]
        [InlineData(2020, true)]
        [InlineData(2000, true)]
        [InlineData(2100, false)]
        [InlineData(1700, false)]
        [InlineData(2008, true)]
        [InlineData(2012, true)]
        [InlineData(2016, true)]
        public void LeapYear_MultiplesTest(int year, bool expected)
        {
            bool isLeapYear = _leapYears.IsLeapYear(year);
            isLeapYear.Should().Be(expected);
        }
    }
}