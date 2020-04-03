using System;
using TaskPrincess.DomainLanguage.Parser.Behaviors;
using Xunit;
namespace TaskPrincess.DomainLanguageTests.Parser.Behaviors
{
    public class YearDatesBehaviorTests
    {
        [Fact]
        public void TestParse_StartOfCurrentYear()
        {
            var dateTime = new DateTime(2020, 8, 1, 3, 15, 0);
            var results = BuildParse("socy", dateTime);
            Assert.Equal("2020-01-01 00:00:00", results);
        }

        [Fact]
        public void TestParse_EndOfCurrentYear()
        {
            var dateTime = new DateTime(2020, 1, 1, 3, 15, 0);
            var results = BuildParse("eocy", dateTime);
            Assert.Equal("2020-12-31 23:59:59", results);
        }

        [Fact]
        public void TestParse_StartOfMonth()
        {
            var dateTime = new DateTime(2020, 1, 1, 3, 15, 0);
            var results = BuildParse("som", dateTime);
            Assert.Equal("2020-02-01 00:00:00", results);
        }

        [Fact]
        public void TestParse_EndOfMonth()
        {
            // Leap Year Feb
            var leapYearFeb = new DateTime(2020, 2, 15, 15, 15, 0);
            var leapYearResult = BuildParse("eom", leapYearFeb);
            Assert.Equal("2020-02-29 23:59:59", leapYearResult);

            // Non-leap Year Feb
            var nonLeapYearFeb = new DateTime(2020, 2, 15, 15, 15, 0);
            var nonLeapYearResult = BuildParse("eom", nonLeapYearFeb);
            Assert.Equal("2020-02-29 23:59:59", nonLeapYearResult);
        }

        [Fact]
        public void TestParse_StartOfCurrentMonth()
        {
            var dateTime = new DateTime(2020, 1, 1, 3, 15, 0);
            var results = BuildParse("socm", dateTime);
            Assert.Equal("2020-01-01 00:00:00", results);
        }

        [Fact]
        public void TestParse_EndOfCurrentMonth()
        {
            var dateTime = new DateTime(2020, 1, 1, 3, 15, 0);
            var results = BuildParse("eocm", dateTime);
            Assert.Equal("2020-01-31 23:59:59", results);
        }

        [Fact]
        public void TestParse_StartOfYear()
        {
            var dateTime = new DateTime(2020, 1, 1, 3, 15, 0);
            var results = BuildParse("soy", dateTime);
            Assert.Equal("2021-01-01 00:00:00", results);
        }

        [Fact]
        public void TestParse_EndOfYear()
        {
            var dateTime = new DateTime(2020, 1, 1, 3, 15, 0);
            var results = BuildParse("eoy", dateTime);
            Assert.Equal("2020-12-31 23:59:59", results);
        }

        [Fact]
        public void TestParse_StartOfCurrentQuarter()
        {
            var dateTime = new DateTime(2020, 11, 1, 3, 15, 0);
            var results = BuildParse("socq", dateTime);
            Assert.Equal("2020-10-01 00:00:00", results);
        }

        [Fact]
        public void TestParse_EndOfCurrentQuarter()
        {
            var dateTime = new DateTime(2020, 11, 1, 3, 15, 0);
            var results = BuildParse("eocq", dateTime);
            Assert.Equal("2020-12-31 23:59:59", results);
        }

        [Fact]
        public void TestParse_StartOfQuarter()
        {
            var dateTime = new DateTime(2020, 11, 1, 3, 15, 0);
            var results = BuildParse("soq", dateTime);
            Assert.Equal("2021-01-01 00:00:00", results);
        }

        [Fact]
        public void TestParse_EndOfQuarter()
        {
            var dateTime = new DateTime(2020, 11, 1, 3, 15, 0);
            var results = BuildParse("eoq", dateTime);
            Assert.Equal("2020-12-31 23:59:59", results);
        }

        [Fact]
        public void TestParse_UnhandledShouldReturnNull()
        {
            var dateTime = new DateTime(2020, 11, 1, 3, 15, 0);
            var results = BuildParse("unhandled", dateTime);
            Assert.Null(results);
        }

        public string BuildParse(string parse, DateTime now)
        {
            var behavior = new YearDatesBehavior();
            var result = behavior.Parse(parse, now, null);
            return result.HasValue ? result.Value.ToString("yyyy-MM-dd HH:mm:ss") : null;
        }
    }
}
